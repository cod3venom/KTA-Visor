using Falcon_Protocol.interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon_Protocol.wrapper
{
    public class SDK 
    {
        private  byte[] pwd = Encoding.ASCII.GetBytes("000000");

        public bool init()
        {
            byte idCode = new byte();
            int[] iRet = new int[1];

            FalconProtocolInteropService.Init_Device(ref idCode, iRet);

            return iRet[0] > 0;
        }
        public bool login()
        {
            int[] userType = new int[1];
            int[] iRet= new int[1];

            FalconProtocolInteropService.Eylog_Login(ref userType, ref pwd, iRet);

            return iRet[0] > 0;
        }
    }
}
