// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.BBCode.Lexer
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;
using System.Collections.Generic;

namespace FirstFloor.ModernUI.Windows.Controls.BBCode
{
  internal abstract class Lexer
  {
    public const int TokenEnd = 2147483647;
    private CharBuffer buffer;
    private Stack<int> states;

    protected Lexer(string value)
    {
      this.buffer = new CharBuffer(value);
      this.states = new Stack<int>();
    }

    private static void ValidateOccurence(int count, int minOccurs, int maxOccurs)
    {
      if (count < minOccurs || count > maxOccurs)
        throw new ParseException("Invalid number of characters");
    }

    protected abstract int DefaultState { get; }

    protected int State => this.states.Count > 0 ? this.states.Peek() : this.DefaultState;

    protected void PushState(int state) => this.states.Push(state);

    protected int PopState() => this.states.Pop();

    protected char LA(int count) => this.buffer.LA(count);

    protected void Mark() => this.buffer.Mark();

    protected string GetMark() => this.buffer.GetMark();

    protected void Consume() => this.buffer.Consume();

    protected bool IsInRange(char first, char last)
    {
      char ch = this.LA(1);
      return (int) ch >= (int) first && (int) ch <= (int) last;
    }

    protected bool IsInRange(char[] value)
    {
      if (value == null)
        return false;
      char ch = this.LA(1);
      for (int index = 0; index < value.Length; ++index)
      {
        if ((int) ch == (int) value[index])
          return true;
      }
      return false;
    }

    protected void Match(char value)
    {
      if ((int) this.LA(1) != (int) value)
        throw new ParseException("Character mismatch");
      this.Consume();
    }

    protected void Match(char value, int minOccurs, int maxOccurs)
    {
      int count = 0;
      while ((int) this.LA(1) == (int) value)
      {
        this.Consume();
        ++count;
      }
      Lexer.ValidateOccurence(count, minOccurs, maxOccurs);
    }

    protected void Match(string value)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      for (int index = 0; index < value.Length; ++index)
      {
        if ((int) this.LA(1) != (int) value[index])
          throw new ParseException("String mismatch");
        this.Consume();
      }
    }

    protected void MatchRange(char[] value)
    {
      if (!this.IsInRange(value))
        throw new ParseException("Character mismatch");
      this.Consume();
    }

    protected void MatchRange(char[] value, int minOccurs, int maxOccurs)
    {
      int count = 0;
      while (this.IsInRange(value))
      {
        this.Consume();
        ++count;
      }
      Lexer.ValidateOccurence(count, minOccurs, maxOccurs);
    }

    protected void MatchRange(char first, char last)
    {
      if (!this.IsInRange(first, last))
        throw new ParseException("Character mismatch");
      this.Consume();
    }

    protected void MatchRange(char first, char last, int minOccurs, int maxOccurs)
    {
      int count = 0;
      while (this.IsInRange(first, last))
      {
        this.Consume();
        ++count;
      }
      Lexer.ValidateOccurence(count, minOccurs, maxOccurs);
    }

    public abstract Token NextToken();
  }
}
