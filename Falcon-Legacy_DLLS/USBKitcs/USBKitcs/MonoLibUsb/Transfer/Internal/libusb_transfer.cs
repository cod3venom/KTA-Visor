// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Transfer.Internal.libusb_transfer
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;
using USBKitcs.Main;

namespace USBKitcs.MonoLibUsb.Transfer.Internal
{
  [StructLayout(LayoutKind.Sequential)]
  internal class libusb_transfer
  {
    private IntPtr deviceHandle;
    private MonoUsbTransferFlags flags;
    private byte endpoint;
    private EndpointType type;
    private uint timeout;
    private MonoUsbTansferStatus status;
    private int length;
    private int actual_length;
    private IntPtr pCallbackFn;
    private IntPtr pUserData;
    private IntPtr pBuffer;
    private int num_iso_packets;
    private IntPtr iso_packets;

    private libusb_transfer()
    {
    }
  }
}
