// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Presentation.CommandBase
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;
using System.Windows.Input;

namespace FirstFloor.ModernUI.Presentation
{
  public abstract class CommandBase : ICommand
  {
    public event EventHandler CanExecuteChanged
    {
      add => CommandManager.RequerySuggested += value;
      remove => CommandManager.RequerySuggested -= value;
    }

    public void OnCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();

    public virtual bool CanExecute(object parameter) => true;

    public void Execute(object parameter)
    {
      if (!this.CanExecute(parameter))
        return;
      this.OnExecute(parameter);
    }

    protected abstract void OnExecute(object parameter);
  }
}
