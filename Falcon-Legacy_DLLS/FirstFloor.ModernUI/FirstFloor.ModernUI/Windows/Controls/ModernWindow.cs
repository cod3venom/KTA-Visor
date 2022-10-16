// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.ModernWindow
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Navigation;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FirstFloor.ModernUI.Windows.Controls
{
  public class ModernWindow : DpiAwareWindow
  {
    public static readonly DependencyProperty BackgroundContentProperty = DependencyProperty.Register(nameof (BackgroundContent), typeof (object), typeof (ModernWindow));
    public static readonly DependencyProperty MenuLinkGroupsProperty = DependencyProperty.Register(nameof (MenuLinkGroups), typeof (LinkGroupCollection), typeof (ModernWindow));
    public static readonly DependencyProperty MenuLinkGroupsIconProperty = DependencyProperty.Register(nameof (MenuLinkGroupsIcon), typeof (LinkGroupCollectionIcon), typeof (ModernWindow));
    public static readonly DependencyProperty TitleLinksProperty = DependencyProperty.Register(nameof (TitleLinks), typeof (LinkCollection), typeof (ModernWindow));
    public static readonly DependencyProperty IsTitleVisibleProperty = DependencyProperty.Register(nameof (IsTitleVisible), typeof (bool), typeof (ModernWindow), new PropertyMetadata((object) false));
    public static readonly DependencyProperty LogoDataProperty = DependencyProperty.Register(nameof (LogoData), typeof (Geometry), typeof (ModernWindow));
    public static readonly DependencyProperty ContentSourceProperty = DependencyProperty.Register(nameof (ContentSource), typeof (Uri), typeof (ModernWindow));
    public static readonly DependencyProperty ContentLoaderProperty = DependencyProperty.Register(nameof (ContentLoader), typeof (IContentLoader), typeof (ModernWindow), new PropertyMetadata((object) new DefaultContentLoader()));
    public static DependencyProperty LinkNavigatorProperty = DependencyProperty.Register(nameof (LinkNavigator), typeof (ILinkNavigator), typeof (ModernWindow), new PropertyMetadata((object) new DefaultLinkNavigator()));
    private Storyboard backgroundAnimation;

    public ModernWindow()
    {
      this.DefaultStyleKey = (object) typeof (ModernWindow);
      this.SetCurrentValue(ModernWindow.MenuLinkGroupsProperty, (object) new LinkGroupCollection());
      this.SetCurrentValue(ModernWindow.MenuLinkGroupsIconProperty, (object) new LinkGroupCollectionIcon());
      this.SetCurrentValue(ModernWindow.TitleLinksProperty, (object) new LinkCollection());
      this.CommandBindings.Add(new CommandBinding((ICommand) SystemCommands.CloseWindowCommand, new ExecutedRoutedEventHandler(this.OnCloseWindow)));
      this.CommandBindings.Add(new CommandBinding((ICommand) SystemCommands.MaximizeWindowCommand, new ExecutedRoutedEventHandler(this.OnMaximizeWindow), new CanExecuteRoutedEventHandler(this.OnCanResizeWindow)));
      this.CommandBindings.Add(new CommandBinding((ICommand) SystemCommands.MinimizeWindowCommand, new ExecutedRoutedEventHandler(this.OnMinimizeWindow), new CanExecuteRoutedEventHandler(this.OnCanMinimizeWindow)));
      this.CommandBindings.Add(new CommandBinding((ICommand) SystemCommands.RestoreWindowCommand, new ExecutedRoutedEventHandler(this.OnRestoreWindow), new CanExecuteRoutedEventHandler(this.OnCanResizeWindow)));
      this.CommandBindings.Add(new CommandBinding((ICommand) LinkCommands.NavigateLink, new ExecutedRoutedEventHandler(this.OnNavigateLink), new CanExecuteRoutedEventHandler(this.OnCanNavigateLink)));
      AppearanceManager.Current.PropertyChanged += new PropertyChangedEventHandler(this.OnAppearanceManagerPropertyChanged);
    }

    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      AppearanceManager.Current.PropertyChanged -= new PropertyChangedEventHandler(this.OnAppearanceManagerPropertyChanged);
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      if (!(this.GetTemplateChild("WindowBorder") is Border templateChild))
        return;
      this.backgroundAnimation = templateChild.Resources[(object) "BackgroundAnimation"] as Storyboard;
      if (this.backgroundAnimation == null)
        return;
      this.backgroundAnimation.Begin();
    }

    private void OnAppearanceManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == "ThemeSource") || this.backgroundAnimation == null)
        return;
      this.backgroundAnimation.Begin();
    }

    private void OnCanNavigateLink(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
      Uri uri;
      string parameter;
      ICommand command;
      if (this.LinkNavigator == null || this.LinkNavigator.Commands == null || !NavigationHelper.TryParseUriWithParameters(e.Parameter, out uri, out parameter, out string _) || !this.LinkNavigator.Commands.TryGetValue(uri, out command))
        return;
      e.CanExecute = command.CanExecute((object) parameter);
    }

    private void OnNavigateLink(object sender, ExecutedRoutedEventArgs e)
    {
      Uri uri;
      string parameter;
      if (this.LinkNavigator == null || !NavigationHelper.TryParseUriWithParameters(e.Parameter, out uri, out parameter, out string _))
        return;
      this.LinkNavigator.Navigate(uri, e.Source as FrameworkElement, parameter);
    }

    private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = this.ResizeMode == ResizeMode.CanResize || this.ResizeMode == ResizeMode.CanResizeWithGrip;

    private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = this.ResizeMode != 0;

    private void OnCloseWindow(object target, ExecutedRoutedEventArgs e) => SystemCommands.CloseWindow((Window) this);

    private void OnMaximizeWindow(object target, ExecutedRoutedEventArgs e) => SystemCommands.MaximizeWindow((Window) this);

    private void OnMinimizeWindow(object target, ExecutedRoutedEventArgs e) => SystemCommands.MinimizeWindow((Window) this);

    private void OnRestoreWindow(object target, ExecutedRoutedEventArgs e) => SystemCommands.RestoreWindow((Window) this);

    public object BackgroundContent
    {
      get => this.GetValue(ModernWindow.BackgroundContentProperty);
      set => this.SetValue(ModernWindow.BackgroundContentProperty, value);
    }

    public LinkGroupCollection MenuLinkGroups
    {
      get => (LinkGroupCollection) this.GetValue(ModernWindow.MenuLinkGroupsProperty);
      set => this.SetValue(ModernWindow.MenuLinkGroupsProperty, (object) value);
    }

    public LinkGroupCollectionIcon MenuLinkGroupsIcon
    {
      get => (LinkGroupCollectionIcon) this.GetValue(ModernWindow.MenuLinkGroupsIconProperty);
      set => this.SetValue(ModernWindow.MenuLinkGroupsIconProperty, (object) value);
    }

    public LinkCollection TitleLinks
    {
      get => (LinkCollection) this.GetValue(ModernWindow.TitleLinksProperty);
      set => this.SetValue(ModernWindow.TitleLinksProperty, (object) value);
    }

    public bool IsTitleVisible
    {
      get => (bool) this.GetValue(ModernWindow.IsTitleVisibleProperty);
      set => this.SetValue(ModernWindow.IsTitleVisibleProperty, (object) value);
    }

    public Geometry LogoData
    {
      get => (Geometry) this.GetValue(ModernWindow.LogoDataProperty);
      set => this.SetValue(ModernWindow.LogoDataProperty, (object) value);
    }

    public Uri ContentSource
    {
      get => (Uri) this.GetValue(ModernWindow.ContentSourceProperty);
      set => this.SetValue(ModernWindow.ContentSourceProperty, (object) value);
    }

    public IContentLoader ContentLoader
    {
      get => (IContentLoader) this.GetValue(ModernWindow.ContentLoaderProperty);
      set => this.SetValue(ModernWindow.ContentLoaderProperty, (object) value);
    }

    public ILinkNavigator LinkNavigator
    {
      get => (ILinkNavigator) this.GetValue(ModernWindow.LinkNavigatorProperty);
      set => this.SetValue(ModernWindow.LinkNavigatorProperty, (object) value);
    }
  }
}
