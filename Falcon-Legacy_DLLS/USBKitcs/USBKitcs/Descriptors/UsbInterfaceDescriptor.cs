// Decompiled with JetBrains decompiler
// Type: USBKitcs.Descriptors.UsbInterfaceDescriptor
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;
using USBKitcs.Main;
using USBKitcs.MonoLibUsb.Descriptors;

namespace USBKitcs.Descriptors
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public class UsbInterfaceDescriptor : UsbDescriptor
  {
    public new static readonly int Size = Marshal.SizeOf(typeof (UsbInterfaceDescriptor));
    public readonly byte InterfaceID;
    public readonly byte AlternateID;
    public readonly byte EndpointCount;
    public readonly ClassCodeType Class;
    public readonly byte SubClass;
    public readonly byte Protocol;
    public readonly byte StringIndex;

    public override string ToString() => this.ToString("", UsbDescriptor.ToStringParamValueSeperator, UsbDescriptor.ToStringFieldSeperator);

    public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
    {
      object[] values = new object[9]
      {
        (object) this.Length,
        (object) this.DescriptorType,
        (object) this.InterfaceID,
        (object) this.AlternateID,
        (object) this.EndpointCount,
        (object) this.Class,
        (object) ("0x" + this.SubClass.ToString("X2")),
        (object) ("0x" + this.Protocol.ToString("X2")),
        (object) this.StringIndex
      };
      string[] names = new string[9]
      {
        "Length",
        "DescriptorType",
        "InterfaceID",
        "AlternateID",
        "EndpointCount",
        "Class",
        "SubClass",
        "Protocol",
        "StringIndex"
      };
      return SysOps.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
    }

    internal UsbInterfaceDescriptor()
    {
    }

    internal UsbInterfaceDescriptor(
      MonoUsbAltInterfaceDescriptor altInterfaceDescriptor)
    {
      this.AlternateID = altInterfaceDescriptor.bAlternateSetting;
      this.Class = altInterfaceDescriptor.bInterfaceClass;
      this.DescriptorType = altInterfaceDescriptor.bDescriptorType;
      this.EndpointCount = altInterfaceDescriptor.bNumEndpoints;
      this.InterfaceID = altInterfaceDescriptor.bInterfaceNumber;
      this.Length = altInterfaceDescriptor.bLength;
      this.Protocol = altInterfaceDescriptor.bInterfaceProtocol;
      this.StringIndex = altInterfaceDescriptor.iInterface;
      this.SubClass = altInterfaceDescriptor.bInterfaceSubClass;
    }
  }
}
