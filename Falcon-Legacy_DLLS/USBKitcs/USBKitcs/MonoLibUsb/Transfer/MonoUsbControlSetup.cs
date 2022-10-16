// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Transfer.MonoUsbControlSetup
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;
using USBKitcs.Main;
using USBKitcs.MonoLibUsb.Transfer.Internal;

namespace USBKitcs.MonoLibUsb.Transfer
{
  [StructLayout(LayoutKind.Sequential)]
  public class MonoUsbControlSetup
  {
    public static int SETUP_PACKET_SIZE = Marshal.SizeOf(typeof (libusb_control_setup));
    private static readonly int OfsRequestType = Marshal.OffsetOf(typeof (libusb_control_setup), "bmRequestType").ToInt32();
    private static readonly int OfsRequest = Marshal.OffsetOf(typeof (libusb_control_setup), "bRequest").ToInt32();
    private static readonly int OfsValue = Marshal.OffsetOf(typeof (libusb_control_setup), "wValue").ToInt32();
    private static readonly int OfsIndex = Marshal.OffsetOf(typeof (libusb_control_setup), "wIndex").ToInt32();
    private static readonly int OfsLength = Marshal.OffsetOf(typeof (libusb_control_setup), "wLength").ToInt32();
    private static readonly int OfsPtrData = MonoUsbControlSetup.SETUP_PACKET_SIZE;
    private IntPtr handle;

    public MonoUsbControlSetup(IntPtr pControlSetup) => this.handle = pControlSetup;

    public byte RequestType
    {
      get => Marshal.ReadByte(this.handle, MonoUsbControlSetup.OfsRequestType);
      set => Marshal.WriteByte(this.handle, MonoUsbControlSetup.OfsRequestType, value);
    }

    public byte Request
    {
      get => Marshal.ReadByte(this.handle, MonoUsbControlSetup.OfsRequest);
      set => Marshal.WriteByte(this.handle, MonoUsbControlSetup.OfsRequest, value);
    }

    public short Value
    {
      get => SysOps.HostEndianToLE16(Marshal.ReadInt16(this.handle, MonoUsbControlSetup.OfsValue));
      set => Marshal.WriteInt16(this.handle, MonoUsbControlSetup.OfsValue, SysOps.HostEndianToLE16(value));
    }

    public short Index
    {
      get => SysOps.HostEndianToLE16(Marshal.ReadInt16(this.handle, MonoUsbControlSetup.OfsIndex));
      set => Marshal.WriteInt16(this.handle, MonoUsbControlSetup.OfsIndex, SysOps.HostEndianToLE16(value));
    }

    public short Length
    {
      get => SysOps.HostEndianToLE16(Marshal.ReadInt16(this.handle, MonoUsbControlSetup.OfsLength));
      set => Marshal.WriteInt16(this.handle, MonoUsbControlSetup.OfsLength, SysOps.HostEndianToLE16(value));
    }

    public IntPtr PtrData => new IntPtr(this.handle.ToInt64() + (long) MonoUsbControlSetup.OfsPtrData);

    public void SetData(object data, int offset, int length)
    {
      PinnedHandle pinnedHandle = new PinnedHandle(data);
      byte[] numArray = new byte[length];
      Marshal.Copy(pinnedHandle.Handle, numArray, offset, length);
      pinnedHandle.Dispose();
      Marshal.Copy(numArray, 0, this.PtrData, length);
    }

    public byte[] GetData(int transferLength)
    {
      byte[] destination = new byte[transferLength];
      Marshal.Copy(this.PtrData, destination, 0, destination.Length);
      return destination;
    }
  }
}
