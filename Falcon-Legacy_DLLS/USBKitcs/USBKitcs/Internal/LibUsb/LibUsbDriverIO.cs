// Decompiled with JetBrains decompiler
// Type: USBKitcs.Internal.LibUsb.LibUsbDriverIO
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using USBKitcs.Main;

namespace USBKitcs.Internal.LibUsb
{
  internal class LibUsbDriverIO
  {
    public const int ERROR_IO_PENDING = 997;
    public const int FALSE = 0;
    public const int FILE_FLAG_OVERLAPPED = 1073741824;
    internal const string LIBUSB_DEVICE_NAME = "\\\\.\\libusb0-";
    public const int TRUE = 1;
    private static byte[] _tempCfgBuf;
    public const int EINVAL = 22;

    internal static byte[] GlobalTempCfgBuffer
    {
      get
      {
        if (LibUsbDriverIO._tempCfgBuf == null)
          LibUsbDriverIO._tempCfgBuf = new byte[4096];
        return LibUsbDriverIO._tempCfgBuf;
      }
    }

    internal static string GetDeviceNameString(int index) => string.Format("{0}{1}", (object) "\\\\.\\libusb0-", (object) index.ToString("0000"));

    internal static SafeFileHandle OpenDevice(string deviceFileName) => Kernel32.CreateFile(deviceFileName, NativeFileAccess.FILE_SPECIAL, NativeFileShare.NONE, IntPtr.Zero, NativeFileMode.OPEN_EXISTING, NativeFileFlag.FILE_FLAG_OVERLAPPED, IntPtr.Zero);

    internal static bool UsbIOSync(
      SafeHandle dev,
      int code,
      object inBuffer,
      int inSize,
      IntPtr outBuffer,
      int outSize,
      out int ret)
    {
      SafeOverlapped safeOverlapped = new SafeOverlapped();
      ManualResetEvent manualResetEvent = new ManualResetEvent(false);
      safeOverlapped.ClearAndSetEvent(manualResetEvent.SafeWaitHandle.DangerousGetHandle());
      ret = 0;
      if (!Kernel32.DeviceIoControlAsObject(dev, code, inBuffer, inSize, outBuffer, outSize, ref ret, safeOverlapped.GlobalOverlapped))
      {
        int lastWin32Error = Marshal.GetLastWin32Error();
        if (lastWin32Error != 997)
        {
          if (code != LibUsbIoCtl.GET_REG_PROPERTY && code != LibUsbIoCtl.GET_CUSTOM_REG_PROPERTY)
            UsbError.Error(ErrorCode.Win32Error, lastWin32Error, string.Format("DeviceIoControl code {0:X8} failed:{1}", (object) code, (object) Kernel32.FormatSystemMessage(lastWin32Error)), (object) typeof (LibUsbDriverIO));
          manualResetEvent.Close();
          return false;
        }
      }
      if (Kernel32.GetOverlappedResult(dev, safeOverlapped.GlobalOverlapped, out ret, true))
      {
        manualResetEvent.Close();
        return true;
      }
      UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "GetOverlappedResult failed.\nIoCtlCode:" + (object) code, (object) typeof (LibUsbDriverIO));
      manualResetEvent.Close();
      return false;
    }

    internal static bool ControlTransferEx(
      SafeHandle interfaceHandle,
      UsbSetupPacket setupPacket,
      IntPtr buffer,
      int bufferLength,
      out int lengthTransferred,
      int timeout)
    {
      lengthTransferred = 0;
      byte[] bytes = new LibUsbRequest()
      {
        Timeout = timeout,
        Control = {
          RequestType = setupPacket.RequestType,
          Request = setupPacket.Request,
          Value = ((ushort) setupPacket.Value),
          Index = ((ushort) setupPacket.Index),
          Length = ((ushort) setupPacket.Length)
        }
      }.Bytes;
      byte[] numArray = bytes;
      if (((int) setupPacket.RequestType & 128) == 0)
      {
        numArray = new byte[LibUsbRequest.Size + bufferLength];
        bytes.CopyTo((Array) numArray, 0);
        if (buffer != IntPtr.Zero)
          Marshal.Copy(buffer, numArray, LibUsbRequest.Size, bufferLength);
        buffer = IntPtr.Zero;
        bufferLength = 0;
      }
      if (!LibUsbDriverIO.UsbIOSync(interfaceHandle, LibUsbIoCtl.CONTROL_TRANSFER, (object) numArray, numArray.Length, buffer, bufferLength, out lengthTransferred))
        return false;
      if (((int) setupPacket.RequestType & 128) == 0)
        lengthTransferred = numArray.Length - bytes.Length;
      return true;
    }

    internal static bool ControlTransfer(
      SafeHandle interfaceHandle,
      UsbSetupPacket setupPacket,
      IntPtr buffer,
      int bufferLength,
      out int lengthTransferred,
      int timeout)
    {
      lengthTransferred = 0;
      LibUsbRequest libUsbRequest = new LibUsbRequest();
      libUsbRequest.Timeout = timeout;
      UsbRequestType usbRequestType = (UsbRequestType) ((uint) setupPacket.RequestType & 96U);
      int code;
      if ((uint) usbRequestType <= 32U)
      {
        switch (usbRequestType)
        {
          case UsbRequestType.TypeStandard:
            switch (setupPacket.Request)
            {
              case 0:
                libUsbRequest.Status.Recipient = (int) setupPacket.RequestType & 31;
                libUsbRequest.Status.Index = (int) setupPacket.Index;
                code = LibUsbIoCtl.GET_STATUS;
                goto label_17;
              case 1:
                libUsbRequest.Feature.Recipient = (int) setupPacket.RequestType & 31;
                libUsbRequest.Feature.ID = (int) setupPacket.Value;
                libUsbRequest.Feature.Index = (int) setupPacket.Index;
                code = LibUsbIoCtl.CLEAR_FEATURE;
                goto label_17;
              case 3:
                libUsbRequest.Feature.Recipient = (int) setupPacket.RequestType & 31;
                libUsbRequest.Feature.ID = (int) setupPacket.Value;
                libUsbRequest.Feature.Index = (int) setupPacket.Index;
                code = LibUsbIoCtl.SET_FEATURE;
                goto label_17;
              case 6:
                libUsbRequest.Descriptor.Recipient = (int) setupPacket.RequestType & 31;
                libUsbRequest.Descriptor.Type = (int) setupPacket.Value >> 8 & (int) byte.MaxValue;
                libUsbRequest.Descriptor.Index = (int) setupPacket.Value & (int) byte.MaxValue;
                libUsbRequest.Descriptor.LangID = (int) setupPacket.Index;
                code = LibUsbIoCtl.GET_DESCRIPTOR;
                goto label_17;
              case 7:
                libUsbRequest.Descriptor.Recipient = (int) setupPacket.RequestType & 31;
                libUsbRequest.Descriptor.Type = (int) setupPacket.Value >> 8 & (int) byte.MaxValue;
                libUsbRequest.Descriptor.Index = (int) setupPacket.Value & (int) byte.MaxValue;
                libUsbRequest.Descriptor.LangID = (int) setupPacket.Index;
                code = LibUsbIoCtl.SET_DESCRIPTOR;
                goto label_17;
              case 8:
                code = LibUsbIoCtl.GET_CONFIGURATION;
                goto label_17;
              case 9:
                libUsbRequest.Config.ID = (int) setupPacket.Value;
                code = LibUsbIoCtl.SET_CONFIGURATION;
                goto label_17;
              case 10:
                libUsbRequest.Iface.ID = (int) setupPacket.Index;
                code = LibUsbIoCtl.GET_INTERFACE;
                goto label_17;
              case 11:
                libUsbRequest.Iface.ID = (int) setupPacket.Index;
                libUsbRequest.Iface.AlternateID = (int) setupPacket.Value;
                code = LibUsbIoCtl.SET_INTERFACE;
                goto label_17;
              default:
                UsbError.Error(ErrorCode.IoControlMessage, 0, string.Format("Invalid request: 0x{0:X8}", (object) setupPacket.Request), (object) typeof (LibUsbDriverIO));
                return false;
            }
          case UsbRequestType.TypeClass:
            break;
          default:
            goto label_16;
        }
      }
      else if (usbRequestType != UsbRequestType.TypeVendor)
      {
        if (usbRequestType == UsbRequestType.TypeReserved)
          goto label_16;
        else
          goto label_16;
      }
      libUsbRequest.Vendor.Type = (int) setupPacket.RequestType >> 5 & 3;
      libUsbRequest.Vendor.Recipient = (int) setupPacket.RequestType & 31;
      libUsbRequest.Vendor.Request = (int) setupPacket.Request;
      libUsbRequest.Vendor.ID = (int) setupPacket.Value;
      libUsbRequest.Vendor.Index = (int) setupPacket.Index;
      code = ((int) setupPacket.RequestType & 128) > 0 ? LibUsbIoCtl.VENDOR_READ : LibUsbIoCtl.VENDOR_WRITE;
      goto label_17;
label_16:
      UsbError.Error(ErrorCode.IoControlMessage, 0, string.Format("invalid or unsupported request type: 0x{0:X8}", (object) setupPacket.RequestType), (object) typeof (LibUsbDriverIO));
      return false;
label_17:
      byte[] bytes = libUsbRequest.Bytes;
      byte[] numArray = bytes;
      if (((int) setupPacket.RequestType & 128) == 0)
      {
        numArray = new byte[LibUsbRequest.Size + bufferLength];
        bytes.CopyTo((Array) numArray, 0);
        if (buffer != IntPtr.Zero)
          Marshal.Copy(buffer, numArray, LibUsbRequest.Size, bufferLength);
        buffer = IntPtr.Zero;
        bufferLength = 0;
      }
      if (!LibUsbDriverIO.UsbIOSync(interfaceHandle, code, (object) numArray, numArray.Length, buffer, bufferLength, out lengthTransferred))
        return false;
      if (((int) setupPacket.RequestType & 128) == 0)
        lengthTransferred = numArray.Length - bytes.Length;
      return true;
    }
  }
}
