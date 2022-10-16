// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.ModernMenuIcon
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
  public class ModernMenuIcon : Control
  {
    public static readonly DependencyProperty LinkGroupsIconProperty = DependencyProperty.Register(nameof (LinkGroupsIcon), typeof (LinkGroupCollectionIcon), typeof (ModernMenuIcon), new PropertyMetadata(new PropertyChangedCallback(ModernMenuIcon.OnLinkGroupsChanged)));
    public static readonly DependencyProperty SelectedLinkGroupProperty = DependencyProperty.Register(nameof (SelectedLinkGroup), typeof (LinkGroupIcon), typeof (ModernMenuIcon), new PropertyMetadata(new PropertyChangedCallback(ModernMenuIcon.OnSelectedLinkGroupChanged)));
    public static readonly DependencyProperty SelectedLinkProperty = DependencyProperty.Register(nameof (SelectedLink), typeof (Link), typeof (ModernMenuIcon), new PropertyMetadata(new PropertyChangedCallback(ModernMenuIcon.OnSelectedLinkChanged)));
    public static readonly DependencyProperty SelectedSourceProperty = DependencyProperty.Register(nameof (SelectedSource), typeof (Uri), typeof (ModernMenuIcon), new PropertyMetadata(new PropertyChangedCallback(ModernMenuIcon.OnSelectedSourceChanged)));
    private static readonly DependencyPropertyKey VisibleLinkGroupsPropertyKey = DependencyProperty.RegisterReadOnly(nameof (VisibleLinkGroups), typeof (ReadOnlyLinkGroupCollectionIcon), typeof (ModernMenuIcon), (PropertyMetadata) null);
    public static readonly DependencyProperty VisibleLinkGroupsProperty = ModernMenuIcon.VisibleLinkGroupsPropertyKey.DependencyProperty;
    public static readonly DependencyProperty EllipseDiameterProperty = DependencyProperty.Register(nameof (EllipseDiameter), typeof (double), typeof (ModernMenuIcon), new PropertyMetadata((object) 22.0));
    public static readonly DependencyProperty EllipseStrokeThicknessProperty = DependencyProperty.Register(nameof (EllipseStrokeThickness), typeof (double), typeof (ModernMenuIcon), new PropertyMetadata((object) 1.0));
    private Dictionary<string, ReadOnlyLinkGroupCollectionIcon> groupMap = new Dictionary<string, ReadOnlyLinkGroupCollectionIcon>();
    private bool isSelecting;

    public event EventHandler<SourceEventArgs> SelectedSourceChanged;

    public ModernMenuIcon()
    {
      this.DefaultStyleKey = (object) typeof (ModernMenuIcon);
      this.SetCurrentValue(ModernMenuIcon.LinkGroupsIconProperty, (object) new LinkGroupCollectionIcon());
    }

    private static void OnLinkGroupsChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      ((ModernMenuIcon) o).OnLinkGroupsChanged((LinkGroupCollectionIcon) e.OldValue, (LinkGroupCollectionIcon) e.NewValue);
    }

    private void OnLinkGroupsChanged(
      LinkGroupCollectionIcon oldValue,
      LinkGroupCollectionIcon newValue)
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
      LinkGroupIcon newValue = (LinkGroupIcon) e.NewValue;
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
      o.SetCurrentValue(ModernMenuIcon.SelectedLinkProperty, (object) selectedLink);
    }

    private static void OnSelectedLinkChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      Link newValue = (Link) e.NewValue;
      Uri uri = (Uri) null;
      if (newValue != null)
        uri = newValue.Source;
      o.SetCurrentValue(ModernMenuIcon.SelectedSourceProperty, (object) uri);
    }

    private void OnLinkGroupsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => this.RebuildMenu((LinkGroupCollectionIcon) sender);

    private static void OnSelectedSourceChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      ((ModernMenuIcon) o).OnSelectedSourceChanged((Uri) e.OldValue, (Uri) e.NewValue);
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

    public LinkGroupCollectionIcon LinkGroupsIcon
    {
      get => (LinkGroupCollectionIcon) this.GetValue(ModernMenuIcon.LinkGroupsIconProperty);
      set => this.SetValue(ModernMenuIcon.LinkGroupsIconProperty, (object) value);
    }

    public Link SelectedLink
    {
      get => (Link) this.GetValue(ModernMenuIcon.SelectedLinkProperty);
      set => this.SetValue(ModernMenuIcon.SelectedLinkProperty, (object) value);
    }

    public Uri SelectedSource
    {
      get => (Uri) this.GetValue(ModernMenuIcon.SelectedSourceProperty);
      set => this.SetValue(ModernMenuIcon.SelectedSourceProperty, (object) value);
    }

    public LinkGroupIcon SelectedLinkGroup => (LinkGroupIcon) this.GetValue(ModernMenuIcon.SelectedLinkGroupProperty);

    public double EllipseDiameter
    {
      get => (double) this.GetValue(ModernMenuIcon.EllipseDiameterProperty);
      set => this.SetValue(ModernMenuIcon.EllipseDiameterProperty, (object) value);
    }

    public double EllipseStrokeThickness
    {
      get => (double) this.GetValue(ModernMenuIcon.EllipseStrokeThicknessProperty);
      set => this.SetValue(ModernMenuIcon.EllipseStrokeThicknessProperty, (object) value);
    }

    public ReadOnlyLinkGroupCollectionIcon VisibleLinkGroups => (ReadOnlyLinkGroupCollectionIcon) this.GetValue(ModernMenuIcon.VisibleLinkGroupsProperty);

    private static string GetGroupKey(LinkGroupIcon group) => group.GroupKey ?? "<null>";

    private void RebuildMenu(LinkGroupCollectionIcon groups)
    {
      this.groupMap.Clear();
      if (groups != null)
      {
        foreach (LinkGroupIcon group in (Collection<LinkGroupIcon>) groups)
        {
          string groupKey = ModernMenuIcon.GetGroupKey(group);
          ReadOnlyLinkGroupCollectionIcon groupCollectionIcon;
          if (!this.groupMap.TryGetValue(groupKey, out groupCollectionIcon))
          {
            groupCollectionIcon = new ReadOnlyLinkGroupCollectionIcon(new LinkGroupCollectionIcon());
            this.groupMap.Add(groupKey, groupCollectionIcon);
          }
          groupCollectionIcon.List.Add(group);
        }
      }
      this.UpdateSelection();
    }

    private void UpdateSelection()
    {
      LinkGroupIcon selectedGroup = (LinkGroupIcon) null;
      Link link = (Link) null;
      Uri sourceNoFragment = NavigationHelper.RemoveFragment(this.SelectedSource);
      if (this.LinkGroupsIcon != null)
      {
        var data = this.LinkGroupsIcon.SelectMany((Func<LinkGroupIcon, IEnumerable<Link>>) (g => (IEnumerable<Link>) g.Links), (g, l) => new
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
          if (!this.LinkGroupsIcon.Any<LinkGroupIcon>((Func<LinkGroupIcon, bool>) (g => g == selectedGroup)))
            selectedGroup = this.LinkGroupsIcon.FirstOrDefault<LinkGroupIcon>();
        }
      }
      ReadOnlyLinkGroupCollectionIcon groupCollectionIcon = (ReadOnlyLinkGroupCollectionIcon) null;
      if (selectedGroup != null)
      {
        selectedGroup.SelectedLink = link;
        this.groupMap.TryGetValue(ModernMenuIcon.GetGroupKey(selectedGroup), out groupCollectionIcon);
      }
      this.isSelecting = true;
      this.SetValue(ModernMenuIcon.VisibleLinkGroupsPropertyKey, (object) groupCollectionIcon);
      this.SetCurrentValue(ModernMenuIcon.SelectedLinkGroupProperty, (object) selectedGroup);
      this.SetCurrentValue(ModernMenuIcon.SelectedLinkProperty, (object) link);
      this.isSelecting = false;
    }
  }
}
