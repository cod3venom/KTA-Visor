// Decompiled with JetBrains decompiler
// Type: USBKitcs.Internal.WinUsb.SafeWinUsbInterfaceHandle
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;
using USBKitcs.WinUsb.Internal;

namespace USBKitcs.Internal.WinUsb
{
  internal class SafeWinUsbInterfaceHandle : SafeHandle
  {
    public SafeWinUsbInterfaceHandle()
      : base(IntPtr.Zero, true)
    {
    }

    public SafeWinUsbInterfaceHandle(IntPtr handle)
      : base(handle, true)
    {
    }

    public override bool IsInvalid => this.handle == IntPtr.Zero || this.handle.ToInt64() == -1L;

    protected override bool ReleaseHandle()
    {
      bool flag = true;
      if (!this.IsInvalid)
      {
        flag = WinUsbAPI.WinUsb_Free(this.handle);
        this.handle = IntPtr.Zero;
      }
      return flag;
    }
  }
}
