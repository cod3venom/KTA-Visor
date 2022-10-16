// Decompiled with JetBrains decompiler
// Type: USBKitcs.Internal.LibUsb.LibUsbRequest
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;
using USBKitcs.Main;

namespace USBKitcs.Internal.LibUsb
{
  [StructLayout(LayoutKind.Explicit, Size = 24, Pack = 1)]
  internal class LibUsbRequest
  {
    public static int Size = Marshal.SizeOf(typeof (LibUsbRequest));
    [FieldOffset(0)]
    public int Timeout = 1000;
    [FieldOffset(4)]
    public Control Control;
    [FieldOffset(4)]
    public Config Config;
    [FieldOffset(4)]
    public Debug Debug;
    [FieldOffset(4)]
    public Descriptor Descriptor;
    [FieldOffset(4)]
    public Endpoint Endpoint;
    [FieldOffset(4)]
    public Feature Feature;
    [FieldOffset(4)]
    public Iface Iface;
    [FieldOffset(4)]
    public Status Status;
    [FieldOffset(4)]
    public Vendor Vendor;
    [FieldOffset(4)]
    public UsbKernelVersion Version;
    [FieldOffset(4)]
    public DeviceProperty DeviceProperty;
    [FieldOffset(4)]
    public DeviceRegKey DeviceRegKey;
    [FieldOffset(4)]
    public BusQueryID BusQueryID;

    public byte[] Bytes
    {
      get
      {
        byte[] bytes = new byte[LibUsbRequest.Size];
        for (int ofs = 0; ofs < LibUsbRequest.Size; ++ofs)
          bytes[ofs] = Marshal.ReadByte((object) this, ofs);
        return bytes;
      }
    }

    public void RequestConfigDescriptor(int index)
    {
      this.Timeout = 1000;
      int num = 512 + index;
      this.Descriptor.Recipient = 0;
      this.Descriptor.Type = num >> 8 & (int) byte.MaxValue;
      this.Descriptor.Index = num & (int) byte.MaxValue;
      this.Descriptor.LangID = 0;
    }

    public void RequestStringDescriptor(int index, short langid)
    {
      this.Timeout = 1000;
      int num = 768 + index;
      this.Descriptor.Recipient = 0;
      this.Descriptor.Type = num >> 8 & (int) byte.MaxValue;
      this.Descriptor.Index = num & (int) byte.MaxValue;
      this.Descriptor.LangID = (int) langid;
    }
  }
}
