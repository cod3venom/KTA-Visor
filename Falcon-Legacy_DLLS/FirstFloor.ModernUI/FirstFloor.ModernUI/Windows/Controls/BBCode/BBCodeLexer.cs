// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.BBCode.BBCodeLexer
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

namespace FirstFloor.ModernUI.Windows.Controls.BBCode
{
  internal class BBCodeLexer : Lexer
  {
    private static readonly char[] QuoteChars = new char[2]
    {
      '\'',
      '"'
    };
    private static readonly char[] WhitespaceChars = new char[2]
    {
      ' ',
      '\t'
    };
    private static readonly char[] NewlineChars = new char[2]
    {
      '\r',
      '\n'
    };
    public const int TokenStartTag = 0;
    public const int TokenEndTag = 1;
    public const int TokenAttribute = 2;
    public const int TokenText = 3;
    public const int TokenLineBreak = 4;
    public const int StateNormal = 0;
    public const int StateTag = 1;

    public BBCodeLexer(string value)
      : base(value)
    {
    }

    private bool IsTagNameChar()
    {
      if (this.IsInRange('A', 'Z') || this.IsInRange('a', 'z'))
        return true;
      return this.IsInRange(new char[1]{ '*' });
    }

    private Token OpenTag()
    {
      this.Match('[');
      this.Mark();
      while (this.IsTagNameChar())
        this.Consume();
      return new Token(this.GetMark(), 0);
    }

    private Token CloseTag()
    {
      this.Match('[');
      this.Match('/');
      this.Mark();
      while (this.IsTagNameChar())
        this.Consume();
      Token token = new Token(this.GetMark(), 1);
      this.Match(']');
      return token;
    }

    private Token Newline()
    {
      this.Match('\r', 0, 1);
      this.Match('\n');
      return new Token(string.Empty, 4);
    }

    private Token Text()
    {
      this.Mark();
      while (this.LA(1) != '[' && this.LA(1) != char.MaxValue && !this.IsInRange(BBCodeLexer.NewlineChars))
        this.Consume();
      return new Token(this.GetMark(), 3);
    }

    private Token Attribute()
    {
      this.Match('=');
      while (this.IsInRange(BBCodeLexer.WhitespaceChars))
        this.Consume();
      Token token;
      if (this.IsInRange(BBCodeLexer.QuoteChars))
      {
        this.Consume();
        this.Mark();
        while (!this.IsInRange(BBCodeLexer.QuoteChars))
          this.Consume();
        token = new Token(this.GetMark(), 2);
        this.Consume();
      }
      else
      {
        this.Mark();
        while (!this.IsInRange(BBCodeLexer.WhitespaceChars) && this.LA(1) != ']' && this.LA(1) != char.MaxValue)
          this.Consume();
        token = new Token(this.GetMark(), 2);
      }
      while (this.IsInRange(BBCodeLexer.WhitespaceChars))
        this.Consume();
      return token;
    }

    protected override int DefaultState => 0;

    public override Token NextToken()
    {
      if (this.LA(1) == char.MaxValue)
        return Token.End;
      if (this.State == 0)
      {
        if (this.LA(1) == '[')
        {
          if (this.LA(2) == '/')
            return this.CloseTag();
          Token token = this.OpenTag();
          this.PushState(1);
          return token;
        }
        return this.IsInRange(BBCodeLexer.NewlineChars) ? this.Newline() : this.Text();
      }
      if (this.State != 1)
        throw new ParseException("Invalid state");
      if (this.LA(1) != ']')
        return this.Attribute();
      this.Consume();
      this.PopState();
      return this.NextToken();
    }
  }
}
