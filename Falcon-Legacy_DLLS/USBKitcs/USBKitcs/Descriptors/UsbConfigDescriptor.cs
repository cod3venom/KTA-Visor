// Decompiled with JetBrains decompiler
// Type: USBKitcs.Descriptors.UsbConfigDescriptor
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;
using USBKitcs.Main;
using USBKitcs.MonoLibUsb.Descriptors;

namespace USBKitcs.Descriptors
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public class UsbConfigDescriptor : UsbDescriptor
  {
    public new static readonly int Size = Marshal.SizeOf(typeof (UsbConfigDescriptor));
    public readonly short TotalLength;
    public readonly byte InterfaceCount;
    public readonly byte ConfigID;
    public readonly byte StringIndex;
    public readonly byte Attributes;
    public readonly byte MaxPower;

    internal UsbConfigDescriptor(MonoUsbConfigDescriptor descriptor)
    {
      this.Attributes = descriptor.bmAttributes;
      this.ConfigID = descriptor.bConfigurationValue;
      this.DescriptorType = descriptor.bDescriptorType;
      this.InterfaceCount = descriptor.bNumInterfaces;
      this.Length = descriptor.bLength;
      this.MaxPower = descriptor.MaxPower;
      this.StringIndex = descriptor.iConfiguration;
      this.TotalLength = descriptor.wTotalLength;
    }

    internal UsbConfigDescriptor()
    {
    }

    public override string ToString() => this.ToString("", UsbDescriptor.ToStringParamValueSeperator, UsbDescriptor.ToStringFieldSeperator);

    public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
    {
      object[] values = new object[8]
      {
        (object) this.Length,
        (object) this.DescriptorType,
        (object) this.TotalLength,
        (object) this.InterfaceCount,
        (object) this.ConfigID,
        (object) this.StringIndex,
        (object) ("0x" + this.Attributes.ToString("X2")),
        (object) this.MaxPower
      };
      string[] names = new string[8]
      {
        "Length",
        "DescriptorType",
        "TotalLength",
        "InterfaceCount",
        "ConfigID",
        "StringIndex",
        "Attributes",
        "MaxPower"
      };
      return SysOps.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
    }
  }
}
