// Decompiled with JetBrains decompiler
// Type: Falcon_USB.FalconManager
// Assembly: Falcon_USB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7924EA10-DAC0-471E-BD57-BD7B43142DEE
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon_USB.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using USBKitcs;
using USBKitcs.DeviceNotify;
using USBKitcs.Main;

namespace Falcon_USB
{
  public class FalconManager
  {
    private IDeviceNotifier _deviceNotifier;
    private IUsbDeviceEventDetector _usbNotifier = (IUsbDeviceEventDetector) new UsbDeviceEventDetector();
    private List<FalconDevice> _devices;

    public FalconDevice[] Devices => this._devices.ToArray();

    public event EventHandler DeviceInserted;

    public event EventHandler<DeviceMountedEventArgsFalcon> DeviceMounted;

    public event EventHandler<DeviceMountedEventArgsFalcon> DeviceDismounted;

    public event EventHandler DeviceRemoved;

    public FalconManager()
    {
      this._devices = new List<FalconDevice>();
      this.InitNotifiers();
    }

    private void InitNotifiers()
    {
      this._usbNotifier.DriveInserted += (EventHandler<DriveChangedEventArgs>) ((s, e) => this.DeviceMountNotified(e.Drive));
      this._usbNotifier.DriveRemoved += (EventHandler<DriveChangedEventArgs>) ((s, e) => this.DeviceDismountNotified(e.Drive));
      this._deviceNotifier = DeviceNotifier.OpenDeviceNotifier();
      this._deviceNotifier.OnDeviceNotify += new EventHandler<DeviceNotifyEventArgs>(this.DeviceNotified);
    }

    private void DeviceNotified(object sender, DeviceNotifyEventArgs e)
    {
      switch (e.EventType)
      {
        case EventType.DeviceArrival:
          string[] deviceLocations = this._devices.Select<FalconDevice, string>((Func<FalconDevice, string>) (x => x.Location)).ToArray<string>();
          Array.ForEach<UsbFalconDevice>(UsbDevice.AllLibUsbDevices.Where<UsbRegistry>((Func<UsbRegistry, bool>) (x => !((IEnumerable<string>) deviceLocations).Contains<string>(x.DeviceProperties["LocationInformation"].ToString()))).Select<UsbRegistry, UsbFalconDevice>((Func<UsbRegistry, UsbFalconDevice>) (x => new UsbFalconDevice(x))).ToArray<UsbFalconDevice>(), new Action<UsbFalconDevice>(this.CreateDevice));
          break;
        case EventType.DeviceRemoveComplete:
          string[] usbLocations = UsbDevice.AllLibUsbDevices.Select<UsbRegistry, string>((Func<UsbRegistry, string>) (x => x.DeviceProperties["LocationInformation"].ToString())).ToArray<string>();
          Array.ForEach<FalconDevice>(this._devices.Where<FalconDevice>((Func<FalconDevice, bool>) (x => !((IEnumerable<string>) usbLocations).Contains<string>(x.Location))).ToArray<FalconDevice>(), new Action<FalconDevice>(this.RemoveDevice));
          break;
      }
    }

    private void DeviceMountNotified(string drive)
    {
      if (this.DeviceMounted == null || !Directory.Exists(drive))
        return;
      this.DeviceMounted((object) this, new DeviceMountedEventArgsFalcon(drive));
    }

    private void DeviceDismountNotified(string drive)
    {
      if (this.DeviceDismounted == null)
        return;
      this.DeviceDismounted((object) this, new DeviceMountedEventArgsFalcon(drive));
    }

    private void RemoveDevices() => ((IEnumerable<FalconDevice>) this.Devices).Where<FalconDevice>((Func<FalconDevice, bool>) (dev => dev.IsDeviceInserted())).ToList<FalconDevice>().ForEach(new Action<FalconDevice>(this.RemoveDevice));

    private void RemoveDevice(FalconDevice device)
    {
      device.Dispose();
      this._devices.Remove(device);
      if (this.DeviceRemoved != null)
        this.DeviceRemoved((object) device, EventArgs.Empty);
      device.FireRemoved();
    }

    public void ScanDevices()
    {
      Array.ForEach<FalconDevice>(this.Devices, new Action<FalconDevice>(this.RemoveDevice));
      Array.ForEach<UsbFalconDevice>(UsbFalconDevice.GetVisionDevices(), new Action<UsbFalconDevice>(this.CreateDevice));
    }

    private void CreateDevice(UsbFalconDevice dev)
    {
      FalconDevice sender = new FalconDevice(dev);
      this._devices.Add(sender);
      if (this.DeviceInserted == null)
        return;
      this.DeviceInserted((object) sender, EventArgs.Empty);
    }
  }
}
