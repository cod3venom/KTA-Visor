// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Transfer.Internal.libusb_iso_packet_descriptor
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;

namespace USBKitcs.MonoLibUsb.Transfer.Internal
{
  [StructLayout(LayoutKind.Sequential)]
  internal class libusb_iso_packet_descriptor
  {
    private uint length;
    private uint actual_length;
    private MonoUsbTansferStatus status;

    private libusb_iso_packet_descriptor()
    {
    }
  }
}
