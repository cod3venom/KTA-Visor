using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher
{
    public class DeviceWatcher
    {

        private BackgroundWorker backgroundWorker;


        /// <summary>
        /// 
        /// </summary>
        private ManagementEventWatcher watcher;


        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnPNPDeviceInsert;


        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnPNPDeviceRemoved;


        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnUSBDeviceInsert;


        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnUSBDeviceRemoved;



        public DeviceWatcher()
        { 
            this.backgroundWorker = new BackgroundWorker();
            this.watcher = new ManagementEventWatcher();
        }

        public void startWatching()
        {
            this.backgroundWorker.DoWork += bgwDriveDetector_DoWork;
            this.backgroundWorker.RunWorkerAsync();
        }



         

        void bgwDriveDetector_DoWork(object sender, DoWorkEventArgs e)
        {
            var insertPnPQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            var insertWatcher = new ManagementEventWatcher(insertPnPQuery);
            insertWatcher.EventArrived += InsertPNPWatcher_EventArrived; ;
            insertWatcher.Start();

            var removePnPQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
            var removeWatcher = new ManagementEventWatcher(removePnPQuery);
            removeWatcher.EventArrived += RemoveWatcher_EventArrived; ;
            removeWatcher.Start();

            var insertUSBQuery= new WqlEventQuery("SELECT * FROM Win32_LogicalDisk WHERE EventType = 2");
            var insertUSBWatcher = new ManagementEventWatcher(insertUSBQuery);
            insertUSBWatcher.EventArrived += InsertUSBWatcher_EventArrived;
            insertUSBWatcher.Start();

            var removeUSBQuery = new WqlEventQuery("SELECT * FROM Win32_LogicalDisk WHERE EventType = 3");
            var removeUSBWatcher = new ManagementEventWatcher(removeUSBQuery);
            removeUSBWatcher.EventArrived += RemoveUSBWatcher_EventArrived;
            removeUSBWatcher.Start();
        }

        private void RemoveUSBWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            this.OnUSBDeviceRemoved?.Invoke(sender, e);
        }

        private void InsertUSBWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            this.OnUSBDeviceInsert?.Invoke(sender, e);
        }

        private void RemoveWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            this.OnPNPDeviceRemoved?.Invoke(this, e);
        }

        private void InsertPNPWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            this.OnPNPDeviceInsert?.Invoke(this, e);
        }
    }
}
