// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.Internal.DevBroadcastPort
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;

namespace USBKitcs.DeviceNotify.Internal
{
  [StructLayout(LayoutKind.Sequential)]
  internal class DevBroadcastPort : DevBroadcastHdr
  {
    private char mNameHolder;

    public DevBroadcastPort()
    {
      this.Size = Marshal.SizeOf<DevBroadcastPort>(this);
      this.DeviceType = DeviceType.Port;
    }
  }
}
