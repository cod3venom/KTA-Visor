﻿// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceInfo.UsbDeviceInfo
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Globalization;
using System.Runtime.InteropServices;
using USBKitcs.Descriptors;
using USBKitcs.Main;
using USBKitcs.MonoLibUsb.Descriptors;

namespace USBKitcs.DeviceInfo
{
  public class UsbDeviceInfo
  {
    private const short NO_LANG = 32767;
    private readonly UsbDeviceDescriptor mDeviceDescriptor;
    private short mCurrentCultureLangID = short.MaxValue;
    private string mManufacturerString;
    private string mProductString;
    private string mSerialString;
    internal UsbDevice mUsbDevice;

    internal UsbDeviceInfo(UsbDevice usbDevice)
    {
      this.mUsbDevice = usbDevice;
      UsbDeviceInfo.GetDeviceDescriptor(this.mUsbDevice, out this.mDeviceDescriptor);
    }

    internal UsbDeviceInfo(UsbDevice usbDevice, MonoUsbDeviceDescriptor usbDeviceDescriptor)
    {
      this.mUsbDevice = usbDevice;
      this.mDeviceDescriptor = new UsbDeviceDescriptor();
      this.mDeviceDescriptor.BcdDevice = usbDeviceDescriptor.BcdDevice;
      this.mDeviceDescriptor.BcdUsb = usbDeviceDescriptor.BcdUsb;
      this.mDeviceDescriptor.Class = usbDeviceDescriptor.Class;
      this.mDeviceDescriptor.ConfigurationCount = usbDeviceDescriptor.ConfigurationCount;
      this.mDeviceDescriptor.DescriptorType = usbDeviceDescriptor.DescriptorType;
      this.mDeviceDescriptor.Length = usbDeviceDescriptor.Length;
      this.mDeviceDescriptor.ManufacturerStringIndex = usbDeviceDescriptor.ManufacturerStringIndex;
      this.mDeviceDescriptor.MaxPacketSize0 = usbDeviceDescriptor.MaxPacketSize0;
      this.mDeviceDescriptor.ProductID = usbDeviceDescriptor.ProductID;
      this.mDeviceDescriptor.ProductStringIndex = usbDeviceDescriptor.ProductStringIndex;
      this.mDeviceDescriptor.Protocol = usbDeviceDescriptor.Protocol;
      this.mDeviceDescriptor.SerialStringIndex = usbDeviceDescriptor.SerialStringIndex;
      this.mDeviceDescriptor.SubClass = usbDeviceDescriptor.SubClass;
      this.mDeviceDescriptor.VendorID = usbDeviceDescriptor.VendorID;
    }

    public UsbDeviceDescriptor Descriptor => this.mDeviceDescriptor;

    public short CurrentCultureLangID
    {
      get
      {
        if (this.mCurrentCultureLangID == short.MaxValue)
        {
          short lcid = (short) CultureInfo.CurrentCulture.LCID;
          short[] langIDs;
          if (this.mUsbDevice.GetLangIDs(out langIDs))
          {
            foreach (short num in langIDs)
            {
              if ((int) num == (int) lcid)
              {
                this.mCurrentCultureLangID = num;
                return this.mCurrentCultureLangID;
              }
            }
          }
          this.mCurrentCultureLangID = langIDs.Length != 0 ? langIDs[0] : (short) 0;
        }
        return this.mCurrentCultureLangID;
      }
    }

    public string ManufacturerString
    {
      get
      {
        if (this.mManufacturerString == null)
        {
          this.mManufacturerString = string.Empty;
          if (this.Descriptor.ManufacturerStringIndex > (byte) 0)
            this.mUsbDevice.GetString(out this.mManufacturerString, this.CurrentCultureLangID, this.Descriptor.ManufacturerStringIndex);
        }
        return this.mManufacturerString;
      }
    }

    public string ProductString
    {
      get
      {
        if (this.mProductString == null)
        {
          this.mProductString = string.Empty;
          if (this.Descriptor.ProductStringIndex > (byte) 0)
            this.mUsbDevice.GetString(out this.mProductString, this.CurrentCultureLangID, this.Descriptor.ProductStringIndex);
        }
        return this.mProductString;
      }
    }

    public string SerialString
    {
      get
      {
        if (this.mSerialString == null)
        {
          this.mSerialString = string.Empty;
          if (this.Descriptor.SerialStringIndex > (byte) 0)
            this.mUsbDevice.GetString(out this.mSerialString, (short) 1033, this.Descriptor.SerialStringIndex);
        }
        return this.mSerialString;
      }
    }

    public override string ToString() => this.ToString("", UsbDescriptor.ToStringParamValueSeperator, UsbDescriptor.ToStringFieldSeperator);

    public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
    {
      string[] names = new string[3]
      {
        "ManufacturerString",
        "ProductString",
        "SerialString"
      };
      object[] values = new object[3]
      {
        (object) this.ManufacturerString,
        (object) this.ProductString,
        (object) this.SerialString
      };
      return this.Descriptor.ToString(prefixSeperator, entitySperator, suffixSeperator) + SysOps.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
    }

    internal static bool GetDeviceDescriptor(
      UsbDevice usbDevice,
      out UsbDeviceDescriptor deviceDescriptor)
    {
      if (usbDevice.mCachedDeviceDescriptor != (UsbDeviceDescriptor) null)
      {
        deviceDescriptor = usbDevice.mCachedDeviceDescriptor;
        return true;
      }
      deviceDescriptor = new UsbDeviceDescriptor();
      GCHandle gcHandle = GCHandle.Alloc((object) deviceDescriptor, GCHandleType.Pinned);
      bool descriptor = usbDevice.GetDescriptor((byte) 1, (byte) 0, (short) 0, gcHandle.AddrOfPinnedObject(), UsbDeviceDescriptor.Size, out int _);
      gcHandle.Free();
      return descriptor;
    }
  }
}
