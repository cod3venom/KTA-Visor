// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.ModernTab
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Presentation;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FirstFloor.ModernUI.Windows.Controls
{
  public class ModernTab : Control
  {
    public static readonly DependencyProperty ContentLoaderProperty = DependencyProperty.Register(nameof (ContentLoader), typeof (IContentLoader), typeof (ModernTab), new PropertyMetadata((object) new DefaultContentLoader()));
    public static readonly DependencyProperty LayoutProperty = DependencyProperty.Register(nameof (Layout), typeof (TabLayout), typeof (ModernTab), new PropertyMetadata((object) TabLayout.Tab));
    public static readonly DependencyProperty ListWidthProperty = DependencyProperty.Register(nameof (ListWidth), typeof (GridLength), typeof (ModernTab), new PropertyMetadata((object) new GridLength(170.0)));
    public static readonly DependencyProperty LinksProperty = DependencyProperty.Register(nameof (Links), typeof (LinkCollection), typeof (ModernTab), new PropertyMetadata(new PropertyChangedCallback(ModernTab.OnLinksChanged)));
    public static readonly DependencyProperty SelectedSourceProperty = DependencyProperty.Register(nameof (SelectedSource), typeof (Uri), typeof (ModernTab), new PropertyMetadata(new PropertyChangedCallback(ModernTab.OnSelectedSourceChanged)));
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof (Title), typeof (string), typeof (ModernTab));
    private ListBox linkList;

    public event EventHandler<SourceEventArgs> SelectedSourceChanged;

    public ModernTab()
    {
      this.DefaultStyleKey = (object) typeof (ModernTab);
      this.SetCurrentValue(ModernTab.LinksProperty, (object) new LinkCollection());
    }

    private static void OnLinksChanged(DependencyObject o, DependencyPropertyChangedEventArgs e) => ((ModernTab) o).UpdateSelection();

    private static void OnSelectedSourceChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      ((ModernTab) o).OnSelectedSourceChanged((Uri) e.OldValue, (Uri) e.NewValue);
    }

    private void OnSelectedSourceChanged(Uri oldValue, Uri newValue)
    {
      this.UpdateSelection();
      EventHandler<SourceEventArgs> selectedSourceChanged = this.SelectedSourceChanged;
      if (selectedSourceChanged == null)
        return;
      selectedSourceChanged((object) this, new SourceEventArgs(newValue));
    }

    private void UpdateSelection()
    {
      if (this.linkList == null || this.Links == null)
        return;
      this.linkList.SelectedItem = (object) this.Links.FirstOrDefault<Link>((Func<Link, bool>) (l => l.Source == this.SelectedSource));
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      if (this.linkList != null)
        this.linkList.SelectionChanged -= new SelectionChangedEventHandler(this.OnLinkListSelectionChanged);
      this.linkList = this.GetTemplateChild("LinkList") as ListBox;
      if (this.linkList != null)
        this.linkList.SelectionChanged += new SelectionChangedEventHandler(this.OnLinkListSelectionChanged);
      this.UpdateSelection();
    }

    private void OnLinkListSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (!(this.linkList.SelectedItem is Link selectedItem) || !(selectedItem.Source != this.SelectedSource))
        return;
      this.SetCurrentValue(ModernTab.SelectedSourceProperty, (object) selectedItem.Source);
    }

    public IContentLoader ContentLoader
    {
      get => (IContentLoader) this.GetValue(ModernTab.ContentLoaderProperty);
      set => this.SetValue(ModernTab.ContentLoaderProperty, (object) value);
    }

    public TabLayout Layout
    {
      get => (TabLayout) this.GetValue(ModernTab.LayoutProperty);
      set => this.SetValue(ModernTab.LayoutProperty, (object) value);
    }

    public LinkCollection Links
    {
      get => (LinkCollection) this.GetValue(ModernTab.LinksProperty);
      set => this.SetValue(ModernTab.LinksProperty, (object) value);
    }

    public GridLength ListWidth
    {
      get => (GridLength) this.GetValue(ModernTab.ListWidthProperty);
      set => this.SetValue(ModernTab.ListWidthProperty, (object) value);
    }

    public Uri SelectedSource
    {
      get => (Uri) this.GetValue(ModernTab.SelectedSourceProperty);
      set => this.SetValue(ModernTab.SelectedSourceProperty, (object) value);
    }

    public string Title
    {
      get => (string) this.GetValue(ModernTab.TitleProperty);
      set => this.SetValue(ModernTab.TitleProperty, (object) value);
    }
  }
}
