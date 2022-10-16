// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.RelativeAnimatingContentControl
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FirstFloor.ModernUI.Windows.Controls
{
  public class RelativeAnimatingContentControl : ContentControl
  {
    private const double SimpleDoubleComparisonEpsilon = 9E-06;
    private double _knownWidth;
    private double _knownHeight;
    private List<RelativeAnimatingContentControl.AnimationValueAdapter> _specialAnimations;

    public RelativeAnimatingContentControl() => this.SizeChanged += new SizeChangedEventHandler(this.OnSizeChanged);

    private void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
      if (e == null || e.NewSize.Height <= 0.0 || e.NewSize.Width <= 0.0)
        return;
      Size newSize = e.NewSize;
      this._knownWidth = newSize.Width;
      newSize = e.NewSize;
      this._knownHeight = newSize.Height;
      this.UpdateAnyAnimationValues();
    }

    private void UpdateAnyAnimationValues()
    {
      if (this._knownHeight <= 0.0 || this._knownWidth <= 0.0)
        return;
      if (this._specialAnimations == null)
      {
        this._specialAnimations = new List<RelativeAnimatingContentControl.AnimationValueAdapter>();
        foreach (VisualStateGroup visualStateGroup in (IEnumerable) VisualStateManager.GetVisualStateGroups((FrameworkElement) this))
        {
          if (visualStateGroup != null)
          {
            foreach (VisualState state in (IEnumerable) visualStateGroup.States)
            {
              if (state != null)
              {
                Storyboard storyboard = state.Storyboard;
                if (storyboard != null)
                {
                  foreach (Timeline child in storyboard.Children)
                  {
                    DoubleAnimation da1 = child as DoubleAnimation;
                    DoubleAnimationUsingKeyFrames da2 = child as DoubleAnimationUsingKeyFrames;
                    if (da1 != null)
                      this.ProcessDoubleAnimation(da1);
                    else if (da2 != null)
                      this.ProcessDoubleAnimationWithKeys(da2);
                  }
                }
              }
            }
          }
        }
      }
      this.UpdateKnownAnimations();
      foreach (VisualStateGroup visualStateGroup in (IEnumerable) VisualStateManager.GetVisualStateGroups((FrameworkElement) this))
      {
        if (visualStateGroup != null)
        {
          foreach (VisualState state in (IEnumerable) visualStateGroup.States)
            state?.Storyboard?.Begin((FrameworkElement) this);
        }
      }
    }

    private void UpdateKnownAnimations()
    {
      foreach (RelativeAnimatingContentControl.AnimationValueAdapter specialAnimation in this._specialAnimations)
        specialAnimation.UpdateWithNewDimension(this._knownWidth, this._knownHeight);
    }

    private void ProcessDoubleAnimationWithKeys(DoubleAnimationUsingKeyFrames da)
    {
      foreach (DoubleKeyFrame keyFrame in da.KeyFrames)
      {
        RelativeAnimatingContentControl.DoubleAnimationDimension? identifyingValue = RelativeAnimatingContentControl.GeneralAnimationValueAdapter<DoubleKeyFrame>.GetDimensionFromIdentifyingValue(keyFrame.Value);
        if (identifyingValue.HasValue)
          this._specialAnimations.Add((RelativeAnimatingContentControl.AnimationValueAdapter) new RelativeAnimatingContentControl.DoubleAnimationFrameAdapter(identifyingValue.Value, keyFrame));
      }
    }

    private void ProcessDoubleAnimation(DoubleAnimation da)
    {
      if (da.To.HasValue)
      {
        RelativeAnimatingContentControl.DoubleAnimationDimension? identifyingValue = RelativeAnimatingContentControl.GeneralAnimationValueAdapter<DoubleAnimation>.GetDimensionFromIdentifyingValue(da.To.Value);
        if (identifyingValue.HasValue)
          this._specialAnimations.Add((RelativeAnimatingContentControl.AnimationValueAdapter) new RelativeAnimatingContentControl.DoubleAnimationToAdapter(identifyingValue.Value, da));
      }
      if (!da.From.HasValue)
        return;
      RelativeAnimatingContentControl.DoubleAnimationDimension? identifyingValue1 = RelativeAnimatingContentControl.GeneralAnimationValueAdapter<DoubleAnimation>.GetDimensionFromIdentifyingValue(da.To.Value);
      if (!identifyingValue1.HasValue)
        return;
      this._specialAnimations.Add((RelativeAnimatingContentControl.AnimationValueAdapter) new RelativeAnimatingContentControl.DoubleAnimationFromAdapter(identifyingValue1.Value, da));
    }

    private enum DoubleAnimationDimension
    {
      Width,
      Height,
    }

    private abstract class AnimationValueAdapter
    {
      protected double OriginalValue { get; set; }

      public AnimationValueAdapter(
        RelativeAnimatingContentControl.DoubleAnimationDimension dimension)
      {
        this.Dimension = dimension;
      }

      public RelativeAnimatingContentControl.DoubleAnimationDimension Dimension { get; private set; }

      public abstract void UpdateWithNewDimension(double width, double height);
    }

    private abstract class GeneralAnimationValueAdapter<T> : 
      RelativeAnimatingContentControl.AnimationValueAdapter
    {
      private double _ratio;

      protected T Instance { get; set; }

      protected abstract double GetValue();

      protected abstract void SetValue(double newValue);

      protected double InitialValue { get; private set; }

      public GeneralAnimationValueAdapter(
        RelativeAnimatingContentControl.DoubleAnimationDimension d,
        T instance)
        : base(d)
      {
        this.Instance = instance;
        this.InitialValue = this.StripIdentifyingValueOff(this.GetValue());
        this._ratio = this.InitialValue / 100.0;
      }

      public double StripIdentifyingValueOff(double number) => this.Dimension != RelativeAnimatingContentControl.DoubleAnimationDimension.Width ? number - 0.2 : number - 0.1;

      public static RelativeAnimatingContentControl.DoubleAnimationDimension? GetDimensionFromIdentifyingValue(
        double number)
      {
        double num1 = Math.Floor(number);
        double num2 = number - num1;
        if (num2 >= 0.099991 && num2 <= 0.100009)
          return new RelativeAnimatingContentControl.DoubleAnimationDimension?(RelativeAnimatingContentControl.DoubleAnimationDimension.Width);
        return num2 >= 0.199991 && num2 <= 0.200009 ? new RelativeAnimatingContentControl.DoubleAnimationDimension?(RelativeAnimatingContentControl.DoubleAnimationDimension.Height) : new RelativeAnimatingContentControl.DoubleAnimationDimension?();
      }

      public override void UpdateWithNewDimension(double width, double height) => this.UpdateValue(this.Dimension == RelativeAnimatingContentControl.DoubleAnimationDimension.Width ? width : height);

      private void UpdateValue(double sizeToUse) => this.SetValue(sizeToUse * this._ratio);
    }

    private class DoubleAnimationToAdapter : 
      RelativeAnimatingContentControl.GeneralAnimationValueAdapter<DoubleAnimation>
    {
      protected override double GetValue() => this.Instance.To.Value;

      protected override void SetValue(double newValue) => this.Instance.To = new double?(newValue);

      public DoubleAnimationToAdapter(
        RelativeAnimatingContentControl.DoubleAnimationDimension dimension,
        DoubleAnimation instance)
        : base(dimension, instance)
      {
      }
    }

    private class DoubleAnimationFromAdapter : 
      RelativeAnimatingContentControl.GeneralAnimationValueAdapter<DoubleAnimation>
    {
      protected override double GetValue() => this.Instance.From.Value;

      protected override void SetValue(double newValue) => this.Instance.From = new double?(newValue);

      public DoubleAnimationFromAdapter(
        RelativeAnimatingContentControl.DoubleAnimationDimension dimension,
        DoubleAnimation instance)
        : base(dimension, instance)
      {
      }
    }

    private class DoubleAnimationFrameAdapter : 
      RelativeAnimatingContentControl.GeneralAnimationValueAdapter<DoubleKeyFrame>
    {
      protected override double GetValue() => this.Instance.Value;

      protected override void SetValue(double newValue) => this.Instance.Value = newValue;

      public DoubleAnimationFrameAdapter(
        RelativeAnimatingContentControl.DoubleAnimationDimension dimension,
        DoubleKeyFrame frame)
        : base(dimension, frame)
      {
      }
    }
  }
}
