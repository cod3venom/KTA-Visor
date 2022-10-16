// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.BBCode.BBCodeParser
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Windows.Navigation;
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace FirstFloor.ModernUI.Windows.Controls.BBCode
{
  internal class BBCodeParser : Parser<Span>
  {
    private const string TagBold = "b";
    private const string TagColor = "color";
    private const string TagItalic = "i";
    private const string TagSize = "size";
    private const string TagUnderline = "u";
    private const string TagUrl = "url";
    private FrameworkElement source;

    public BBCodeParser(string value, FrameworkElement source)
      : base((Lexer) new BBCodeLexer(value))
    {
      this.source = source != null ? source : throw new ArgumentNullException(nameof (source));
    }

    public CommandDictionary Commands { get; set; }

    private void ParseTag(string tag, bool start, BBCodeParser.ParseContext context)
    {
      if (tag == "b")
      {
        context.FontWeight = new FontWeight?();
        if (!start)
          return;
        context.FontWeight = new FontWeight?(FontWeights.Bold);
      }
      else if (tag == "color")
      {
        if (start)
        {
          Token token = this.LA(1);
          if (token.TokenType != 2)
            return;
          Color color = (Color) ColorConverter.ConvertFromString(token.Value);
          context.Foreground = (Brush) new SolidColorBrush(color);
          this.Consume();
        }
        else
          context.Foreground = (Brush) null;
      }
      else if (tag == "i")
      {
        if (start)
          context.FontStyle = new FontStyle?(FontStyles.Italic);
        else
          context.FontStyle = new FontStyle?();
      }
      else if (tag == "size")
      {
        if (start)
        {
          Token token = this.LA(1);
          if (token.TokenType != 2)
            return;
          context.FontSize = new double?(Convert.ToDouble(token.Value));
          this.Consume();
        }
        else
          context.FontSize = new double?();
      }
      else if (tag == "u")
      {
        context.TextDecorations = start ? TextDecorations.Underline : (TextDecorationCollection) null;
      }
      else
      {
        if (!(tag == "url"))
          return;
        if (start)
        {
          Token token = this.LA(1);
          if (token.TokenType != 2)
            return;
          context.NavigateUri = token.Value;
          this.Consume();
        }
        else
          context.NavigateUri = (string) null;
      }
    }

    private void Parse(Span span)
    {
      BBCodeParser.ParseContext context = new BBCodeParser.ParseContext(span);
      Token token;
      while (true)
      {
        token = this.LA(1);
        this.Consume();
        if (token.TokenType == 0)
          this.ParseTag(token.Value, true, context);
        else if (token.TokenType == 1)
          this.ParseTag(token.Value, false, context);
        else if (token.TokenType == 3)
        {
          Span span1 = span;
          string parameter = (string) null;
          string targetName = (string) null;
          Uri uri;
          if (NavigationHelper.TryParseUriWithParameters(context.NavigateUri, out uri, out parameter, out targetName))
          {
            Hyperlink hyperlink = new Hyperlink();
            ICommand command;
            if (this.Commands != null && this.Commands.TryGetValue(uri, out command))
            {
              hyperlink.Command = command;
              hyperlink.CommandParameter = (object) parameter;
              if (targetName != null)
                hyperlink.CommandTarget = this.source.FindName(targetName) as IInputElement;
            }
            else
            {
              hyperlink.NavigateUri = uri;
              hyperlink.TargetName = parameter;
            }
            span1 = (Span) hyperlink;
            span.Inlines.Add((Inline) span1);
          }
          Run run = context.CreateRun(token.Value);
          span1.Inlines.Add((Inline) run);
        }
        else if (token.TokenType == 4)
          span.Inlines.Add((Inline) new LineBreak());
        else
          break;
      }
      if (token.TokenType == 2)
        throw new ParseException(Resources.UnexpectedToken);
      if (token.TokenType != int.MaxValue)
        throw new ParseException(Resources.UnknownTokenType);
    }

    public override Span Parse()
    {
      Span span = new Span();
      this.Parse(span);
      return span;
    }

    private class ParseContext
    {
      public ParseContext(Span parent) => this.Parent = parent;

      public Span Parent { get; private set; }

      public double? FontSize { get; set; }

      public FontWeight? FontWeight { get; set; }

      public FontStyle? FontStyle { get; set; }

      public Brush Foreground { get; set; }

      public TextDecorationCollection TextDecorations { get; set; }

      public string NavigateUri { get; set; }

      public Run CreateRun(string text)
      {
        Run run = new Run() { Text = text };
        if (this.FontSize.HasValue)
          run.FontSize = this.FontSize.Value;
        if (this.FontWeight.HasValue)
          run.FontWeight = this.FontWeight.Value;
        if (this.FontStyle.HasValue)
          run.FontStyle = this.FontStyle.Value;
        if (this.Foreground != null)
          run.Foreground = this.Foreground;
        run.TextDecorations = this.TextDecorations;
        return run;
      }
    }
  }
}
