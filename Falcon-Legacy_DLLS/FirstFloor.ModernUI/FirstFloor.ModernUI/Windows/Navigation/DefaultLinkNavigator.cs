// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Navigation.DefaultLinkNavigator
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace FirstFloor.ModernUI.Windows.Navigation
{
  public class DefaultLinkNavigator : ILinkNavigator
  {
    private CommandDictionary commands = new CommandDictionary();
    private string[] externalSchemes = new string[3]
    {
      Uri.UriSchemeHttp,
      Uri.UriSchemeHttps,
      Uri.UriSchemeMailto
    };

    public DefaultLinkNavigator()
    {
      this.Commands.Add(new Uri("cmd://accentcolor"), AppearanceManager.Current.AccentColorCommand);
      this.Commands.Add(new Uri("cmd://darktheme"), AppearanceManager.Current.DarkThemeCommand);
      this.Commands.Add(new Uri("cmd://largefontsize"), AppearanceManager.Current.LargeFontSizeCommand);
      this.Commands.Add(new Uri("cmd://lighttheme"), AppearanceManager.Current.LightThemeCommand);
      this.Commands.Add(new Uri("cmd://settheme"), AppearanceManager.Current.SetThemeCommand);
      this.Commands.Add(new Uri("cmd://smallfontsize"), AppearanceManager.Current.SmallFontSizeCommand);
      this.commands.Add(new Uri("cmd://browseback"), (ICommand) NavigationCommands.BrowseBack);
      this.commands.Add(new Uri("cmd://refresh"), (ICommand) NavigationCommands.Refresh);
      this.commands.Add(new Uri("cmd://gotopage"), (ICommand) NavigationCommands.GoToPage);
      this.commands.Add(new Uri("cmd://copy"), (ICommand) ApplicationCommands.Copy);
    }

    public string[] ExternalSchemes
    {
      get => this.externalSchemes;
      set => this.externalSchemes = value;
    }

    public CommandDictionary Commands
    {
      get => this.commands;
      set => this.commands = value;
    }

    public virtual void Navigate(Uri uri, FrameworkElement source = null, string parameter = null)
    {
      if (uri == (Uri) null)
        throw new ArgumentNullException(nameof (uri));
      ICommand command;
      if (this.commands != null && this.commands.TryGetValue(uri, out command))
      {
        if (!command.CanExecute((object) parameter))
          return;
        command.Execute((object) parameter);
      }
      else if (uri.IsAbsoluteUri && this.externalSchemes != null && ((IEnumerable<string>) this.externalSchemes).Any<string>((Func<string, bool>) (s => uri.Scheme.Equals(s, StringComparison.OrdinalIgnoreCase))))
      {
        Process.Start(uri.AbsoluteUri);
      }
      else
      {
        ModernFrame modernFrame = source != null ? NavigationHelper.FindFrame(parameter, source) : throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.CurrentUICulture, Resources.NavigationFailedSourceNotSpecified, new object[1]
        {
          (object) uri
        }));
        if (modernFrame == null)
          throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.CurrentUICulture, Resources.NavigationFailedFrameNotFound, new object[2]
          {
            (object) uri,
            (object) parameter
          }));
        modernFrame.Source = uri;
      }
    }
  }
}
