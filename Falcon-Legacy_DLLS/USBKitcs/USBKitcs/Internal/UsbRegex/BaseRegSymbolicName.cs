// Decompiled with JetBrains decompiler
// Type: USBKitcs.Internal.UsbRegex.BaseRegSymbolicName
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Text.RegularExpressions;

namespace USBKitcs.Internal.UsbRegex
{
  internal class BaseRegSymbolicName : Regex
  {
    private const RegexOptions OPTIONS = RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.CultureInvariant;
    private const string PATTERN = "((&){0,1}Vid_(?<Vid>[0-9A-Fa-f]{1,4})(&){0,1}Pid_(?<Pid>[0-9A-Fa-f]{1,4})((&){0,1}Rev_(?<Rev>[0-9A-Fa-f]{1,4})){0,1})((\\x23{0,1}\\{(?<ClassGuid>([0-9A-Fa-f]+)-([0-9A-Fa-f]+)-([0-9A-Fa-f]+)-([0-9A-Fa-f]+)-([0-9A-Fa-f]+))})|(\\x23(?<String>[\\x20-\\x22\\x24-\\x2b\\x2d-\\x7f]+?)(?=\\x23|$)))*";

    public BaseRegSymbolicName()
      : base("((&){0,1}Vid_(?<Vid>[0-9A-Fa-f]{1,4})(&){0,1}Pid_(?<Pid>[0-9A-Fa-f]{1,4})((&){0,1}Rev_(?<Rev>[0-9A-Fa-f]{1,4})){0,1})((\\x23{0,1}\\{(?<ClassGuid>([0-9A-Fa-f]+)-([0-9A-Fa-f]+)-([0-9A-Fa-f]+)-([0-9A-Fa-f]+)-([0-9A-Fa-f]+))})|(\\x23(?<String>[\\x20-\\x22\\x24-\\x2b\\x2d-\\x7f]+?)(?=\\x23|$)))*", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.CultureInvariant)
    {
    }
  }
}
