// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Presentation.AppearanceManager
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Windows.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FirstFloor.ModernUI.Presentation
{
  public class AppearanceManager : NotifyPropertyChanged
  {
    public static readonly Uri DarkThemeSource = new Uri("/FirstFloor.ModernUI;component/Assets/ModernUI.Dark.xaml", UriKind.Relative);
    public static readonly Uri LightThemeSource = new Uri("/FirstFloor.ModernUI;component/Assets/ModernUI.Light.xaml", UriKind.Relative);
    public const string KeyAccentColor = "AccentColor";
    public const string KeyAccent = "Accent";
    public const string KeyDefaultFontSize = "DefaultFontSize";
    public const string KeyFixedFontSize = "FixedFontSize";
    private static AppearanceManager current = new AppearanceManager();

    private AppearanceManager()
    {
      this.DarkThemeCommand = (ICommand) new RelayCommand((Action<object>) (o => this.ThemeSource = AppearanceManager.DarkThemeSource), (Func<object, bool>) (o => !AppearanceManager.DarkThemeSource.Equals((object) this.ThemeSource)));
      this.LightThemeCommand = (ICommand) new RelayCommand((Action<object>) (o => this.ThemeSource = AppearanceManager.LightThemeSource), (Func<object, bool>) (o => !AppearanceManager.LightThemeSource.Equals((object) this.ThemeSource)));
      this.SetThemeCommand = (ICommand) new RelayCommand((Action<object>) (o =>
      {
        Uri uri = NavigationHelper.ToUri(o);
        if (!(uri != (Uri) null))
          return;
        this.ThemeSource = uri;
      }), (Func<object, bool>) (o => (object) (o as Uri) != null || o is string));
      this.LargeFontSizeCommand = (ICommand) new RelayCommand((Action<object>) (o => this.FontSize = FontSize.Large));
      this.SmallFontSizeCommand = (ICommand) new RelayCommand((Action<object>) (o => this.FontSize = FontSize.Small));
      this.AccentColorCommand = (ICommand) new RelayCommand((Action<object>) (o =>
      {
        switch (o)
        {
          case Color color2:
            this.AccentColor = color2;
            break;
          case string str2:
            this.AccentColor = (Color) ColorConverter.ConvertFromString(str2);
            break;
        }
      }), (Func<object, bool>) (o => o is Color || o is string));
    }

    private ResourceDictionary GetThemeDictionary() => Application.Current.Resources.MergedDictionaries.Where<ResourceDictionary>((Func<ResourceDictionary, bool>) (dict => dict.Contains((object) "WindowBackground"))).FirstOrDefault<ResourceDictionary>();

    private Uri GetThemeSource() => this.GetThemeDictionary()?.Source;

    private void SetThemeSource(Uri source, bool useThemeAccentColor)
    {
      if (source == (Uri) null)
        throw new ArgumentNullException(nameof (source));
      ResourceDictionary themeDictionary = this.GetThemeDictionary();
      Collection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
      ResourceDictionary resourceDictionary = new ResourceDictionary()
      {
        Source = source
      };
      Color? nullable = resourceDictionary[(object) "AccentColor"] as Color?;
      if (nullable.HasValue)
      {
        resourceDictionary.Remove((object) "AccentColor");
        if (useThemeAccentColor)
          this.ApplyAccentColor(nullable.Value);
      }
      mergedDictionaries.Add(resourceDictionary);
      if (themeDictionary != null)
        mergedDictionaries.Remove(themeDictionary);
      this.OnPropertyChanged("ThemeSource");
    }

    private void ApplyAccentColor(Color accentColor)
    {
      Application.Current.Resources[(object) "AccentColor"] = (object) accentColor;
      Application.Current.Resources[(object) "Accent"] = (object) new SolidColorBrush(accentColor);
    }

    private FontSize GetFontSize()
    {
      double? resource = Application.Current.Resources[(object) "DefaultFontSize"] as double?;
      return resource.HasValue && resource.Value == 12.0 ? FontSize.Small : FontSize.Large;
    }

    private void SetFontSize(FontSize fontSize)
    {
      if (this.GetFontSize() == fontSize)
        return;
      Application.Current.Resources[(object) "DefaultFontSize"] = (object) (fontSize == FontSize.Small ? 12.0 : 13.0);
      Application.Current.Resources[(object) "FixedFontSize"] = (object) (fontSize == FontSize.Small ? 10.667 : 13.333);
      this.OnPropertyChanged("FontSize");
    }

    private Color GetAccentColor()
    {
      Color? resource = Application.Current.Resources[(object) "AccentColor"] as Color?;
      return resource.HasValue ? resource.Value : Color.FromArgb(byte.MaxValue, (byte) 27, (byte) 161, (byte) 226);
    }

    private void SetAccentColor(Color value)
    {
      this.ApplyAccentColor(value);
      Uri themeSource = this.GetThemeSource();
      if (themeSource != (Uri) null)
        this.SetThemeSource(themeSource, false);
      this.OnPropertyChanged("AccentColor");
    }

    public static AppearanceManager Current => AppearanceManager.current;

    public ICommand DarkThemeCommand { get; private set; }

    public ICommand LightThemeCommand { get; private set; }

    public ICommand SetThemeCommand { get; private set; }

    public ICommand LargeFontSizeCommand { get; private set; }

    public ICommand SmallFontSizeCommand { get; private set; }

    public ICommand AccentColorCommand { get; private set; }

    public Uri ThemeSource
    {
      get => this.GetThemeSource();
      set => this.SetThemeSource(value, true);
    }

    public FontSize FontSize
    {
      get => this.GetFontSize();
      set => this.SetFontSize(value);
    }

    public Color AccentColor
    {
      get => this.GetAccentColor();
      set => this.SetAccentColor(value);
    }
  }
}
