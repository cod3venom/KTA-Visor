// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Profile.MonoUsbProfileListHandle
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Collections;
using System.Collections.Generic;
using USBKitcs.Main;

namespace USBKitcs.MonoLibUsb.Profile
{
  public class MonoUsbProfileListHandle : 
    SafeContextHandle,
    IEnumerable<MonoUsbProfileHandle>,
    IEnumerable
  {
    private MonoUsbProfileListHandle()
      : base(IntPtr.Zero)
    {
    }

    internal MonoUsbProfileListHandle(IntPtr pHandleToOwn)
      : base(pHandleToOwn)
    {
    }

    public IEnumerator<MonoUsbProfileHandle> GetEnumerator() => (IEnumerator<MonoUsbProfileHandle>) new MonoUsbProfileHandleEnumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    protected override bool ReleaseHandle()
    {
      if (!this.IsInvalid)
      {
        MonoUsbApi.FreeDeviceList(this.handle, 1);
        this.SetHandleAsInvalid();
      }
      return true;
    }
  }
}
