﻿// Decompiled with JetBrains decompiler
// Type: USBKitcs.WinUsb.Internal.WinUsbAPI
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Security;
using USBKitcs.Descriptors;
using USBKitcs.Internal;
using USBKitcs.Internal.WinUsb;
using USBKitcs.Main;

namespace USBKitcs.WinUsb.Internal
{
  [SuppressUnmanagedCodeSecurity]
  internal class WinUsbAPI : UsbApiBase
  {
    internal const string WIN_USB_DLL = "winusb.dll";

    [DllImport("winusb.dll", SetLastError = true)]
    private static extern bool WinUsb_AbortPipe([In] SafeHandle InterfaceHandle, byte PipeID);

    [DllImport("winusb.dll", SetLastError = true)]
    private static extern bool WinUsb_ControlTransfer(
      [In] SafeHandle InterfaceHandle,
      [In] UsbSetupPacket SetupPacket,
      IntPtr Buffer,
      int BufferLength,
      out int LengthTransferred,
      IntPtr pOVERLAPPED);

    [DllImport("winusb.dll", SetLastError = true)]
    private static extern bool WinUsb_FlushPipe([In] SafeHandle InterfaceHandle, byte PipeID);

    [DllImport("winusb.dll", SetLastError = true)]
    internal static extern bool WinUsb_Free([In] IntPtr InterfaceHandle);

    [DllImport("winusb.dll", SetLastError = true)]
    internal static extern bool WinUsb_GetAssociatedInterface(
      [In] SafeHandle InterfaceHandle,
      byte AssociatedInterfaceIndex,
      ref IntPtr AssociatedInterfaceHandle);

    [DllImport("winusb.dll", SetLastError = true)]
    internal static extern bool WinUsb_GetCurrentAlternateSetting(
      [In] SafeHandle InterfaceHandle,
      out byte SettingNumber);

    [DllImport("winusb.dll", SetLastError = true)]
    private static extern bool WinUsb_GetDescriptor(
      [In] SafeHandle InterfaceHandle,
      byte DescriptorType,
      byte Index,
      ushort LanguageID,
      IntPtr Buffer,
      int BufferLength,
      out int LengthTransferred);

    [DllImport("winusb.dll", SetLastError = true)]
    private static extern bool WinUsb_GetOverlappedResult(
      [In] SafeHandle InterfaceHandle,
      IntPtr pOVERLAPPED,
      out int lpNumberOfBytesTransferred,
      bool Wait);

    [DllImport("winusb.dll", SetLastError = true)]
    internal static extern bool WinUsb_GetPipePolicy(
      [In] SafeHandle InterfaceHandle,
      byte PipeID,
      PipePolicyType policyType,
      ref int ValueLength,
      IntPtr Value);

    [DllImport("winusb.dll", SetLastError = true)]
    internal static extern bool WinUsb_GetPowerPolicy(
      [In] SafeHandle InterfaceHandle,
      PowerPolicyType policyType,
      ref int ValueLength,
      IntPtr Value);

    [DllImport("winusb.dll", SetLastError = true)]
    internal static extern bool WinUsb_Initialize(
      [In] SafeHandle DeviceHandle,
      [In, Out] ref SafeWinUsbInterfaceHandle InterfaceHandle);

    [DllImport("winusb.dll", SetLastError = true)]
    internal static extern bool WinUsb_QueryDeviceInformation(
      [In] SafeHandle InterfaceHandle,
      DeviceInformationTypes InformationType,
      ref int BufferLength,
      [MarshalAs(UnmanagedType.AsAny), In, Out] object Buffer);

    [DllImport("winusb.dll", SetLastError = true)]
    internal static extern bool WinUsb_QueryInterfaceSettings(
      [In] SafeHandle InterfaceHandle,
      byte AlternateInterfaceNumber,
      [MarshalAs(UnmanagedType.LPStruct), In, Out] UsbInterfaceDescriptor UsbAltInterfaceDescriptor);

    [DllImport("winusb.dll", SetLastError = true)]
    internal static extern bool WinUsb_QueryPipe(
      [In] SafeHandle InterfaceHandle,
      byte AlternateInterfaceNumber,
      byte PipeIndex,
      [MarshalAs(UnmanagedType.LPStruct), In, Out] PipeInformation PipeInformation);

    [DllImport("winusb.dll", SetLastError = true)]
    private static extern bool WinUsb_ReadPipe(
      [In] SafeHandle InterfaceHandle,
      byte PipeID,
      byte[] Buffer,
      int BufferLength,
      out int LengthTransferred,
      IntPtr pOVERLAPPED);

    [DllImport("winusb.dll", SetLastError = true)]
    private static extern bool WinUsb_ReadPipe(
      [In] SafeHandle InterfaceHandle,
      byte PipeID,
      IntPtr pBuffer,
      int BufferLength,
      out int LengthTransferred,
      IntPtr pOVERLAPPED);

    [DllImport("winusb.dll", SetLastError = true)]
    private static extern bool WinUsb_ResetPipe([In] SafeHandle InterfaceHandle, byte PipeID);

    [DllImport("winusb.dll", SetLastError = true)]
    internal static extern bool WinUsb_SetPipePolicy(
      [In] SafeHandle InterfaceHandle,
      byte PipeID,
      PipePolicyType policyType,
      int ValueLength,
      IntPtr Value);

    [DllImport("winusb.dll", SetLastError = true)]
    internal static extern bool WinUsb_SetPowerPolicy(
      [In] SafeHandle InterfaceHandle,
      PowerPolicyType policyType,
      int ValueLength,
      IntPtr Value);

    [DllImport("winusb.dll", SetLastError = true)]
    private static extern bool WinUsb_WritePipe(
      [In] SafeHandle InterfaceHandle,
      byte PipeID,
      byte[] Buffer,
      int BufferLength,
      out int LengthTransferred,
      IntPtr pOVERLAPPED);

    [DllImport("winusb.dll", SetLastError = true)]
    private static extern bool WinUsb_WritePipe(
      [In] SafeHandle InterfaceHandle,
      byte PipeID,
      IntPtr pBuffer,
      int BufferLength,
      out int LengthTransferred,
      IntPtr pOVERLAPPED);

    public override bool AbortPipe(SafeHandle InterfaceHandle, byte PipeID) => WinUsbAPI.WinUsb_AbortPipe(InterfaceHandle, PipeID);

    public override bool ControlTransfer(
      SafeHandle InterfaceHandle,
      UsbSetupPacket SetupPacket,
      IntPtr Buffer,
      int BufferLength,
      out int LengthTransferred)
    {
      return WinUsbAPI.WinUsb_ControlTransfer(InterfaceHandle, SetupPacket, Buffer, BufferLength, out LengthTransferred, IntPtr.Zero);
    }

    public override bool FlushPipe(SafeHandle InterfaceHandle, byte PipeID) => WinUsbAPI.WinUsb_FlushPipe(InterfaceHandle, PipeID);

    public override bool GetDescriptor(
      SafeHandle InterfaceHandle,
      byte DescriptorType,
      byte Index,
      ushort LanguageID,
      IntPtr Buffer,
      int BufferLength,
      out int LengthTransferred)
    {
      return WinUsbAPI.WinUsb_GetDescriptor(InterfaceHandle, DescriptorType, Index, LanguageID, Buffer, BufferLength, out LengthTransferred);
    }

    public override bool GetOverlappedResult(
      SafeHandle InterfaceHandle,
      IntPtr pOVERLAPPED,
      out int numberOfBytesTransferred,
      bool Wait)
    {
      return WinUsbAPI.WinUsb_GetOverlappedResult(InterfaceHandle, pOVERLAPPED, out numberOfBytesTransferred, Wait);
    }

    public override bool ReadPipe(
      UsbEndpointBase endPointBase,
      IntPtr pBuffer,
      int BufferLength,
      out int LengthTransferred,
      int isoPacketSize,
      IntPtr pOVERLAPPED)
    {
      return WinUsbAPI.WinUsb_ReadPipe(endPointBase.Device.Handle, endPointBase.EpNum, pBuffer, BufferLength, out LengthTransferred, pOVERLAPPED);
    }

    public override bool ResetPipe(SafeHandle InterfaceHandle, byte PipeID) => WinUsbAPI.WinUsb_ResetPipe(InterfaceHandle, PipeID);

    public override bool WritePipe(
      UsbEndpointBase endPointBase,
      IntPtr pBuffer,
      int BufferLength,
      out int LengthTransferred,
      int isoPacketSize,
      IntPtr pOVERLAPPED)
    {
      return WinUsbAPI.WinUsb_WritePipe(endPointBase.Device.Handle, endPointBase.EpNum, pBuffer, BufferLength, out LengthTransferred, pOVERLAPPED);
    }

    internal static bool OpenDevice(out SafeFileHandle sfhDevice, string DevicePath)
    {
      sfhDevice = Kernel32.CreateFile(DevicePath, NativeFileAccess.FILE_GENERIC_WRITE | NativeFileAccess.FILE_READ_DATA | NativeFileAccess.FILE_READ_EA | NativeFileAccess.FILE_READ_ATTRIBUTES, NativeFileShare.FILE_SHARE_READ | NativeFileShare.FILE_SHARE_WRITE, IntPtr.Zero, NativeFileMode.OPEN_EXISTING, NativeFileFlag.FILE_ATTRIBUTE_NORMAL | NativeFileFlag.FILE_FLAG_OVERLAPPED, IntPtr.Zero);
      return !sfhDevice.IsInvalid && !sfhDevice.IsClosed;
    }
  }
}
