// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceInfo.UsbEndpointInfo
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using USBKitcs.Descriptors;
using USBKitcs.Main;
using USBKitcs.MonoLibUsb.Descriptors;

namespace USBKitcs.DeviceInfo
{
  public class UsbEndpointInfo : UsbBaseInfo
  {
    internal UsbEndpointDescriptor mUsbEndpointDescriptor;

    internal UsbEndpointInfo(byte[] descriptor)
    {
      this.mUsbEndpointDescriptor = new UsbEndpointDescriptor();
      SysOps.BytesToObject(descriptor, 0, Math.Min(UsbEndpointDescriptor.Size, (int) descriptor[0]), (object) this.mUsbEndpointDescriptor);
    }

    internal UsbEndpointInfo(
      MonoUsbEndpointDescriptor monoUsbEndpointDescriptor)
    {
      this.mUsbEndpointDescriptor = new UsbEndpointDescriptor(monoUsbEndpointDescriptor);
    }

    public UsbEndpointDescriptor Descriptor => this.mUsbEndpointDescriptor;

    public override string ToString() => this.Descriptor.ToString();

    public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator) => this.Descriptor.ToString(prefixSeperator, entitySperator, suffixSeperator);
  }
}
