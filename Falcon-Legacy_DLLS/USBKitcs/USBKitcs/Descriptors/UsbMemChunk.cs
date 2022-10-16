// Decompiled with JetBrains decompiler
// Type: USBKitcs.Descriptors.UsbMemChunk
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;

namespace USBKitcs.Descriptors
{
  internal abstract class UsbMemChunk
  {
    private readonly int mMaxSize;
    private IntPtr mMemPointer = IntPtr.Zero;

    protected UsbMemChunk(int maxSize)
    {
      this.mMaxSize = maxSize;
      this.mMemPointer = Marshal.AllocHGlobal(maxSize);
    }

    public int MaxSize => this.mMaxSize;

    public IntPtr Ptr => this.mMemPointer;

    public void Free()
    {
      if (!(this.mMemPointer != IntPtr.Zero))
        return;
      Marshal.FreeHGlobal(this.mMemPointer);
      this.mMemPointer = IntPtr.Zero;
    }

    ~UsbMemChunk() => this.Free();
  }
}
