// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.Info.UsbDeviceNotifyInfo
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;
using USBKitcs.DeviceNotify.Internal;
using USBKitcs.Main;

namespace USBKitcs.DeviceNotify.Info
{
  public class UsbDeviceNotifyInfo : IUsbDeviceNotifyInfo
  {
    private readonly DevBroadcastDeviceinterface mBaseHdr = new DevBroadcastDeviceinterface();
    private readonly string mName;
    private UsbSymbolicName mSymbolicName;

    internal UsbDeviceNotifyInfo(IntPtr lParam)
    {
      Marshal.PtrToStructure<DevBroadcastDeviceinterface>(lParam, this.mBaseHdr);
      this.mName = Marshal.PtrToStringAuto(new IntPtr(lParam.ToInt64() + Marshal.OffsetOf(typeof (DevBroadcastDeviceinterface), "mNameHolder").ToInt64()));
    }

    public UsbSymbolicName SymbolicName
    {
      get
      {
        if (this.mSymbolicName == null)
          this.mSymbolicName = new UsbSymbolicName(this.mName);
        return this.mSymbolicName;
      }
    }

    public string Name => this.mName;

    public Guid ClassGuid => this.SymbolicName.ClassGuid;

    public int IdVendor => this.SymbolicName.Vid;

    public int IdProduct => this.SymbolicName.Pid;

    public string SerialNumber => this.SymbolicName.SerialNumber;

    public override string ToString() => this.SymbolicName.ToString();
  }
}
