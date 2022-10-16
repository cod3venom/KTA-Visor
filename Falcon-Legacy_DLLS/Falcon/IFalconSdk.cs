// Decompiled with JetBrains decompiler
// Type: Falcon.IFalconSdk
// Assembly: Falcon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B63D6514-B208-43D6-B3E8-6CD8252CCADA
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon.dll

using Falcon.Enums;
using System;
using System.Collections.Generic;

namespace Falcon
{
  public interface IFalconSdk
  {
    FalconDeviceInformation GetDeviceInformation();

    bool ConnectToDevice();

    bool CheckDeviceState();

    bool CloseDevice();

    bool LoginToDevice(string password);

    bool Mount();

    bool SetDeviceID(string deviceId);

    bool SyncDateTime(DateTime datetimeToSync);

    bool SetGPS(bool flag);

    IList<string> GetFiles(string deviceId);

    bool Format(string deviceId);

    bool SetPassword(string password);

    bool SetResolution(VideoResolutions idx);

    bool SetVideoSplitTime(VideoSplitTimes idx);

    bool SetVideoQuality(Qualitys idx);

    bool SetSoundVolume(Volumes idx);

    bool SetInfrared(Infrareds idx);

    bool SetVideoCodecFormat(CodecFormats idx);

    bool SetTimezoneinfo(TimeZones idx);

    bool SetRecordingWarning(bool flag);

    bool SetLoopRecord(bool flag);

    bool SetPreRecord(bool flag);
  }
}
