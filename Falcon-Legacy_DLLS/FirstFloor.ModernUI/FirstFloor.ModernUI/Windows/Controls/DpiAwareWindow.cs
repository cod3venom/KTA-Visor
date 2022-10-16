// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.DpiAwareWindow
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Win32;
using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace FirstFloor.ModernUI.Windows.Controls
{
  public abstract class DpiAwareWindow : Window
  {
    private HwndSource source;
    private DpiInformation dpiInfo;
    private bool isPerMonitorDpiAware;

    public event EventHandler DpiChanged;

    public DpiAwareWindow()
    {
      this.SourceInitialized += new EventHandler(this.OnSourceInitialized);
      SystemEvents.DisplaySettingsChanged += new EventHandler(this.OnSystemEventsDisplaySettingsChanged);
      this.isPerMonitorDpiAware = ModernUIHelper.TrySetPerMonitorDpiAware();
    }

    public DpiInformation DpiInformation => this.dpiInfo;

    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      SystemEvents.DisplaySettingsChanged -= new EventHandler(this.OnSystemEventsDisplaySettingsChanged);
    }

    private void OnSystemEventsDisplaySettingsChanged(object sender, EventArgs e)
    {
      if (this.source == null || this.WindowState != WindowState.Minimized)
        return;
      this.RefreshMonitorDpi();
    }

    private void OnSourceInitialized(object sender, EventArgs e)
    {
      this.source = (HwndSource) PresentationSource.FromVisual((Visual) this);
      Matrix transformToDevice = this.source.CompositionTarget.TransformToDevice;
      this.dpiInfo = new DpiInformation(96.0 * transformToDevice.M11, 96.0 * transformToDevice.M22);
      if (!this.isPerMonitorDpiAware)
        return;
      this.source.AddHook(new HwndSourceHook(this.WndProc));
      this.RefreshMonitorDpi();
    }

    private IntPtr WndProc(
      IntPtr hwnd,
      int msg,
      IntPtr wParam,
      IntPtr lParam,
      ref bool handled)
    {
      if (msg == 736)
      {
        RECT structure = (RECT) Marshal.PtrToStructure(lParam, typeof (RECT));
        Matrix transformFromDevice = this.source.CompositionTarget.TransformFromDevice;
        Vector vector1 = transformFromDevice.Transform(new Vector((double) structure.left, (double) structure.top));
        Vector vector2 = transformFromDevice.Transform(new Vector((double) (structure.right - structure.left), (double) (structure.bottom - structure.top)));
        this.Left = vector1.X;
        this.Top = vector1.Y;
        this.UpdateWindowSize(vector2.X, vector2.Y);
        double? monitorDpiX = this.dpiInfo.MonitorDpiX;
        double? monitorDpiY = this.dpiInfo.MonitorDpiY;
        double dpiX = (double) (wParam.ToInt32() >> 16);
        double dpiY = (double) (wParam.ToInt32() & (int) ushort.MaxValue);
        double? nullable = monitorDpiX;
        double num1 = dpiX;
        if (nullable.GetValueOrDefault() == num1 & nullable.HasValue)
        {
          nullable = monitorDpiY;
          double num2 = dpiY;
          if (nullable.GetValueOrDefault() == num2 & nullable.HasValue)
            goto label_4;
        }
        this.dpiInfo.UpdateMonitorDpi(dpiX, dpiY);
        this.UpdateLayoutTransform();
        this.OnDpiChanged(EventArgs.Empty);
label_4:
        handled = true;
      }
      return IntPtr.Zero;
    }

    private void UpdateLayoutTransform()
    {
      if (!this.isPerMonitorDpiAware)
        return;
      FrameworkElement visualChild = (FrameworkElement) this.GetVisualChild(0);
      if (visualChild == null)
        return;
      if (this.dpiInfo.ScaleX != 1.0 || this.dpiInfo.ScaleY != 1.0)
        visualChild.LayoutTransform = (Transform) new ScaleTransform(this.dpiInfo.ScaleX, this.dpiInfo.ScaleY);
      else
        visualChild.LayoutTransform = (Transform) null;
    }

    private void UpdateWindowSize(double width, double height)
    {
      double num1 = width / this.Width;
      double num2 = height / this.Height;
      if (num1 == 1.0 && num2 == 1.0)
        return;
      this.MinWidth *= num1;
      this.MaxWidth *= num1;
      this.MinHeight *= num2;
      this.MaxHeight *= num2;
      this.Width = width;
      this.Height = height;
    }

    protected void RefreshMonitorDpi()
    {
      if (!this.isPerMonitorDpiAware)
        return;
      IntPtr hMonitor = FirstFloor.ModernUI.Win32.NativeMethods.MonitorFromWindow(this.source.Handle, 2);
      uint dpiX = 96;
      uint dpiY = 96;
      ref uint local1 = ref dpiX;
      ref uint local2 = ref dpiY;
      if (FirstFloor.ModernUI.Win32.NativeMethods.GetDpiForMonitor(hMonitor, 0, ref local1, ref local2) != 0)
      {
        dpiX = 96U;
        dpiY = 96U;
      }
      Vector vector = this.dpiInfo.UpdateMonitorDpi((double) dpiX, (double) dpiY);
      this.UpdateWindowSize(this.Width * vector.X, this.Height * vector.Y);
      this.UpdateLayoutTransform();
    }

    protected virtual void OnDpiChanged(EventArgs e)
    {
      EventHandler dpiChanged = this.DpiChanged;
      if (dpiChanged == null)
        return;
      dpiChanged((object) this, e);
    }
  }
}
