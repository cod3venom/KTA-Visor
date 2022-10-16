// Decompiled with JetBrains decompiler
// Type: Falcon.Wrapper.IFalconSdkInteropWrapper
// Assembly: Falcon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B63D6514-B208-43D6-B3E8-6CD8252CCADA
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon.dll

using Falcon.Enums;
using System;

namespace Falcon.Wrapper
{
  internal interface IFalconSdkInteropWrapper
  {
    bool OpenDevice();

    bool CheckDeviceState();

    bool CloseDevice();

    bool DeviceLogin(string password);

    bool Mount();

    string GetDeviceID();

    string GetFirmware();

    int GetResolution();

    int GetVideoSplitTime();

    int GetSoundVolume();

    int GetVideoQuality();

    bool GetRecordingWarning();

    bool GetLoopRecord();

    int GetInfrared();

    int GetVideoCodecFormat();

    bool GetPreRecord();

    DateTime GetDateTime();

    int GetTimezoneinfo();

    bool GetGPS();

    bool SetDeviceID(string deviceId);

    bool SyncDateTime(DateTime datetimeToSync);

    bool SetGPS(bool flag);

    bool SetResolution(VideoResolutions idx);

    bool SetVideoSplitTime(VideoSplitTimes idx);

    bool SetSoundVolume(Volumes idx);

    bool SetVideoQuality(Qualitys idx);

    bool SetRecordingWarning(bool flag);

    bool SetLoopRecord(bool flag);

    bool SetInfrared(Infrareds idx);

    bool SetVideoCodecFormat(CodecFormats idx);

    bool SetPreRecord(bool flag);

    bool SetTimezoneinfo(TimeZones idx);

    bool SetPassword(string password);
  }
}
