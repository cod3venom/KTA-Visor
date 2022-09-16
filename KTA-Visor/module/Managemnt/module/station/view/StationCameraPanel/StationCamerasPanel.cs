using KTA_Visor.module.Managemnt.module.camera.form;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.station.view.StationCameraPanel
{
    public partial class StationCamerasPanel : UserControl
    {

        private readonly string stationId;
        private readonly StationService stationService;
        public readonly CameraService cameraService;
        private StationEntity station;

        public StationCamerasPanel()
        {
            InitializeComponent();
        }
        public StationCamerasPanel(string stationId)
        {
            InitializeComponent();
            this.stationId = stationId;
            this.stationService = new StationService();
            this.cameraService = new CameraService();
        }

        private void StationCamerasPanel_Load(object sender, EventArgs e)
        {
            this.fetchStation();
            this.fetchCameras();
        }

        private async void fetchStation()
        {
            this.station = await this.stationService.findByCustomId(this.stationId);
        }
        private async void fetchCameras()
        {
            CameraEntity cameras = await this.cameraService.findByStationId(this.stationId);
            foreach(CameraEntity.Camera camera in cameras.datas)
            {
                if (!camera.active){
                    continue;
                }

                CameraItem cameraItem = new CameraItem(camera, this.station);
                cameraItem.OnOpenCameraItem += onOpenCameraSettings;
            }
        }

        private void onOpenCameraSettings(object sender, Camera.component.CameraItem.events.OnOpenCameraItemEvent e)
        {
            CameraItemSettingsForm settingsForm = new CameraItemSettingsForm(e.Camera, this.station);
            settingsForm.ShowDialog();
        }
    }
}
