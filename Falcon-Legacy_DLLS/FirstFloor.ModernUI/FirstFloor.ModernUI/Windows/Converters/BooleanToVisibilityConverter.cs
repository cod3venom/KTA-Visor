// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Converters.BooleanToVisibilityConverter
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FirstFloor.ModernUI.Windows.Converters
{
  public class BooleanToVisibilityConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      flag = false;
      if (!(value is bool flag) && value is bool? nullable)
        flag = nullable.HasValue && nullable.Value;
      return parameter as string == "inverse" ? (object) (Visibility) (flag ? 2 : 0) : (object) (Visibility) (flag ? 0 : 2);
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      throw new NotSupportedException();
    }
  }
}
