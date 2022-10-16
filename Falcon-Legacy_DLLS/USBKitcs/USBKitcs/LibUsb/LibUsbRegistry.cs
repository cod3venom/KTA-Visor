// Decompiled with JetBrains decompiler
// Type: USBKitcs.LibUsb.LibUsbRegistry
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using USBKitcs.Internal;
using USBKitcs.Internal.LibUsb;
using USBKitcs.Main;

namespace USBKitcs.LibUsb
{
  public class LibUsbRegistry : UsbRegistry
  {
    private readonly string mDeviceFilename;
    private readonly int mDeviceIndex;

    private LibUsbRegistry(SafeFileHandle usbHandle, string deviceFileName, int deviceIndex)
    {
      this.mDeviceFilename = deviceFileName;
      this.mDeviceIndex = deviceIndex;
      this.GetPropertiesSPDRP((SafeHandle) usbHandle);
      string propData1;
      if (this.GetCustomDeviceKeyValue(usbHandle, "SymbolicName", out propData1, 512) == ErrorCode.None)
        this.mDeviceProperties.Add("SymbolicName", (object) propData1);
      if (!this.mDeviceProperties.ContainsKey("SymbolicName") || string.IsNullOrEmpty(propData1))
      {
        if (!(this.mDeviceProperties[SPDRP.HardwareId.ToString()] is string[] mDeviceProperty) || mDeviceProperty.Length == 0)
        {
          LegacyUsbRegistry.GetPropertiesSPDRP((UsbDevice) new LibUsbDevice((UsbApiBase) UsbDevice.LibUsbApi, (SafeHandle) usbHandle, deviceFileName), this.mDeviceProperties);
          return;
        }
        if (mDeviceProperty.Length != 0)
          this.mDeviceProperties.Add("SymbolicName", (object) mDeviceProperty[0]);
      }
      string propData2;
      if (this.GetCustomDeviceKeyValue(usbHandle, "LibUsbInterfaceGUIDs", out propData2, 512) != ErrorCode.None)
        return;
      this.mDeviceProperties.Add("LibUsbInterfaceGUIDs", (object) propData2.Split(new char[1], StringSplitOptions.RemoveEmptyEntries));
    }

    public int DeviceIndex => this.mDeviceIndex;

    public static List<LibUsbRegistry> DeviceList
    {
      get
      {
        List<LibUsbRegistry> deviceList = new List<LibUsbRegistry>();
        for (int index = 1; index < 128; ++index)
        {
          string deviceNameString = LibUsbDriverIO.GetDeviceNameString(index);
          SafeFileHandle usbHandle = LibUsbDriverIO.OpenDevice(deviceNameString);
          if (usbHandle != null && !usbHandle.IsInvalid && !usbHandle.IsClosed)
          {
            try
            {
              LibUsbRegistry libUsbRegistry = new LibUsbRegistry(usbHandle, deviceNameString, index);
              deviceList.Add(libUsbRegistry);
            }
            catch (Exception ex)
            {
              System.Diagnostics.Debug.Print(ex.Message);
            }
          }
          if (usbHandle != null && !usbHandle.IsClosed)
            usbHandle.Close();
        }
        return deviceList;
      }
    }

    public override bool IsAlive
    {
      get
      {
        if (string.IsNullOrEmpty(this.SymbolicName))
          throw new UsbException((object) this, "A symbolic name is required for this property.");
        foreach (LibUsbRegistry device in LibUsbRegistry.DeviceList)
        {
          if (!string.IsNullOrEmpty(device.SymbolicName) && device.SymbolicName == this.SymbolicName)
            return true;
        }
        return false;
      }
    }

    public override UsbDevice Device
    {
      get
      {
        LibUsbDevice usbDevice;
        this.Open(out usbDevice);
        return (UsbDevice) usbDevice;
      }
    }

    public override Guid[] DeviceInterfaceGuids
    {
      get
      {
        if (this.mDeviceInterfaceGuids == null)
        {
          if (!this.mDeviceProperties.ContainsKey("LibUsbInterfaceGUIDs"))
            return new Guid[0];
          if (!(this.mDeviceProperties["LibUsbInterfaceGUIDs"] is string[] mDeviceProperty))
            return new Guid[0];
          this.mDeviceInterfaceGuids = new Guid[mDeviceProperty.Length];
          for (int index = 0; index < mDeviceProperty.Length; ++index)
          {
            string g = mDeviceProperty[index].Trim(' ', '{', '}', '[', ']', char.MinValue);
            this.mDeviceInterfaceGuids[index] = new Guid(g);
          }
        }
        return this.mDeviceInterfaceGuids;
      }
    }

    public bool Open(out LibUsbDevice usbDevice)
    {
      bool flag = LibUsbDevice.Open(this.mDeviceFilename, out usbDevice);
      if (flag)
        usbDevice.mUsbRegistry = (UsbRegistry) this;
      return flag;
    }

    public override bool Open(out UsbDevice usbDevice)
    {
      usbDevice = (UsbDevice) null;
      LibUsbDevice usbDevice1;
      bool flag = this.Open(out usbDevice1);
      if (flag)
        usbDevice = (UsbDevice) usbDevice1;
      return flag;
    }

    internal ErrorCode GetCustomDeviceKeyValue(
      SafeFileHandle usbHandle,
      string key,
      out string propData,
      int maxDataLength)
    {
      byte[] propData1;
      ErrorCode customDeviceKeyValue = this.GetCustomDeviceKeyValue(usbHandle, key, out propData1, maxDataLength);
      if (customDeviceKeyValue == ErrorCode.None)
      {
        propData = Encoding.Unicode.GetString(propData1);
        propData.TrimEnd(new char[1]);
      }
      else
        propData = (string) null;
      return customDeviceKeyValue;
    }

    internal ErrorCode GetCustomDeviceKeyValue(
      SafeFileHandle usbHandle,
      string key,
      out byte[] propData,
      int maxDataLength)
    {
      ErrorCode customDeviceKeyValue = ErrorCode.None;
      propData = (byte[]) null;
      byte[] request = LibUsbDeviceRegistryKeyRequest.RegGetRequest(key, maxDataLength);
      GCHandle gcHandle = GCHandle.Alloc((object) request, GCHandleType.Pinned);
      int ret;
      bool flag = LibUsbDriverIO.UsbIOSync((SafeHandle) usbHandle, LibUsbIoCtl.GET_CUSTOM_REG_PROPERTY, (object) request, request.Length, gcHandle.AddrOfPinnedObject(), request.Length, out ret);
      gcHandle.Free();
      if (flag)
      {
        propData = new byte[ret];
        Array.Copy((Array) request, (Array) propData, ret);
      }
      else
        customDeviceKeyValue = ErrorCode.GetDeviceKeyValueFailed;
      return customDeviceKeyValue;
    }

    private void GetPropertiesSPDRP(SafeHandle usbHandle)
    {
      byte[] buffer = new byte[1024];
      GCHandle gcHandle = GCHandle.Alloc((object) buffer, GCHandleType.Pinned);
      LibUsbRequest inBuffer = new LibUsbRequest();
      foreach (KeyValuePair<string, int> keyValuePair in SysOps.GetEnumData(typeof (DevicePropertyType)))
      {
        object obj = (object) string.Empty;
        inBuffer.DeviceProperty.ID = keyValuePair.Value;
        int ret;
        if (LibUsbDriverIO.UsbIOSync(usbHandle, LibUsbIoCtl.GET_REG_PROPERTY, (object) inBuffer, LibUsbRequest.Size, gcHandle.AddrOfPinnedObject(), buffer.Length, out ret))
        {
          switch (keyValuePair.Value)
          {
            case 0:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 15:
              obj = (object) UsbRegistry.GetAsString(buffer, ret);
              break;
            case 1:
            case 2:
              obj = (object) UsbRegistry.GetAsStringArray(buffer, ret);
              break;
            case 12:
              obj = (object) UsbRegistry.GetAsGuid(buffer, ret);
              break;
            case 13:
            case 14:
            case 16:
            case 17:
            case 18:
            case 19:
              obj = (object) UsbRegistry.GetAsStringInt32(buffer, ret);
              break;
          }
        }
        else
          obj = (object) string.Empty;
        this.mDeviceProperties.Add(keyValuePair.Key, obj);
      }
      gcHandle.Free();
    }
  }
}
