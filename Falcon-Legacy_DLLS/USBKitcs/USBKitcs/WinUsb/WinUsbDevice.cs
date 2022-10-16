// Decompiled with JetBrains decompiler
// Type: USBKitcs.WinUsb.WinUsbDevice
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using USBKitcs.Descriptors;
using USBKitcs.Internal;
using USBKitcs.Internal.WinUsb;
using USBKitcs.Main;
using USBKitcs.WinUsb.Internal;

namespace USBKitcs.WinUsb
{
  public class WinUsbDevice : UsbDevice, IUsbInterface
  {
    private readonly string mDevicePath;
    private PowerPolicies mPowerPolicies;
    private SafeFileHandle mSafeDevHandle;

    internal WinUsbDevice(
      UsbApiBase usbApi,
      SafeFileHandle usbHandle,
      SafeHandle handle,
      string devicePath)
      : base(usbApi, handle)
    {
      this.mDevicePath = devicePath;
      this.mSafeDevHandle = usbHandle;
      this.mPowerPolicies = new PowerPolicies(this);
    }

    public PowerPolicies PowerPolicy => this.mPowerPolicies;

    public string DevicePath => this.mDevicePath;

    public override UsbDevice.DriverModeType DriverMode => UsbDevice.DriverModeType.WinUsb;

    public override bool Close()
    {
      if (this.IsOpen)
      {
        this.ActiveEndpoints.Clear();
        this.mUsbHandle.Close();
        if (this.mSafeDevHandle != null && !this.mSafeDevHandle.IsClosed)
          this.mSafeDevHandle.Close();
      }
      return true;
    }

    public override bool Open()
    {
      if (this.IsOpen)
        return true;
      SafeFileHandle sfhDevice;
      bool flag = WinUsbAPI.OpenDevice(out sfhDevice, this.mDevicePath);
      if (flag)
      {
        SafeWinUsbInterfaceHandle InterfaceHandle = new SafeWinUsbInterfaceHandle();
        if (flag = WinUsbAPI.WinUsb_Initialize((SafeHandle) sfhDevice, ref InterfaceHandle))
        {
          this.mSafeDevHandle = sfhDevice;
          this.mUsbHandle = (SafeHandle) InterfaceHandle;
          this.mPowerPolicies = new PowerPolicies(this);
        }
        else
          UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "Open:Initialize", (object) typeof (UsbDevice));
      }
      else
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (Open), (object) typeof (UsbDevice));
      return flag;
    }

    public static bool Open(string devicePath, out WinUsbDevice usbDevice)
    {
      usbDevice = (WinUsbDevice) null;
      SafeFileHandle sfhDevice;
      bool flag = WinUsbAPI.OpenDevice(out sfhDevice, devicePath);
      if (flag)
      {
        SafeWinUsbInterfaceHandle InterfaceHandle = new SafeWinUsbInterfaceHandle();
        flag = WinUsbAPI.WinUsb_Initialize((SafeHandle) sfhDevice, ref InterfaceHandle);
        if (flag)
          usbDevice = new WinUsbDevice((UsbApiBase) UsbDevice.WinUsbApi, sfhDevice, (SafeHandle) InterfaceHandle, devicePath);
        else
          UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "Open:Initialize", (object) typeof (UsbDevice));
      }
      else
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (Open), (object) typeof (UsbDevice));
      return flag;
    }

    public PipePolicies EndpointPolicies(ReadEndpointID epNum) => new PipePolicies(this.mUsbHandle, (byte) epNum);

    public PipePolicies EndpointPolicies(WriteEndpointID epNum) => new PipePolicies(this.mUsbHandle, (byte) epNum);

    public bool GetAssociatedInterface(byte associatedInterfaceIndex, out WinUsbDevice usbDevice)
    {
      usbDevice = (WinUsbDevice) null;
      IntPtr zero = IntPtr.Zero;
      bool associatedInterface = WinUsbAPI.WinUsb_GetAssociatedInterface(this.mUsbHandle, associatedInterfaceIndex, ref zero);
      if (associatedInterface)
      {
        SafeWinUsbInterfaceHandle handle = new SafeWinUsbInterfaceHandle(zero);
        usbDevice = new WinUsbDevice(this.mUsbApi, (SafeFileHandle) null, (SafeHandle) handle, this.mDevicePath);
      }
      if (!associatedInterface)
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (GetAssociatedInterface), (object) this);
      return associatedInterface;
    }

    public bool GetCurrentAlternateSetting(out byte settingNumber)
    {
      bool alternateSetting = WinUsbAPI.WinUsb_GetCurrentAlternateSetting(this.mUsbHandle, out settingNumber);
      if (!alternateSetting)
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (GetCurrentAlternateSetting), (object) this);
      return alternateSetting;
    }

    public bool QueryDeviceSpeed(out DeviceSpeedTypes deviceSpeed)
    {
      deviceSpeed = DeviceSpeedTypes.Undefined;
      byte[] Buffer = new byte[1];
      int BufferLength = 1;
      bool flag = WinUsbAPI.WinUsb_QueryDeviceInformation(this.mUsbHandle, DeviceInformationTypes.DeviceSpeed, ref BufferLength, (object) Buffer);
      if (flag)
        deviceSpeed = (DeviceSpeedTypes) Buffer[0];
      else
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "QueryDeviceInformation:QueryDeviceSpeed", (object) this);
      return flag;
    }

    public bool QueryInterfaceSettings(
      byte alternateInterfaceNumber,
      ref UsbInterfaceDescriptor usbAltInterfaceDescriptor)
    {
      bool flag = WinUsbAPI.WinUsb_QueryInterfaceSettings(this.Handle, alternateInterfaceNumber, usbAltInterfaceDescriptor);
      if (!flag)
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (QueryInterfaceSettings), (object) this);
      return flag;
    }

    internal bool GetPowerPolicy(PowerPolicyType policyType, ref int valueLength, IntPtr pBuffer)
    {
      bool powerPolicy = WinUsbAPI.WinUsb_GetPowerPolicy(this.mUsbHandle, policyType, ref valueLength, pBuffer);
      if (!powerPolicy)
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (GetPowerPolicy), (object) this);
      return powerPolicy;
    }

    public static bool GetDevicePathList(Guid interfaceGuid, out List<string> devicePathList) => WinUsbRegistry.GetDevicePathList(interfaceGuid, out devicePathList);

    internal bool SetPowerPolicy(PowerPolicyType policyType, int valueLength, IntPtr pBuffer)
    {
      bool flag = WinUsbAPI.WinUsb_SetPowerPolicy(this.mUsbHandle, policyType, valueLength, pBuffer);
      if (!flag)
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (SetPowerPolicy), (object) this);
      return flag;
    }

    ~WinUsbDevice() => this.Close();
  }
}
