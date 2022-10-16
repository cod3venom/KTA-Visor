// Decompiled with JetBrains decompiler
// Type: USBKitcs.IUsbInterface
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Collections.ObjectModel;
using USBKitcs.DeviceInfo;
using USBKitcs.Main;

namespace USBKitcs
{
  public interface IUsbInterface
  {
    UsbEndpointList ActiveEndpoints { get; }

    ReadOnlyCollection<UsbConfigInfo> Configs { get; }

    UsbDevice.DriverModeType DriverMode { get; }

    UsbDeviceInfo Info { get; }

    bool IsOpen { get; }

    UsbRegistry UsbRegistryInfo { get; }

    bool Close();

    bool ControlTransfer(
      ref UsbSetupPacket setupPacket,
      IntPtr buffer,
      int bufferLength,
      out int lengthTransferred);

    bool ControlTransfer(
      ref UsbSetupPacket setupPacket,
      object buffer,
      int bufferLength,
      out int lengthTransferred);

    bool GetDescriptor(
      byte descriptorType,
      byte index,
      short langId,
      IntPtr buffer,
      int bufferLength,
      out int transferLength);

    bool GetDescriptor(
      byte descriptorType,
      byte index,
      short langId,
      object buffer,
      int bufferLength,
      out int transferLength);

    bool GetLangIDs(out short[] langIDs);

    bool GetString(out string stringData, short langId, byte stringIndex);

    bool Open();

    UsbEndpointReader OpenEndpointReader(
      ReadEndpointID readEndpointID,
      int readBufferSize);

    UsbEndpointReader OpenEndpointReader(
      ReadEndpointID readEndpointID,
      int readBufferSize,
      EndpointType endpointType);

    UsbEndpointReader OpenEndpointReader(ReadEndpointID readEndpointID);

    UsbEndpointWriter OpenEndpointWriter(WriteEndpointID writeEndpointID);

    UsbEndpointWriter OpenEndpointWriter(
      WriteEndpointID writeEndpointID,
      EndpointType endpointType);
  }
}
