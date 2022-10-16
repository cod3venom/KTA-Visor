// Decompiled with JetBrains decompiler
// Type: USBKitcs.LudnMonoLibUsb.MonoUsbEndpointWriter
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using USBKitcs.LudnMonoLibUsb.Internal;
using USBKitcs.Main;
using USBKitcs.MonoLibUsb;

namespace USBKitcs.LudnMonoLibUsb
{
  public class MonoUsbEndpointWriter : UsbEndpointWriter
  {
    private MonoUsbTransferContext mMonoTransferContext;

    internal MonoUsbEndpointWriter(
      UsbDevice usbDevice,
      WriteEndpointID writeEndpointID,
      EndpointType endpointType)
      : base(usbDevice, writeEndpointID, endpointType)
    {
    }

    public override void Dispose()
    {
      base.Dispose();
      if (this.mMonoTransferContext == null)
        return;
      this.mMonoTransferContext.Dispose();
      this.mMonoTransferContext = (MonoUsbTransferContext) null;
    }

    public override bool Flush() => true;

    public override bool Reset()
    {
      if (this.IsDisposed)
        throw new ObjectDisposedException(this.GetType().Name);
      this.Abort();
      int ret = MonoUsbApi.ClearHalt((MonoUsbDeviceHandle) this.Device.Handle, this.EpNum);
      if (ret >= 0)
        return true;
      UsbError.Error(ErrorCode.MonoApiError, ret, "Endpoint Reset Failed", (object) this);
      return false;
    }

    internal override UsbTransfer CreateTransferContext() => (UsbTransfer) new MonoUsbTransferContext((UsbEndpointBase) this);
  }
}
