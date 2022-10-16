// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.UsbCtrlFlags
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;

namespace USBKitcs.Main
{
  [Flags]
  public enum UsbCtrlFlags : byte
  {
    Direction_In = 128, // 0x80
    Direction_Out = 0,
    Recipient_Device = 0,
    Recipient_Endpoint = 2,
    Recipient_Interface = 1,
    Recipient_Other = Recipient_Interface | Recipient_Endpoint, // 0x03
    RequestType_Class = 32, // 0x20
    RequestType_Reserved = 96, // 0x60
    RequestType_Standard = 0,
    RequestType_Vendor = 64, // 0x40
  }
}
