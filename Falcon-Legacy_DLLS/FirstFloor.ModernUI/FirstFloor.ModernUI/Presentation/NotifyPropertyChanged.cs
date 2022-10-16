// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Presentation.NotifyPropertyChanged
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FirstFloor.ModernUI.Presentation
{
  public abstract class NotifyPropertyChanged : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
      if (object.Equals((object) storage, (object) value))
        return false;
      storage = value;
      this.OnPropertyChanged(propertyName);
      return true;
    }
  }
}
