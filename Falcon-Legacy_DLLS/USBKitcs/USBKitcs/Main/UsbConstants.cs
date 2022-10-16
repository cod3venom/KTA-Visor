// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.UsbConstants
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

namespace USBKitcs.Main
{
  public static class UsbConstants
  {
    public const int DEFAULT_TIMEOUT = 1000;
    internal const bool EXIT_CONTEXT = false;
    public const int MAX_CONFIG_SIZE = 4096;
    public const int MAX_DEVICES = 128;
    public const int MAX_ENDPOINTS = 32;
    public const byte ENDPOINT_DIR_MASK = 128;
    public const byte ENDPOINT_NUMBER_MASK = 15;
  }
}
