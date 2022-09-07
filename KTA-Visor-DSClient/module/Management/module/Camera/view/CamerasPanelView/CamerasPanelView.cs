using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.FalconBridge;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
using KTA_Visor_DSClient.module.Management.module.Camera.command;
using KTA_Visor_DSClient.module.Management.module.Camera.component.CameraItem;
using KTA_Visor_DSClient.module.Management.module.Camera.component.CameraItem.events;
using KTA_Visor_DSClient.module.Management.module.Camera.service;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.dto.request;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.fileHistory.service;
using KTAVisorAPISDK.module.station.dto;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            Program.Relay.OnTurnedOnByPort += onOpeningSelectedCameraInExternalTool;

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

            CameraEntity cameraEntity = await this.cameraService.create(new CreateCameraRequestTObject(
                    e.Camera.ID,
                    e.Camera.BadgeId,
                    e.Camera.Drive.Name
            ));

            if (cameraEntity.data.id == null)
                return;


            List<string> activeCamerasList = new List<string>() { cameraEntity.data.id };
            AddActiveCameraToStationRequestTObject payload = new AddActiveCameraToStationRequestTObject(
                activeCamerasList
            );
            Globals.STATION = await this.stationService.addActiveCamerasToStation(
                Globals.STATION?.data?.id,
                payload
            );


            CameraItem cameraItem = new CameraItem(e.Camera, this.camerasService.FalconBridge);
            this.containerPanel.Controls.Add(cameraItem);

            cameraItem.OnOpenCameraItem += (delegate (object sender, OnOpenCameraItemEvent evt)
            {
                if (!Globals.IS_ALL_COPYING_PROCESS_ARE_END)
                {
                    MessageBox.Show("Proszę poczekać póki trwa kopiowanie wszystkich plików");
                    return;
                }

                Thread thr = new Thread((ThreadStart) delegate
                {   
                    cameraItem.Camera.RelayPort = Program.Relay.findPortByBadgeId(evt.Camera.BadgeId);
                    this.camerasService.FalconBridge.Sdk.CloseDevice();
                    Program.Relay.turnOffAll();
                    Globals.CAMERAS_LIST.Clear();
                    
                    Thread.Sleep(4000);
                    Program.Relay.turnOnByPort(cameraItem.Camera.RelayPort);
                });

                thr.IsBackground = true;
                thr.Start();
            });

            if (this.settings.SettingsObj.app.fileSystem.autoCopy)
            {
                CopyCameraFilesToNetworkStorageCommand.Execute(
                    Globals.STATION?.data?.stationId ,
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
        private void handleDisconnectedCamera(CameraDisconnectedEvent e)
        {
            foreach (Control control in this.containerPanel.Controls)
            {
                if (!typeof(CameraItem).IsInstanceOfType(control))
                    continue;

                CameraItem cameraItem = (CameraItem)control;

                if (cameraItem.Badge == e.Camera.BadgeId)
                {
                    this.containerPanel.Controls.Remove(control);
                }
            }
        }

        /// <summary>
        /// This method is used to
        /// Configure global variables which
        /// are IS_IN_SETTINGS_MODE and ALLOW_FS_MOUNTING
        /// then open external tool to be able to configure
        /// the selected camera, after that it should
        /// once tool will be closed, we should receive
        /// event and then TurnOFF and again TurnON all the cameras back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onOpeningSelectedCameraInExternalTool(object sender, EventArgs e)
        {
            Program.logger.success("Turned ON one device by port number");

            Globals.IS_IN_SETTINGS_MODE = true;
            FalconGlobals.ALLOW_FS_MOUNTING = false;

            Process prc = new Process();
            prc.StartInfo.FileName = @"fpro\fpro.exe";
            prc.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            prc.EnableRaisingEvents = true;
            prc.Exited += (async delegate (object _sender, EventArgs _e) {
                Globals.IS_IN_SETTINGS_MODE = false;
                FalconGlobals.ALLOW_FS_MOUNTING = true;

                Program.Relay.turnOffAll();
                await Task.Delay(4000);
                Program.Relay.turnOnAll();
            });
            prc.Start();
        }

    }
}
