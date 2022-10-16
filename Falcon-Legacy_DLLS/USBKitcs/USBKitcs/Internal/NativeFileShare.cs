// Decompiled with JetBrains decompiler
// Type: USBKitcs.Internal.NativeFileShare
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;

namespace USBKitcs.Internal
{
  [Flags]
  internal enum NativeFileShare : uint
  {
    NONE = 0,
    FILE_SHARE_READ = 1,
    FILE_SHARE_WRITE = 2,
    FILE_SHARE_DEELETE = 4,
  }
}
