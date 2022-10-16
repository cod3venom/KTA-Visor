// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.DevicePropertyType
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

namespace USBKitcs.Main
{
  public enum DevicePropertyType
  {
    DeviceDesc = 0,
    HardwareId = 1,
    CompatibleIds = 2,
    Class = 5,
    ClassGuid = 6,
    Driver = 7,
    Mfg = 8,
    FriendlyName = 9,
    LocationInformation = 10, // 0x0000000A
    PhysicalDeviceObjectName = 11, // 0x0000000B
    BusTypeGuid = 12, // 0x0000000C
    LegacyBusType = 13, // 0x0000000D
    BusNumber = 14, // 0x0000000E
    EnumeratorName = 15, // 0x0000000F
    Address = 16, // 0x00000010
    UiNumber = 17, // 0x00000011
    InstallState = 18, // 0x00000012
    RemovalPolicy = 19, // 0x00000013
  }
}
