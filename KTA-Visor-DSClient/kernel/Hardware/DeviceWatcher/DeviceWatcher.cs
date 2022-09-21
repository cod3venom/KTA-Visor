
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher.events;
using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;

namespace KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher
{
    public class DeviceWatcher :  IDisposable
    {
        public event EventHandler<EventArgs> OnDeviceConnectedOrDisconnected;
        public event EventHandler<DriveChangedEventArgs> OnDeviceConnected;
        public event EventHandler<DriveChangedEventArgs> OnDeviceDisconnected;

        private const int WM_DEVICECHANGE = 537;
        private const int DBT_DEVICEARRIVAL = 32768;
        private const int DBT_DEVICEREMOVECOMPLETE = 32772;
        private const int DBT_DEVNODES_CHANGED = 7;
        private const int DBT_DEVTYP_VOLUME = 2;
        private readonly string _className;
        private readonly IntPtr _windowHandle;
        private static DeviceWatcher.WndProc noGCthis;
        private bool disposedValue = false;


        public DeviceWatcher()
        {
            DeviceWatcher.WNDCLASS wc = new DeviceWatcher.WNDCLASS();
            DeviceWatcher.noGCthis = new DeviceWatcher.WndProc(this.WndProcCallback);
            wc.lpfnWndProc = DeviceWatcher.noGCthis;
            this._className = nameof(DeviceWatcher) + (object)new Random().Next();
            wc.lpszClassName = this._className;
            int num = (int)DeviceWatcher.RegisterClass(wc);
            this._windowHandle = DeviceWatcher.CreateWindowEx(0, wc.lpszClassName, "Window title", 0, 100, 100, 500, 500, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (object)0);
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
        public static extern short RegisterClass(DeviceWatcher.WNDCLASS wc);

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
                        this.FireOnDeviceConnectedOrDisconnected();
                        break;
                    case 32768:
                        string drive1 = this.GetDrive(lparam);
                        if (drive1.Length > 0)
                        {
                            this.FireOnDeviceConnected(drive1);
                            break;
                        }
                        break;
                    case 32772:
                        string drive2 = this.GetDrive(lparam);
                        if (drive2.Length > 0)
                        {
                            this.FireOnDeviceDisconnected(drive2);
                            break;
                        }
                        break;
                }
            }
            return DeviceWatcher.DefWindowProc(hWnd, msg, wparam, lparam);
        }

        private string GetDrive(IntPtr lparam)
        {
            DeviceWatcher.DEV_BROADCAST_VOLUME devBroadcastVolume = new DeviceWatcher.DEV_BROADCAST_VOLUME();
            Marshal.PtrToStructure(lparam, (object)devBroadcastVolume);
            if (devBroadcastVolume.dbch_Devicetype == 2U)
            {
                ulong dbchUnitmask = (ulong)devBroadcastVolume.dbch_Unitmask;
                char ch = 'A';
                while (ch <= 'Z')
                {
                    if ((dbchUnitmask & 1UL) > 0UL)
                        return string.Format("{0}:\\", (object)ch);
                    ++ch;
                    dbchUnitmask >>= 1;
                }
            }
            return string.Empty;
        }

        private void FireOnDeviceConnected(string drive)
        {
            if (this.OnDeviceConnected == null)
                return;
            this.OnDeviceConnected((object)this, new DriveChangedEventArgs(drive));
        }

        private void FireOnDeviceDisconnected(string drive)
        {
            if (this.OnDeviceDisconnected == null)
                return;
            this.OnDeviceDisconnected((object)this, new DriveChangedEventArgs(drive));
        }

        private void FireOnDeviceConnectedOrDisconnected()
        {
            if (this.OnDeviceConnectedOrDisconnected == null)
                return;
            this.OnDeviceConnectedOrDisconnected((object)this, EventArgs.Empty);
        }

        public async void LoadConnectedDevices()
        {
            ManagementObjectSearcher devices = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");
            try
            {
                Thread.Sleep(2000);

                foreach (ManagementObject device in devices.Get())
                {
                    foreach (ManagementObject partition in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + device.Properties["DeviceID"].Value + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                    {
                        foreach (ManagementObject disk in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                        {

                            string deviceID = device.GetPropertyValue("DeviceID").ToString();
                            string pnpnDeviceID = device.GetPropertyValue("PNPDeviceID").ToString();
                            string volumeName = disk["VolumeName"].ToString();
                            string drive = disk["Name"].ToString();

                            this.FireOnDeviceConnected(drive);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposedValue)
                return;
            if (!disposing)
                ;
            int num = (int)DeviceWatcher.UnRegisterClass(this._className, this._windowHandle);
            this.disposedValue = true;
        }

        void IDisposable.Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class WNDCLASS
        {
            public int style;
            public DeviceWatcher.WndProc lpfnWndProc;
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