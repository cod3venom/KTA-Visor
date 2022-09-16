using KTAVisorAPISDK.module.camera.entity;
using TCPTunnel.kernel.extensions.router.dto;
using Newtonsoft.Json;
using KTA_Visor.module.Shared.Global;

namespace KTA_Visor.module.Managemnt.module.camera.controller
{
    public class CamerasController
    {
        public CamerasController()
        {

        }
        public void Watch(Request request)
        {
            switch (request.Endpoint)
            {
                case "response://cameras/all":
                    break;
            }
        }

        private void receiveAllActiveCamerasFromSelectedStation(Request request)
        {
            CameraEntity cameraEntity = JsonConvert.DeserializeObject<CameraEntity.Camera>(request.Body);
            Globals.SELECTED_STATION_ACTIVE_CAMERAS = cameraEntity.datas;
        }
    }
}
