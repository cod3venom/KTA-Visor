﻿// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.UsbEndpointDirection
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;

namespace USBKitcs.Main
{
  [Flags]
  public enum UsbEndpointDirection : byte
  {
    EndpointIn = 128, // 0x80
    EndpointOut = 0,
  }
}
