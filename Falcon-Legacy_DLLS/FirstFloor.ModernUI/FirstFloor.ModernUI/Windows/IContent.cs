﻿// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.IContent
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Windows.Navigation;

namespace FirstFloor.ModernUI.Windows
{
  public interface IContent
  {
    void OnFragmentNavigation(FragmentNavigationEventArgs e);

    void OnNavigatedFrom(NavigationEventArgs e);

    void OnNavigatedTo(NavigationEventArgs e);

    void OnNavigatingFrom(NavigatingCancelEventArgs e);
  }
}
