using Falcon_Protocol.interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Falcon_Protocol.interop.FalconProtocolInteropService;

namespace Falcon_Protocol.wrapper
{
    public class SDK 
    {
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
            byte idCode = new byte();
            int[] iRet = new int[1];

            FalconProtocolInteropService.Init_Device(ref idCode, iRet);
            this.SyncDevTime();

            return this.calcIRet(iRet);
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
        public MENU_CONFIG GetMenuConfig()
        {
            var menuStruct = new MENU_CONFIG();
            int readMenuConfigLen = Marshal.SizeOf(menuStruct);
            int[] iret = new int[1];

            FalconProtocolInteropService.Eylog_GetMenuConfig(ref menuStruct, readMenuConfigLen, iret);

            return menuStruct;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuStruct"></param>
        /// <returns></returns>
        public MENU_CONFIG SetMenuConfig(MENU_CONFIG menuStruct)
        {
            int config_len = Marshal.SizeOf(menuStruct);
            int[] iret = new int[1];

            FalconProtocolInteropService.Eylog_SetMenuConfig(ref menuStruct, config_len, iret);

            return menuStruct;
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
