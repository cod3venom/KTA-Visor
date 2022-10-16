// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Presentation.Displayable
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

namespace FirstFloor.ModernUI.Presentation
{
  public abstract class Displayable : NotifyPropertyChanged
  {
    private string displayName;
    private string imageSource;
    private string imageMouseHover;
    private string imageSelected;

    public string DisplayName
    {
      get => this.displayName;
      set
      {
        if (!(this.displayName != value))
          return;
        this.displayName = value;
        this.OnPropertyChanged(nameof (DisplayName));
      }
    }

    public string ImageSource
    {
      get => this.imageSource;
      set
      {
        if (!(this.imageSource != value))
          return;
        this.imageSource = value;
        this.OnPropertyChanged(nameof (ImageSource));
      }
    }

    public string ImageMouseHover
    {
      get => this.imageMouseHover;
      set
      {
        if (!(this.imageMouseHover != value))
          return;
        this.imageMouseHover = value;
        this.OnPropertyChanged(nameof (ImageMouseHover));
      }
    }

    public string ImageSelected
    {
      get => this.imageSelected;
      set
      {
        if (!(this.imageSelected != value))
          return;
        this.imageSelected = value;
        this.OnPropertyChanged(nameof (ImageSelected));
      }
    }
  }
}
