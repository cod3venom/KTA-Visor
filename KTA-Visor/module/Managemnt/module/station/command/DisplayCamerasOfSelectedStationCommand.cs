using KTA_Visor.module.Managemnt.module.camera.form;
using KTA_Visor.module.Managemnt.module.camera.form.settings;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.station.command
{
    public class DisplayCamerasOfSelectedStationCommand
    {
        public static List<CameraEntity.Camera> ALL_STATION_CAMERAS = new List<CameraEntity.Camera>();

        public static async void Execute(FlowLayoutPanel camerasFlowPanel, string stationCustomId)
        {
            
            try
            {
                CameraEntity camerasEntity = await new CameraService().findByStationId(stationCustomId);
                StationEntity station = await new StationService().findByCustomId(stationCustomId);
                
                if (camerasEntity.datas == null){
                    return;
                }

                camerasFlowPanel.Invoke((MethodInvoker)delegate {
                    camerasFlowPanel.Controls.Clear();
                });


                foreach (CameraEntity.Camera camera in camerasEntity.datas)
                {
                    if (DisplayCamerasOfSelectedStationCommand.ALL_STATION_CAMERAS.Contains(camera)){
                        continue;
                    }

                    Thread thr = new Thread(() =>
                    {
                        camerasFlowPanel.Invoke((MethodInvoker)async delegate
                        {
                            CameraItem item = new CameraItem(camera, station);
                            item.OnOpenCameraItem += (delegate (Object _sender, OnOpenCameraItemEvent e){
                                new CameraItemSettingsForm(e.Camera, station).ShowDialog();
                            });
                            await Task.Delay(100);

                            DisplayCamerasOfSelectedStationCommand.ALL_STATION_CAMERAS.Add(camera);
                            camerasFlowPanel.Controls.Add(item);
                        });
                    });

                    thr.IsBackground = true;
                    thr.Start();
                 }
             
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
