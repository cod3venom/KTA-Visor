﻿// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Transfer.MonoUsbTransferFlags
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

namespace USBKitcs.MonoLibUsb.Transfer
{
  public enum MonoUsbTransferFlags : byte
  {
    None = 0,
    TransferShortNotOk = 1,
    TransferFreeBuffer = 2,
    TransferFreeTransfer = 4,
  }
}
