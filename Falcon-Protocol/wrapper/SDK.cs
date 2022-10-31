using Falcon_Protocol.interop;
using Falcon_Protocol.modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Falcon_Protocol.interop.FalconProtocolInteropService;

namespace Falcon_Protocol.wrapper
{
    public class SDK : ModulesManager
    {

        private byte[] getPwd()
        {
            return Encoding.ASCII.GetBytes("000000");
        }

        public bool Connect()
        {
           try
            {
                byte idCode = new byte();
                int[] iRet = new int[1];

                FalconProtocolInteropService.Init_Device(ref idCode, iRet);
                return this.calcIRet(iRet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool Disconnect()
        {
            int[] iRet = new int[1];

            FalconProtocolInteropService.UnInit_Device(iRet);
         
            return this.calcIRet(iRet);
        }

        public bool Login()
        {
            byte[] pwd = this.getPwd();
            int[] userType = new int[1];
            int[] iRet= new int[1];

            FalconProtocolInteropService.Eylog_Login(ref userType, ref pwd, iRet);

            return this.calcIRet(iRet);
        }

        public bool SyncDevTime()
        {
            int[] iRet = new int[1];
            byte[] pwd = this.getPwd();
            FalconProtocolInteropService.SyncDevTime(ref pwd, iRet);

            return this.calcIRet(iRet);
        }

        public MENU_CONFIG GetMenuConfig(int deviceIndex = -1)
        {
            var menuStruct = new MENU_CONFIG();
            int readMenuConfigLen = Marshal.SizeOf(menuStruct);
            int[] iret = new int[1];

            if (deviceIndex > 0)
            {
                FalconProtocolInteropService.Eylog_GetMenuConfig_ByIndex(ref menuStruct, readMenuConfigLen, iret, deviceIndex);
            }
            else
            {
                FalconProtocolInteropService.Eylog_GetMenuConfig(ref menuStruct, readMenuConfigLen, iret);
            }

            return menuStruct;
        }

        public MENU_CONFIG SetMenuConfig(MENU_CONFIG menuStruct, int deviceIndex = -1)
        {
            int config_len = Marshal.SizeOf(menuStruct);
            int[] iret = new int[1];

            if (deviceIndex == -1)
            {
                FalconProtocolInteropService.Eylog_SetMenuConfig(ref menuStruct, config_len, iret);
                FalconProtocolInteropService.Eylog_GetMenuConfig(ref menuStruct, config_len, iret);
                return menuStruct;
            }
           
            FalconProtocolInteropService.Eylog_SetMenuConfig_ByIndex(ref menuStruct, config_len, iret, deviceIndex);
            FalconProtocolInteropService.Eylog_GetMenuConfig_ByIndex(ref menuStruct, config_len, iret, deviceIndex);

            return menuStruct;
        }

        public ZFY_INFO GetDeviceInfo(int deviceIndex = -1)
        {
            
            ZFY_INFO info = new ZFY_INFO();
            int[] iret = new int[1];
            byte[] pwd = this.getPwd();

            if (deviceIndex == -1)
            {
                FalconProtocolInteropService.GetZFYInfo(ref info, pwd, iret);
                return info;
            }
            FalconProtocolInteropService.GetZFYInfo_ByIndex(ref info, pwd, iret, deviceIndex);
            return info;
        }

        public ZFY_INFO SetDeviceInfo(ZFY_INFO info, int deviceIndex = -1)
        {

            int[] iret = new int[1];
            byte[] pwd = this.getPwd();

            if (deviceIndex == -1)
            {
                byte[] _pwd = Encoding.ASCII.GetBytes("000000");
                FalconProtocolInteropService.WriteZFYInfo(ref info, _pwd, iret);
                FalconProtocolInteropService.GetZFYInfo(ref info, _pwd, iret);
                return info;
            }
            FalconProtocolInteropService.WriteZFYInfo_ByIndex(ref info, pwd, iret, deviceIndex);
            FalconProtocolInteropService.GetZFYInfo_ByIndex(ref info, pwd, iret, deviceIndex);
            return info;
        }

        public int GetTotalConnectedDevices
        {
            get
            {
                byte[] idcode = new byte[6];
                int[] iret = new int[1];
                int[] usb_totalnum = new int[1];
                FalconProtocolInteropService.Init_Device_UsbTotal(idcode, iret, usb_totalnum);

                return usb_totalnum[0];
            }
        }

        public void Blink(int index)
        {
            int[] iret = new int[1];
            byte[] cmd_params = new byte[1];
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < index; j++)
                {
                    if (i % 2 == 0)
                    {
                        cmd_params[0] = 0;
                        FalconProtocolInteropService.Eylog_Customized_Command((char)S_DEV_CMD_CUSTOMIZED.CUSTOMIZED_CMD_RED_LED_CTRL, cmd_params, iret, j);
                        cmd_params[0] = 1;
                        FalconProtocolInteropService.Eylog_Customized_Command((char)S_DEV_CMD_CUSTOMIZED.CUSTOMIZED_CMD_GREEN_LED_CTRL, cmd_params, iret, j);
                    }
                    else
                    {
                        cmd_params[0] = 1;
                        FalconProtocolInteropService.Eylog_Customized_Command((char)S_DEV_CMD_CUSTOMIZED.CUSTOMIZED_CMD_RED_LED_CTRL, cmd_params, iret, j);
                        cmd_params[0] = 0;
                        FalconProtocolInteropService.Eylog_Customized_Command((char)S_DEV_CMD_CUSTOMIZED.CUSTOMIZED_CMD_GREEN_LED_CTRL, cmd_params, iret, j);
                    }
                }

                Thread.Sleep(1000);
            }
        }

        public int GetBatteryLevel()
        {
            return 0;
        }

        public bool SetUDiskMode()
        {
            int[] iRet = new int[1];
            byte[] pwd = this.getPwd();

       
            FalconProtocolInteropService.SetMSDC(ref pwd, iRet);
       
            return this.calcIRet(iRet);
        }

        public bool SetUDiskMode(int index)
        {
            int[] iRet = new int[1];
            byte[] pwd = this.getPwd();

            FalconProtocolInteropService.SetMSDC_ByIndex(pwd, iRet, index);
            return this.calcIRet(iRet);
        }

        public void SetAPIMode(string drive_letter)
        {
            IntPtr[] filehandle = new IntPtr[1];
            int[] iret = new int[1];

            FalconProtocolInteropService.ConnectStorageDevice(drive_letter[0], filehandle);
            FalconProtocolInteropService.PassWordCheck(filehandle[0], this.getPwd(), iret);
            FalconProtocolInteropService.SetBWC_MSC_Return(filehandle[0], iret);
            Thread.Sleep(2500);
        }

        private bool calcIRet(int[] iRet)
        {
            return iRet[0] > 0; ;
        }
    }
}
