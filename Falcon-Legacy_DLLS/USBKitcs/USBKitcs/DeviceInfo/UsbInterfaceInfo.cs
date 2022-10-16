// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceInfo.UsbInterfaceInfo
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using USBKitcs.Descriptors;
using USBKitcs.Main;
using USBKitcs.MonoLibUsb.Descriptors;

namespace USBKitcs.DeviceInfo
{
  public class UsbInterfaceInfo : UsbBaseInfo
  {
    internal readonly UsbInterfaceDescriptor mUsbInterfaceDescriptor;
    internal List<UsbEndpointInfo> mEndpointInfo = new List<UsbEndpointInfo>();
    private string mInterfaceString;
    internal UsbDevice mUsbDevice;

    internal UsbInterfaceInfo(UsbDevice usbDevice, byte[] descriptor)
    {
      this.mUsbDevice = usbDevice;
      this.mUsbInterfaceDescriptor = new UsbInterfaceDescriptor();
      SysOps.BytesToObject(descriptor, 0, Math.Min(UsbInterfaceDescriptor.Size, (int) descriptor[0]), (object) this.mUsbInterfaceDescriptor);
    }

    internal UsbInterfaceInfo(
      UsbDevice usbDevice,
      MonoUsbAltInterfaceDescriptor monoUSBAltInterfaceDescriptor)
    {
      this.mUsbDevice = usbDevice;
      this.mUsbInterfaceDescriptor = new UsbInterfaceDescriptor(monoUSBAltInterfaceDescriptor);
      foreach (MonoUsbEndpointDescriptor endpoint in monoUSBAltInterfaceDescriptor.EndpointList)
        this.mEndpointInfo.Add(new UsbEndpointInfo(endpoint));
    }

    public UsbInterfaceDescriptor Descriptor => this.mUsbInterfaceDescriptor;

    public ReadOnlyCollection<UsbEndpointInfo> EndpointInfoList => this.mEndpointInfo.AsReadOnly();

    public string InterfaceString
    {
      get
      {
        if (this.mInterfaceString == null)
        {
          this.mInterfaceString = string.Empty;
          if (this.Descriptor.StringIndex > (byte) 0)
            this.mUsbDevice.GetString(out this.mInterfaceString, this.mUsbDevice.Info.CurrentCultureLangID, this.Descriptor.StringIndex);
        }
        return this.mInterfaceString;
      }
    }

    public override string ToString() => this.ToString("", UsbDescriptor.ToStringParamValueSeperator, UsbDescriptor.ToStringFieldSeperator);

    public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
    {
      object[] values = new object[1]
      {
        (object) this.InterfaceString
      };
      string[] names = new string[1]{ "InterfaceString" };
      return this.Descriptor.ToString(prefixSeperator, entitySperator, suffixSeperator) + SysOps.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
    }
  }
}
