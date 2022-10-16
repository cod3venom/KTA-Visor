// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.UnixNativeTimeval
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using USBKitcs.Main;

namespace USBKitcs.MonoLibUsb
{
  public struct UnixNativeTimeval
  {
    private IntPtr mTvSecInternal;
    private IntPtr mTvUSecInternal;

    public static UnixNativeTimeval WindowsDefault => new UnixNativeTimeval(2L, 0L);

    public static UnixNativeTimeval LinuxDefault => new UnixNativeTimeval(2L, 0L);

    public static UnixNativeTimeval Default => SysOps.IsLinux ? UnixNativeTimeval.LinuxDefault : UnixNativeTimeval.WindowsDefault;

    public long tv_sec
    {
      get => this.mTvSecInternal.ToInt64();
      set => this.mTvSecInternal = new IntPtr(value);
    }

    public long tv_usec
    {
      get => this.mTvUSecInternal.ToInt64();
      set => this.mTvUSecInternal = new IntPtr(value);
    }

    public UnixNativeTimeval(long tvSec, long tvUsec)
    {
      this.mTvSecInternal = new IntPtr(tvSec);
      this.mTvUSecInternal = new IntPtr(tvUsec);
    }
  }
}
