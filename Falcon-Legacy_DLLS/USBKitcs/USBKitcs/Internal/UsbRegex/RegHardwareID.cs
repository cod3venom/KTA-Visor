// Decompiled with JetBrains decompiler
// Type: USBKitcs.Internal.UsbRegex.RegHardwareID
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Text.RegularExpressions;

namespace USBKitcs.Internal.UsbRegex
{
  internal class RegHardwareID : Regex
  {
    private const RegexOptions OPTIONS = RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.CultureInvariant;
    private const string PATTERN = "(Vid_(?<Vid>[0-9A-F]{1,4}))|(Pid_(?<Pid>[0-9A-F]{1,4}))|(Rev_(?<Rev>[0-9]{1,4}))|(MI_(?<MI>[0-9A-F]{1,2}))";
    public static readonly NamedGroup[] NAMED_GROUPS = new NamedGroup[4]
    {
      new NamedGroup(1, "Vid"),
      new NamedGroup(2, "Pid"),
      new NamedGroup(3, "Rev"),
      new NamedGroup(4, "MI")
    };
    private static RegHardwareID __globalInstance;

    public RegHardwareID()
      : base("(Vid_(?<Vid>[0-9A-F]{1,4}))|(Pid_(?<Pid>[0-9A-F]{1,4}))|(Rev_(?<Rev>[0-9]{1,4}))|(MI_(?<MI>[0-9A-F]{1,2}))", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.CultureInvariant)
    {
    }

    public static RegHardwareID GlobalInstance
    {
      get
      {
        if (RegHardwareID.__globalInstance == null)
          RegHardwareID.__globalInstance = new RegHardwareID();
        return RegHardwareID.__globalInstance;
      }
    }

    public new string[] GetGroupNames() => new string[4]
    {
      "Vid",
      "Pid",
      "Rev",
      "MI"
    };

    public new int[] GetGroupNumbers() => new int[4]
    {
      1,
      2,
      3,
      4
    };

    public new string GroupNameFromNumber(int GroupNumber)
    {
      switch (GroupNumber)
      {
        case 1:
          return "Vid";
        case 2:
          return "Pid";
        case 3:
          return "Rev";
        case 4:
          return "MI";
        default:
          return "";
      }
    }

    public new int GroupNumberFromName(string GroupName)
    {
      string str = GroupName;
      if (str == "Vid")
        return 1;
      if (str == "Pid")
        return 2;
      if (str == "Rev")
        return 3;
      return str == "MI" ? 4 : -1;
    }

    public enum ENamedGroups
    {
      Vid = 1,
      Pid = 2,
      Rev = 3,
      MI = 4,
    }
  }
}
