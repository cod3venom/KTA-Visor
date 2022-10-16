// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.Info.IUsbDeviceNotifyInfo
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using USBKitcs.Main;

namespace USBKitcs.DeviceNotify.Info
{
  public interface IUsbDeviceNotifyInfo
  {
    UsbSymbolicName SymbolicName { get; }

    string Name { get; }

    Guid ClassGuid { get; }

    int IdVendor { get; }

    int IdProduct { get; }

    string SerialNumber { get; }

    string ToString();
  }
}
