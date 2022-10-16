// Decompiled with JetBrains decompiler
// Type: USBKitcs.Internal.UsbApiBase
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;
using USBKitcs.Main;

namespace USBKitcs.Internal
{
  internal abstract class UsbApiBase
  {
    public abstract bool AbortPipe(SafeHandle interfaceHandle, byte pipeID);

    public abstract bool ControlTransfer(
      SafeHandle interfaceHandle,
      UsbSetupPacket setupPacket,
      IntPtr buffer,
      int bufferLength,
      out int lengthTransferred);

    public abstract bool FlushPipe(SafeHandle interfaceHandle, byte pipeID);

    public abstract bool GetDescriptor(
      SafeHandle interfaceHandle,
      byte descriptorType,
      byte index,
      ushort languageID,
      IntPtr buffer,
      int bufferLength,
      out int lengthTransferred);

    public abstract bool GetOverlappedResult(
      SafeHandle interfaceHandle,
      IntPtr pOverlapped,
      out int numberOfBytesTransferred,
      bool wait);

    public abstract bool ReadPipe(
      UsbEndpointBase endPointBase,
      IntPtr pBuffer,
      int bufferLength,
      out int lengthTransferred,
      int isoPacketSize,
      IntPtr pOverlapped);

    public abstract bool ResetPipe(SafeHandle interfaceHandle, byte pipeID);

    public abstract bool WritePipe(
      UsbEndpointBase endPointBase,
      IntPtr pBuffer,
      int bufferLength,
      out int lengthTransferred,
      int isoPacketSize,
      IntPtr pOverlapped);
  }
}
