// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.DefaultContentLoader
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FirstFloor.ModernUI.Windows
{
  public class DefaultContentLoader : IContentLoader
  {
    public Task<object> LoadContentAsync(Uri uri, CancellationToken cancellationToken)
    {
      if (!Application.Current.Dispatcher.CheckAccess())
        throw new InvalidOperationException(Resources.UIThreadRequired);
      TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();
      return Task.Factory.StartNew<object>((Func<object>) (() => this.LoadContent(uri)), cancellationToken, TaskCreationOptions.None, scheduler);
    }

    protected virtual object LoadContent(Uri uri) => ModernUIHelper.IsInDesignMode ? (object) null : Application.LoadComponent(uri);
  }
}
