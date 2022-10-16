// Decompiled with JetBrains decompiler
// Type: Sdk.Core.DevicesDetection.DeviceDetectionHandle
// Assembly: Sdk.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8603C600-6128-4214-B6AC-92C1763A5259
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Sdk.Core.dll

using Sdk.Core.Enums;

namespace Sdk.Core.DevicesDetection
{
  public delegate void DeviceDetectionHandle(
    DeviceDetectedInformation detectedInformation,
    VolumeChangeEventType changeEventType);
}
