// Decompiled with JetBrains decompiler
// Type: USBKitcs.LibUsb.LibUsbDeviceRegistryKeyRequest
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Text;
using USBKitcs.Internal.LibUsb;
using USBKitcs.Main;

namespace USBKitcs.LibUsb
{
  internal static class LibUsbDeviceRegistryKeyRequest
  {
    public static byte[] RegGetRequest(string name, int valueBufferSize)
    {
      if (valueBufferSize < 1 || name.Trim().Length == 0)
        throw new UsbException((object) "Global", "Invalid DeviceRegistry het parameter.");
      LibUsbRequest libUsbRequest = new LibUsbRequest();
      int size = LibUsbRequest.Size;
      libUsbRequest.DeviceRegKey.KeyType = 3;
      byte[] bytes1 = Encoding.Unicode.GetBytes(name + "\0");
      libUsbRequest.DeviceRegKey.NameOffset = size;
      int num = size + bytes1.Length;
      libUsbRequest.DeviceRegKey.ValueOffset = num;
      libUsbRequest.DeviceRegKey.ValueLength = valueBufferSize;
      byte[] destinationArray = new byte[num + Math.Max(num + 1, valueBufferSize - (LibUsbRequest.Size + bytes1.Length))];
      byte[] bytes2 = libUsbRequest.Bytes;
      Array.Copy((Array) bytes2, (Array) destinationArray, bytes2.Length);
      Array.Copy((Array) bytes1, 0, (Array) destinationArray, libUsbRequest.DeviceRegKey.NameOffset, bytes1.Length);
      return destinationArray;
    }

    public static byte[] RegSetBinaryRequest(string name, byte[] value)
    {
      LibUsbRequest libUsbRequest = new LibUsbRequest();
      int size = LibUsbRequest.Size;
      libUsbRequest.DeviceRegKey.KeyType = 3;
      byte[] bytes1 = Encoding.Unicode.GetBytes(name + "\0");
      byte[] sourceArray = value;
      libUsbRequest.DeviceRegKey.NameOffset = size;
      int num = size + bytes1.Length;
      libUsbRequest.DeviceRegKey.ValueOffset = num;
      libUsbRequest.DeviceRegKey.ValueLength = sourceArray.Length;
      byte[] destinationArray = new byte[num + sourceArray.Length];
      byte[] bytes2 = libUsbRequest.Bytes;
      Array.Copy((Array) bytes2, (Array) destinationArray, bytes2.Length);
      Array.Copy((Array) bytes1, 0, (Array) destinationArray, libUsbRequest.DeviceRegKey.NameOffset, bytes1.Length);
      Array.Copy((Array) sourceArray, 0, (Array) destinationArray, libUsbRequest.DeviceRegKey.ValueOffset, sourceArray.Length);
      return destinationArray;
    }

    public static byte[] RegSetStringRequest(string name, string value)
    {
      LibUsbRequest libUsbRequest = new LibUsbRequest();
      int size = LibUsbRequest.Size;
      libUsbRequest.DeviceRegKey.KeyType = 1;
      byte[] bytes1 = Encoding.Unicode.GetBytes(name + "\0");
      byte[] bytes2 = Encoding.Unicode.GetBytes(value + "\0");
      libUsbRequest.DeviceRegKey.NameOffset = size;
      int num = size + bytes1.Length;
      libUsbRequest.DeviceRegKey.ValueOffset = num;
      libUsbRequest.DeviceRegKey.ValueLength = bytes2.Length;
      byte[] destinationArray = new byte[num + bytes2.Length];
      byte[] bytes3 = libUsbRequest.Bytes;
      Array.Copy((Array) bytes3, (Array) destinationArray, bytes3.Length);
      Array.Copy((Array) bytes1, 0, (Array) destinationArray, libUsbRequest.DeviceRegKey.NameOffset, bytes1.Length);
      Array.Copy((Array) bytes2, 0, (Array) destinationArray, libUsbRequest.DeviceRegKey.ValueOffset, bytes2.Length);
      return destinationArray;
    }

    private enum KeyType
    {
      RegSz = 1,
      RegBinary = 3,
    }
  }
}
