// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.BBCode.ParseException
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;

namespace FirstFloor.ModernUI.Windows.Controls.BBCode
{
  internal class ParseException : Exception
  {
    public ParseException()
    {
    }

    public ParseException(string message)
      : base(message)
    {
    }

    public ParseException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
