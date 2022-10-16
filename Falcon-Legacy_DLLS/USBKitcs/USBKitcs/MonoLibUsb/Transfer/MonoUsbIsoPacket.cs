// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Transfer.MonoUsbIsoPacket
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;
using USBKitcs.MonoLibUsb.Transfer.Internal;

namespace USBKitcs.MonoLibUsb.Transfer
{
  [StructLayout(LayoutKind.Sequential)]
  public class MonoUsbIsoPacket
  {
    private static readonly int OfsActualLength = Marshal.OffsetOf(typeof (libusb_iso_packet_descriptor), "actual_length").ToInt32();
    private static readonly int OfsLength = Marshal.OffsetOf(typeof (libusb_iso_packet_descriptor), "length").ToInt32();
    private static readonly int OfsStatus = Marshal.OffsetOf(typeof (libusb_iso_packet_descriptor), "status").ToInt32();
    private IntPtr mpMonoUsbIsoPacket = IntPtr.Zero;

    public MonoUsbIsoPacket(IntPtr isoPacketPtr) => this.mpMonoUsbIsoPacket = isoPacketPtr;

    public IntPtr PtrIsoPacket => this.mpMonoUsbIsoPacket;

    public int ActualLength
    {
      get => Marshal.ReadInt32(this.mpMonoUsbIsoPacket, MonoUsbIsoPacket.OfsActualLength);
      set => Marshal.WriteInt32(this.mpMonoUsbIsoPacket, MonoUsbIsoPacket.OfsActualLength, value);
    }

    public int Length
    {
      get => Marshal.ReadInt32(this.mpMonoUsbIsoPacket, MonoUsbIsoPacket.OfsLength);
      set => Marshal.WriteInt32(this.mpMonoUsbIsoPacket, MonoUsbIsoPacket.OfsLength, value);
    }

    public MonoUsbTansferStatus Status
    {
      get => (MonoUsbTansferStatus) Marshal.ReadInt32(this.mpMonoUsbIsoPacket, MonoUsbIsoPacket.OfsStatus);
      set => Marshal.WriteInt32(this.mpMonoUsbIsoPacket, MonoUsbIsoPacket.OfsStatus, (int) value);
    }
  }
}
