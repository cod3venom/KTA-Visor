// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.BBCodeBlock
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Windows.Controls.BBCode;
using FirstFloor.ModernUI.Windows.Navigation;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace FirstFloor.ModernUI.Windows.Controls
{
  [ContentProperty("BBCode")]
  public class BBCodeBlock : TextBlock
  {
    public static DependencyProperty BBCodeProperty = DependencyProperty.Register(nameof (BBCode), typeof (string), typeof (BBCodeBlock), new PropertyMetadata(new PropertyChangedCallback(BBCodeBlock.OnBBCodeChanged)));
    public static DependencyProperty LinkNavigatorProperty = DependencyProperty.Register(nameof (LinkNavigator), typeof (ILinkNavigator), typeof (BBCodeBlock), new PropertyMetadata((object) new DefaultLinkNavigator(), new PropertyChangedCallback(BBCodeBlock.OnLinkNavigatorChanged)));
    private bool dirty;

    public BBCodeBlock()
    {
      this.DefaultStyleKey = (object) typeof (BBCodeBlock);
      this.AddHandler(FrameworkContentElement.LoadedEvent, (Delegate) new RoutedEventHandler(this.OnLoaded));
      this.AddHandler(Hyperlink.RequestNavigateEvent, (Delegate) new RequestNavigateEventHandler(this.OnRequestNavigate));
    }

    private static void OnBBCodeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e) => ((BBCodeBlock) o).UpdateDirty();

    private static void OnLinkNavigatorChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      if (e.NewValue == null)
        throw new ArgumentNullException("LinkNavigator");
      ((BBCodeBlock) o).UpdateDirty();
    }

    private void OnLoaded(object o, EventArgs e) => this.Update();

    private void UpdateDirty()
    {
      this.dirty = true;
      this.Update();
    }

    private void Update()
    {
      if (!this.IsLoaded || !this.dirty)
        return;
      string bbCode = this.BBCode;
      this.Inlines.Clear();
      if (!string.IsNullOrWhiteSpace(bbCode))
      {
        Inline inline;
        try
        {
          inline = (Inline) new BBCodeParser(bbCode, (FrameworkElement) this)
          {
            Commands = this.LinkNavigator.Commands
          }.Parse();
        }
        catch (Exception ex)
        {
          inline = (Inline) new Run()
          {
            Text = bbCode
          };
        }
        this.Inlines.Add(inline);
      }
      this.dirty = false;
    }

    private void OnRequestNavigate(object sender, RequestNavigateEventArgs e)
    {
      try
      {
        this.LinkNavigator.Navigate(e.Uri, (FrameworkElement) this, e.Target);
      }
      catch (Exception ex)
      {
        int num = (int) ModernDialog.ShowMessage(ex.Message, Resources.NavigationFailed, MessageBoxButton.OK);
      }
    }

    public string BBCode
    {
      get => (string) this.GetValue(BBCodeBlock.BBCodeProperty);
      set => this.SetValue(BBCodeBlock.BBCodeProperty, (object) value);
    }

    public ILinkNavigator LinkNavigator
    {
      get => (ILinkNavigator) this.GetValue(BBCodeBlock.LinkNavigatorProperty);
      set => this.SetValue(BBCodeBlock.LinkNavigatorProperty, (object) value);
    }
  }
}
