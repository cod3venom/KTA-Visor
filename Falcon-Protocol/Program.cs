using Falcon_Protocol.interop;
using Falcon_Protocol.wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Falcon_Protocol.interop.FalconProtocolInteropService;

namespace Falcon_Protocol
{
    public class Program
    {
        private static SDK sdk;
 

        public static void Main()
        {
            sdk = new SDK();
            byte[] spwd = Encoding.ASCII.GetBytes("000000");



            

            byte idCode = new byte();
            int[] idCodeRet = new int[1];
             
            FalconProtocolInteropService.Init_Device(ref idCode, idCodeRet);

            //int[] mountResult = new int[1];
            //FalconProtocolInteropService.SetMSDC(ref spwd, mountResult);

            //int[] width = new int [1];
            //int[] height = new int[1];
            //int[] resIRet = new int[1];
            //FalconProtocolInteropService.ReadDeviceResolution(width, height, ref spwd, resIRet);


       

            //set config
            //MENU_CONFIG menuStruct = new MENU_CONFIG();
            //menuStruct.gps = 1;
            //menuStruct.video_quality = 1;

            //int configLen = System.Runtime.InteropServices.Marshal.SizeOf(menuStruct);
            //int[] configiRet = new int[1];

            //FalconProtocolInteropService.Eylog_SetMenuConfig(ref menuStruct, configLen, configiRet);


            ////read config
            //MENU_CONFIG readMenuStruct = new MENU_CONFIG();
            //int readMenuConfigLen = System.Runtime.InteropServices.Marshal.SizeOf(readMenuStruct);
            //int[] readMenuConfigiRet = new int[1];

            //FalconProtocolInteropService.Eylog_GetMenuConfig(ref readMenuStruct, readMenuConfigLen, readMenuConfigiRet);

            int battery = 0;
            int[] batteryRet = new int[1];

            FalconProtocolInteropService.ReadDeviceBatteryDumpEnergy(ref battery, ref spwd, batteryRet);
            
            //if (sdk.init())
            //{
            //    Console.WriteLine("INIT [OK]");

            //    if (sdk.login())
            //    {
            //        Console.WriteLine("LOGIN [OK]");
            //    }
            //}


            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
