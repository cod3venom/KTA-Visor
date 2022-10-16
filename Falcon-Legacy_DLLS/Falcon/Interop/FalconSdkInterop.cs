// Decompiled with JetBrains decompiler
// Type: Falcon.Interop.FalconSdkInterop
// Assembly: Falcon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B63D6514-B208-43D6-B3E8-6CD8252CCADA
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon.dll

using System;
using System.Runtime.InteropServices;

namespace Falcon.Interop
{
  internal sealed class FalconSdkInterop
  {
    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool Open_Device();

    [DllImport("DLL\\BodyWornCamera_protocol.dll", EntryPoint = "Login", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool Login_Device(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool Close_Device();

    [DllImport("DLL\\BodyWornCamera_protocol.dll", EntryPoint = "enter_udisk", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool Mount();

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool Check_Device_state();

    [DllImport("DLL\\BodyWornCamera_protocol.dll", EntryPoint = "get_id", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_DeviceID(IntPtr pData);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_time(
      ref int year,
      ref int month,
      ref int day,
      ref int hour,
      ref int min,
      ref int sec);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_firmware_version(IntPtr pData);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_Resolution(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", EntryPoint = "get_Gps", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_GPS(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_VideoSplitTime(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_SoundVolume(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_Video_quality(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_Recording_warning(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_loop_record(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_Infrared(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_video_codec_format(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_pre_record(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl, PreserveSig = false)]
    public static extern bool get_Timezone_info(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", EntryPoint = "alert_passwd", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_password(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", EntryPoint = "set_id", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_DeviceID(IntPtr pData, uint nBytes);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", EntryPoint = "set_time", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_DateTime(
      int year,
      int month,
      int day,
      int hour,
      int min,
      int sec);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", EntryPoint = "set_Gps", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_GPS(int idx);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_Resolution(int idx);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_VideoSplitTime(int idx);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_SoundVolume(int idx);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_Video_quality(int idx);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_Recording_warning(int idx);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_loop_record(int idx);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_Infrared(int idx);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_video_codec_format(int idx);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_pre_record(int idx);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool set_Timezone_info(int idx);

    [DllImport("DLL\\BodyWornCamera_protocol.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool restore_default();
  }
}
