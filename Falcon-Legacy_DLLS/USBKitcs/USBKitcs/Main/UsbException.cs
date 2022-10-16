// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.UsbException
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;

namespace USBKitcs.Main
{
  public class UsbException : Exception
  {
    private readonly object mSender;

    internal UsbException(object sender, string description)
      : base(description)
    {
      this.mSender = sender;
    }

    public object Sender => this.mSender;
  }
}
