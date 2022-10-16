// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.Info.PortNotifyInfo
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;
using USBKitcs.DeviceNotify.Internal;

namespace USBKitcs.DeviceNotify.Info
{
  public class PortNotifyInfo : IPortNotifyInfo
  {
    private readonly DevBroadcastPort mBaseHdr = new DevBroadcastPort();
    private readonly string mName;

    internal PortNotifyInfo(IntPtr lParam)
    {
      Marshal.PtrToStructure<DevBroadcastPort>(lParam, this.mBaseHdr);
      this.mName = Marshal.PtrToStringAuto(new IntPtr(lParam.ToInt64() + Marshal.OffsetOf(typeof (DevBroadcastPort), "mNameHolder").ToInt64()));
    }

    public string Name => this.mName;

    public override string ToString() => string.Format("[Port Name:{0}] ", (object) this.Name);
  }
}
