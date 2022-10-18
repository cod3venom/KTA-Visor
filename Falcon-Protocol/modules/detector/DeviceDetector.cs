using Falcon_Protocol.interfaces;
using Falcon_Protocol.modules.detector.events;
using Sdk.Core.DevicesDetection;
using Sdk.Core.Enums;
using System;
using System.Management;
using System.Threading;

namespace Falcon_Protocol.modules.detector
{
    public class DeviceDetector : IModuleInterface
    {
        public static string ModuleName = "DeviceDetector";

        public event EventHandler<OnDeviceMountedEvent> OnDeviceMounted;
        public event EventHandler<OnDeviceRemoved> OnDeviceRemoved;
        public event EventHandler<Exception> OnExceptionOccured;

        public enum EventType
        {
            Inserted = 2,
            Removed = 3
        }

        public void Run()
        {
             
            try
            {

                ManagementEventWatcher watcher = new ManagementEventWatcher();
                WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2 or EventType = 3");

                watcher.EventArrived += (s, e) =>
                {
                    string driveName = e.NewEvent.Properties["DriveName"].Value.ToString();
                    EventType eventType = (EventType)(Convert.ToInt16(e.NewEvent.Properties["EventType"].Value));

                    switch(eventType)
                    {
                        case EventType.Inserted:
                            this.onDriveMounted(driveName);
                            break;
                        case EventType.Removed:
                            this.onDriveRemoved(driveName);
                            break;
                    }
                    string eventName = Enum.GetName(typeof(EventType), eventType);

                    Console.WriteLine("{0}: {1} {2}", DateTime.Now, driveName, eventName);
                };

                watcher.Query = query;
                watcher.Start();

                Thread.Sleep(2000);
            }
            catch (Exception exception)
            {
                this.OnExceptionOccured?.Invoke(this, exception);
            }
        } 
 
        public void LoadConnectedDevices()
        {
            try
            {
                foreach (ManagementObject device in new ManagementObjectSearcher(@"SELECT * FROM Win32_DiskDrive WHERE InterfaceType LIKE 'USB%'").Get())
                {
                    foreach (ManagementObject partition in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + device.Properties["DeviceID"].Value + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                    {
                        foreach (ManagementObject disk in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                        {
                            string driveName = disk["Name"].ToString();
                            this.onDriveMounted(driveName);
                        }
                    }
                }
            }
            catch (ManagementException e)
            {
                this.OnExceptionOccured?.Invoke(this, e);
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }
        }

        private void onDriveMounted(string driveName)
        {
            try
            {
                this.OnDeviceMounted?.Invoke(this, new OnDeviceMountedEvent(driveName));
            }
            catch(Exception exception)
            {
                this.OnExceptionOccured?.Invoke(this, exception);
            }
        }

        private void onDriveRemoved(string driveName)
        {
           try
            {
                this.OnDeviceRemoved?.Invoke(this, new OnDeviceRemoved(driveName));
            }
            catch(Exception exception)
            {
                this.OnExceptionOccured?.Invoke(this, exception);
            }
        }

        public string GetModuleName()
        {
            return DeviceDetector.ModuleName;
        }
    }
}
