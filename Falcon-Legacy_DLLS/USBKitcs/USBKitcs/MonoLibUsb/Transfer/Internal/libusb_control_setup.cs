// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Transfer.Internal.libusb_control_setup
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;

namespace USBKitcs.MonoLibUsb.Transfer.Internal
{
  [StructLayout(LayoutKind.Sequential)]
  internal class libusb_control_setup
  {
    public readonly byte bmRequestType;
    public readonly byte bRequest;
    public readonly short wValue;
    public readonly short wIndex;
    public readonly short wLength;
  }
}
