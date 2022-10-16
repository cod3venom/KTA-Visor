// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.MonoUsbError
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

namespace USBKitcs.MonoLibUsb
{
  public enum MonoUsbError
  {
    ErrorOther = -99, // 0xFFFFFF9D
    ErrorIOCancelled = -13, // 0xFFFFFFF3
    ErrorNotSupported = -12, // 0xFFFFFFF4
    ErrorNoMem = -11, // 0xFFFFFFF5
    ErrorInterrupted = -10, // 0xFFFFFFF6
    ErrorPipe = -9, // 0xFFFFFFF7
    ErrorOverflow = -8, // 0xFFFFFFF8
    ErrorTimeout = -7, // 0xFFFFFFF9
    ErrorBusy = -6, // 0xFFFFFFFA
    ErrorNotFound = -5, // 0xFFFFFFFB
    ErrorNoDevice = -4, // 0xFFFFFFFC
    ErrorAccess = -3, // 0xFFFFFFFD
    ErrorInvalidParam = -2, // 0xFFFFFFFE
    ErrorIO = -1, // 0xFFFFFFFF
    Success = 0,
  }
}
