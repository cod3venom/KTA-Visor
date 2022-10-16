// Decompiled with JetBrains decompiler
// Type: Falcon_USB.UsbFalconDevice
// Assembly: Falcon_USB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7924EA10-DAC0-471E-BD57-BD7B43142DEE
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon_USB.dll

using System;
using System.Linq;
using System.Runtime.InteropServices;
using USBKitcs;
using USBKitcs.Main;

namespace Falcon_USB
{
  internal class UsbFalconDevice : IDisposable
  {
    public static UsbDeviceFinder _usbFinder = new UsbDeviceFinder(16981, 1);
    private const int BUF_SIZE = 12288;
    private const uint RAW_READ = 2748;
    private const uint RAW_WRITE = 291;
    private const uint _MAGIC_HEAD_ = 1728199237;
    private const uint _MAGIC_TAIL_ = 2566768058;
    private const int USB_VENDOR_ID = 16981;
    private const int USB_PRODUCT_ID = 1;
    private IUsbDevice _dev;
    private UsbEndpointReader _reader;
    private UsbEndpointWriter _writer;

    internal string DeviceLocation { get; private set; }

    internal UsbFalconDevice(UsbRegistry dev)
    {
      this._dev = dev.Device as IUsbDevice;
      this.DeviceLocation = dev.DeviceProperties["LocationInformation"].ToString();
      this._dev.SetConfiguration((byte) 1);
      this._dev.ClaimInterface(0);
      this._reader = this._dev.OpenEndpointReader(ReadEndpointID.Ep01);
      this._writer = this._dev.OpenEndpointWriter(WriteEndpointID.Ep01);
    }

    internal static UsbFalconDevice[] GetVisionDevices() => UsbDevice.AllLibUsbDevices.Select<UsbRegistry, UsbFalconDevice>((Func<UsbRegistry, UsbFalconDevice>) (x => new UsbFalconDevice(x))).ToArray<UsbFalconDevice>();

    internal void Release() => this._dev.Close();

    internal bool IsOpen() => this._dev.IsOpen;

    private T GetStruct<T>(byte[] data) where T : struct
    {
      int num1 = Marshal.SizeOf(typeof (T));
      IntPtr num2 = Marshal.AllocHGlobal(num1);
      Array.Resize<byte>(ref data, num1);
      Marshal.Copy(data, 0, num2, data.Length);
      T structure = (T) Marshal.PtrToStructure(num2, typeof (T));
      Marshal.FreeHGlobal(num2);
      return structure;
    }

    public static byte[] GetBytes<T>(T data) where T : struct
    {
      int length = Marshal.SizeOf(typeof (T));
      byte[] destination = new byte[length];
      IntPtr num = Marshal.AllocHGlobal(length);
      Marshal.StructureToPtr((object) data, num, true);
      Marshal.Copy(num, destination, 0, length);
      Marshal.FreeHGlobal(num);
      return destination;
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      this._dev.Close();
    }

    private enum Direction : uint
    {
      RAW_WRITE = 291, // 0x00000123
      RAW_READ = 2748, // 0x00000ABC
    }

    private struct SYSTEMTIME
    {
      [MarshalAs(UnmanagedType.U2)]
      public short Year;
      [MarshalAs(UnmanagedType.U2)]
      public short Month;
      [MarshalAs(UnmanagedType.U2)]
      public short DayOfWeek;
      [MarshalAs(UnmanagedType.U2)]
      public short Day;
      [MarshalAs(UnmanagedType.U2)]
      public short Hour;
      [MarshalAs(UnmanagedType.U2)]
      public short Minute;
      [MarshalAs(UnmanagedType.U2)]
      public short Second;
      [MarshalAs(UnmanagedType.U2)]
      public short Milliseconds;

      public SYSTEMTIME(DateTime dt)
      {
        this.Year = (short) dt.Year;
        this.Month = (short) dt.Month;
        this.DayOfWeek = (short) dt.DayOfWeek;
        this.Day = (short) dt.Day;
        this.Hour = (short) dt.Hour;
        this.Minute = (short) dt.Minute;
        this.Second = (short) dt.Second;
        this.Milliseconds = (short) dt.Millisecond;
      }
    }
  }
}
