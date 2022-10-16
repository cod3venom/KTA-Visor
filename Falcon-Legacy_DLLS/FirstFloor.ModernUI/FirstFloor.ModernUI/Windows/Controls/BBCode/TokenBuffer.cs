// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.BBCode.TokenBuffer
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;
using System.Collections.Generic;

namespace FirstFloor.ModernUI.Windows.Controls.BBCode
{
  internal class TokenBuffer
  {
    private List<Token> tokens = new List<Token>();
    private int position;

    public TokenBuffer(Lexer lexer)
    {
      if (lexer == null)
        throw new ArgumentNullException(nameof (lexer));
      Token token;
      do
      {
        token = lexer.NextToken();
        this.tokens.Add(token);
      }
      while (token.TokenType != int.MaxValue);
    }

    public Token LA(int count)
    {
      int index = this.position + count - 1;
      return index < this.tokens.Count ? this.tokens[index] : Token.End;
    }

    public void Consume() => ++this.position;
  }
}
