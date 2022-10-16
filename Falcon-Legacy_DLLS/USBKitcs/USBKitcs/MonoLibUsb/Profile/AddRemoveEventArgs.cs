// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Profile.AddRemoveEventArgs
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;

namespace USBKitcs.MonoLibUsb.Profile
{
  public class AddRemoveEventArgs : EventArgs
  {
    private readonly AddRemoveType mAddRemoveType;
    private readonly MonoUsbProfile mMonoUSBProfile;

    internal AddRemoveEventArgs(MonoUsbProfile monoUSBProfile, AddRemoveType addRemoveType)
    {
      this.mMonoUSBProfile = monoUSBProfile;
      this.mAddRemoveType = addRemoveType;
    }

    public MonoUsbProfile MonoUSBProfile => this.mMonoUSBProfile;

    public AddRemoveType EventType => this.mAddRemoveType;
  }
}
