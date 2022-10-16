// Decompiled with JetBrains decompiler
// Type: Falcon.FalconDeviceInformation
// Assembly: Falcon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B63D6514-B208-43D6-B3E8-6CD8252CCADA
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon.dll

using Falcon.Enums;
using Sdk.Core;

namespace Falcon
{
  public class FalconDeviceInformation : DeviceInformation
  {
    public string DeviceIc { get; set; }

    public string PoliceId { get; set; }

    public string UserId { get; set; }

    public string VersionNumber { get; set; }

    public VideoResolutions VideoResolution { get; set; }

    public VideoSplitTimes VideoSplitTime { get; set; }

    public Volumes Volume { get; set; }

    public TimeZones TimeZone { get; set; }

    public Qualitys Quality { get; set; }

    public Infrareds Infrared { get; set; }

    public CodecFormats CodecFormat { get; set; }

    public bool? RecordingWarning { get; set; }

    public bool? PreRecord { get; set; }

    public bool? LoopRecord { get; set; }

    public string WifiPassword { get; set; }

    public string DeviceTimeString { get; set; }
  }
}
