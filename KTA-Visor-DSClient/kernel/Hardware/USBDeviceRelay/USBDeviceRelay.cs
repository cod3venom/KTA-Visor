using KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay.events;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
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
        public int FindPortByCameraCustomId(string cameraCustomId)
        {
            USBCameraDevice requestedDevice = Globals.CAMERAS_LIST.Find(
                (USBCameraDevice requestedCamera) => requestedCamera.ID == cameraCustomId
            );
            
            foreach(int portNumber in this.Ports)
            {
                this.turnOffByPort(portNumber, 100);
                Thread.Sleep(100);

                bool driveExists = DriveInfo.GetDrives().Any(x => x.Name == requestedDevice?.Drive?.Name);

                if (!driveExists){
                    requestedDevice.RelayPort = portNumber;
                    return requestedDevice.RelayPort;
                }
            }
            return -1;
        }
    }
}
