// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.ModernToggleButton
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FirstFloor.ModernUI.Windows.Controls
{
  public class ModernToggleButton : ToggleButton
  {
    public static readonly DependencyProperty EllipseDiameterProperty = DependencyProperty.Register(nameof (EllipseDiameter), typeof (double), typeof (ModernToggleButton), new PropertyMetadata((object) 22.0));
    public static readonly DependencyProperty EllipseStrokeThicknessProperty = DependencyProperty.Register(nameof (EllipseStrokeThickness), typeof (double), typeof (ModernToggleButton), new PropertyMetadata((object) 1.0));
    public static readonly DependencyProperty IconDataProperty = DependencyProperty.Register(nameof (IconData), typeof (Geometry), typeof (ModernToggleButton));
    public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(nameof (IconHeight), typeof (double), typeof (ModernToggleButton), new PropertyMetadata((object) 12.0));
    public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(nameof (IconWidth), typeof (double), typeof (ModernToggleButton), new PropertyMetadata((object) 12.0));

    public ModernToggleButton() => this.DefaultStyleKey = (object) typeof (ModernToggleButton);

    public double EllipseDiameter
    {
      get => (double) this.GetValue(ModernToggleButton.EllipseDiameterProperty);
      set => this.SetValue(ModernToggleButton.EllipseDiameterProperty, (object) value);
    }

    public double EllipseStrokeThickness
    {
      get => (double) this.GetValue(ModernToggleButton.EllipseStrokeThicknessProperty);
      set => this.SetValue(ModernToggleButton.EllipseStrokeThicknessProperty, (object) value);
    }

    public Geometry IconData
    {
      get => (Geometry) this.GetValue(ModernToggleButton.IconDataProperty);
      set => this.SetValue(ModernToggleButton.IconDataProperty, (object) value);
    }

    public double IconHeight
    {
      get => (double) this.GetValue(ModernToggleButton.IconHeightProperty);
      set => this.SetValue(ModernToggleButton.IconHeightProperty, (object) value);
    }

    public double IconWidth
    {
      get => (double) this.GetValue(ModernToggleButton.IconWidthProperty);
      set => this.SetValue(ModernToggleButton.IconWidthProperty, (object) value);
    }
  }
}
