// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Presentation.RelayCommand
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;

namespace FirstFloor.ModernUI.Presentation
{
  public class RelayCommand : CommandBase
  {
    private Action<object> execute;
    private Func<object, bool> canExecute;

    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
      if (execute == null)
        throw new ArgumentNullException(nameof (execute));
      if (canExecute == null)
        canExecute = (Func<object, bool>) (o => true);
      this.execute = execute;
      this.canExecute = canExecute;
    }

    public override bool CanExecute(object parameter) => this.canExecute(parameter);

    protected override void OnExecute(object parameter) => this.execute(parameter);
  }
}
