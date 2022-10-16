// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.Linux.LinuxDeviceNotifyEventArgs
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using USBKitcs.DeviceNotify.Info;

namespace USBKitcs.DeviceNotify.Linux
{
  public class LinuxDeviceNotifyEventArgs : DeviceNotifyEventArgs
  {
    internal LinuxDeviceNotifyEventArgs(
      LinuxDevItem linuxDevItem,
      DeviceType deviceType,
      EventType eventType)
    {
      this.mEventType = eventType;
      this.mDeviceType = deviceType;
      switch (this.mDeviceType)
      {
        case DeviceType.Volume:
          throw new NotImplementedException(this.mDeviceType.ToString());
        case DeviceType.Port:
          throw new NotImplementedException(this.mDeviceType.ToString());
        case DeviceType.DeviceInterface:
          this.mDevice = (IUsbDeviceNotifyInfo) new LinuxUsbDeviceNotifyInfo(linuxDevItem);
          this.mObject = (object) this.mDevice;
          break;
      }
    }
  }
}
