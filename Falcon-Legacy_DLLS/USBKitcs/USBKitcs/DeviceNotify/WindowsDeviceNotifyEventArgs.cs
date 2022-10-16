// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.WindowsDeviceNotifyEventArgs
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using USBKitcs.DeviceNotify.Info;
using USBKitcs.DeviceNotify.Internal;

namespace USBKitcs.DeviceNotify
{
  public class WindowsDeviceNotifyEventArgs : DeviceNotifyEventArgs
  {
    private readonly DevBroadcastHdr mBaseHdr;

    internal WindowsDeviceNotifyEventArgs(DevBroadcastHdr hdr, IntPtr ptrHdr, EventType eventType)
    {
      this.mBaseHdr = hdr;
      this.mEventType = eventType;
      this.mDeviceType = this.mBaseHdr.DeviceType;
      switch (this.mDeviceType)
      {
        case DeviceType.Volume:
          this.mVolume = (IVolumeNotifyInfo) new VolumeNotifyInfo(ptrHdr);
          this.mObject = (object) this.mVolume;
          break;
        case DeviceType.Port:
          this.mPort = (IPortNotifyInfo) new PortNotifyInfo(ptrHdr);
          this.mObject = (object) this.mPort;
          break;
        case DeviceType.DeviceInterface:
          this.mDevice = (IUsbDeviceNotifyInfo) new UsbDeviceNotifyInfo(ptrHdr);
          this.mObject = (object) this.mDevice;
          break;
      }
    }
  }
}
