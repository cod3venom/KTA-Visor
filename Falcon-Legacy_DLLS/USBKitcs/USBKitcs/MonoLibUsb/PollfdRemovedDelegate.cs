// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.PollfdRemovedDelegate
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;

namespace USBKitcs.MonoLibUsb
{
  [UnmanagedFunctionPointer((CallingConvention) 0)]
  public delegate void PollfdRemovedDelegate(int fd, IntPtr user_data);
}
