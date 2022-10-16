// Decompiled with JetBrains decompiler
// Type: USBKitcs.UsbEndpointWriter
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;
using USBKitcs.Internal;
using USBKitcs.Main;

namespace USBKitcs
{
  public class UsbEndpointWriter : UsbEndpointBase
  {
    internal UsbEndpointWriter(
      UsbDevice usbDevice,
      WriteEndpointID writeEndpointID,
      EndpointType endpointType)
      : base(usbDevice, (byte) writeEndpointID, endpointType)
    {
    }

    public virtual ErrorCode Write(byte[] buffer, int timeout, out int transferLength) => this.Write(buffer, 0, buffer.Length, timeout, out transferLength);

    public virtual ErrorCode Write(
      IntPtr pBuffer,
      int offset,
      int count,
      int timeout,
      out int transferLength)
    {
      return this.Transfer(pBuffer, offset, count, timeout, out transferLength);
    }

    public virtual ErrorCode Write(
      byte[] buffer,
      int offset,
      int count,
      int timeout,
      out int transferLength)
    {
      return this.Transfer((object) buffer, offset, count, timeout, out transferLength);
    }

    public virtual ErrorCode Write(
      object buffer,
      int offset,
      int count,
      int timeout,
      out int transferLength)
    {
      return this.Transfer(buffer, offset, count, timeout, out transferLength);
    }

    public virtual ErrorCode Write(object buffer, int timeout, out int transferLength) => this.Write(buffer, 0, Marshal.SizeOf(buffer), timeout, out transferLength);

    internal override UsbTransfer CreateTransferContext() => (UsbTransfer) new OverlappedTransferContext((UsbEndpointBase) this);
  }
}
