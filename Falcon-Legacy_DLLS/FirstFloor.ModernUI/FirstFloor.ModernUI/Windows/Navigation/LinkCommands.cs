// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Navigation.LinkCommands
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System.Windows.Input;

namespace FirstFloor.ModernUI.Windows.Navigation
{
  public static class LinkCommands
  {
    private static RoutedUICommand navigateLink = new RoutedUICommand(Resources.NavigateLink, nameof (NavigateLink), typeof (LinkCommands));

    public static RoutedUICommand NavigateLink => LinkCommands.navigateLink;
  }
}
