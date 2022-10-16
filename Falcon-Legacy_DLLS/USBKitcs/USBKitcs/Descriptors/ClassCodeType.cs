// Decompiled with JetBrains decompiler
// Type: USBKitcs.Descriptors.ClassCodeType
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;

namespace USBKitcs.Descriptors
{
  [Flags]
  public enum ClassCodeType : byte
  {
    PerInterface = 0,
    Audio = 1,
    Comm = 2,
    Hid = Comm | Audio, // 0x03
    Printer = 7,
    Ptp = 6,
    MassStorage = 8,
    Hub = MassStorage | Audio, // 0x09
    Data = MassStorage | Comm, // 0x0A
    VendorSpec = 255, // 0xFF
  }
}
