// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Presentation.LinkGroup
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

namespace FirstFloor.ModernUI.Presentation
{
  public class LinkGroup : Displayable
  {
    private string groupKey;
    private Link selectedLink;
    private LinkCollection links = new LinkCollection();

    public string GroupKey
    {
      get => this.groupKey;
      set
      {
        if (!(this.groupKey != value))
          return;
        this.groupKey = value;
        this.OnPropertyChanged(nameof (GroupKey));
      }
    }

    internal Link SelectedLink
    {
      get => this.selectedLink;
      set
      {
        if (this.selectedLink == value)
          return;
        this.selectedLink = value;
        this.OnPropertyChanged(nameof (SelectedLink));
      }
    }

    public LinkCollection Links => this.links;
  }
}
