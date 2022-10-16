using Falcon_Protocol.interop;
using Falcon_Protocol.modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Falcon_Protocol.interop.FalconProtocolInteropService;

namespace Falcon_Protocol.wrapper
{
    public class SDK : ModulesManager
    {

        private event EventHandler<EventArgs> OnDeviceMounted;

        /// <summary>
        /// 
        /// </summary>
        private byte[] pwd = Encoding.ASCII.GetBytes("000000");

        private int index = 0;

        public SDK SetIndex(int index)
        {
            this.index = index;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
           try
            {
                byte idCode = new byte();
                int[] iRet = new int[1];

                FalconProtocolInteropService.Init_Device(ref idCode, iRet);
                this.SyncDevTime();

                return this.calcIRet(iRet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Disconnect()
        {
            int[] iRet = new int[1];

            FalconProtocolInteropService.UnInit_Device(iRet);
         
            return this.calcIRet(iRet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Login()
        {
            int[] userType = new int[1];
            int[] iRet= new int[1];

            FalconProtocolInteropService.Eylog_Login(ref userType, ref pwd, iRet);

            return this.calcIRet(iRet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Mount()
        {
            int[] iRet = new int[1];
            FalconProtocolInteropService.SetMSDC(ref this.pwd, iRet);
            this.OnDeviceMounted?.Invoke(this, EventArgs.Empty);

            return this.calcIRet(iRet);
        }

        public bool SyncDevTime()
        {
            int[] iRet = new int[1];
            FalconProtocolInteropService.SyncDevTime(ref this.pwd, iRet);

            return this.calcIRet(iRet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuStruct"></param>
        /// <returns></returns>
        public MENU_CONFIG SetMenuConfig(MENU_CONFIG menuStruct, int deviceIndex = -1)
        {
            int config_len = Marshal.SizeOf(menuStruct);
            int[] iret = new int[1];

            if (deviceIndex != -1)
            {
                FalconProtocolInteropService.Eylog_SetMenuConfig_ByIndex(ref menuStruct, config_len, iret, deviceIndex);
            }
            else
            {
                FalconProtocolInteropService.Eylog_SetMenuConfig(ref menuStruct, config_len, iret);
            }
            return menuStruct;
        }

        public ZFY_INFO GetDeviceInfo(int deviceIndex)
        {
            
            ZFY_INFO info = new ZFY_INFO();
            int[] iret = new int[1];

            FalconProtocolInteropService.GetZFYInfo_ByIndex(ref info, this.pwd, iret, deviceIndex);
            return info;
        }


        public ZFY_INFO SetDeviceInfo(ZFY_INFO info, int deviceIndex)
        {

            int[] iret = new int[1];

            FalconProtocolInteropService.WriteZFYInfo_ByIndex(ref info, this.pwd, iret, deviceIndex);
            return info;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRet"></param>
        /// <returns></returns>
        private bool calcIRet(int[] iRet)
        {
            return iRet[0] > 0; ;
        }
    }
}
