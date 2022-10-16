// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Descriptors.MonoUsbConfigDescriptor
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using USBKitcs.Descriptors;
using USBKitcs.MonoLibUsb.Profile;

namespace USBKitcs.MonoLibUsb.Descriptors
{
  [StructLayout(LayoutKind.Sequential)]
  public class MonoUsbConfigDescriptor
  {
    public readonly byte bLength;
    public readonly DescriptorType bDescriptorType;
    public readonly short wTotalLength;
    public readonly byte bNumInterfaces;
    public readonly byte bConfigurationValue;
    public readonly byte iConfiguration;
    public readonly byte bmAttributes;
    public readonly byte MaxPower;
    private readonly IntPtr pInterfaces;
    private readonly IntPtr pExtraBytes;
    public readonly int ExtraLength;

    internal MonoUsbConfigDescriptor()
    {
    }

    public MonoUsbConfigDescriptor(MonoUsbConfigHandle configHandle) => Marshal.PtrToStructure<MonoUsbConfigDescriptor>(configHandle.DangerousGetHandle(), this);

    public byte[] ExtraBytes
    {
      get
      {
        byte[] destination = new byte[this.ExtraLength];
        Marshal.Copy(this.pExtraBytes, destination, 0, destination.Length);
        return destination;
      }
    }

    public List<MonoUsbInterface> InterfaceList
    {
      get
      {
        List<MonoUsbInterface> interfaceList = new List<MonoUsbInterface>();
        for (int index = 0; index < (int) this.bNumInterfaces; ++index)
        {
          IntPtr ptr = new IntPtr(this.pInterfaces.ToInt64() + (long) (Marshal.SizeOf(typeof (MonoUsbInterface)) * index));
          MonoUsbInterface structure = new MonoUsbInterface();
          Marshal.PtrToStructure<MonoUsbInterface>(ptr, structure);
          interfaceList.Add(structure);
        }
        return interfaceList;
      }
    }
  }
}
