// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Navigation.NavigationHelper
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FirstFloor.ModernUI.Windows.Navigation
{
  public static class NavigationHelper
  {
    public const string FrameSelf = "_self";
    public const string FrameTop = "_top";
    public const string FrameParent = "_parent";

    public static ModernFrame FindFrame(string name, FrameworkElement context)
    {
      ModernFrame[] source = context != null ? context.AncestorsAndSelf().OfType<ModernFrame>().ToArray<ModernFrame>() : throw new ArgumentNullException(nameof (context));
      if (name == null || name == "_self")
        return ((IEnumerable<ModernFrame>) source).FirstOrDefault<ModernFrame>();
      if (name == "_parent")
        return ((IEnumerable<ModernFrame>) source).Skip<ModernFrame>(1).FirstOrDefault<ModernFrame>();
      if (name == "_top")
        return ((IEnumerable<ModernFrame>) source).LastOrDefault<ModernFrame>();
      frame = ((IEnumerable<ModernFrame>) source).FirstOrDefault<ModernFrame>((Func<ModernFrame, bool>) (f => f.Name == name));
      if (frame == null && !(context.FindName(name) is ModernFrame frame))
      {
        ModernFrame modernFrame = ((IEnumerable<ModernFrame>) source).FirstOrDefault<ModernFrame>();
        if (modernFrame != null && modernFrame.Content != null && modernFrame.Content is FrameworkElement content)
          frame = content.FindName(name) as ModernFrame;
      }
      return frame;
    }

    public static Uri RemoveFragment(Uri uri) => NavigationHelper.RemoveFragment(uri, out string _);

    public static Uri RemoveFragment(Uri uri, out string fragment)
    {
      fragment = (string) null;
      if (uri != (Uri) null)
      {
        string originalString = uri.OriginalString;
        int length = originalString.IndexOf('#');
        if (length != -1)
        {
          fragment = originalString.Substring(length + 1);
          uri = new Uri(originalString.Substring(0, length), uri.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative);
        }
      }
      return uri;
    }

    public static Uri ToUri(object value)
    {
      Uri result = value as Uri;
      return result == (Uri) null && (!(value is string uriString) || !Uri.TryCreate(uriString, UriKind.RelativeOrAbsolute, out result)) ? (Uri) null : result;
    }

    public static bool TryParseUriWithParameters(
      object value,
      out Uri uri,
      out string parameter,
      out string targetName)
    {
      uri = value as Uri;
      parameter = (string) null;
      targetName = (string) null;
      return !(uri == (Uri) null) || NavigationHelper.TryParseUriWithParameters(value as string, out uri, out parameter, out targetName);
    }

    public static bool TryParseUriWithParameters(
      string value,
      out Uri uri,
      out string parameter,
      out string targetName)
    {
      uri = (Uri) null;
      parameter = (string) null;
      targetName = (string) null;
      if (value == null)
        return false;
      string uriString = value;
      string[] strArray = uriString.Split(new char[1]{ '|' }, 3);
      if (strArray.Length == 3)
      {
        uriString = strArray[0];
        parameter = Uri.UnescapeDataString(strArray[1]);
        targetName = Uri.UnescapeDataString(strArray[2]);
      }
      else if (strArray.Length == 2)
      {
        uriString = strArray[0];
        parameter = Uri.UnescapeDataString(strArray[1]);
      }
      return Uri.TryCreate(uriString, UriKind.RelativeOrAbsolute, out uri);
    }
  }
}
