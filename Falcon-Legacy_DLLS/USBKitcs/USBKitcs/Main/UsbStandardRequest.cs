// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.UsbStandardRequest
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;

namespace USBKitcs.Main
{
  [Flags]
  public enum UsbStandardRequest : byte
  {
    ClearFeature = 1,
    GetConfiguration = 8,
    GetDescriptor = 6,
    GetInterface = 10, // 0x0A
    GetStatus = 0,
    SetAddress = 5,
    SetConfiguration = GetConfiguration | ClearFeature, // 0x09
    SetDescriptor = 7,
    SetFeature = 3,
    SetInterface = SetFeature | GetConfiguration, // 0x0B
    SynchFrame = 12, // 0x0C
  }
}
