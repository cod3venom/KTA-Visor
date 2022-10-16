// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.MonoUsbDeviceHandle
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Diagnostics;
using USBKitcs.Main;
using USBKitcs.MonoLibUsb.Profile;

namespace USBKitcs.MonoLibUsb
{
  public class MonoUsbDeviceHandle : SafeContextHandle
  {
    private static object handleLOCK = new object();
    private static MonoUsbError mLastReturnCode;
    private static string mLastReturnString = string.Empty;

    public static string LastErrorString
    {
      get
      {
        lock (MonoUsbDeviceHandle.handleLOCK)
          return MonoUsbDeviceHandle.mLastReturnString;
      }
    }

    public static MonoUsbError LastErrorCode
    {
      get
      {
        lock (MonoUsbDeviceHandle.handleLOCK)
          return MonoUsbDeviceHandle.mLastReturnCode;
      }
    }

    public MonoUsbDeviceHandle(MonoUsbProfileHandle profileHandle)
      : base(IntPtr.Zero)
    {
      IntPtr zero = IntPtr.Zero;
      int num = MonoUsbApi.Open(profileHandle, ref zero);
      if (num < 0 || zero == IntPtr.Zero)
      {
        lock (MonoUsbDeviceHandle.handleLOCK)
        {
          MonoUsbDeviceHandle.mLastReturnCode = (MonoUsbError) num;
          MonoUsbDeviceHandle.mLastReturnString = MonoUsbApi.StrError(MonoUsbDeviceHandle.mLastReturnCode);
        }
        this.SetHandleAsInvalid();
      }
      else
        this.SetHandle(zero);
    }

    internal MonoUsbDeviceHandle(IntPtr pDeviceHandle)
      : base(pDeviceHandle)
    {
    }

    protected override bool ReleaseHandle()
    {
      if (!this.IsInvalid)
      {
        Debug.WriteLine(this.GetType().Name + ".ReleaseHandle() Before", "Libusb-1.0");
        MonoUsbApi.Close(this.handle);
        Debug.WriteLine(this.GetType().Name + ".ReleaseHandle() After", "Libusb-1.0");
        this.SetHandleAsInvalid();
      }
      return true;
    }

    public new void Close() => base.Close();
  }
}
