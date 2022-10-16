// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.Linux.LinuxDevItem
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;
using USBKitcs.Descriptors;
using USBKitcs.MonoLibUsb.Descriptors;

namespace USBKitcs.DeviceNotify.Linux
{
  internal class LinuxDevItem
  {
    public readonly byte BusNumber;
    public readonly byte DeviceAddress;
    public readonly UsbDeviceDescriptor DeviceDescriptor;
    public readonly string DeviceFileName;

    public LinuxDevItem(
      string deviceFileName,
      byte busNumber,
      byte deviceAddress,
      byte[] fileDescriptor)
    {
      this.DeviceFileName = deviceFileName;
      this.BusNumber = busNumber;
      this.DeviceAddress = deviceAddress;
      this.DeviceDescriptor = new UsbDeviceDescriptor();
      GCHandle gcHandle = GCHandle.Alloc((object) this.DeviceDescriptor, GCHandleType.Pinned);
      Marshal.Copy(fileDescriptor, 0, gcHandle.AddrOfPinnedObject(), Marshal.SizeOf<UsbDeviceDescriptor>(this.DeviceDescriptor));
      gcHandle.Free();
    }

    public LinuxDevItem(
      string deviceFileName,
      byte busNumber,
      byte deviceAddress,
      MonoUsbDeviceDescriptor monoUsbDeviceDescriptor)
    {
      this.DeviceFileName = deviceFileName;
      this.BusNumber = busNumber;
      this.DeviceAddress = deviceAddress;
      this.DeviceDescriptor = new UsbDeviceDescriptor(monoUsbDeviceDescriptor);
    }

    public bool Equals(LinuxDevItem other)
    {
      if ((object) other == null)
        return false;
      return (object) this == (object) other || object.Equals((object) other.DeviceFileName, (object) this.DeviceFileName) && (int) other.BusNumber == (int) this.BusNumber && (int) other.DeviceAddress == (int) this.DeviceAddress && object.Equals((object) other.DeviceDescriptor, (object) this.DeviceDescriptor);
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if ((object) this == obj)
        return true;
      return !(obj.GetType() != typeof (LinuxDevItem)) && this.Equals((LinuxDevItem) obj);
    }

    public override int GetHashCode() => (((this.DeviceFileName != null ? this.DeviceFileName.GetHashCode() : 0) * 397 ^ this.BusNumber.GetHashCode()) * 397 ^ this.DeviceAddress.GetHashCode()) * 397 ^ (this.DeviceDescriptor != (UsbDeviceDescriptor) null ? this.DeviceDescriptor.GetHashCode() : 0);

    public static bool operator ==(LinuxDevItem left, LinuxDevItem right) => object.Equals((object) left, (object) right);

    public static bool operator !=(LinuxDevItem left, LinuxDevItem right) => !object.Equals((object) left, (object) right);
  }
}
