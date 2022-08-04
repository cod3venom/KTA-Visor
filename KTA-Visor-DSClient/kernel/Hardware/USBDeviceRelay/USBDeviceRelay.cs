using KTA_USB_Relay.interop.interfaces;
using KTA_USB_Relay.interop.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay
{
    public class USBDeviceRelay : IUSBRelay
    {
        public int Init()
        {
            return InteropService.Init();
        }

        public int Open(UsbRelayDeviceInfo deviceInfo)
        {
            return InteropService.Open(deviceInfo);
        }

        public int OpenAllRelayChannels(int hHandle)
        {
            return InteropService.OpenAllRelayChannels(hHandle);
        }

        public int OpenOneRelayChannel(int hHandle, int index)
        {
            return InteropService.OpenOneRelayChannel(hHandle, index);
        }

        public int OpenWithSerialNumber(string serialNumber, int stringLength)
        {
            return InteropService.OpenWithSerialNumber(serialNumber, stringLength);
        }

        public void Close(int hHandle)
        {
            InteropService.Close(hHandle);
        }

        public int CloseAllRelayChannels(int hHandle)
        {
            return InteropService.CloseAllRelayChannels(hHandle);
        }

        public int CloseOneRelayChannel(int hHandle, int index)
        {
            return InteropService.CloseOneRelayChannel(hHandle, index);
        }

        public UsbRelayDeviceInfo Enumerate()
        {
            return InteropService.Enumerate();
        }

        public int Exit()
        {
            return InteropService.Exit();
        }

        public void FreeEnumerate(UsbRelayDeviceInfo deviceInfo)
        {
            InteropService.FreeEnumerate(deviceInfo);
        }

        public int GetStatus(int hHandle, ref int status)
        {
            return InteropService.GetStatus(hHandle, ref status);
        }
    }
}
