// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.ModernUIHelper
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Win32;
using System;
using System.ComponentModel;
using System.Windows;

namespace FirstFloor.ModernUI
{
  public static class ModernUIHelper
  {
    private static bool? isInDesignMode;

    public static bool IsInDesignMode
    {
      get
      {
        if (!ModernUIHelper.isInDesignMode.HasValue)
          ModernUIHelper.isInDesignMode = new bool?(DesignerProperties.GetIsInDesignMode(new DependencyObject()));
        return ModernUIHelper.isInDesignMode.Value;
      }
    }

    public static ProcessDpiAwareness GetDpiAwareness()
    {
      if (OSVersionHelper.IsWindows8Point1OrGreater)
      {
        ProcessDpiAwareness dpiAwareness;
        int processDpiAwareness = NativeMethods.GetProcessDpiAwareness(IntPtr.Zero, out dpiAwareness);
        if (processDpiAwareness != 0)
          throw new Win32Exception(processDpiAwareness);
        return dpiAwareness;
      }
      return OSVersionHelper.IsWindowsVistaOrGreater && !NativeMethods.IsProcessDPIAware() ? ProcessDpiAwareness.DpiUnaware : ProcessDpiAwareness.SystemDpiAware;
    }

    public static bool TrySetPerMonitorDpiAware()
    {
      ProcessDpiAwareness dpiAwareness = ModernUIHelper.GetDpiAwareness();
      if (dpiAwareness != ProcessDpiAwareness.DpiUnaware)
        return dpiAwareness == ProcessDpiAwareness.PerMonitorDpiAware;
      return OSVersionHelper.IsWindows8Point1OrGreater ? NativeMethods.SetProcessDpiAwareness(ProcessDpiAwareness.PerMonitorDpiAware) == 0 : NativeMethods.SetProcessDPIAware() == 0;
    }
  }
}
