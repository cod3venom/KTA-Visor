// Decompiled with JetBrains decompiler
// Type: USBKitcs.IUsbDevice
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

namespace USBKitcs
{
  public interface IUsbDevice : IUsbInterface
  {
    bool SetConfiguration(byte config);

    bool GetConfiguration(out byte config);

    bool SetAltInterface(int alternateID);

    bool GetAltInterfaceSetting(byte interfaceID, out byte selectedAltInterfaceID);

    bool ClaimInterface(int interfaceID);

    bool ReleaseInterface(int interfaceID);

    bool ResetDevice();
  }
}
