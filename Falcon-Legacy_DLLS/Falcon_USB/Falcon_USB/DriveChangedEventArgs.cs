// Decompiled with JetBrains decompiler
// Type: Falcon_USB.DriveChangedEventArgs
// Assembly: Falcon_USB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7924EA10-DAC0-471E-BD57-BD7B43142DEE
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon_USB.dll

using System;

namespace Falcon_USB
{
  internal class DriveChangedEventArgs : EventArgs
  {
    internal readonly string Drive;

    internal DriveChangedEventArgs(string drive) => this.Drive = drive;
  }
}
