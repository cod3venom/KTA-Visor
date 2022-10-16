// Decompiled with JetBrains decompiler
// Type: USBKitcs.Internal.OverlappedTransferContext
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;
using System.Threading;
using USBKitcs.Main;

namespace USBKitcs.Internal
{
  internal class OverlappedTransferContext : UsbTransfer
  {
    private readonly SafeOverlapped mOverlapped = new SafeOverlapped();

    public OverlappedTransferContext(UsbEndpointBase endpointBase)
      : base(endpointBase)
    {
    }

    public SafeOverlapped Overlapped => this.mOverlapped;

    public override ErrorCode Submit()
    {
      ErrorCode errorCode = ErrorCode.None;
      if (this.mTransferCancelEvent.WaitOne(0, false))
        return ErrorCode.IoCancelled;
      if (!this.mTransferCompleteEvent.WaitOne(0, false))
        return ErrorCode.ResourceBusy;
      this.mHasWaitBeenCalled = false;
      this.mTransferCompleteEvent.Reset();
      this.Overlapped.ClearAndSetEvent(this.mTransferCompleteEvent.SafeWaitHandle.DangerousGetHandle());
      int lengthTransferred;
      int num = this.EndpointBase.PipeTransferSubmit(this.NextBufPtr, this.RequestCount, out lengthTransferred, this.mIsoPacketSize, this.Overlapped.GlobalOverlapped);
      if (num != 0 && num != 997)
      {
        this.mTransferCompleteEvent.Set();
        errorCode = UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "PipeTransferSubmit", (object) this.EndpointBase).ErrorCode;
      }
      return errorCode;
    }

    public override ErrorCode Wait(out int transferredCount, bool cancel)
    {
      if (this.mHasWaitBeenCalled)
        throw new UsbException((object) this, "Repeated calls to wait with a submit is not allowed.");
      transferredCount = 0;
      int num = WaitHandle.WaitAny(new WaitHandle[2]
      {
        (WaitHandle) this.mTransferCompleteEvent,
        (WaitHandle) this.mTransferCancelEvent
      }, this.mTimeout, false);
      if (num == 258 && !cancel)
        return ErrorCode.IoTimedOut;
      this.mHasWaitBeenCalled = true;
      if (num != 0)
      {
        bool flag1 = this.EndpointBase.mUsbApi.AbortPipe(this.EndpointBase.Handle, this.EndpointBase.EpNum);
        bool flag2 = this.mTransferCompleteEvent.WaitOne(100, false);
        this.mTransferCompleteEvent.Set();
        if (!flag1 || !flag2)
        {
          ErrorCode errorCode = flag1 ? ErrorCode.Win32Error : ErrorCode.CancelIoFailed;
          UsbError.Error(errorCode, Marshal.GetLastWin32Error(), "Wait:AbortPipe Failed", (object) this);
          return errorCode;
        }
        return num == 258 ? ErrorCode.IoTimedOut : ErrorCode.IoCancelled;
      }
      return !this.EndpointBase.mUsbApi.GetOverlappedResult(this.EndpointBase.Handle, this.Overlapped.GlobalOverlapped, out transferredCount, true) ? UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "GetOverlappedResult", (object) this.EndpointBase).ErrorCode : ErrorCode.None;
    }
  }
}
