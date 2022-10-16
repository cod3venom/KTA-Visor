// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.Info.VolumeNotifyInfo
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;
using USBKitcs.DeviceNotify.Internal;

namespace USBKitcs.DeviceNotify.Info
{
  public class VolumeNotifyInfo : IVolumeNotifyInfo
  {
    private const int DBTF_MEDIA = 1;
    private const int DBTF_NET = 2;
    private readonly DevBroadcastVolume mBaseHdr = new DevBroadcastVolume();

    internal VolumeNotifyInfo(IntPtr lParam) => Marshal.PtrToStructure<DevBroadcastVolume>(lParam, this.mBaseHdr);

    public string Letter
    {
      get
      {
        int unitmask = this.Unitmask;
        for (byte index = 65; index < (byte) 97; ++index)
        {
          byte num = index;
          if (num > (byte) 90)
            num -= (byte) 43;
          if ((unitmask & 1) == 1)
            return ((char) num).ToString();
          unitmask >>= 1;
        }
        return '?'.ToString();
      }
    }

    public bool ChangeAffectsMediaInDrive => ((int) this.Flags & 1) == 1;

    public bool IsNetworkVolume => ((int) this.Flags & 2) == 2;

    public short Flags => this.mBaseHdr.Flags;

    public int Unitmask => this.mBaseHdr.UnitMask;

    public override string ToString() => string.Format("[Letter:{0}] [IsNetworkVolume:{1}] [ChangeAffectsMediaInDrive:{2}] ", (object) this.Letter, (object) this.IsNetworkVolume, (object) this.ChangeAffectsMediaInDrive);
  }
}
