// Decompiled with JetBrains decompiler
// Type: Falcon.FalconSdk
// Assembly: Falcon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B63D6514-B208-43D6-B3E8-6CD8252CCADA
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon.dll

using Falcon.Enums;
using Falcon.Wrapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Falcon
{
  public class FalconSdk : IFalconSdk
  {
    private readonly IFalconSdkInteropWrapper _falconSdkInteropWrapper;

    public int CurrentDeviceId { get; set; }

    public FalconSdk() => this._falconSdkInteropWrapper = (IFalconSdkInteropWrapper) new FalconSdkInteropWrapper();

    public bool ConnectToDevice() => this._falconSdkInteropWrapper.OpenDevice();

    public bool CheckDeviceState() => this._falconSdkInteropWrapper.CheckDeviceState() && this._falconSdkInteropWrapper.OpenDevice();

    public bool CloseDevice() => this._falconSdkInteropWrapper.CloseDevice();

    public bool LoginToDevice(string password) => this._falconSdkInteropWrapper.DeviceLogin(password);

    public FalconDeviceInformation GetDeviceInformation()
    {
      string deviceId = this._falconSdkInteropWrapper.GetDeviceID();
      string str1 = "";
      string str2 = "";
      if (deviceId.Length == 12)
      {
        str1 = deviceId.ToString().Substring(0, 5);
        str2 = deviceId.ToString().Substring(6, 6);
      }
      DateTime dateTime = this._falconSdkInteropWrapper.GetDateTime();
      string firmware = this._falconSdkInteropWrapper.GetFirmware();
      int resolution = this._falconSdkInteropWrapper.GetResolution();
      bool gps = this._falconSdkInteropWrapper.GetGPS();
      int videoSplitTime = this._falconSdkInteropWrapper.GetVideoSplitTime();
      int soundVolume = this._falconSdkInteropWrapper.GetSoundVolume();
      int timezoneinfo = this._falconSdkInteropWrapper.GetTimezoneinfo();
      int videoQuality = this._falconSdkInteropWrapper.GetVideoQuality();
      int infrared = this._falconSdkInteropWrapper.GetInfrared();
      int videoCodecFormat = this._falconSdkInteropWrapper.GetVideoCodecFormat();
      bool recordingWarning = this._falconSdkInteropWrapper.GetRecordingWarning();
      bool preRecord = this._falconSdkInteropWrapper.GetPreRecord();
      bool loopRecord = this._falconSdkInteropWrapper.GetLoopRecord();
      FalconDeviceInformation deviceInformation = new FalconDeviceInformation();
      deviceInformation.DeviceId = str1;
      deviceInformation.PoliceId = str2;
      deviceInformation.VersionNumber = firmware;
      deviceInformation.VideoResolution = (VideoResolutions) resolution;
      deviceInformation.GpsStatus = new bool?(gps);
      deviceInformation.DeviceDateTime = new DateTime?(dateTime);
      deviceInformation.VideoSplitTime = (VideoSplitTimes) videoSplitTime;
      deviceInformation.Volume = (Volumes) soundVolume;
      deviceInformation.TimeZone = (TimeZones) timezoneinfo;
      deviceInformation.Quality = (Qualitys) videoQuality;
      deviceInformation.Infrared = (Infrareds) infrared;
      deviceInformation.CodecFormat = (CodecFormats) videoCodecFormat;
      deviceInformation.RecordingWarning = new bool?(recordingWarning);
      deviceInformation.PreRecord = new bool?(preRecord);
      deviceInformation.LoopRecord = new bool?(loopRecord);
      return deviceInformation;
    }

    public bool Mount() => this._falconSdkInteropWrapper.Mount();

    public bool SetPassword(string password) => this._falconSdkInteropWrapper.SetPassword(password);

    public bool SetDeviceID(string deviceId) => this._falconSdkInteropWrapper.SetDeviceID(deviceId);

    public bool SetResolution(VideoResolutions idx) => this._falconSdkInteropWrapper.SetResolution(idx);

    public bool SetVideoSplitTime(VideoSplitTimes idx) => this._falconSdkInteropWrapper.SetVideoSplitTime(idx);

    public bool SetVideoCodecFormat(CodecFormats idx) => this._falconSdkInteropWrapper.SetVideoCodecFormat(idx);

    public bool SetInfrared(Infrareds idx) => this._falconSdkInteropWrapper.SetInfrared(idx);

    public bool SetVideoQuality(Qualitys idx) => this._falconSdkInteropWrapper.SetVideoQuality(idx);

    public bool SetTimezoneinfo(TimeZones idx) => this._falconSdkInteropWrapper.SetTimezoneinfo(idx);

    public bool SetSoundVolume(Volumes idx) => this._falconSdkInteropWrapper.SetSoundVolume(idx);

    public bool SyncDateTime(DateTime datetimeToSync) => this._falconSdkInteropWrapper.SyncDateTime(datetimeToSync);

    public bool SetGPS(bool flag) => this._falconSdkInteropWrapper.SetGPS(flag);

    public bool SetRecordingWarning(bool flag) => this._falconSdkInteropWrapper.SetRecordingWarning(flag);

    public bool SetLoopRecord(bool flag) => this._falconSdkInteropWrapper.SetLoopRecord(flag);

    public bool SetPreRecord(bool flag) => this._falconSdkInteropWrapper.SetPreRecord(flag);

    public IList<string> GetFiles(string deviceId)
    {
      try
      {
        List<string> files = new List<string>();
        foreach (DriveInfo driveInfo in ((IEnumerable<DriveInfo>) DriveInfo.GetDrives()).Where<DriveInfo>((Func<DriveInfo, bool>) (d => d.DriveType == DriveType.Removable)))
        {
          if (driveInfo.VolumeLabel == deviceId)
          {
            foreach (FileInfo file in ((IEnumerable<DirectoryInfo>) new DirectoryInfo(driveInfo.Name).Root.GetDirectories("*.*", SearchOption.AllDirectories)).Where<DirectoryInfo>((Func<DirectoryInfo, bool>) (dir => dir.Name == "100MEDIA")).Single<DirectoryInfo>().GetFiles())
              files.Add(file.Name);
            return (IList<string>) files;
          }
        }
        return (IList<string>) null;
      }
      catch (Exception ex)
      {
        return (IList<string>) new List<string>();
      }
    }

    public bool Format(string deviceId)
    {
      try
      {
        foreach (DriveInfo driveInfo1 in ((IEnumerable<DriveInfo>) DriveInfo.GetDrives()).Where<DriveInfo>((Func<DriveInfo, bool>) (d => d.DriveType == DriveType.Removable)))
        {
          DriveInfo driveInfo = driveInfo1;
          if (driveInfo.VolumeLabel == deviceId)
          {
            Task.Run((Action) (() => Array.ForEach<string>(Directory.GetFiles(driveInfo.RootDirectory.FullName + "DCIM\\100MEDIA"), new Action<string>(File.Delete))));
            return true;
          }
        }
        return false;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}
