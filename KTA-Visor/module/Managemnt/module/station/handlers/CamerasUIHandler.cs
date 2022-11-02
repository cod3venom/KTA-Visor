using KTA_Visor.module.Managemnt.module.camera.form;
using KTA_Visor.module.Managemnt.module.camera.form.settings;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem.events;
using KTA_Visor.module.Managemnt.module.station.view;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.station.handlers
{
    public class CamerasUIHandler
    {
        private readonly StationView stationView;
        private readonly CameraService cameraService;
        private readonly StationService stationService;
        public readonly List<CameraEntity.Camera> tempCameras;

        private StationEntity currentStation;
        public CamerasUIHandler(StationView stationView)
        {
            this.stationView = stationView;
            this.cameraService = new CameraService();
            this.stationService = new StationService();
            this.tempCameras = new List<CameraEntity.Camera>();
        }


        public void Load(string stationCustomId)
        {
            Thread loadingThread = new Thread(async () =>
            {
                try
                {
                    this.currentStation = await this.getStationByCustomId(stationCustomId);
                    List<CameraEntity.Camera> stationCameras = await this.getCamerasBystationCustomId(stationCustomId);

                    this.clearBoard();

                    ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 10 };
                    Parallel.ForEach(stationCameras, options, camera => {
                        if (camera.active)
                        {
                            this.addToBoard(camera);
                        }
                    });
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            });

            loadingThread.IsBackground = true;
            loadingThread.Start();
            
        }

        private async Task<StationEntity> getStationByCustomId(string customId)
        {
            return await this.stationService.findByCustomId(customId);
        }

        private async Task<List<CameraEntity.Camera>> getCamerasBystationCustomId(string stationCustomId)
        {
            CameraEntity camera = await this.cameraService.findByStationId(stationCustomId);
            if (camera.datas == null){
                return new List<CameraEntity.Camera>();
            }

            return camera.datas;
        }


        private void clearBoard()
        {
            this.stationView.CamerasBoard.Invoke((MethodInvoker)delegate
            {
                this.stationView.CamerasBoard.Controls.Clear() ;
            });
        }

        private void addToBoard(CameraEntity.Camera camera)
        {
            if (this.tempCameras.Contains(camera)){
                return;
            }

            this.tempCameras.Add(camera);
            this.stationView.CamerasBoard.Invoke((MethodInvoker)async delegate
            {
                CameraItem item = new CameraItem(camera, this.currentStation);
                item.OnOpenCameraItem += (delegate (Object _sender, OnOpenCameraItemEvent e) {
                    new CameraItemSettingsForm(e.Camera, this.currentStation).ShowDialog();
                });
                await Task.Delay(100);

                this.stationView.CamerasBoard.Controls.Add(item);
            });
        }
    }
}
