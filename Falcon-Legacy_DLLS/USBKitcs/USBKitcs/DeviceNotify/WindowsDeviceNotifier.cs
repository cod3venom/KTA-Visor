// Decompiled with JetBrains decompiler
// Type: USBKitcs.DeviceNotify.WindowsDeviceNotifier
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using USBKitcs.DeviceNotify.Internal;

namespace USBKitcs.DeviceNotify
{
  public class WindowsDeviceNotifier : IDeviceNotifier
  {
    private readonly DevBroadcastDeviceinterface mDevInterface = new DevBroadcastDeviceinterface(new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"));
    private SafeNotifyHandle mDevInterfaceHandle;
    private bool mEnabled = true;
    private DevNotifyNativeWindow mNotifyWindow;

    public WindowsDeviceNotifier() => this.mNotifyWindow = new DevNotifyNativeWindow(new DevNotifyNativeWindow.OnHandleChangeDelegate(this.OnHandleChange), new DevNotifyNativeWindow.OnDeviceChangeDelegate(this.OnDeviceChange));

    public bool Enabled
    {
      get => this.mEnabled;
      set => this.mEnabled = value;
    }

    public event EventHandler<DeviceNotifyEventArgs> OnDeviceNotify;

    [DllImport("user32.dll", EntryPoint = "RegisterDeviceNotificationA", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern SafeNotifyHandle RegisterDeviceNotification(
      IntPtr hRecipient,
      [MarshalAs(UnmanagedType.AsAny), In] object notificationFilter,
      int flags);

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool UnregisterDeviceNotification(IntPtr handle);

    ~WindowsDeviceNotifier()
    {
      if (this.mNotifyWindow != null)
        this.mNotifyWindow.DestroyHandle();
      this.mNotifyWindow = (DevNotifyNativeWindow) null;
      if (this.mDevInterfaceHandle != null)
        this.mDevInterfaceHandle.Dispose();
      this.mDevInterfaceHandle = (SafeNotifyHandle) null;
    }

    internal bool RegisterDeviceInterface(IntPtr windowHandle)
    {
      if (this.mDevInterfaceHandle != null)
      {
        this.mDevInterfaceHandle.Dispose();
        this.mDevInterfaceHandle = (SafeNotifyHandle) null;
      }
      if (!(windowHandle != IntPtr.Zero))
        return false;
      this.mDevInterfaceHandle = WindowsDeviceNotifier.RegisterDeviceNotification(windowHandle, (object) this.mDevInterface, 0);
      return this.mDevInterfaceHandle != null && !this.mDevInterfaceHandle.IsInvalid;
    }

    private void OnDeviceChange(ref Message m)
    {
      if (!this.mEnabled || m.LParam.ToInt32() == 0)
        return;
      EventHandler<DeviceNotifyEventArgs> onDeviceNotify = this.OnDeviceNotify;
      if (onDeviceNotify != null)
      {
        DevBroadcastHdr devBroadcastHdr = new DevBroadcastHdr();
        Marshal.PtrToStructure<DevBroadcastHdr>(m.LParam, devBroadcastHdr);
        DeviceNotifyEventArgs e;
        switch (devBroadcastHdr.DeviceType)
        {
          case DeviceType.Volume:
          case DeviceType.Port:
          case DeviceType.DeviceInterface:
            e = (DeviceNotifyEventArgs) new WindowsDeviceNotifyEventArgs(devBroadcastHdr, m.LParam, (EventType) m.WParam.ToInt32());
            break;
          default:
            e = (DeviceNotifyEventArgs) null;
            break;
        }
        if (e != null)
          onDeviceNotify((object) this, e);
      }
    }

    private void OnHandleChange(IntPtr newWindowHandle) => Debug.Print("RegisterDeviceInterface:" + this.RegisterDeviceInterface(newWindowHandle).ToString());
  }
}
