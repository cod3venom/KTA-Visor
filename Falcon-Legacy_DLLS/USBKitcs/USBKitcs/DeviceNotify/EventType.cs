// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.EventType
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

namespace USBKitcs.DeviceNotify
{
  public enum EventType
  {
    DeviceArrival = 32768, // 0x00008000
    DeviceQueryRemove = 32769, // 0x00008001
    DeviceQueryRemoveFailed = 32770, // 0x00008002
    DeviceRemovePending = 32771, // 0x00008003
    DeviceRemoveComplete = 32772, // 0x00008004
    DeviceTypeSpecific = 32773, // 0x00008005
    CustomEvent = 32774, // 0x00008006
  }
}
