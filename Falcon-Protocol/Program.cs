using Falcon_Protocol.interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Falcon_Protocol.interop.FalconProtocolInteropService;

namespace Falcon_Protocol
{
    internal static class Program
    {

        static void Main()
        {
            FalconProtocol protocol = new FalconProtocol();

            protocol.Connect();
            ZFY_INFO info = protocol.GetDeviceInfo(0);

            

            info.userNo = System.Text.Encoding.UTF8.GetBytes("00000000000000");
            protocol.SetDeviceInfo(info, 0);

            info = protocol.GetDeviceInfo(0);

            //Console.WriteLine("cSerial: " + System.Text.Encoding.UTF8.GetChars(info.cSerial);
            Console.WriteLine("userNo: " + System.Text.Encoding.UTF8.GetString(info.userNo));
            Console.WriteLine("userName: " + System.Text.Encoding.UTF8.GetString(info.userName));
            Console.WriteLine("unitNo: " + System.Text.Encoding.UTF8.GetString(info.unitNo));
            Console.WriteLine("unitName: " + System.Text.Encoding.UTF8.GetString(info.unitName));

            Console.ReadLine();
        }
    }
}
