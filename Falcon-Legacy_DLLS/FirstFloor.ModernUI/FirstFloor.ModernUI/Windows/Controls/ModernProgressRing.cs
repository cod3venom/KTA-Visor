// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.ModernProgressRing
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System.Windows;
using System.Windows.Controls;

namespace FirstFloor.ModernUI.Windows.Controls
{
  [TemplateVisualState(GroupName = "ActiveStates", Name = "Inactive")]
  [TemplateVisualState(GroupName = "ActiveStates", Name = "Active")]
  public class ModernProgressRing : Control
  {
    private const string GroupActiveStates = "ActiveStates";
    private const string StateInactive = "Inactive";
    private const string StateActive = "Active";
    public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(nameof (IsActive), typeof (bool), typeof (ModernProgressRing), new PropertyMetadata((object) false, new PropertyChangedCallback(ModernProgressRing.OnIsActiveChanged)));

    public ModernProgressRing() => this.DefaultStyleKey = (object) typeof (ModernProgressRing);

    private void GotoCurrentState(bool animate) => VisualStateManager.GoToState((FrameworkElement) this, this.IsActive ? "Active" : "Inactive", animate);

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.GotoCurrentState(false);
    }

    private static void OnIsActiveChanged(DependencyObject o, DependencyPropertyChangedEventArgs e) => ((ModernProgressRing) o).GotoCurrentState(true);

    public bool IsActive
    {
      get => (bool) this.GetValue(ModernProgressRing.IsActiveProperty);
      set => this.SetValue(ModernProgressRing.IsActiveProperty, (object) value);
    }
  }
}
