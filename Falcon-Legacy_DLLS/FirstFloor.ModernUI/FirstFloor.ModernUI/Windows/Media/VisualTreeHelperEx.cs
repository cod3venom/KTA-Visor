// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Media.VisualTreeHelperEx
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace FirstFloor.ModernUI.Windows.Media
{
  public static class VisualTreeHelperEx
  {
    public static VisualStateGroup TryGetVisualStateGroup(
      this DependencyObject dependencyObject,
      string groupName)
    {
      FrameworkElement implementationRoot = dependencyObject.GetImplementationRoot();
      return implementationRoot == null ? (VisualStateGroup) null : VisualStateManager.GetVisualStateGroups(implementationRoot).OfType<VisualStateGroup>().Where<VisualStateGroup>((Func<VisualStateGroup, bool>) (group => string.CompareOrdinal(groupName, group.Name) == 0)).FirstOrDefault<VisualStateGroup>();
    }

    public static FrameworkElement GetImplementationRoot(
      this DependencyObject dependencyObject)
    {
      return 1 != VisualTreeHelper.GetChildrenCount(dependencyObject) ? (FrameworkElement) null : VisualTreeHelper.GetChild(dependencyObject, 0) as FrameworkElement;
    }

    public static IEnumerable<DependencyObject> Ancestors(
      this DependencyObject dependencyObject)
    {
      DependencyObject parent = dependencyObject;
      while (true)
      {
        parent = parent.GetParent();
        if (parent != null)
          yield return parent;
        else
          break;
      }
    }

    public static IEnumerable<DependencyObject> AncestorsAndSelf(
      this DependencyObject dependencyObject)
    {
      if (dependencyObject == null)
        throw new ArgumentNullException(nameof (dependencyObject));
      for (DependencyObject parent = dependencyObject; parent != null; parent = parent.GetParent())
        yield return parent;
    }

    public static DependencyObject GetParent(this DependencyObject dependencyObject)
    {
      if (dependencyObject == null)
        throw new ArgumentNullException(nameof (dependencyObject));
      if (!(dependencyObject is ContentElement reference))
        return VisualTreeHelper.GetParent(dependencyObject);
      DependencyObject parent = ContentOperations.GetParent(reference);
      if (parent != null)
        return parent;
      return !(reference is FrameworkContentElement frameworkContentElement) ? (DependencyObject) null : frameworkContentElement.Parent;
    }
  }
}
