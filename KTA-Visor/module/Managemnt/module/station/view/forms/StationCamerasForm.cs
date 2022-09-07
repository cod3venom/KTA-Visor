using KTA_Visor.module.Managemnt.module.camera.form;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem.events;
using KTA_Visor.module.Shared.Global;
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
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Managemnt.module.station.view.forms
{
    public partial class StationCamerasForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string stationId;

        /// <summary>
        /// 
        /// </summary>
        private readonly StationService stationService;

        /// <summary>
        /// 
        /// </summary>
        public readonly CameraService cameraService;

        /// <summary>
        /// 
        /// </summary>
        private StationEntity station;

        /// <summary>
        /// 
        /// </summary>
        private CameraRDPForm cameraRDPForm;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        public StationCamerasForm(string stationId)
        {
            InitializeComponent();
            this.topBar1.Parent = this;
            this.stationId = stationId;
            this.stationService = new StationService();
            this.cameraService = new CameraService();
        }

        private async void StationCamerasForm_Load(object sender, EventArgs e)
        {
            this.station = await this.stationService.findById(stationId);
            this.cameraRDPForm = new CameraRDPForm(this.station.data.stationIp);
            this.cameraRDPForm.OnClose += turnOnAllCameras;
            this.fetchCameras();
        }

        private async void fetchCameras()
        {
            CameraEntity cameras = await this.cameraService.findByStationId(this.stationId);
            if (cameras.datas == null || cameras.datas.Count == 0)
                return;

            this.camerasFlowPanel.Controls.Clear();
            foreach(CameraEntity.Camera camera in cameras.datas)
            {
                CameraItem cameraItem = new CameraItem(camera);
                cameraItem.OnOpenCameraItem += (delegate (object sender, OnOpenCameraItemEvent e)
                {
                    this.openCameraSettings();
                });
                this.camerasFlowPanel.Controls.Add(cameraItem);
            }
        }

        private void openCameraSettings()
        {
            new CameraItemSettingsForm().ShowDialog();
        }

        private void turnOnAllCameras(object sender, EventArgs e)
        {
            Program.TunnelBackgroundWorker.sendRequest(new Request(
                "request://cameras/turn/all"
            ), this.station.data.stationIp);
        }
    }
}
