// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.BBCode.Parser`1
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;

namespace FirstFloor.ModernUI.Windows.Controls.BBCode
{
  internal abstract class Parser<TResult>
  {
    private TokenBuffer buffer;

    protected Parser(Lexer lexer) => this.buffer = lexer != null ? new TokenBuffer(lexer) : throw new ArgumentNullException(nameof (lexer));

    protected Token LA(int count) => this.buffer.LA(count);

    protected void Consume() => this.buffer.Consume();

    protected bool IsInRange(params int[] tokenTypes)
    {
      if (tokenTypes == null)
        return false;
      Token token = this.LA(1);
      for (int index = 0; index < tokenTypes.Length; ++index)
      {
        if (token.TokenType == tokenTypes[index])
          return true;
      }
      return false;
    }

    protected void Match(int tokenType)
    {
      if (this.LA(1).TokenType != tokenType)
        throw new ParseException("Token mismatch");
      this.Consume();
    }

    protected void MatchNot(int tokenType)
    {
      if (this.LA(1).TokenType == tokenType)
        throw new ParseException("Token mismatch");
      this.Consume();
    }

    protected void MatchRange(int[] tokenTypes, int minOccurs, int maxOccurs)
    {
      int num = 0;
      while (this.IsInRange(tokenTypes))
      {
        this.Consume();
        ++num;
      }
      if (num < minOccurs || num > maxOccurs)
        throw new ParseException("Invalid number of tokens");
    }

    public abstract TResult Parse();
  }
}
