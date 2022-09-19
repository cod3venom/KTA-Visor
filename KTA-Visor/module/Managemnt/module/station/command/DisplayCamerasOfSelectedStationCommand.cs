using KTA_Visor.module.Managemnt.module.camera.form;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem.events;
using KTA_Visor.module.Shared.Global;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.station.command
{
    public class DisplayCamerasOfSelectedStationCommand
    {
        public static void Execute(FlowLayoutPanel camerasFlowPanel, dynamic camerasData)
        {
            if (camerasData == null || camerasData?.datas == null) return;

            CameraEntity camerasEntity = JsonConvert.DeserializeObject<CameraEntity>(camerasData.ToString());

            camerasFlowPanel.Invoke((MethodInvoker) delegate {
                camerasFlowPanel.Controls.Clear();
            });

                foreach (CameraEntity.Camera camera in camerasEntity.datas)
            {
                if (Globals.ALL_STATION_CAMERAS.Contains(camera))
                    continue;

                Globals.ALL_STATION_CAMERAS.Add(camera);

                camerasFlowPanel.Invoke((MethodInvoker)async delegate
                {
                    StationEntity station = await new StationService().findByCustomId(camera.stationId);
                    CameraItem item = new CameraItem(camera, station);

                    item.OnOpenCameraItem += (delegate (Object _sender, OnOpenCameraItemEvent e)
                    {
                        new CameraItemSettingsForm(e.Camera, station).ShowDialog();
                    });
                     camerasFlowPanel.Controls.Add(item);

                });
            }
        }
    }
}
