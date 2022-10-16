// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Navigation.ILinkNavigator
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;
using System.Windows;

namespace FirstFloor.ModernUI.Windows.Navigation
{
  public interface ILinkNavigator
  {
    CommandDictionary Commands { get; set; }

    void Navigate(Uri uri, FrameworkElement source, string parameter = null);
  }
}
