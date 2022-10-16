// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.DpiInformation
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System.Windows;

namespace FirstFloor.ModernUI.Windows.Controls
{
  public class DpiInformation
  {
    internal DpiInformation(double wpfDpiX, double wpfDpiY)
    {
      this.WpfDpiX = wpfDpiX;
      this.WpfDpiY = wpfDpiY;
      this.ScaleX = 1.0;
      this.ScaleY = 1.0;
    }

    public double WpfDpiX { get; private set; }

    public double WpfDpiY { get; private set; }

    public double? MonitorDpiX { get; private set; }

    public double? MonitorDpiY { get; private set; }

    public double ScaleX { get; private set; }

    public double ScaleY { get; private set; }

    internal Vector UpdateMonitorDpi(double dpiX, double dpiY)
    {
      double? nullable = this.MonitorDpiX;
      double num1 = nullable ?? this.WpfDpiX;
      nullable = this.MonitorDpiY;
      double num2 = nullable ?? this.WpfDpiY;
      this.MonitorDpiX = new double?(dpiX);
      this.MonitorDpiY = new double?(dpiY);
      this.ScaleX = dpiX / this.WpfDpiX;
      this.ScaleY = dpiY / this.WpfDpiY;
      return new Vector(dpiX / num1, dpiY / num2);
    }
  }
}
