// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.Linux.LinuxUsbDeviceNotifyInfo
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using USBKitcs.Descriptors;
using USBKitcs.DeviceNotify.Info;
using USBKitcs.Main;

namespace USBKitcs.DeviceNotify.Linux
{
  public class LinuxUsbDeviceNotifyInfo : IUsbDeviceNotifyInfo
  {
    private readonly LinuxDevItem mLinuxDevItem;

    internal LinuxUsbDeviceNotifyInfo(LinuxDevItem linuxDevItem) => this.mLinuxDevItem = linuxDevItem;

    public UsbDeviceDescriptor DeviceDescriptor => this.mLinuxDevItem.DeviceDescriptor;

    public byte BusNumber => this.mLinuxDevItem.BusNumber;

    public byte DeviceAddress => this.mLinuxDevItem.DeviceAddress;

    public UsbSymbolicName SymbolicName => (UsbSymbolicName) null;

    public string Name => this.mLinuxDevItem.DeviceFileName;

    public Guid ClassGuid => Guid.Empty;

    public int IdVendor => (int) (ushort) this.mLinuxDevItem.DeviceDescriptor.VendorID;

    public int IdProduct => (int) (ushort) this.mLinuxDevItem.DeviceDescriptor.ProductID;

    public string SerialNumber => string.Empty;

    public override string ToString() => string.Format("Name:{0} BusNumber:{1} DeviceAddress:{2}\n{3}", (object) this.Name, (object) this.BusNumber, (object) this.DeviceAddress, (object) this.DeviceDescriptor.ToString());
  }
}
