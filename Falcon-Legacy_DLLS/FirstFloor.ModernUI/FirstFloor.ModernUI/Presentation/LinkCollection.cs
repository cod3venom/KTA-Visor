// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Presentation.LinkCollection
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FirstFloor.ModernUI.Presentation
{
  public class LinkCollection : ObservableCollection<Link>
  {
    public LinkCollection()
    {
    }

    public LinkCollection(IEnumerable<Link> links)
    {
      if (links == null)
        throw new ArgumentNullException(nameof (links));
      foreach (Link link in links)
        this.Add(link);
    }
  }
}
