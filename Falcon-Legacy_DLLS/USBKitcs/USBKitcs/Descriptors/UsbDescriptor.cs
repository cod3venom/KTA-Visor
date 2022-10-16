// Decompiled with JetBrains decompiler
// Type: USBKitcs.Descriptors.UsbDescriptor
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;
using USBKitcs.Main;

namespace USBKitcs.Descriptors
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public abstract class UsbDescriptor
  {
    public static string ToStringParamValueSeperator = ":";
    public static string ToStringFieldSeperator = "\r\n";
    public static readonly int Size = Marshal.SizeOf(typeof (UsbDescriptor));
    public byte Length;
    public DescriptorType DescriptorType;

    public override string ToString()
    {
      object[] values = new object[2]
      {
        (object) this.Length,
        (object) this.DescriptorType
      };
      return SysOps.ToString("", new string[2]
      {
        "Length",
        "DescriptorType"
      }, UsbDescriptor.ToStringParamValueSeperator, values, UsbDescriptor.ToStringFieldSeperator);
    }
  }
}
