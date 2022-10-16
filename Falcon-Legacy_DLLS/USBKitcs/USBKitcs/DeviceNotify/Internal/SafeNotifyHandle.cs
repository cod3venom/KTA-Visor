// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.Internal.SafeNotifyHandle
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using Microsoft.Win32.SafeHandles;
using System;

namespace USBKitcs.DeviceNotify.Internal
{
  internal class SafeNotifyHandle : SafeHandleZeroOrMinusOneIsInvalid
  {
    public SafeNotifyHandle()
      : base(true)
    {
    }

    public SafeNotifyHandle(IntPtr pHandle)
      : base(true)
    {
      this.SetHandle(pHandle);
    }

    protected override bool ReleaseHandle()
    {
      if (this.handle != IntPtr.Zero)
      {
        WindowsDeviceNotifier.UnregisterDeviceNotification(this.handle);
        this.handle = IntPtr.Zero;
      }
      return true;
    }
  }
}
