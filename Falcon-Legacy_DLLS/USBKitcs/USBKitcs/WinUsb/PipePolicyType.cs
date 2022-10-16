// Decompiled with JetBrains decompiler
// Type: USBKitcs.WinUsb.PipePolicyType
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

namespace USBKitcs.WinUsb
{
  internal enum PipePolicyType : byte
  {
    ShortPacketTerminate = 1,
    AutoClearStall = 2,
    PipeTransferTimeout = 3,
    IgnoreShortPackets = 4,
    AllowPartialReads = 5,
    AutoFlush = 6,
    RawIo = 7,
    MaximumTransferSize = 8,
  }
}
