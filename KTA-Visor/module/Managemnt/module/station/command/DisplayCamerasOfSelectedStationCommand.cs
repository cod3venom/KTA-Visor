using KTA_Visor.module.Managemnt.module.camera.form;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem.events;
using KTA_Visor.module.Shared.Global;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
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
        public static async void Execute(FlowLayoutPanel camerasFlowPanel, string stationCustomId)
        {
            
            try
            {
                CameraEntity camerasEntity = await new CameraService().findByStationId(stationCustomId);

                camerasFlowPanel.Invoke((MethodInvoker)delegate {
                    camerasFlowPanel.Controls.Clear();
                });

                if (camerasEntity.datas == null)
                    return;

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
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void displayfakeRecords()
        {
            CameraEntity entity1 = new CameraEntity();
            entity1.data = new CameraEntity.Camera();
            entity1.data.id = "1";
            entity1.data.index = 1;
            entity1.data.cameraCustomId = "1234";
            entity1.data.badgeId= "1234";
            entity1.data.driveName= "1";
            entity1.data.active = true;
            entity1.data.stationId = "1111";
            entity1.data.updatedAt = "11.01.2022";
            entity1.data.createdAt= "12.01.2022";

            //for (int i = 0; i <)
        }
    }
}
