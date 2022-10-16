// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Presentation.ReadOnlyLinkGroupCollection
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System.Collections.ObjectModel;

namespace FirstFloor.ModernUI.Presentation
{
  public class ReadOnlyLinkGroupCollection : ReadOnlyObservableCollection<LinkGroup>
  {
    public ReadOnlyLinkGroupCollection(LinkGroupCollection list)
      : base((ObservableCollection<LinkGroup>) list)
    {
      this.List = list;
    }

    internal LinkGroupCollection List { get; private set; }
  }
}
