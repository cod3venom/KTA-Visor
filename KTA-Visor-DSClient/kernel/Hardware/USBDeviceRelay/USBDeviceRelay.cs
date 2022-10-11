using KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay.events;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay
{
    public class USBDeviceRelay: KTA_USB_Relay.Relay
    {
        public event EventHandler<OnFoundPortByBadgeId> OnFoundPortByBadgeId;

        public USBDeviceRelay(string portName,int baudRate, Parity parity, int dataBits, StopBits stopBit, KTALogger.Logger logger): base(portName, baudRate, parity, dataBits, stopBit, logger)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="badgeId"></param>
        /// <returns></returns>
        public int findPortByBadgeId(string badgeId)
        {
            int originLength = Globals.CAMERAS_LIST.Count;
            USBCameraDevice requestedDevice = Globals.CAMERAS_LIST.ToList().Find(requestedCamera => requestedCamera.BadgeId == badgeId);
            
            foreach(int portNumber in this.Ports)
            {
                if (!this.assignRelayPortToTheCamera(portNumber, ref requestedDevice))
                    continue;
                //this.OnFoundPortByBadgeId?.Invoke(this, new events.OnFoundPortByBadgeId(portNumber, requestedDevice));
                return portNumber;
            }
            return -1;
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="portNumber"></param>
        /// <param name="requestedDevice"></param>
        /// <returns></returns>
        private bool assignRelayPortToTheCamera(int portNumber, ref USBCameraDevice requestedDevice)
        {
            this.turnOffByPort(portNumber);
            Thread.Sleep(100);
            
            if (!Directory.Exists(requestedDevice.Drive.Name))
            {
                requestedDevice.RelayPort = portNumber;
                return true;
            }
            return false;
        }
    }
}
