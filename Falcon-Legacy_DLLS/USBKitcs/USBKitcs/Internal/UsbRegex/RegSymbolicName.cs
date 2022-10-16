// Decompiled with JetBrains decompiler
// Type: USBKitcs.Internal.UsbRegex.RegSymbolicName
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

namespace USBKitcs.Internal.UsbRegex
{
  internal class RegSymbolicName : BaseRegSymbolicName
  {
    public static readonly NamedGroup[] NamedGroups = new NamedGroup[5]
    {
      new NamedGroup(1, "Vid"),
      new NamedGroup(2, "Pid"),
      new NamedGroup(3, "Rev"),
      new NamedGroup(4, "ClassGuid"),
      new NamedGroup(5, "String")
    };

    public new string[] GetGroupNames() => new string[5]
    {
      "Vid",
      "Pid",
      "Rev",
      "ClassGuid",
      "String"
    };

    public new int[] GetGroupNumbers() => new int[5]
    {
      1,
      2,
      3,
      4,
      5
    };

    public new string GroupNameFromNumber(int groupNumber)
    {
      switch (groupNumber)
      {
        case 1:
          return "Vid";
        case 2:
          return "Pid";
        case 3:
          return "Rev";
        case 4:
          return "ClassGuid";
        case 5:
          return "String";
        default:
          return "";
      }
    }

    public new int GroupNumberFromName(string groupName)
    {
      string lower = groupName.ToLower();
      if (lower == "vid")
        return 1;
      if (lower == "pid")
        return 2;
      if (lower == "rev")
        return 3;
      if (lower == "classguid")
        return 4;
      return lower == "string" ? 5 : -1;
    }
  }
}
