// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.ErrorCode
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

namespace USBKitcs.Main
{
  public enum ErrorCode
  {
    InvalidConfig = -16384, // 0xFFFFC000
    IoSyncFailed = -16383, // 0xFFFFC001
    GetString = -16382, // 0xFFFFC002
    InvalidEndpoint = -16381, // 0xFFFFC003
    AbortEndpoint = -16380, // 0xFFFFC004
    DeviceIoControl = -16379, // 0xFFFFC005
    GetOverlappedResult = -16378, // 0xFFFFC006
    ReceiveThreadTerminated = -16377, // 0xFFFFC007
    WriteFailed = -16376, // 0xFFFFC008
    ReadFailed = -16375, // 0xFFFFC009
    IoControlMessage = -16374, // 0xFFFFC00A
    CancelIoFailed = -16373, // 0xFFFFC00B
    IoCancelled = -16372, // 0xFFFFC00C
    IoTimedOut = -16371, // 0xFFFFC00D
    IoEndpointGlobalCancelRedo = -16370, // 0xFFFFC00E
    GetDeviceKeyValueFailed = -16369, // 0xFFFFC00F
    SetDeviceKeyValueFailed = -16368, // 0xFFFFC010
    Win32Error = -16367, // 0xFFFFC011
    DeviceAllreadyLocked = -16366, // 0xFFFFC012
    EndpointAllreadyLocked = -16365, // 0xFFFFC013
    DeviceNotFound = -16364, // 0xFFFFC014
    UserAborted = -16363, // 0xFFFFC015
    InvalidParam = -16362, // 0xFFFFC016
    AccessDenied = -16361, // 0xFFFFC017
    ResourceBusy = -16360, // 0xFFFFC018
    Overflow = -16359, // 0xFFFFC019
    PipeError = -16358, // 0xFFFFC01A
    Interrupted = -16357, // 0xFFFFC01B
    InsufficientMemory = -16356, // 0xFFFFC01C
    NotSupported = -16355, // 0xFFFFC01D
    UnknownError = -16354, // 0xFFFFC01E
    MonoApiError = -16353, // 0xFFFFC01F
    None = 0,
    Ok = 0,
    Success = 0,
  }
}
