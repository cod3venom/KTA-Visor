// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceInfo.UsbConfigInfo
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;
using USBKitcs.Descriptors;
using USBKitcs.LudnMonoLibUsb;
using USBKitcs.Main;
using USBKitcs.MonoLibUsb.Descriptors;

namespace USBKitcs.DeviceInfo
{
  public class UsbConfigInfo : UsbBaseInfo
  {
    private readonly List<UsbInterfaceInfo> mInterfaceList = new List<UsbInterfaceInfo>();
    internal readonly UsbConfigDescriptor mUsbConfigDescriptor;
    private string mConfigString;
    internal UsbDevice mUsbDevice;

    internal UsbConfigInfo(
      UsbDevice usbDevice,
      UsbConfigDescriptor descriptor,
      ref List<byte[]> rawDescriptors)
    {
      this.mUsbDevice = usbDevice;
      this.mUsbConfigDescriptor = descriptor;
      this.mRawDescriptors = rawDescriptors;
      UsbInterfaceInfo usbInterfaceInfo = (UsbInterfaceInfo) null;
      for (int index = 0; index < rawDescriptors.Count; ++index)
      {
        byte[] descriptor1 = rawDescriptors[index];
        switch (descriptor1[1])
        {
          case 4:
            usbInterfaceInfo = new UsbInterfaceInfo(usbDevice, descriptor1);
            this.mRawDescriptors.RemoveAt(index);
            this.mInterfaceList.Add(usbInterfaceInfo);
            --index;
            break;
          case 5:
            if (usbInterfaceInfo == null)
              throw new UsbException((object) this, "Recieved and endpoint descriptor before receiving an interface descriptor.");
            usbInterfaceInfo.mEndpointInfo.Add(new UsbEndpointInfo(descriptor1));
            this.mRawDescriptors.RemoveAt(index);
            --index;
            break;
          default:
            if (usbInterfaceInfo != null)
            {
              usbInterfaceInfo.mRawDescriptors.Add(descriptor1);
              this.mRawDescriptors.RemoveAt(index);
              --index;
              break;
            }
            break;
        }
      }
    }

    internal UsbConfigInfo(MonoUsbDevice usbDevice, MonoUsbConfigDescriptor configDescriptor)
    {
      this.mUsbDevice = (UsbDevice) usbDevice;
      this.mUsbConfigDescriptor = new UsbConfigDescriptor(configDescriptor);
      foreach (MonoUsbInterface monoUsbInterface in configDescriptor.InterfaceList)
      {
        foreach (MonoUsbAltInterfaceDescriptor altInterface in monoUsbInterface.AltInterfaceList)
          this.mInterfaceList.Add(new UsbInterfaceInfo(this.mUsbDevice, altInterface));
      }
    }

    public UsbConfigDescriptor Descriptor => this.mUsbConfigDescriptor;

    public string ConfigString
    {
      get
      {
        if (this.mConfigString == null)
        {
          this.mConfigString = string.Empty;
          if (this.Descriptor.StringIndex > (byte) 0)
            this.mUsbDevice.GetString(out this.mConfigString, this.mUsbDevice.Info.CurrentCultureLangID, this.Descriptor.StringIndex);
        }
        return this.mConfigString;
      }
    }

    public ReadOnlyCollection<UsbInterfaceInfo> InterfaceInfoList => this.mInterfaceList.AsReadOnly();

    public override string ToString() => this.ToString("", UsbDescriptor.ToStringParamValueSeperator, UsbDescriptor.ToStringFieldSeperator);

    public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
    {
      object[] values = new object[1]
      {
        (object) this.ConfigString
      };
      string[] names = new string[1]{ "ConfigString" };
      return this.Descriptor.ToString(prefixSeperator, entitySperator, suffixSeperator) + SysOps.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
    }
  }
}
