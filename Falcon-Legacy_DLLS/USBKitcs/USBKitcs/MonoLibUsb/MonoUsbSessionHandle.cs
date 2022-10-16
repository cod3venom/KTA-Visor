// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.MonoUsbSessionHandle
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Diagnostics;
using USBKitcs.Main;

namespace USBKitcs.MonoLibUsb
{
  public class MonoUsbSessionHandle : SafeContextHandle
  {
    private static object sessionLOCK = new object();
    private static MonoUsbError mLastReturnCode;
    private static string mLastReturnString = string.Empty;
    private static int mSessionCount;
    private static string DLL_NOT_FOUND_LINUX = "libusb-1.0 library not found.  This is often an indication that libusb-1.0 was installed to '/usr/local/lib' and mono.net is not looking for it there. To resolve this, add the path '/usr/local/lib' to '/etc/ld.so.conf' and run 'ldconfig' as root. (http://www.mono-project.com/DllNotFoundException)";
    private static string DLL_NOT_FOUND_WINDOWS = "libusb-1.0.dll not found. If this is a 64bit operating system, ensure that the 64bit version of libusb-1.0.dll exists in the '\\Windows\\System32' directory.";

    public static MonoUsbError LastErrorCode
    {
      get
      {
        lock (MonoUsbSessionHandle.sessionLOCK)
          return MonoUsbSessionHandle.mLastReturnCode;
      }
    }

    public static string LastErrorString
    {
      get
      {
        lock (MonoUsbSessionHandle.sessionLOCK)
          return MonoUsbSessionHandle.mLastReturnString;
      }
    }

    public MonoUsbSessionHandle()
      : base(IntPtr.Zero, true)
    {
      lock (MonoUsbSessionHandle.sessionLOCK)
      {
        IntPtr zero = IntPtr.Zero;
        try
        {
          MonoUsbSessionHandle.mLastReturnCode = (MonoUsbError) MonoUsbApi.Init(ref zero);
        }
        catch (DllNotFoundException ex)
        {
          if (SysOps.IsLinux)
            throw new DllNotFoundException(MonoUsbSessionHandle.DLL_NOT_FOUND_LINUX, (Exception) ex);
          throw new DllNotFoundException(MonoUsbSessionHandle.DLL_NOT_FOUND_WINDOWS, (Exception) ex);
        }
        if (MonoUsbSessionHandle.mLastReturnCode < MonoUsbError.Success)
        {
          MonoUsbSessionHandle.mLastReturnString = MonoUsbApi.StrError(MonoUsbSessionHandle.mLastReturnCode);
          this.SetHandleAsInvalid();
        }
        else
        {
          this.SetHandle(zero);
          ++MonoUsbSessionHandle.mSessionCount;
        }
      }
    }

    protected override bool ReleaseHandle()
    {
      if (!this.IsInvalid)
      {
        lock (MonoUsbSessionHandle.sessionLOCK)
        {
          MonoUsbApi.Exit(this.handle);
          this.SetHandleAsInvalid();
          --MonoUsbSessionHandle.mSessionCount;
          Debug.Print(this.GetType().Name + " : ReleaseHandle #{0}", (object) MonoUsbSessionHandle.mSessionCount);
        }
      }
      return true;
    }
  }
}
