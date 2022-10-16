// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.ModernButton
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FirstFloor.ModernUI.Windows.Controls
{
  public class ModernButton : Button
  {
    public static readonly DependencyProperty EllipseDiameterProperty = DependencyProperty.Register(nameof (EllipseDiameter), typeof (double), typeof (ModernButton), new PropertyMetadata((object) 22.0));
    public static readonly DependencyProperty EllipseStrokeThicknessProperty = DependencyProperty.Register(nameof (EllipseStrokeThickness), typeof (double), typeof (ModernButton), new PropertyMetadata((object) 1.0));
    public static readonly DependencyProperty IconDataProperty = DependencyProperty.Register(nameof (IconData), typeof (Geometry), typeof (ModernButton));
    public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(nameof (IconHeight), typeof (double), typeof (ModernButton), new PropertyMetadata((object) 12.0));
    public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(nameof (IconWidth), typeof (double), typeof (ModernButton), new PropertyMetadata((object) 12.0));

    public ModernButton() => this.DefaultStyleKey = (object) typeof (ModernButton);

    public double EllipseDiameter
    {
      get => (double) this.GetValue(ModernButton.EllipseDiameterProperty);
      set => this.SetValue(ModernButton.EllipseDiameterProperty, (object) value);
    }

    public double EllipseStrokeThickness
    {
      get => (double) this.GetValue(ModernButton.EllipseStrokeThicknessProperty);
      set => this.SetValue(ModernButton.EllipseStrokeThicknessProperty, (object) value);
    }

    public Geometry IconData
    {
      get => (Geometry) this.GetValue(ModernButton.IconDataProperty);
      set => this.SetValue(ModernButton.IconDataProperty, (object) value);
    }

    public double IconHeight
    {
      get => (double) this.GetValue(ModernButton.IconHeightProperty);
      set => this.SetValue(ModernButton.IconHeightProperty, (object) value);
    }

    public double IconWidth
    {
      get => (double) this.GetValue(ModernButton.IconWidthProperty);
      set => this.SetValue(ModernButton.IconWidthProperty, (object) value);
    }
  }
}
