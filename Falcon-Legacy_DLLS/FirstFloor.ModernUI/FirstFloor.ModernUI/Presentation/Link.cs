// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Presentation.Link
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;

namespace FirstFloor.ModernUI.Presentation
{
  public class Link : Displayable
  {
    private Uri source;

    public Uri Source
    {
      get => this.source;
      set
      {
        if (!(this.source != value))
          return;
        this.source = value;
        this.OnPropertyChanged(nameof (Source));
      }
    }
  }
}
