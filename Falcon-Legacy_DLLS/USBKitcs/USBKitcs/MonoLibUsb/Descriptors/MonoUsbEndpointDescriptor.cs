// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Descriptors.MonoUsbEndpointDescriptor
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;
using USBKitcs.Descriptors;

namespace USBKitcs.MonoLibUsb.Descriptors
{
  [StructLayout(LayoutKind.Sequential)]
  public class MonoUsbEndpointDescriptor
  {
    public readonly byte bLength;
    public readonly DescriptorType bDescriptorType;
    public readonly byte bEndpointAddress;
    public readonly byte bmAttributes;
    public readonly short wMaxPacketSize;
    public readonly byte bInterval;
    public readonly byte bRefresh;
    public readonly byte bSynchAddress;
    private readonly IntPtr pExtraBytes;
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
  }
}
