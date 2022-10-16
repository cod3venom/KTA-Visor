// Decompiled with JetBrains decompiler
// Type: USBKitcs.LibUsb.LibUsbDevice
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using USBKitcs.DeviceInfo;
using USBKitcs.Internal;
using USBKitcs.Internal.LibUsb;
using USBKitcs.Main;

namespace USBKitcs.LibUsb
{
  public class LibUsbDevice : UsbDevice, IUsbDevice, IUsbInterface
  {
    private readonly List<int> mClaimedInterfaces = new List<int>();
    private readonly string mDeviceFilename;

    internal LibUsbDevice(UsbApiBase api, SafeHandle usbHandle, string deviceFilename)
      : base(api, usbHandle)
    {
      this.mDeviceFilename = deviceFilename;
    }

    public static List<LibUsbDevice> LegacyLibUsbDeviceList
    {
      get
      {
        List<LibUsbDevice> libUsbDeviceList = new List<LibUsbDevice>();
        for (int index = 1; index < 128; ++index)
        {
          LibUsbDevice usbDevice;
          if (LibUsbDevice.Open(LibUsbDriverIO.GetDeviceNameString(index), out usbDevice))
          {
            usbDevice.mDeviceInfo = new UsbDeviceInfo((UsbDevice) usbDevice);
            usbDevice.Close();
            libUsbDeviceList.Add(usbDevice);
          }
        }
        return libUsbDeviceList;
      }
    }

    public string DeviceFilename => this.mDeviceFilename;

    public override bool Open()
    {
      if (this.IsOpen)
        return true;
      this.mUsbHandle = (SafeHandle) LibUsbDriverIO.OpenDevice(this.mDeviceFilename);
      if (this.IsOpen)
        return true;
      UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "LibUsbDevice.Open Failed", (object) this);
      return false;
    }

    public bool ClaimInterface(int interfaceID)
    {
      if (this.mClaimedInterfaces.Contains(interfaceID))
        return true;
      bool flag = this.UsbIoSync(LibUsbIoCtl.CLAIM_INTERFACE, (object) new LibUsbRequest()
      {
        Iface = {
          ID = interfaceID
        },
        Timeout = 1000
      }, LibUsbRequest.Size, IntPtr.Zero, 0, out int _);
      if (flag)
        this.mClaimedInterfaces.Add(interfaceID);
      return flag;
    }

    public override UsbDevice.DriverModeType DriverMode => UsbDevice.DriverModeType.LibUsb;

    public override bool Close()
    {
      if (this.IsOpen)
      {
        this.ReleaseAllInterfaces();
        this.ActiveEndpoints.Clear();
        this.mUsbHandle.Close();
      }
      return true;
    }

    public bool ReleaseInterface(int interfaceID)
    {
      LibUsbRequest inBuffer = new LibUsbRequest();
      inBuffer.Iface.ID = interfaceID;
      if (!this.mClaimedInterfaces.Remove(interfaceID))
        return true;
      inBuffer.Timeout = 1000;
      return this.UsbIoSync(LibUsbIoCtl.RELEASE_INTERFACE, (object) inBuffer, LibUsbRequest.Size, IntPtr.Zero, 0, out int _);
    }

    public bool SetAltInterface(int alternateID)
    {
      if (this.mClaimedInterfaces.Count == 0)
        throw new UsbException((object) this, "You must claim an interface before setting an alternate interface.");
      return this.SetAltInterface(this.mClaimedInterfaces[this.mClaimedInterfaces.Count - 1], alternateID);
    }

    public bool SetConfiguration(byte config)
    {
            bool flag = false;
      if (flag)
        this.mCurrentConfigValue = (int) config;
      else
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (SetConfiguration), (object) this);
      return flag;
    }

    public static bool Open(string deviceFilename, out LibUsbDevice usbDevice)
    {
      usbDevice = (LibUsbDevice) null;
      SafeFileHandle usbHandle = LibUsbDriverIO.OpenDevice(deviceFilename);
      if (usbHandle.IsClosed || usbHandle.IsInvalid)
        return false;
      usbDevice = new LibUsbDevice((UsbApiBase) UsbDevice.LibUsbApi, (SafeHandle) usbHandle, deviceFilename);
      return true;
    }

    public int ReleaseAllInterfaces()
    {
      int num = 0;
      while (this.mClaimedInterfaces.Count > 0)
      {
        ++num;
        this.ReleaseInterface(this.mClaimedInterfaces[this.mClaimedInterfaces.Count - num]);
      }
      return num;
    }

    public bool ReleaseInterface() => this.mClaimedInterfaces.Count == 0 || this.ReleaseInterface(this.mClaimedInterfaces[this.mClaimedInterfaces.Count - 1]);

    public bool SetAltInterface(int interfaceID, int alternateID)
    {
      if (!this.mClaimedInterfaces.Contains(interfaceID))
        throw new UsbException((object) this, string.Format("You must claim interface {0} before setting an alternate interface.", (object) interfaceID));
      return this.UsbIoSync(LibUsbIoCtl.SET_INTERFACE, (object) new LibUsbRequest()
      {
        Iface = {
          ID = interfaceID,
          AlternateID = alternateID
        },
        Timeout = 1000
      }, LibUsbRequest.Size, IntPtr.Zero, 0, out int _);
    }

    public bool ResetDevice()
    {
      if (!this.IsOpen)
        throw new UsbException((object) this, "Device is not opened.");
      this.ActiveEndpoints.Clear();
      bool flag;
      if (!(flag = UsbDevice.LibUsbApi.ResetDevice(this.mUsbHandle)))
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "ResetDevice Failed", (object) this);
      else
        this.Close();
      return flag;
    }

    internal bool ControlTransferEx(
      UsbSetupPacket setupPacket,
      IntPtr buffer,
      int bufferLength,
      out int lengthTransferred,
      int timeout)
    {
      return LibUsbDriverIO.ControlTransferEx(this.mUsbHandle, setupPacket, buffer, bufferLength, out lengthTransferred, timeout);
    }

    internal bool UsbIoSync(
      int controlCode,
      object inBuffer,
      int inSize,
      IntPtr outBuffer,
      int outSize,
      out int ret)
    {
      return LibUsbDriverIO.UsbIOSync(this.mUsbHandle, controlCode, inBuffer, inSize, outBuffer, outSize, out ret);
    }
  }
}
