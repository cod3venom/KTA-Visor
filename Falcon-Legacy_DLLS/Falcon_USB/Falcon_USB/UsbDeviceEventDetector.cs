// Decompiled with JetBrains decompiler
// Type: Falcon_USB.UsbDeviceEventDetector
// Assembly: Falcon_USB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7924EA10-DAC0-471E-BD57-BD7B43142DEE
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon_USB.dll

using System;
using System.Runtime.InteropServices;

namespace Falcon_USB
{
  internal class UsbDeviceEventDetector : IUsbDeviceEventDetector, IDisposable
  {
    private const int WM_DEVICECHANGE = 537;
    private const int DBT_DEVICEARRIVAL = 32768;
    private const int DBT_DEVICEREMOVECOMPLETE = 32772;
    private const int DBT_DEVNODES_CHANGED = 7;
    private const int DBT_DEVTYP_VOLUME = 2;
    private readonly string _className;
    private readonly IntPtr _windowHandle;
    private static UsbDeviceEventDetector.WndProc noGCthis;
    private bool disposedValue = false;

    public event EventHandler<EventArgs> DeviceInsertedOrRemoved;

    public event EventHandler<DriveChangedEventArgs> DriveInserted;

    public event EventHandler<DriveChangedEventArgs> DriveRemoved;

    internal UsbDeviceEventDetector()
    {
      UsbDeviceEventDetector.WNDCLASS wc = new UsbDeviceEventDetector.WNDCLASS();
      UsbDeviceEventDetector.noGCthis = new UsbDeviceEventDetector.WndProc(this.WndProcCallback);
      wc.lpfnWndProc = UsbDeviceEventDetector.noGCthis;
      this._className = nameof (UsbDeviceEventDetector) + (object) new Random().Next();
      wc.lpszClassName = this._className;
      int num = (int) UsbDeviceEventDetector.RegisterClass(wc);
      this._windowHandle = UsbDeviceEventDetector.CreateWindowEx(0, wc.lpszClassName, "Window title", 0, 100, 100, 500, 500, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (object) 0);
    }

    [DllImport("User32", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CreateWindowEx(
      int dwExStyle,
      string lpszClassName,
      string lpszWindowName,
      int style,
      int x,
      int y,
      int width,
      int height,
      IntPtr hWndParent,
      IntPtr hMenu,
      IntPtr hInst,
      [MarshalAs(UnmanagedType.AsAny)] object pvParam);

    [DllImport("user32.dll")]
    private static extern IntPtr DefWindowProc(
      IntPtr hWnd,
      int uMsg,
      IntPtr wParam,
      IntPtr lParam);

    [DllImport("User32", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern short RegisterClass(UsbDeviceEventDetector.WNDCLASS wc);

    [DllImport("User32", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern short UnRegisterClass(string className, IntPtr handle);

    [AllowReversePInvokeCalls]
    private IntPtr WndProcCallback(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
    {
      if (msg == 537)
      {
        switch (wparam.ToInt32())
        {
          case 7:
            this.FireDeviceInsertedOrRemoved();
            break;
          case 32768:
            string drive1 = this.GetDrive(lparam);
            if (drive1.Length > 0)
            {
              this.FireDriveInserted(drive1);
              break;
            }
            break;
          case 32772:
            string drive2 = this.GetDrive(lparam);
            if (drive2.Length > 0)
            {
              this.FireDriveRemoved(drive2);
              break;
            }
            break;
        }
      }
      return UsbDeviceEventDetector.DefWindowProc(hWnd, msg, wparam, lparam);
    }

    private string GetDrive(IntPtr lparam)
    {
      UsbDeviceEventDetector.DEV_BROADCAST_VOLUME structure = new UsbDeviceEventDetector.DEV_BROADCAST_VOLUME();
      Marshal.PtrToStructure(lparam, (object) structure);
      if (structure.dbch_Devicetype == 2U)
      {
        ulong dbchUnitmask = (ulong) structure.dbch_Unitmask;
        char ch = 'A';
        while (ch <= 'Z')
        {
          if ((dbchUnitmask & 1UL) > 0UL)
            return string.Format("{0}:\\", (object) ch);
          ++ch;
          dbchUnitmask >>= 1;
        }
      }
      return string.Empty;
    }

    private void FireDriveInserted(string drive)
    {
      if (this.DriveInserted == null)
        return;
      this.DriveInserted((object) this, new DriveChangedEventArgs(drive));
    }

    private void FireDriveRemoved(string drive)
    {
      if (this.DriveRemoved == null)
        return;
      this.DriveRemoved((object) this, new DriveChangedEventArgs(drive));
    }

    private void FireDeviceInsertedOrRemoved()
    {
      if (this.DeviceInsertedOrRemoved == null)
        return;
      this.DeviceInsertedOrRemoved((object) this, EventArgs.Empty);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.disposedValue)
        return;
      if (!disposing)
        ;
      int num = (int) UsbDeviceEventDetector.UnRegisterClass(this._className, this._windowHandle);
      this.disposedValue = true;
    }

    void IDisposable.Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class WNDCLASS
    {
      public int style;
      public UsbDeviceEventDetector.WndProc lpfnWndProc;
      public int cbClsExtra;
      public int cbWndExtra;
      public IntPtr hInstance;
      public IntPtr hIcon;
      public IntPtr hCursor;
      public IntPtr hbrBackground;
      public string lpszMenuName;
      public string lpszClassName;
    }

    [StructLayout(LayoutKind.Sequential)]
    private class DEV_BROADCAST_VOLUME
    {
      public uint dbch_Size;
      public uint dbch_Devicetype;
      public uint dbch_Reserved;
      public uint dbch_Unitmask;
      public ushort dbch_Flags;
    }

    public delegate IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
  }
}
