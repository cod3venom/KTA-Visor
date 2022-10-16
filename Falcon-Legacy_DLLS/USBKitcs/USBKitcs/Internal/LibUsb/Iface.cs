// Decompiled with JetBrains decompiler
// Type: USBKitcs.Internal.LibUsb.Iface
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;

namespace USBKitcs.Internal.LibUsb
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct Iface
  {
    public int ID;
    public int AlternateID;
  }
}
