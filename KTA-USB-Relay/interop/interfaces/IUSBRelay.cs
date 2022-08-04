using KTA_USB_Relay.interop.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_USB_Relay.interop.interfaces
{
    public interface IUSBRelay
    {
        /// <summary>  
        /// Init the USB Relay Libary  
        /// </summary>  
        /// <returns>This function returns 0 on success and -1 on error.</returns>  
        int Init();

        /// <summary>  
        /// Finalize the USB Relay Libary.  
        /// This function frees all of the static data associated with  
        /// USB Relay Libary. It should be called at the end of execution to avoid  
        /// memory leaks.  
        /// </summary>  
        /// <returns>This function returns 0 on success and -1 on error.</returns>  
        int Exit();

        /// <summary>  
        /// Enumerate the USB Relay Devices.  
        /// </summary>  
        /// <returns></returns>  
        UsbRelayDeviceInfo Enumerate();

        /// <summary>  
        /// Free an enumeration Linked List  
        /// </summary>  
        /// <param name="deviceInfo"></param>  
        void FreeEnumerate(UsbRelayDeviceInfo deviceInfo);

        /// <summary>  
        /// Open device that serial number is serialNumber  
        /// </summary>  
        /// <param name="serialNumber"></param>  
        /// <param name="stringLength"></param>  
        /// <returns>This funcation returns a valid handle to the device on success or NULL on failure.</returns>  
        int OpenWithSerialNumber(string serialNumber, int stringLength);

        /// <summary>  
        /// Open a usb relay device  
        /// </summary>  
        /// <param name="deviceInfo"></param>  
        /// <returns>This funcation returns a valid handle to the device on success or NULL on failure.</returns>  
        int Open(UsbRelayDeviceInfo deviceInfo);

        /// <summary>  
        /// Close a usb relay device  
        /// </summary>  
        /// <param name="hHandle"></param>  
        void Close(int hHandle);

        /// <summary>  
        /// open a relay channel on the USB-Relay-Device  
        /// </summary>  
        /// <param name="hHandle">Which usb relay device your want to operate</param>  
        /// <param name="index">Which channel your want to open</param>  
        /// <returns>0 -- success; 1 -- error; 2 -- index is outnumber the number of the usb relay device</returns>  
        int OpenOneRelayChannel(int hHandle, int index);

        /// <summary>  
        /// open all relay channel on the USB-Relay-Device  
        /// </summary>  
        /// <param name="hHandle">which usb relay device your want to operate</param>  
        /// <returns>0 -- success; 1 -- error</returns>  
        int OpenAllRelayChannels(int hHandle);

        /// <summary>  
        /// close a relay channel on the USB-Relay-Device  
        /// </summary>  
        /// <param name="hHandle">which usb relay device your want to operate</param>  
        /// <param name="index">which channel your want to close</param>  
        /// <returns>0 -- success; 1 -- error; 2 -- index is outnumber the number of the usb relay device</returns>  
        int CloseOneRelayChannel(int hHandle, int index);

        /// <summary>  
        /// close all relay channel on the USB-Relay-Device  
        /// </summary>  
        /// <param name="hHandle">hich usb relay device your want to operate</param>  
        /// <returns>0 -- success; 1 -- error</returns>  
        int CloseAllRelayChannels(int hHandle);

        /// <summary>  
        /// status bit: High --> Low 0000 0000 0000 0000 0000 0000 0000 0000, one bit indicate a relay status.  
        /// the lowest bit 0 indicate relay one status, 1 -- means open status, 0 -- means closed status.  
        /// bit 0/1/2/3/4/5/6/7/8 indicate relay 1/2/3/4/5/6/7/8 status  
        /// </summary>  
        /// <param name="hHandle"></param>  
        /// <param name="status"></param>  
        /// <returns>0 -- success; 1 -- error</returns>  
        int GetStatus(int hHandle, ref int status);
    }
}
