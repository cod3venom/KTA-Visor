// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Profile.MonoUsbProfile
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using USBKitcs.Main;
using USBKitcs.MonoLibUsb.Descriptors;

namespace USBKitcs.MonoLibUsb.Profile
{
  public class MonoUsbProfile
  {
    private readonly byte mBusNumber;
    private readonly byte mDeviceAddress;
    private readonly MonoUsbDeviceDescriptor mMonoUsbDeviceDescriptor = new MonoUsbDeviceDescriptor();
    private readonly MonoUsbProfileHandle mMonoUSBProfileHandle;
    internal bool mDiscovered;

    internal MonoUsbProfile(MonoUsbProfileHandle monoUSBProfileHandle)
    {
      this.mMonoUSBProfileHandle = monoUSBProfileHandle;
      this.mBusNumber = MonoUsbApi.GetBusNumber(this.mMonoUSBProfileHandle);
      this.mDeviceAddress = MonoUsbApi.GetDeviceAddress(this.mMonoUSBProfileHandle);
      int deviceDescriptor = (int) this.GetDeviceDescriptor(out this.mMonoUsbDeviceDescriptor);
    }

    public MonoUsbDeviceDescriptor DeviceDescriptor => this.mMonoUsbDeviceDescriptor;

    public byte BusNumber => this.mBusNumber;

    public byte DeviceAddress => this.mDeviceAddress;

    public MonoUsbProfileHandle ProfileHandle => this.mMonoUSBProfileHandle;

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if ((object) this == obj)
        return true;
      return !(obj.GetType() != typeof (MonoUsbProfile)) && this.Equals((MonoUsbProfile) obj);
    }

    public override int GetHashCode()
    {
      byte num1 = this.mBusNumber;
      int num2 = num1.GetHashCode() * 397;
      num1 = this.mDeviceAddress;
      int hashCode = num1.GetHashCode();
      return num2 ^ hashCode;
    }

    public static bool operator ==(MonoUsbProfile left, MonoUsbProfile right) => object.Equals((object) left, (object) right);

    public static bool operator !=(MonoUsbProfile left, MonoUsbProfile right) => !object.Equals((object) left, (object) right);

    private MonoUsbError GetDeviceDescriptor(
      out MonoUsbDeviceDescriptor monoUsbDeviceDescriptor)
    {
      monoUsbDeviceDescriptor = new MonoUsbDeviceDescriptor();
      MonoUsbError deviceDescriptor = (MonoUsbError) MonoUsbApi.GetDeviceDescriptor(this.mMonoUSBProfileHandle, monoUsbDeviceDescriptor);
      if (deviceDescriptor != 0)
      {
        UsbError.Error(ErrorCode.MonoApiError, (int) deviceDescriptor, "GetDeviceDescriptor Failed", (object) this);
        monoUsbDeviceDescriptor = (MonoUsbDeviceDescriptor) null;
      }
      return deviceDescriptor;
    }

    public void Close()
    {
      if (this.mMonoUSBProfileHandle.IsClosed)
        return;
      this.mMonoUSBProfileHandle.Close();
    }

    public MonoUsbDeviceHandle OpenDeviceHandle() => new MonoUsbDeviceHandle(this.ProfileHandle);

    public bool Equals(MonoUsbProfile other)
    {
      if ((object) other == null)
        return false;
      return (object) this == (object) other || (int) other.mBusNumber == (int) this.mBusNumber && (int) other.mDeviceAddress == (int) this.mDeviceAddress;
    }
  }
}
