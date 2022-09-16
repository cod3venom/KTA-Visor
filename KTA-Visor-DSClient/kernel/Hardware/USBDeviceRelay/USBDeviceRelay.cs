using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
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
            USBCameraDevice requestedDevice = Globals.CAMERAS_LIST.ToList().Find(x => x.BadgeId == badgeId);
            if (requestedDevice == null)
                return -1;

            for (int portNumber = 1; portNumber < 9; portNumber++)
            {
                if (this.assignRelayPortToTheCamera(portNumber, ref requestedDevice))
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
            this.sendCommand(String.Format("C {0}", portNumber.ToString()));
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
