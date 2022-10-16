// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.Internal.DevBroadcastVolume
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;

namespace USBKitcs.DeviceNotify.Internal
{
  [StructLayout(LayoutKind.Sequential)]
  internal class DevBroadcastVolume : DevBroadcastHdr
  {
    public int UnitMask;
    public short Flags;

    public DevBroadcastVolume()
    {
      this.Size = Marshal.SizeOf<DevBroadcastVolume>(this);
      this.DeviceType = DeviceType.Volume;
    }
  }
}
