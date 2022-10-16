// Decompiled with JetBrains decompiler
// Type: USBKitcs.Descriptors.DescriptorType
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;

namespace USBKitcs.Descriptors
{
  [Flags]
  public enum DescriptorType : byte
  {
    Device = 1,
    Configuration = 2,
    String = Configuration | Device, // 0x03
    Interface = 4,
    Endpoint = Interface | Device, // 0x05
    DeviceQualifier = Interface | Configuration, // 0x06
    OtherSpeedConfiguration = DeviceQualifier | Device, // 0x07
    InterfacePower = 8,
    OTG = InterfacePower | Device, // 0x09
    Debug = InterfacePower | Configuration, // 0x0A
    InterfaceAssociation = Debug | Device, // 0x0B
    Hid = 33, // 0x21
    HidReport = 34, // 0x22
    Physical = HidReport | Device, // 0x23
    Hub = Hid | InterfacePower, // 0x29
  }
}
