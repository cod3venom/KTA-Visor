// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.ModernDialog
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FirstFloor.ModernUI.Windows.Controls
{
  public class ModernDialog : DpiAwareWindow
  {
    public static readonly DependencyProperty BackgroundContentProperty = DependencyProperty.Register(nameof (BackgroundContent), typeof (object), typeof (ModernDialog));
    public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register(nameof (Buttons), typeof (IEnumerable<Button>), typeof (ModernDialog));
    private ICommand closeCommand;
    private Button okButton;
    private Button cancelButton;
    private Button yesButton;
    private Button noButton;
    private Button closeButton;
    private MessageBoxResult messageBoxResult;

    public ModernDialog()
    {
      this.DefaultStyleKey = (object) typeof (ModernDialog);
      this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
      this.closeCommand = (ICommand) new RelayCommand((Action<object>) (o =>
      {
        MessageBoxResult? nullable = o as MessageBoxResult?;
        if (nullable.HasValue)
        {
          this.messageBoxResult = nullable.Value;
          if (nullable.Value == MessageBoxResult.OK || nullable.Value == MessageBoxResult.Yes)
            this.DialogResult = new bool?(true);
          else if (nullable.Value == MessageBoxResult.Cancel || nullable.Value == MessageBoxResult.No)
            this.DialogResult = new bool?(false);
          else
            this.DialogResult = new bool?();
        }
        this.Close();
      }));
      this.Buttons = (IEnumerable<Button>) new Button[1]
      {
        this.CloseButton
      };
    }

    private Button CreateCloseDialogButton(
      string content,
      bool isDefault,
      bool isCancel,
      MessageBoxResult result)
    {
      Button closeDialogButton = new Button();
      closeDialogButton.Content = (object) content;
      closeDialogButton.Command = this.CloseCommand;
      closeDialogButton.CommandParameter = (object) result;
      closeDialogButton.IsDefault = isDefault;
      closeDialogButton.IsCancel = isCancel;
      closeDialogButton.MinHeight = 21.0;
      closeDialogButton.MinWidth = 65.0;
      closeDialogButton.Margin = new Thickness(4.0, 0.0, 0.0, 0.0);
      return closeDialogButton;
    }

    public ICommand CloseCommand => this.closeCommand;

    public Button OkButton
    {
      get
      {
        if (this.okButton == null)
          this.okButton = this.CreateCloseDialogButton(Resources.Ok, true, false, MessageBoxResult.OK);
        return this.okButton;
      }
    }

    public Button CancelButton
    {
      get
      {
        if (this.cancelButton == null)
          this.cancelButton = this.CreateCloseDialogButton(Resources.Cancel, false, true, MessageBoxResult.Cancel);
        return this.cancelButton;
      }
    }

    public Button YesButton
    {
      get
      {
        if (this.yesButton == null)
          this.yesButton = this.CreateCloseDialogButton(Resources.Yes, true, false, MessageBoxResult.Yes);
        return this.yesButton;
      }
    }

    public Button NoButton
    {
      get
      {
        if (this.noButton == null)
          this.noButton = this.CreateCloseDialogButton(Resources.No, false, true, MessageBoxResult.No);
        return this.noButton;
      }
    }

    public Button CloseButton
    {
      get
      {
        if (this.closeButton == null)
          this.closeButton = this.CreateCloseDialogButton(Resources.Close, true, false, MessageBoxResult.None);
        return this.closeButton;
      }
    }

    public object BackgroundContent
    {
      get => this.GetValue(ModernDialog.BackgroundContentProperty);
      set => this.SetValue(ModernDialog.BackgroundContentProperty, value);
    }

    public IEnumerable<Button> Buttons
    {
      get => (IEnumerable<Button>) this.GetValue(ModernDialog.ButtonsProperty);
      set => this.SetValue(ModernDialog.ButtonsProperty, (object) value);
    }

    public MessageBoxResult MessageBoxResult => this.messageBoxResult;

    public static MessageBoxResult ShowMessage(
      string text,
      string title,
      MessageBoxButton button,
      Window owner = null)
    {
      ModernDialog modernDialog = new ModernDialog();
      modernDialog.Title = title;
      BBCodeBlock bbCodeBlock = new BBCodeBlock();
      bbCodeBlock.BBCode = text;
      bbCodeBlock.Margin = new Thickness(0.0, 0.0, 0.0, 8.0);
      modernDialog.Content = (object) bbCodeBlock;
      modernDialog.MinHeight = 0.0;
      modernDialog.MinWidth = 0.0;
      modernDialog.MaxHeight = 480.0;
      modernDialog.MaxWidth = 640.0;
      ModernDialog owner1 = modernDialog;
      if (owner != null)
        owner1.Owner = owner;
      owner1.Buttons = ModernDialog.GetButtons(owner1, button);
      owner1.ShowDialog();
      return owner1.messageBoxResult;
    }

    private static IEnumerable<Button> GetButtons(
      ModernDialog owner,
      MessageBoxButton button)
    {
      switch (button)
      {
        case MessageBoxButton.OK:
          yield return owner.OkButton;
          break;
        case MessageBoxButton.OKCancel:
          yield return owner.OkButton;
          yield return owner.CancelButton;
          break;
        case MessageBoxButton.YesNoCancel:
          yield return owner.YesButton;
          yield return owner.NoButton;
          yield return owner.CancelButton;
          break;
        case MessageBoxButton.YesNo:
          yield return owner.YesButton;
          yield return owner.NoButton;
          break;
      }
    }
  }
}
