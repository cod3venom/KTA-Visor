using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
using KTA_Visor_DSClient.module.Management.module.Camera.command.backend;
using KTA_Visor_DSClient.module.Management.module.Camera.command.filesystem;
using KTA_Visor_DSClient.module.Management.module.Camera.component.CameraItem;
using KTA_Visor_DSClient.module.Management.module.Camera.component.CameraItem.events;
using KTA_Visor_DSClient.module.Management.module.Camera.service;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTA_Visor_UI.component.custom.MessageWindow;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.fileHistory.service;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.Management.module.Camera.view.CamerasPanelView
{
    public partial class CamerasPanelView : UserControl
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly Settings settings;
        
        /// <summary>
        /// 
        /// </summary>
        private readonly CamerasService camerasService;
        
        /// <summary>
        /// 
        /// </summary>
        private readonly CameraService cameraService;
        
        /// <summary>
        /// 
        /// </summary>
        private readonly StationService stationService;

        /// <summary>
        /// 
        /// </summary>
        private readonly FileHistoryService fileHistoryService;

        public CamerasPanelView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceWatcher"></param>
        public CamerasPanelView(DeviceWatcher deviceWatcher)
        {
            InitializeComponent();
            this.settings = new Settings();
            this.camerasService = new CamerasService(deviceWatcher, Program.logger);
            this.cameraService = new CameraService();
            this.stationService = new StationService();
            this.fileHistoryService = new FileHistoryService();
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CamerasPanelVIew_Load(object sender, EventArgs e)
        {

            this.camerasService.OnCameraConnectedEvent += OnCameraConnectedEvent;
            this.camerasService.OnCameraDisconnectedEvent += OnCameraDisconnectedEvent;
            this.camerasService.OnCameraConnectedOrDisconnected += OnCameraConnectedOrDisconnected;
            this.camerasService.Start();

            this.camerasService.DeviceWatcher.LoadConnectedDevices();

        }
         

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCameraConnectedEvent(object sender, CameraConnectedEvent e)
        {
            Program.logger.success(String.Format("Camera {0} connected", e.Camera.BadgeId));
            this.handleConnectedCamera(e);
        }

        /// <summary>
        /// Event fires when camera
        /// is ejected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCameraDisconnectedEvent(object sender, CameraDisconnectedEvent e)
        {
            Program.logger.error(String.Format("Camera {0} disconnected", e.Camera.BadgeId));
            this.handleDisconnectedCamera(e);
        }

        /// <summary>
        /// Event is fired when camera is 
        /// inserted or ejected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCameraConnectedOrDisconnected(object sender, EventArgs e)
        {
            Program.logger.warn("Camera connected or removed");
        }


        private int counter = 0;
        /// <summary>
        /// Handle connected camera means,
        /// add it to the GUI and handle
        /// its OPEN BUTTON click event.
        /// Once button will be klicked,
        /// it fill find its own port number
        /// on docking station, then it will
        /// turn OFF all cameras and turn ON
        /// again only port assigned to it.
        /// </summary>
        /// <param name="e"></param>
        private async void handleConnectedCamera(CameraConnectedEvent e)
        {
            if (!await MarkCameraAsActiveOnBackendCommand.Execute(e.Camera))
            {
                AlertWindow.Show(string.Format(
                    "Nie udało się oznaczyć kamerę {0} jaką aktywną, proszę wycągnąc i wsadzić kamerę jeszcze raz", e.Camera.BadgeId
                ));
                return;
            }

            CameraItem cameraItem = new CameraItem(e.Camera, this.camerasService.FalconBridge);
            cameraItem.OnOpenCameraItem += (delegate (object sender, OnOpenCameraItemEvent evt) {
                new AlertWindow("Kamerę można konfigurować tylko i wyłącznie za pomocą stacji zarządzającej KTA-Visor");
            });

            this.containerPanel.Controls.Add(cameraItem);

            if (this.settings.SettingsObj.app.fileSystem.autoCopy)
            {
                CopyCameraFilesToNetworkStorageCommand.Execute(
                    Globals.STATION?.data?.stationId,
                    e.Camera.ID,
                    e.Camera.BadgeId,
                    this.fileHistoryService,
                    this.camerasService.FilesFromDrive(e.Camera.Drive.Name),
                    this.settings.SettingsObj.app.fileSystem.filesPath
                );
            }
        }


        /// <summary>
        /// Remove ejected camrea from
        /// the GUI based on its
        /// BADGE ID
        /// </summary>
        /// <param name="e"></param>
        private async void handleDisconnectedCamera(CameraDisconnectedEvent e)
        {
            foreach (Control control in this.containerPanel.Controls)
            {
                if (!typeof(CameraItem).IsInstanceOfType(control))
                    continue;

                CameraItem cameraItem = (CameraItem)control;

                if (cameraItem.Badge == e.Camera.BadgeId)
                {
                    this.containerPanel.Controls.Remove(control);
                    await MarkCameraAsInactiveOnBackendCommand.Execute(e.Camera);
                }
            }
        }

    }
}
