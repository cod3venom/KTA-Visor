// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.UsbTransfer
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Diagnostics;
using System.Threading;
using USBKitcs.DeviceInfo;

namespace USBKitcs.Main
{
  public abstract class UsbTransfer : IDisposable, IAsyncResult
  {
    private readonly UsbEndpointBase mEndpointBase;
    private IntPtr mBuffer;
    private int mCurrentOffset;
    private int mCurrentRemaining;
    private int mCurrentTransmitted;
    protected int mIsoPacketSize;
    protected int mOriginalCount;
    protected int mOriginalOffset;
    private PinnedHandle mPinnedHandle;
    protected int mTimeout;
    protected bool mHasWaitBeenCalled = true;
    protected readonly object mTransferLOCK = new object();
    protected ManualResetEvent mTransferCancelEvent = new ManualResetEvent(false);
    protected internal ManualResetEvent mTransferCompleteEvent = new ManualResetEvent(true);

    protected UsbTransfer(UsbEndpointBase endpointBase) => this.mEndpointBase = endpointBase;

    public UsbEndpointBase EndpointBase => this.mEndpointBase;

    protected int RequestCount => this.mCurrentRemaining > UsbEndpointBase.MaxReadWrite ? UsbEndpointBase.MaxReadWrite : this.mCurrentRemaining;

    protected IntPtr NextBufPtr => new IntPtr(this.mBuffer.ToInt64() + (long) this.mCurrentOffset);

    public bool IsCancelled => this.mTransferCancelEvent.WaitOne(0, false);

    public WaitHandle CancelWaitHandle => (WaitHandle) this.mTransferCancelEvent;

    public int IsoPacketSize => this.mIsoPacketSize;

    public virtual void Dispose()
    {
      if (!this.IsCancelled)
      {
        int num1 = (int) this.Cancel();
      }
      if (!this.mHasWaitBeenCalled)
      {
        int num2 = (int) this.Wait(out int _);
      }
      if (this.mPinnedHandle != null)
        this.mPinnedHandle.Dispose();
      this.mPinnedHandle = (PinnedHandle) null;
    }

    ~UsbTransfer() => this.Dispose();

    public virtual ErrorCode Cancel()
    {
      this.mTransferCancelEvent.Set();
      this.mTransferCompleteEvent.WaitOne(5000, false);
      return ErrorCode.None;
    }

    public abstract ErrorCode Submit();

    public abstract ErrorCode Wait(out int transferredCount, bool cancel);

    public ErrorCode Wait(out int transferredCount) => this.Wait(out transferredCount, true);

    public virtual void Fill(object buffer, int offset, int count, int timeout)
    {
      if (this.mPinnedHandle != null)
        this.mPinnedHandle.Dispose();
      this.mPinnedHandle = new PinnedHandle(buffer);
      this.Fill(this.mPinnedHandle.Handle, offset, count, timeout);
    }

    public virtual void Fill(
      object buffer,
      int offset,
      int count,
      int timeout,
      int isoPacketSize)
    {
      if (this.mPinnedHandle != null)
        this.mPinnedHandle.Dispose();
      this.mPinnedHandle = new PinnedHandle(buffer);
      this.Fill(this.mPinnedHandle.Handle, offset, count, timeout, isoPacketSize);
    }

    public virtual void Fill(IntPtr buffer, int offset, int count, int timeout)
    {
      this.mBuffer = buffer;
      this.mOriginalOffset = offset;
      this.mOriginalCount = count;
      this.mTimeout = timeout;
      this.Reset();
    }

    public virtual void Fill(
      IntPtr buffer,
      int offset,
      int count,
      int timeout,
      int isoPacketSize)
    {
      this.mBuffer = buffer;
      this.mOriginalOffset = offset;
      this.mOriginalCount = count;
      this.mTimeout = timeout;
      this.mIsoPacketSize = isoPacketSize;
      this.Reset();
    }

    internal static ErrorCode SyncTransfer(
      UsbTransfer transferContext,
      IntPtr buffer,
      int offset,
      int length,
      int timeout,
      out int transferLength)
    {
      return UsbTransfer.SyncTransfer(transferContext, buffer, offset, length, timeout, 0, out transferLength);
    }

    internal static ErrorCode SyncTransfer(
      UsbTransfer transferContext,
      IntPtr buffer,
      int offset,
      int length,
      int timeout,
      int isoPacketSize,
      out int transferLength)
    {
      if (transferContext == null)
        throw new NullReferenceException("Invalid transfer context.");
      if (offset < 0)
        throw new ArgumentException("must be >=0", nameof (offset));
      if (isoPacketSize == 0 && transferContext.EndpointBase.Type == EndpointType.Isochronous)
      {
        UsbEndpointInfo endpointInfo = transferContext.EndpointBase.EndpointInfo;
        if (endpointInfo != null)
          isoPacketSize = (int) endpointInfo.Descriptor.MaxPacketSize;
      }
      lock (transferContext.mTransferLOCK)
      {
        transferLength = 0;
        transferContext.Fill(buffer, offset, length, timeout, isoPacketSize);
        ErrorCode errorCode1;
        int transferredCount;
        ErrorCode errorCode2;
        do
        {
          errorCode1 = transferContext.Submit();
          if (errorCode1 == 0)
          {
            errorCode2 = transferContext.Wait(out transferredCount);
            if (errorCode2 == 0)
              transferLength += transferredCount;
            else
              goto label_12;
          }
          else
            goto label_10;
        }
        while (errorCode2 == ErrorCode.None && transferredCount == UsbEndpointBase.MaxReadWrite && transferContext.IncrementTransfer(transferredCount));
        goto label_15;
label_10:
        return errorCode1;
label_12:
        return errorCode2;
label_15:
        return errorCode2;
      }
    }

    public bool IncrementTransfer(int amount)
    {
      this.mCurrentTransmitted += amount;
      this.mCurrentRemaining -= amount;
      this.mCurrentOffset += amount;
      if (this.mCurrentRemaining > 0)
        return true;
      Debug.Assert(this.mCurrentRemaining == 0);
      return false;
    }

    public int Transmitted => this.mCurrentTransmitted;

    public int Remaining => this.mCurrentRemaining;

    public void Reset()
    {
      this.mCurrentOffset = this.mOriginalOffset;
      this.mCurrentRemaining = this.mOriginalCount;
      this.mCurrentTransmitted = 0;
      this.mTransferCancelEvent.Reset();
    }

    public bool IsCompleted => this.mTransferCompleteEvent.WaitOne(0, false);

    public WaitHandle AsyncWaitHandle => (WaitHandle) this.mTransferCompleteEvent;

    public object AsyncState => throw new NotImplementedException();

    public bool CompletedSynchronously => false;
  }
}
