// Decompiled with JetBrains decompiler
// Type: USBKitcs.Internal.UsbRegex.NamedGroup
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

namespace USBKitcs.Internal.UsbRegex
{
  internal struct NamedGroup
  {
    public readonly string GroupName;
    public readonly int GroupNumber;

    public NamedGroup(int GroupNumber, string GroupName)
    {
      this.GroupNumber = GroupNumber;
      this.GroupName = GroupName;
    }
  }
}
