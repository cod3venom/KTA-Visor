// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Presentation.ReadOnlyLinkGroupCollectionIcon
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System.Collections.ObjectModel;

namespace FirstFloor.ModernUI.Presentation
{
  public class ReadOnlyLinkGroupCollectionIcon : ReadOnlyObservableCollection<LinkGroupIcon>
  {
    public ReadOnlyLinkGroupCollectionIcon(LinkGroupCollectionIcon list)
      : base((ObservableCollection<LinkGroupIcon>) list)
    {
      this.List = list;
    }

    internal LinkGroupCollectionIcon List { get; private set; }
  }
}
