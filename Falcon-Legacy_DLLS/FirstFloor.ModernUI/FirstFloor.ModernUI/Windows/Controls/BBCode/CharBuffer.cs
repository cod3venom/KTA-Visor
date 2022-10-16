// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.BBCode.CharBuffer
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;

namespace FirstFloor.ModernUI.Windows.Controls.BBCode
{
  internal class CharBuffer
  {
    private string value;
    private int position;
    private int mark;

    public CharBuffer(string value) => this.value = value != null ? value : throw new ArgumentNullException(nameof (value));

    public char LA(int count)
    {
      int index = this.position + count - 1;
      return index < this.value.Length ? this.value[index] : char.MaxValue;
    }

    public void Mark() => this.mark = this.position;

    public string GetMark() => this.mark < this.position ? this.value.Substring(this.mark, this.position - this.mark) : string.Empty;

    public void Consume() => ++this.position;
  }
}
