// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.SafeContextHandle
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;

namespace USBKitcs.Main
{
  public abstract class SafeContextHandle : SafeHandle
  {
    protected SafeContextHandle(IntPtr pHandle, bool ownsHandle)
      : base(IntPtr.Zero, ownsHandle)
    {
      this.SetHandle(pHandle);
    }

    protected SafeContextHandle(IntPtr pHandleToOwn)
      : this(pHandleToOwn, true)
    {
    }

    public override bool IsInvalid => !(this.handle != IntPtr.Zero) || this.handle == new IntPtr(-1);
  }
}
