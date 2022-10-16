// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.DataGridTextColumn
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System.Windows;

namespace FirstFloor.ModernUI.Windows.Controls
{
  public class DataGridTextColumn : System.Windows.Controls.DataGridTextColumn
  {
    public DataGridTextColumn()
    {
      this.ElementStyle = Application.Current.Resources[(object) "DataGridTextStyle"] as Style;
      this.EditingElementStyle = Application.Current.Resources[(object) "DataGridEditingTextStyle"] as Style;
    }
  }
}
