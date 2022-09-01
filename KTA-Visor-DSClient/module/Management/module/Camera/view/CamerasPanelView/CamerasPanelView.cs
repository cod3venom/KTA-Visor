using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.FalconBridge;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
using KTA_Visor_DSClient.module.Management.module.Camera.command;
using KTA_Visor_DSClient.module.Management.module.Camera.component.CameraItem;
using KTA_Visor_DSClient.module.Management.module.Camera.component.CameraItem.events;
using KTA_Visor_DSClient.module.Management.module.Camera.flags;
using KTA_Visor_DSClient.module.Management.module.Camera.form.CameraControlForm;
using KTA_Visor_DSClient.module.Management.module.Camera.service;
using KTA_Visor_DSClient.module.Shared.Globals;
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

        private readonly Settings settings;
        private readonly CamerasService camerasService;

        public CamerasPanelView()
        {
            InitializeComponent();
        }

        public CamerasPanelView(DeviceWatcher deviceWatcher)
        {
            InitializeComponent();
            this.settings = new Settings();
            this.camerasService = new CamerasService(deviceWatcher, Program.logger);
        }
 
        private void CamerasPanelVIew_Load(object sender, EventArgs e)
        {
            Program.Relay.OnEndTurningOffAll += onEndTurnedonAllCameras;
            Program.Relay.OnEndTurningOnfAll += onEndTurningOnAllCameras;
            Program.Relay.OnTurnedOnByPort += OnTurnedOneByPortNumber;

            this.camerasService.OnCameraConnectedEvent += OnCameraConnectedEvent;
            this.camerasService.OnCameraDisconnectedEvent += OnCameraDisconnectedEvent;
            this.camerasService.OnCameraConnectedOrDisconnected += OnCameraConnectedOrDisconnected;
            this.camerasService.Start();

            this.camerasService.DeviceWatcher.LoadConnectedDevices();

        }

        private void OnTurnedOneByPortNumber(object sender, EventArgs e)
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

        private void onEndTurnedonAllCameras(object sender, EventArgs e)
        {
            Program.logger.success("Turning ON of all ports successfully finished");
        }

        private void onEndTurningOnAllCameras(object sender, EventArgs e)
        {
            Program.logger.success("Turning OFF of all ports successfully finished");
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCameraDisconnectedEvent(object sender, CameraDisconnectedEvent e)
        {
            Program.logger.error(String.Format("Camera {0} disconnected", e.Camera.BadgeId));
            this.handleDisconnectedCamera(e);
        }

        private void OnCameraConnectedOrDisconnected(object sender, EventArgs e)
        {
            Program.logger.warn("Camera connected or removed");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private async void handleConnectedCamera(CameraConnectedEvent e)
        {

            CameraItem cameraItem = new CameraItem(e.Camera, this.camerasService.FalconBridge);
            this.containerPanel.Controls.Add(cameraItem);

            cameraItem.OnOpenCameraItem += (delegate (object sender, OnOpenCameraItemEvent evt)
            {
                if (!Globals.IS_ALL_COPYING_PROCESS_ARE_END)
                {
                    MessageBox.Show("Proszę poczekać póki trwa kopiowanie wszystkich plików");
                    return;
                }

                Thread thr = new Thread((ThreadStart)async delegate
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
                    this.camerasService.FilesFromDrive(e.Camera.Drive.Name),
                    this.settings.SettingsObj.app.fileSystem.networkStorage
                );
            }
        }


        /// <summary>
        /// 
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
    }
}
