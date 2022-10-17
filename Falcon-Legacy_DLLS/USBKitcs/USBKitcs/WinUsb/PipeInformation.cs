﻿// Decompiled with JetBrains decompiler
// Type: USBKitcs.WinUsb.PipeInformation
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;
using USBKitcs.Main;

namespace USBKitcs.WinUsb
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public class PipeInformation
  {
    public static readonly int Size = Marshal.SizeOf(typeof (PipeInformation));
    public EndpointType PipeType;
    public byte PipeId;
    public short MaximumPacketSize;
    public byte Interval;
  }
}