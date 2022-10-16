// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.SysOps
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace USBKitcs.Main
{
  public static class SysOps
  {
    private static object mIsLinux;
    private static OperatingSystem mOs;

    public static OperatingSystem OSVersion
    {
      get
      {
        if (SysOps.mOs == null)
          SysOps.mOs = Environment.OSVersion;
        return SysOps.mOs;
      }
    }

    public static bool IsLinux
    {
      get
      {
        if (SysOps.mIsLinux == null)
        {
          switch (SysOps.OSVersion.Platform.ToString())
          {
            case "MacOSX":
            case "Unix":
              SysOps.mIsLinux = (object) true;
              break;
            case "Win32NT":
            case "Win32S":
            case "Win32Windows":
            case "WinCE":
            case "Xbox":
              SysOps.mIsLinux = (object) false;
              break;
            default:
              throw new NotSupportedException(string.Format("Operating System:{0} not supported.", (object) SysOps.OSVersion));
          }
        }
        return (bool) SysOps.mIsLinux;
      }
    }

    public static void BytesToObject(
      byte[] sourceBytes,
      int iStartIndex,
      int iLength,
      object destObject)
    {
      GCHandle gcHandle = GCHandle.Alloc(destObject, GCHandleType.Pinned);
      IntPtr destination = gcHandle.AddrOfPinnedObject();
      Marshal.Copy(sourceBytes, iStartIndex, destination, iLength);
      gcHandle.Free();
    }

    public static Dictionary<string, int> GetEnumData(Type type)
    {
      Dictionary<string, int> enumData = new Dictionary<string, int>();
      FieldInfo[] fields = type.GetFields();
      for (int index = 1; index < fields.Length; ++index)
      {
        object rawConstantValue = fields[index].GetRawConstantValue();
        enumData.Add(fields[index].Name, Convert.ToInt32(rawConstantValue));
      }
      return enumData;
    }

    public static short HostEndianToLE16(short swapValue) => (short) new SysOps.HostEndian16BitValue(swapValue).U16;

    public static string ShowAsHex(object standardValue)
    {
      switch (standardValue)
      {
        case null:
          return "";
        case long num1:
          return "0x" + num1.ToString("X16");
        case uint num2:
          return "0x" + num2.ToString("X8");
        case int num3:
          return "0x" + num3.ToString("X8");
        case ushort num4:
          return "0x" + num4.ToString("X4");
        case short num5:
          return "0x" + num5.ToString("X4");
        case byte num6:
          return "0x" + num6.ToString("X2");
        case string _:
          return SysOps.HexString(standardValue as byte[], "", " ");
        default:
          return "";
      }
    }

    public static string ToString(
      string sep0,
      string[] names,
      string sep1,
      object[] values,
      string sep2)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < names.Length; ++index)
        stringBuilder.Append(sep0 + names[index] + sep1 + values[index] + sep2);
      return stringBuilder.ToString();
    }

    public static string HexString(byte[] data, string prefix, string suffix)
    {
      if (prefix == null)
        prefix = string.Empty;
      if (suffix == null)
        suffix = string.Empty;
      StringBuilder stringBuilder = new StringBuilder(data.Length * 2 + data.Length * prefix.Length + data.Length * suffix.Length);
      foreach (byte num in data)
        stringBuilder.Append(prefix + num.ToString("X2") + suffix);
      return stringBuilder.ToString();
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    internal struct HostEndian16BitValue
    {
      [FieldOffset(0)]
      public readonly ushort U16;
      [FieldOffset(0)]
      public readonly byte B0;
      [FieldOffset(1)]
      public readonly byte B1;

      public HostEndian16BitValue(short x)
      {
        this.U16 = (ushort) 0;
        this.B1 = (byte) ((uint) x >> 8);
        this.B0 = (byte) ((uint) x & (uint) byte.MaxValue);
      }
    }
  }
}
