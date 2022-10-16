// Decompiled with JetBrains decompiler
// Type: Falcon_USB.DeviceMountedEventArgsFalcon
// Assembly: Falcon_USB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7924EA10-DAC0-471E-BD57-BD7B43142DEE
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon_USB.dll

using System;

namespace Falcon_USB
{
  public class DeviceMountedEventArgsFalcon : EventArgs
  {
    public string Drive { get; private set; }

    internal DeviceMountedEventArgsFalcon(string drive) => this.Drive = drive;
  }
}
