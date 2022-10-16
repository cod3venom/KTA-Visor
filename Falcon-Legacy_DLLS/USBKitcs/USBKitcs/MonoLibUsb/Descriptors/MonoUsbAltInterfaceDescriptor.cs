// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Descriptors.MonoUsbAltInterfaceDescriptor
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using USBKitcs.Descriptors;

namespace USBKitcs.MonoLibUsb.Descriptors
{
  [StructLayout(LayoutKind.Sequential)]
  public class MonoUsbAltInterfaceDescriptor
  {
    public readonly byte bLength;
    public readonly DescriptorType bDescriptorType;
    public readonly byte bInterfaceNumber;
    public readonly byte bAlternateSetting;
    public readonly byte bNumEndpoints;
    public readonly ClassCodeType bInterfaceClass;
    public readonly byte bInterfaceSubClass;
    public readonly byte bInterfaceProtocol;
    public readonly byte iInterface;
    private readonly IntPtr pEndpointDescriptors;
    private IntPtr pExtraBytes;
    public readonly int ExtraLength;

    public byte[] ExtraBytes
    {
      get
      {
        byte[] destination = new byte[this.ExtraLength];
        Marshal.Copy(this.pExtraBytes, destination, 0, destination.Length);
        return destination;
      }
    }

    public List<MonoUsbEndpointDescriptor> EndpointList
    {
      get
      {
        List<MonoUsbEndpointDescriptor> endpointList = new List<MonoUsbEndpointDescriptor>();
        for (int index = 0; index < (int) this.bNumEndpoints; ++index)
        {
          IntPtr ptr = new IntPtr(this.pEndpointDescriptors.ToInt64() + (long) (Marshal.SizeOf(typeof (MonoUsbEndpointDescriptor)) * index));
          MonoUsbEndpointDescriptor structure = new MonoUsbEndpointDescriptor();
          Marshal.PtrToStructure<MonoUsbEndpointDescriptor>(ptr, structure);
          endpointList.Add(structure);
        }
        return endpointList;
      }
    }
  }
}
