using Falcon_Protocol;
using Falcon_Protocol.interop;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Falcon_Protocol.interop.FalconProtocolInteropService;

namespace KTA_VISOR_DSCLIENT_Tests.module.card
{
    [TestClass]
    public class BlinkTest
    {

        [TestMethod]
        public async void TestMethodBlink()
        {
            string cardId = "1153118187";
            CameraService service = new CameraService();
            CameraEntity cameraEntity = await service.findByCardId(cardId);
            Globals.CAMERAS_LIST.GetByBadge(cameraEntity?.data?.badgeId);

            FalconProtocol _protocol = new FalconProtocol();


            _protocol.Connect();
            byte[] pwd = Encoding.ASCII.GetBytes("000000");
            int[] iret = new int[1];
            byte[] cmd_params = new byte[1];
            int[] bat = new int[1];
            int[] usb_totalnum = new int[1];

            usb_totalnum = _protocol.GetTotalConnectedDevices();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < usb_totalnum[0]; j++)
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
                    FalconProtocolInteropService.ReadDeviceBatteryDumpEnergy_ByIndex(bat, pwd, iret, j);

                }

                Thread.Sleep(1000);
            }
        }
    }
}
