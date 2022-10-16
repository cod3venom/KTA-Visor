﻿// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Profile.MonoUsbConfigHandle
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using USBKitcs.Main;

namespace USBKitcs.MonoLibUsb.Profile
{
  public class MonoUsbConfigHandle : SafeContextHandle
  {
    private MonoUsbConfigHandle()
      : base(IntPtr.Zero, true)
    {
    }

    protected override bool ReleaseHandle()
    {
      if (!this.IsInvalid)
      {
        MonoUsbApi.FreeConfigDescriptor(this.handle);
        this.SetHandleAsInvalid();
      }
      return true;
    }
  }
}
