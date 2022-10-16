// Decompiled with JetBrains decompiler
// Type: USBKitcs.Descriptors.UsbEndpointDescriptor
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;
using USBKitcs.Main;
using USBKitcs.MonoLibUsb.Descriptors;

namespace USBKitcs.Descriptors
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public class UsbEndpointDescriptor : UsbDescriptor
  {
    public new static readonly int Size = Marshal.SizeOf(typeof (UsbEndpointDescriptor));
    public readonly byte EndpointID;
    public readonly byte Attributes;
    public readonly short MaxPacketSize;
    public readonly byte Interval;
    public readonly byte Refresh;
    public readonly byte SynchAddress;

    internal UsbEndpointDescriptor()
    {
    }

    internal UsbEndpointDescriptor(MonoUsbEndpointDescriptor descriptor)
    {
      this.Attributes = descriptor.bmAttributes;
      this.DescriptorType = descriptor.bDescriptorType;
      this.EndpointID = descriptor.bEndpointAddress;
      this.Interval = descriptor.bInterval;
      this.Length = descriptor.bLength;
      this.MaxPacketSize = descriptor.wMaxPacketSize;
      this.SynchAddress = descriptor.bSynchAddress;
    }

    public override string ToString() => this.ToString("", UsbDescriptor.ToStringParamValueSeperator, UsbDescriptor.ToStringFieldSeperator);

    public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
    {
      object[] values = new object[8]
      {
        (object) this.Length,
        (object) this.DescriptorType,
        (object) ("0x" + this.EndpointID.ToString("X2")),
        (object) ("0x" + this.Attributes.ToString("X2")),
        (object) this.MaxPacketSize,
        (object) this.Interval,
        (object) this.Refresh,
        (object) ("0x" + this.SynchAddress.ToString("X2"))
      };
      string[] names = new string[8]
      {
        "Length",
        "DescriptorType",
        "EndpointID",
        "Attributes",
        "MaxPacketSize",
        "Interval",
        "Refresh",
        "SynchAddress"
      };
      return SysOps.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
    }
  }
}
