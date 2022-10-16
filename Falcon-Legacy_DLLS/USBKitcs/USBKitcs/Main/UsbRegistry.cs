// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.UsbRegistry
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Collections.Generic;
using System.Text;

namespace USBKitcs.Main
{
  public abstract class UsbRegistry
  {
    internal const string DEVICE_INTERFACE_GUIDS = "DeviceInterfaceGuids";
    internal const string LIBUSB_INTERFACE_GUIDS = "LibUsbInterfaceGUIDs";
    internal const string SYMBOLIC_NAME_KEY = "SymbolicName";
    internal const string DEVICE_ID_KEY = "DeviceID";
    private static readonly char[] ChNull = new char[1];
    public static bool ForceSetupApi = true;
    internal Guid[] mDeviceInterfaceGuids = new Guid[0];
    internal Dictionary<string, object> mDeviceProperties = new Dictionary<string, object>();
    private UsbSymbolicName mSymHardwareId;

    public Dictionary<string, object> DeviceProperties => this.mDeviceProperties;

    public abstract bool IsAlive { get; }

    public string SymbolicName => this.mDeviceProperties.ContainsKey(nameof (SymbolicName)) ? (string) this.mDeviceProperties[nameof (SymbolicName)] : (string) null;

    public abstract Guid[] DeviceInterfaceGuids { get; }

    public virtual int Vid
    {
      get
      {
        if (this.mSymHardwareId == null && this.mDeviceProperties[SPDRP.HardwareId.ToString()] is string[] mDeviceProperty && mDeviceProperty.Length != 0)
          this.mSymHardwareId = UsbSymbolicName.Parse(mDeviceProperty[0]);
        return this.mSymHardwareId != null ? this.mSymHardwareId.Vid : 0;
      }
    }

    public virtual int Pid
    {
      get
      {
        if (this.mSymHardwareId == null && this.mDeviceProperties[SPDRP.HardwareId.ToString()] is string[] mDeviceProperty && mDeviceProperty.Length != 0)
          this.mSymHardwareId = UsbSymbolicName.Parse(mDeviceProperty[0]);
        return this.mSymHardwareId != null ? this.mSymHardwareId.Pid : 0;
      }
    }

    public object this[string name]
    {
      get
      {
        object obj;
        this.mDeviceProperties.TryGetValue(name, out obj);
        return obj;
      }
    }

    public object this[SPDRP spdrp]
    {
      get
      {
        object obj;
        this.mDeviceProperties.TryGetValue(spdrp.ToString(), out obj);
        return obj;
      }
    }

    public object this[DevicePropertyType devicePropertyType]
    {
      get
      {
        object obj;
        this.mDeviceProperties.TryGetValue(devicePropertyType.ToString(), out obj);
        return obj;
      }
    }

    public string Name
    {
      get
      {
        string str = this[SPDRP.DeviceDesc] as string;
        return string.IsNullOrEmpty(str) ? string.Empty : str;
      }
    }

    public string FullName
    {
      get
      {
        string name = this.Name;
        if (!(this[SPDRP.Mfg] is string empty))
          empty = string.Empty;
        string fullName = name.Trim();
        string str = empty.Trim();
        int length1 = str.IndexOf(' ');
        for (int length2 = fullName.IndexOf(' '); length1 == length2 && length2 != -1 && str.Substring(0, length1).Equals(fullName.Substring(0, length2)); length2 = fullName.IndexOf(' '))
        {
          fullName = fullName.Remove(0, length2 + 1);
          length1 = str.IndexOf(' ');
        }
        if (fullName.ToLower().Contains(str.ToLower()))
          return fullName;
        if (str == string.Empty)
          str = "[Not Provided]";
        if (fullName == string.Empty)
          fullName = "[Not Provided]";
        return str + " - " + fullName;
      }
    }

    public int Count => this.mDeviceProperties.Count;

    public virtual int Rev
    {
      get
      {
        if (this.mSymHardwareId == null && this.mDeviceProperties[SPDRP.HardwareId.ToString()] is string[] mDeviceProperty && mDeviceProperty.Length != 0)
          this.mSymHardwareId = UsbSymbolicName.Parse(mDeviceProperty[0]);
        return this.mSymHardwareId != null ? this.mSymHardwareId.Rev : 0;
      }
    }

    public abstract UsbDevice Device { get; }

    public abstract bool Open(out UsbDevice usbDevice);

    internal static Guid GetAsGuid(byte[] buffer, int len)
    {
      Guid asGuid = Guid.Empty;
      if (len == 16)
      {
        byte[] numArray = new byte[len];
        Array.Copy((Array) buffer, (Array) numArray, numArray.Length);
        asGuid = new Guid(numArray);
      }
      return asGuid;
    }

    internal static string GetAsString(byte[] buffer, int len) => len > 2 ? Encoding.Unicode.GetString(buffer, 0, len).TrimEnd(UsbRegistry.ChNull) : "";

    internal static string[] GetAsStringArray(byte[] buffer, int len) => UsbRegistry.GetAsString(buffer, len).Split(new char[1], StringSplitOptions.RemoveEmptyEntries);

    internal static int GetAsStringInt32(byte[] buffer, int len)
    {
      int asStringInt32 = 0;
      if (len == 4)
        asStringInt32 = (int) buffer[0] | (int) buffer[1] << 8 | (int) buffer[2] << 16 | (int) buffer[3] << 24;
      return asStringInt32;
    }
  }
}
