// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.EndpointDataEventArgs
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;

namespace USBKitcs.Main
{
  public class EndpointDataEventArgs : EventArgs
  {
    private readonly byte[] mBytesReceived;
    private readonly int mCount;

    internal EndpointDataEventArgs(byte[] bytes, int size)
    {
      this.mBytesReceived = bytes;
      this.mCount = size;
    }

    public byte[] Buffer => this.mBytesReceived;

    public int Count => this.mCount;
  }
}
