// Decompiled with JetBrains decompiler
// Type: Falcon.Detection.DevicesDetection
// Assembly: Falcon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B63D6514-B208-43D6-B3E8-6CD8252CCADA
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon.dll

using Sdk.Core.DevicesDetection;
using Sdk.Core.Enums;
using System;
using System.Management;

namespace Falcon.Detection
{
  public class DevicesDetection : IDeviceDetection
  {
    private ManagementEventWatcher _usbInsertedManagementEventWatcher;
    private ManagementEventWatcher _usbRemovedManagementEventWatcher;

    public event DeviceDetectionHandle OnDeviceDetected;

    public event DeviceDetectionHandle OnDeviceRemoved;

    public event DeviceDetectionHandle OnDeviceMounted;

    public DevicesDetection() => this.Init();

    private void Init()
    {
      ManagementScope scope = new ManagementScope("root\\CIMV2")
      {
        Options = {
          EnablePrivileges = true
        }
      };
      try
      {
        this._usbInsertedManagementEventWatcher = new ManagementEventWatcher(scope, (EventQuery) new WqlEventQuery()
        {
          EventClassName = "__InstanceCreationEvent",
          WithinInterval = new TimeSpan(0, 0, 0, 0, 500),
          Condition = "TargetInstance ISA 'Win32_DiskDrive'"
        });
        this._usbInsertedManagementEventWatcher.EventArrived += new EventArrivedEventHandler(this.UsbUsbInsertedEventWatcherOnEventArrived);
        this._usbInsertedManagementEventWatcher.Start();
      }
      catch (Exception ex)
      {
        this._usbInsertedManagementEventWatcher?.Stop();
      }
      try
      {
        this._usbRemovedManagementEventWatcher = new ManagementEventWatcher(scope, (EventQuery) new WqlEventQuery()
        {
          EventClassName = "__InstanceDeletionEvent",
          WithinInterval = new TimeSpan(0, 0, 0, 0, 500),
          Condition = "TargetInstance ISA 'Win32_USBHub'"
        });
        this._usbRemovedManagementEventWatcher.EventArrived += new EventArrivedEventHandler(this.UsbRemovedEventWatcherOnEventArrived);
        this._usbRemovedManagementEventWatcher.Start();
      }
      catch
      {
        this._usbRemovedManagementEventWatcher?.Stop();
      }
    }

    private void UsbUsbInsertedEventWatcherOnEventArrived(object sender, EventArrivedEventArgs e)
    {
      ManagementBaseObject targetInstance = (ManagementBaseObject) e.NewEvent["TargetInstance"];
      if (!this.VerifyInsertedUsb(targetInstance))
        return;
      string volumeName;
      string driveName;
      if (this.GetDriveLetterFromDisk(targetInstance["DeviceID"]?.ToString(), out volumeName, out driveName))
      {
        string str = targetInstance["SerialNumber"]?.ToString();
        DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
        {
          DriveLetter = driveName,
          DriveCaption = volumeName,
          SerialNumber = str
        };
        DeviceDetectionHandle onDeviceMounted = this.OnDeviceMounted;
        if (onDeviceMounted == null)
          return;
        onDeviceMounted(detectedInformation, VolumeChangeEventType.Mount);
      }
      else
      {
        string str1 = targetInstance["Caption"]?.ToString();
        string str2 = targetInstance["SerialNumber"]?.ToString();
        DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
        {
          DriveCaption = str1,
          SerialNumber = str2
        };
        DeviceDetectionHandle onDeviceDetected = this.OnDeviceDetected;
        if (onDeviceDetected == null)
          return;
        onDeviceDetected(detectedInformation, VolumeChangeEventType.Inserted);
      }
    }

    private void UsbRemovedEventWatcherOnEventArrived(object sender, EventArrivedEventArgs e)
    {
      ManagementBaseObject targetInstance = (ManagementBaseObject) e.NewEvent["TargetInstance"];
      if (!this.VerifyRemovedUsb(targetInstance))
        return;
      string volumeName;
      string driveName;
      if (this.GetDriveLetterFromDisk(targetInstance["DeviceID"]?.ToString(), out volumeName, out driveName))
      {
        DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
        {
          DriveCaption = volumeName,
          DriveLetter = driveName,
          SerialNumber = this.GetDeviceSerialNumber(targetInstance.Properties["PNPDeviceID"].Value.ToString())
        };
        DeviceDetectionHandle onDeviceRemoved = this.OnDeviceRemoved;
        if (onDeviceRemoved == null)
          return;
        onDeviceRemoved(detectedInformation, VolumeChangeEventType.Unmount);
      }
      else
      {
        DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
        {
          SerialNumber = this.GetDeviceSerialNumber(targetInstance.Properties["PNPDeviceID"].Value.ToString())
        };
        DeviceDetectionHandle onDeviceRemoved = this.OnDeviceRemoved;
        if (onDeviceRemoved == null)
          return;
        onDeviceRemoved(detectedInformation, VolumeChangeEventType.Removed);
      }
    }

    private bool GetDriveLetterFromDisk(
      string deviceId,
      out string volumeName,
      out string driveName)
    {
      volumeName = (string) null;
      driveName = (string) null;
      ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(new ObjectQuery("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + deviceId + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition"));
      try
      {
        foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
        {
          using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + managementBaseObject["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get().GetEnumerator())
          {
            if (enumerator.MoveNext())
            {
              ManagementBaseObject current = enumerator.Current;
              volumeName = current["VolumeName"]?.ToString();
              driveName = current["Name"]?.ToString();
              return true;
            }
          }
        }
        return false;
      }
      catch
      {
        return false;
      }
    }

    private bool VerifyInsertedUsb(ManagementBaseObject targetInstance) => targetInstance != null && targetInstance["Status"]?.ToString() == "OK" && bool.Parse(targetInstance["MediaLoaded"].ToString()) && targetInstance["InterfaceType"]?.ToString() == "USB" && targetInstance["Caption"]?.ToString() == "NOVATEKN vt-DSC";

    private bool VerifyRemovedUsb(ManagementBaseObject targetInstance) => targetInstance != null && targetInstance["Status"]?.ToString() == "OK" && targetInstance["PNPDeviceID"]?.ToString() == "USB\\VID_0603&PID_8611\\966110000000100";

    private string GetDeviceSerialNumber(string deviceIdString)
    {
      int length = deviceIdString.Length - deviceIdString.LastIndexOf("\\", StringComparison.Ordinal) - 1;
      return deviceIdString.Substring(deviceIdString.LastIndexOf("\\", StringComparison.Ordinal) + 1, length);
    }
  }
}
