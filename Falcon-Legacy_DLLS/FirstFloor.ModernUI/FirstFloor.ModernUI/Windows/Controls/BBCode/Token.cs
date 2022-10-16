// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.BBCode.Token
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;
using System.Globalization;

namespace FirstFloor.ModernUI.Windows.Controls.BBCode
{
  internal class Token
  {
    public static readonly Token End = new Token(string.Empty, int.MaxValue);
    private string value;
    private int tokenType;

    public Token(string value, int tokenType)
    {
      this.value = value;
      this.tokenType = tokenType;
    }

    public string Value => this.value;

    public int TokenType => this.tokenType;

    public override string ToString() => string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}: {1}", new object[2]
    {
      (object) this.tokenType,
      (object) this.value
    });
  }
}
