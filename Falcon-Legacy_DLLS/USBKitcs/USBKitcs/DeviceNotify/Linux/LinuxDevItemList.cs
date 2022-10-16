// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.Linux.LinuxDevItemList
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Collections.Generic;

namespace USBKitcs.DeviceNotify.Linux
{
  internal class LinuxDevItemList : List<LinuxDevItem>
  {
    public LinuxDevItem FindByName(string deviceFileName)
    {
      foreach (LinuxDevItem byName in (List<LinuxDevItem>) this)
      {
        if (byName.DeviceFileName == deviceFileName)
          return byName;
      }
      return (LinuxDevItem) null;
    }
  }
}
