// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.UsbSymbolicName
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Globalization;
using System.Text.RegularExpressions;
using USBKitcs.Internal.UsbRegex;

namespace USBKitcs.Main
{
  public class UsbSymbolicName
  {
    private static RegHardwareID _regHardwareId;
    private static RegSymbolicName _regSymbolicName;
    private readonly string mSymbolicName;
    private Guid mClassGuid = Guid.Empty;
    private bool mIsParsed;
    private int mProductID;
    private int mRevisionCode;
    private string mSerialNumber = string.Empty;
    private int mVendorID;

    internal UsbSymbolicName(string symbolicName) => this.mSymbolicName = symbolicName;

    private static RegSymbolicName RegSymbolicName
    {
      get
      {
        if (UsbSymbolicName._regSymbolicName == null)
          UsbSymbolicName._regSymbolicName = new RegSymbolicName();
        return UsbSymbolicName._regSymbolicName;
      }
    }

    private static RegHardwareID RegHardwareId
    {
      get
      {
        if (UsbSymbolicName._regHardwareId == null)
          UsbSymbolicName._regHardwareId = new RegHardwareID();
        return UsbSymbolicName._regHardwareId;
      }
    }

    public string FullName
    {
      get
      {
        if (this.mSymbolicName == null)
          return string.Empty;
        return this.mSymbolicName.TrimStart('\\', '?');
      }
    }

    public int Vid
    {
      get
      {
        this.Parse();
        return this.mVendorID;
      }
    }

    public int Pid
    {
      get
      {
        this.Parse();
        return this.mProductID;
      }
    }

    public string SerialNumber
    {
      get
      {
        this.Parse();
        return this.mSerialNumber;
      }
    }

    public Guid ClassGuid
    {
      get
      {
        this.Parse();
        return this.mClassGuid;
      }
    }

    public int Rev
    {
      get
      {
        this.Parse();
        return this.mRevisionCode;
      }
    }

    public static UsbSymbolicName Parse(string identifiers) => new UsbSymbolicName(identifiers);

    public override string ToString() => string.Format("FullName:{0}\r\nVid:0x{1}\r\nPid:0x{2}\r\nSerialNumber:{3}\r\nClassGuid:{4}\r\n", (object) this.FullName, (object) this.Vid.ToString("X4"), (object) this.Pid.ToString("X4"), (object) this.SerialNumber, (object) this.ClassGuid);

    private void Parse()
    {
      if (this.mIsParsed)
        return;
      this.mIsParsed = true;
      if (this.mSymbolicName != null)
      {
        foreach (Match match in UsbSymbolicName.RegSymbolicName.Matches(this.mSymbolicName))
        {
          Group group1 = match.Groups[1];
          Group group2 = match.Groups[2];
          Group group3 = match.Groups[3];
          Group group4 = match.Groups[5];
          Group group5 = match.Groups[4];
          if (group1.Success && this.mVendorID == 0)
            int.TryParse(group1.Captures[0].Value, NumberStyles.HexNumber, (IFormatProvider) null, out this.mVendorID);
          if (group2.Success && this.mProductID == 0)
            int.TryParse(group2.Captures[0].Value, NumberStyles.HexNumber, (IFormatProvider) null, out this.mProductID);
          if (group3.Success && this.mRevisionCode == 0)
            int.TryParse(group3.Captures[0].Value, out this.mRevisionCode);
          if (group4.Success && this.mSerialNumber == string.Empty)
            this.mSerialNumber = group4.Captures[0].Value;
          if (group5.Success && this.mClassGuid == Guid.Empty)
          {
            try
            {
              this.mClassGuid = new Guid(group5.Captures[0].Value);
            }
            catch (Exception ex)
            {
              this.mClassGuid = Guid.Empty;
            }
          }
        }
      }
    }
  }
}
