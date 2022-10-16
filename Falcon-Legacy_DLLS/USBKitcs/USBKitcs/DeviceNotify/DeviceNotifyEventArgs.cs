// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.DeviceNotifyEventArgs
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using USBKitcs.DeviceNotify.Info;

namespace USBKitcs.DeviceNotify
{
  public abstract class DeviceNotifyEventArgs : EventArgs
  {
    internal IUsbDeviceNotifyInfo mDevice;
    internal DeviceType mDeviceType;
    internal EventType mEventType;
    internal object mObject;
    internal IPortNotifyInfo mPort;
    internal IVolumeNotifyInfo mVolume;

    public IVolumeNotifyInfo Volume => this.mVolume;

    public IPortNotifyInfo Port => this.mPort;

    public IUsbDeviceNotifyInfo Device => this.mDevice;

    public EventType EventType => this.mEventType;

    public DeviceType DeviceType => this.mDeviceType;

    public object Object => this.mObject;

    public override string ToString() => string.Format("[DeviceType:{0}] [EventType:{1}] {2}", new object[3]
    {
      (object) this.DeviceType,
      (object) this.EventType,
      (object) this.mObject.ToString()
    });
  }
}
