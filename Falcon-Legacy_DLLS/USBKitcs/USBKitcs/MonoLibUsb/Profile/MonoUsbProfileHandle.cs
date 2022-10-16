// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Profile.MonoUsbProfileHandle
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Diagnostics;
using USBKitcs.Main;

namespace USBKitcs.MonoLibUsb.Profile
{
  public class MonoUsbProfileHandle : SafeContextHandle
  {
    private static int mDeviceProfileRefCount;
    private static readonly object oDeviceProfileRefLock = new object();

    public MonoUsbProfileHandle(IntPtr pProfileHandle)
      : base(pProfileHandle, true)
    {
      lock (MonoUsbProfileHandle.oDeviceProfileRefLock)
      {
        MonoUsbApi.RefDevice(pProfileHandle);
        ++MonoUsbProfileHandle.mDeviceProfileRefCount;
      }
    }

    protected override bool ReleaseHandle()
    {
      lock (MonoUsbProfileHandle.oDeviceProfileRefLock)
      {
        if (!this.IsInvalid)
        {
          MonoUsbApi.UnrefDevice(this.handle);
          --MonoUsbProfileHandle.mDeviceProfileRefCount;
          this.SetHandleAsInvalid();
          Debug.Print(this.GetType().Name + " : ReleaseHandle #{0}", (object) MonoUsbProfileHandle.mDeviceProfileRefCount);
        }
        return true;
      }
    }

    internal static int DeviceProfileRefCount
    {
      get
      {
        lock (MonoUsbProfileHandle.oDeviceProfileRefLock)
          return MonoUsbProfileHandle.mDeviceProfileRefCount;
      }
    }
  }
}
