// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.UsbRequestRecipient
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;

namespace USBKitcs.Main
{
  [Flags]
  public enum UsbRequestRecipient : byte
  {
    RecipDevice = 0,
    RecipEndpoint = 2,
    RecipInterface = 1,
    RecipOther = RecipInterface | RecipEndpoint, // 0x03
  }
}
