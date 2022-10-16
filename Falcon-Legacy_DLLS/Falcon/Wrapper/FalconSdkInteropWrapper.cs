// Decompiled with JetBrains decompiler
// Type: Falcon.Wrapper.FalconSdkInteropWrapper
// Assembly: Falcon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B63D6514-B208-43D6-B3E8-6CD8252CCADA
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon.dll

using Falcon.Enums;
using Falcon.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Falcon.Wrapper
{
  internal sealed class FalconSdkInteropWrapper : IFalconSdkInteropWrapper
  {
    public bool OpenDevice() => FalconSdkInterop.Open_Device();

    public bool CloseDevice() => FalconSdkInterop.Close_Device();

    public bool CheckDeviceState() => FalconSdkInterop.Check_Device_state();

    public bool DeviceLogin(string password)
    {
      Tuple<IntPtr, uint> pointerData = this.GetPointerData(password);
      return FalconSdkInterop.Login_Device(pointerData.Item1, pointerData.Item2);
    }

    public string GetDeviceID()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_DeviceID(num2);
      return this.ResponseText(num2, (int) num1);
    }

    public string GetFirmware()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_firmware_version(num2);
      return this.ResponseText(num2, (int) num1);
    }

    public int GetResolution()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_Resolution(num2, num1);
      return this.ResponseIdx(num2);
    }

    public bool GetGPS()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_GPS(num2, num1);
      return this.ResponseBool(num2);
    }

    public int GetVideoSplitTime()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_VideoSplitTime(num2, num1);
      return this.ResponseIdx(num2);
    }

    public int GetSoundVolume()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_SoundVolume(num2, num1);
      return this.ResponseIdx(num2);
    }

    public int GetVideoQuality()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_Video_quality(num2, num1);
      return this.ResponseIdx(num2);
    }

    public bool GetRecordingWarning()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_Recording_warning(num2, num1);
      return this.ResponseBool(num2);
    }

    public bool GetLoopRecord()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_loop_record(num2, num1);
      return this.ResponseBool(num2);
    }

    public int GetInfrared()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_Infrared(num2, num1);
      return this.ResponseIdx(num2);
    }

    public int GetVideoCodecFormat()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_video_codec_format(num2, num1);
      return this.ResponseIdx(num2);
    }

    public bool GetPreRecord()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_pre_record(num2, num1);
      return this.ResponseBool(num2);
    }

    public DateTime GetDateTime()
    {
     try
            {
                int year = 0;
                int month = 0;
                int day = 0;
                int hour = 0;
                int min = 0;
                int sec = 0;
                //var    dtStr = "2011-03-21 13:26";
               // DateTime? dt = dtStr.ToDate("yyyy-MM-dd HH:mm");
                FalconSdkInterop.get_time(ref year, ref month, ref day, ref hour, ref min, ref sec);
                string dateTimeNow = string.Format("{0}-{1}-{2} {3}:{4}", year.ToString(), month.ToString(), hour.ToString(), min.ToString());
                return DateTime.Parse(dateTimeNow);
                
            }
        catch (Exception)
        {
                return new DateTime();
        }
    }

    public int GetTimezoneinfo()
    {
      uint num1 = 50;
      IntPtr num2 = Marshal.AllocHGlobal((int) num1);
      FalconSdkInterop.get_Timezone_info(num2, num1);
      return this.ResponseIdx(num2);
    }

    public bool SetDeviceID(string deviceId) => FalconSdkInterop.set_DeviceID(Marshal.StringToHGlobalAnsi(deviceId), (uint) Encoding.ASCII.GetByteCount(deviceId));

    public bool SyncDateTime(DateTime datetimeToSync)
    {
      int[] array = ((IEnumerable<string>) datetimeToSync.ToString("yyyy,MM,dd,HH,mm,ss").Split(',')).Select<string, int>(new Func<string, int>(int.Parse)).ToArray<int>();
      return FalconSdkInterop.set_DateTime(array[0], array[1], array[2], array[3], array[4], array[5]);
    }

    public bool SetGPS(bool flag) => FalconSdkInterop.set_GPS(flag ? 1 : 0);

    public bool SetResolution(VideoResolutions idx) => FalconSdkInterop.set_Resolution((int) idx);

    public bool SetVideoSplitTime(VideoSplitTimes idx) => FalconSdkInterop.set_VideoSplitTime((int) idx);

    public bool SetSoundVolume(Volumes idx) => FalconSdkInterop.set_SoundVolume((int) idx);

    public bool SetVideoQuality(Qualitys idx) => FalconSdkInterop.set_Video_quality((int) idx);

    public bool SetRecordingWarning(bool flag) => FalconSdkInterop.set_Recording_warning(flag ? 1 : 0);

    public bool SetLoopRecord(bool flag) => FalconSdkInterop.set_loop_record(flag ? 1 : 0);

    public bool SetInfrared(Infrareds idx) => FalconSdkInterop.set_Infrared((int) idx);

    public bool SetVideoCodecFormat(CodecFormats idx) => FalconSdkInterop.set_video_codec_format((int) idx);

    public bool SetPreRecord(bool flag) => FalconSdkInterop.set_pre_record(flag ? 1 : 0);

    public bool SetTimezoneinfo(TimeZones idx) => FalconSdkInterop.set_Timezone_info((int) idx);

    public bool SetPassword(string password) => FalconSdkInterop.set_password(Marshal.StringToHGlobalAnsi(password), (uint) Encoding.ASCII.GetByteCount(password));

    private string ResponseText(IntPtr Information, int dataSize)
    {
      byte[] destination = new byte[dataSize];
      Marshal.Copy(Information, destination, 0, dataSize);
      string stringAnsi = Marshal.PtrToStringAnsi(Information);
      Marshal.FreeHGlobal(Information);
      return stringAnsi;
    }

    private int ResponseIdx(IntPtr Information)
    {
      byte[] destination = new byte[1];
      Marshal.Copy(Information, destination, 0, destination.Length);
      int num = (int) destination[0];
      Marshal.FreeHGlobal(Information);
      return num;
    }

    private bool ResponseBool(IntPtr Information)
    {
      byte[] destination = new byte[1];
      Marshal.Copy(Information, destination, 0, destination.Length);
      byte num = destination[0];
      Marshal.FreeHGlobal(Information);
      return num != (byte) 0 && num == (byte) 1;
    }

    private Tuple<IntPtr, uint> GetPointerData(string data) => new Tuple<IntPtr, uint>(Marshal.StringToHGlobalAnsi(data), (uint) Encoding.ASCII.GetByteCount(data));

    public bool Mount() => FalconSdkInterop.Mount();
  }
}
