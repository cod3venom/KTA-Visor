// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Navigation.NavigationBaseEventArgs
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Windows.Controls;
using System;

namespace FirstFloor.ModernUI.Windows.Navigation
{
  public abstract class NavigationBaseEventArgs : EventArgs
  {
    public ModernFrame Frame { get; internal set; }

    public Uri Source { get; internal set; }
  }
}
