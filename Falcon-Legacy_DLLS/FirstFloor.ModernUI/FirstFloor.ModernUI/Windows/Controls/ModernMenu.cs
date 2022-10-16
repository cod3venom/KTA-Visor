// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.ModernMenu
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FirstFloor.ModernUI.Windows.Controls
{
  public class ModernMenu : Control
  {
    public static readonly DependencyProperty LinkGroupsProperty = DependencyProperty.Register(nameof (LinkGroups), typeof (LinkGroupCollection), typeof (ModernMenu), new PropertyMetadata(new PropertyChangedCallback(ModernMenu.OnLinkGroupsChanged)));
    public static readonly DependencyProperty SelectedLinkGroupProperty = DependencyProperty.Register(nameof (SelectedLinkGroup), typeof (LinkGroup), typeof (ModernMenu), new PropertyMetadata(new PropertyChangedCallback(ModernMenu.OnSelectedLinkGroupChanged)));
    public static readonly DependencyProperty SelectedLinkProperty = DependencyProperty.Register(nameof (SelectedLink), typeof (Link), typeof (ModernMenu), new PropertyMetadata(new PropertyChangedCallback(ModernMenu.OnSelectedLinkChanged)));
    public static readonly DependencyProperty SelectedSourceProperty = DependencyProperty.Register(nameof (SelectedSource), typeof (Uri), typeof (ModernMenu), new PropertyMetadata(new PropertyChangedCallback(ModernMenu.OnSelectedSourceChanged)));
    private static readonly DependencyPropertyKey VisibleLinkGroupsPropertyKey = DependencyProperty.RegisterReadOnly(nameof (VisibleLinkGroups), typeof (ReadOnlyLinkGroupCollection), typeof (ModernMenu), (PropertyMetadata) null);
    public static readonly DependencyProperty VisibleLinkGroupsProperty = ModernMenu.VisibleLinkGroupsPropertyKey.DependencyProperty;
    public static readonly DependencyProperty EllipseDiameterProperty = DependencyProperty.Register(nameof (EllipseDiameter), typeof (double), typeof (ModernToggleButton), new PropertyMetadata((object) 22.0));
    public static readonly DependencyProperty EllipseStrokeThicknessProperty = DependencyProperty.Register(nameof (EllipseStrokeThickness), typeof (double), typeof (ModernToggleButton), new PropertyMetadata((object) 1.0));
    private Dictionary<string, ReadOnlyLinkGroupCollection> groupMap = new Dictionary<string, ReadOnlyLinkGroupCollection>();
    private bool isSelecting;

    public event EventHandler<SourceEventArgs> SelectedSourceChanged;

    public ModernMenu()
    {
      this.DefaultStyleKey = (object) typeof (ModernMenu);
      this.SetCurrentValue(ModernMenu.LinkGroupsProperty, (object) new LinkGroupCollection());
    }

    private static void OnLinkGroupsChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      ((ModernMenu) o).OnLinkGroupsChanged((LinkGroupCollection) e.OldValue, (LinkGroupCollection) e.NewValue);
    }

    private void OnLinkGroupsChanged(LinkGroupCollection oldValue, LinkGroupCollection newValue)
    {
      if (oldValue != null)
        oldValue.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.OnLinkGroupsCollectionChanged);
      if (newValue != null)
        newValue.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnLinkGroupsCollectionChanged);
      this.RebuildMenu(newValue);
    }

    private static void OnSelectedLinkGroupChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      LinkGroup newValue = (LinkGroup) e.NewValue;
      Link selectedLink = (Link) null;
      if (newValue != null)
      {
        selectedLink = newValue.SelectedLink;
        if (newValue.Links != null)
        {
          if (selectedLink != null && !newValue.Links.Any<Link>((Func<Link, bool>) (l => l == selectedLink)))
            selectedLink = (Link) null;
          if (selectedLink == null)
            selectedLink = newValue.Links.FirstOrDefault<Link>();
        }
      }
      o.SetCurrentValue(ModernMenu.SelectedLinkProperty, (object) selectedLink);
    }

    private static void OnSelectedLinkChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      Link newValue = (Link) e.NewValue;
      Uri uri = (Uri) null;
      if (newValue != null)
        uri = newValue.Source;
      o.SetCurrentValue(ModernMenu.SelectedSourceProperty, (object) uri);
    }

    private void OnLinkGroupsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => this.RebuildMenu((LinkGroupCollection) sender);

    private static void OnSelectedSourceChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      ((ModernMenu) o).OnSelectedSourceChanged((Uri) e.OldValue, (Uri) e.NewValue);
    }

    private void OnSelectedSourceChanged(Uri oldValue, Uri newValue)
    {
      Uri uri1 = NavigationHelper.RemoveFragment(oldValue);
      Uri uri2 = NavigationHelper.RemoveFragment(newValue);
      if (!this.isSelecting)
      {
        if (uri2 != (Uri) null && uri2.Equals((object) uri1))
          return;
        this.UpdateSelection();
      }
      EventHandler<SourceEventArgs> selectedSourceChanged = this.SelectedSourceChanged;
      if (selectedSourceChanged == null)
        return;
      selectedSourceChanged((object) this, new SourceEventArgs(newValue));
    }

    public LinkGroupCollection LinkGroups
    {
      get => (LinkGroupCollection) this.GetValue(ModernMenu.LinkGroupsProperty);
      set => this.SetValue(ModernMenu.LinkGroupsProperty, (object) value);
    }

    public Link SelectedLink
    {
      get => (Link) this.GetValue(ModernMenu.SelectedLinkProperty);
      set => this.SetValue(ModernMenu.SelectedLinkProperty, (object) value);
    }

    public Uri SelectedSource
    {
      get => (Uri) this.GetValue(ModernMenu.SelectedSourceProperty);
      set => this.SetValue(ModernMenu.SelectedSourceProperty, (object) value);
    }

    public LinkGroup SelectedLinkGroup => (LinkGroup) this.GetValue(ModernMenu.SelectedLinkGroupProperty);

    public double EllipseDiameter
    {
      get => (double) this.GetValue(ModernMenu.EllipseDiameterProperty);
      set => this.SetValue(ModernMenu.EllipseDiameterProperty, (object) value);
    }

    public double EllipseStrokeThickness
    {
      get => (double) this.GetValue(ModernMenu.EllipseStrokeThicknessProperty);
      set => this.SetValue(ModernMenu.EllipseStrokeThicknessProperty, (object) value);
    }

    public ReadOnlyLinkGroupCollection VisibleLinkGroups => (ReadOnlyLinkGroupCollection) this.GetValue(ModernMenu.VisibleLinkGroupsProperty);

    private static string GetGroupKey(LinkGroup group) => group.GroupKey ?? "<null>";

    private void RebuildMenu(LinkGroupCollection groups)
    {
      this.groupMap.Clear();
      if (groups != null)
      {
        foreach (LinkGroup group in (Collection<LinkGroup>) groups)
        {
          string groupKey = ModernMenu.GetGroupKey(group);
          ReadOnlyLinkGroupCollection linkGroupCollection;
          if (!this.groupMap.TryGetValue(groupKey, out linkGroupCollection))
          {
            linkGroupCollection = new ReadOnlyLinkGroupCollection(new LinkGroupCollection());
            this.groupMap.Add(groupKey, linkGroupCollection);
          }
          linkGroupCollection.List.Add(group);
        }
      }
      this.UpdateSelection();
    }

    private void UpdateSelection()
    {
      LinkGroup selectedGroup = (LinkGroup) null;
      Link link = (Link) null;
      Uri sourceNoFragment = NavigationHelper.RemoveFragment(this.SelectedSource);
      if (this.LinkGroups != null)
      {
        var data = this.LinkGroups.SelectMany((Func<LinkGroup, IEnumerable<Link>>) (g => (IEnumerable<Link>) g.Links), (g, l) => new
        {
          g = g,
          l = l
        }).Where(_param1 => _param1.l.Source == sourceNoFragment).Select(_param1 => new
        {
          Group = _param1.g,
          Link = _param1.l
        }).FirstOrDefault();
        if (data != null)
        {
          selectedGroup = data.Group;
          link = data.Link;
        }
        else
        {
          selectedGroup = this.SelectedLinkGroup;
          if (!this.LinkGroups.Any<LinkGroup>((Func<LinkGroup, bool>) (g => g == selectedGroup)))
            selectedGroup = this.LinkGroups.FirstOrDefault<LinkGroup>();
        }
      }
      ReadOnlyLinkGroupCollection linkGroupCollection = (ReadOnlyLinkGroupCollection) null;
      if (selectedGroup != null)
      {
        selectedGroup.SelectedLink = link;
        this.groupMap.TryGetValue(ModernMenu.GetGroupKey(selectedGroup), out linkGroupCollection);
      }
      this.isSelecting = true;
      this.SetValue(ModernMenu.VisibleLinkGroupsPropertyKey, (object) linkGroupCollection);
      this.SetCurrentValue(ModernMenu.SelectedLinkGroupProperty, (object) selectedGroup);
      this.SetCurrentValue(ModernMenu.SelectedLinkProperty, (object) link);
      this.isSelecting = false;
    }
  }
}
