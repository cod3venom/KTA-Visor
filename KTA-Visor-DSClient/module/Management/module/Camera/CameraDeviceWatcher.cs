using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.service;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.Camera.events;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.factory;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.module.Management.module.Camera.command.memory;
using Falcon_Protocol;
using KTA_Visor_DSClient.module.Management.module.Camera.handler;
using KTA_Visor_DSClient.install.settings;
using KTAVisorAPISDK.module.camera.entity;
using Falcon_Protocol.modules.detector.events;

using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using KTA_Visor_DSClient.kernel.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.observer;

namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService
{
    public class CameraDeviceWatcher : FalconProtocol
    {

        private readonly Settings settings;
        private readonly KTALogger.Logger _logger;
        private readonly FalconProtocol falconProtocol;
        private readonly CameraService cameraService;
        private readonly CamerasListObserver _camersasListObserver;
        private int _indexIterator = 0;

        public CameraDeviceWatcher(Settings settings, KTALogger.Logger logger)
        {
            this.settings = settings;
            this._logger = logger;
            this.falconProtocol = new FalconProtocol();
            this.cameraService = new CameraService();
            this._camersasListObserver = new CamerasListObserver(this.settings, logger);
        }

        
        public void Start()
        {
            this._camersasListObserver.Observe();
            this.watch();
            this.falconProtocol.Detector.OnExceptionOccured += onExceptionOccured;
            this.falconProtocol.Detector.OnDeviceMounted += OnDeviceMounted;
            this.falconProtocol.Detector.OnDeviceRemoved += OnDeviceDisconnected;
            this.falconProtocol.Detector.LoadConnectedDevices();
            this.falconProtocol.Detector.Run();
        }

       
        private void watch()
        {
            Thread watchThread = new Thread((ThreadStart)delegate
            {
                int tmpIndex = this._indexIterator;
                while(true)
                {
                    if (!Globals.ALLOW_FS_MOUNTING){
                        continue;
                    }

                    this.Connect();
                    if (tmpIndex != this._indexIterator)
                    {
                        tmpIndex = this._indexIterator;

                        Console.WriteLine("Current index is : " + tmpIndex);
                    }
                    this._indexIterator = this.GetTotalConnectedDevices();
                    this.TryToMountDevice();
                }
            });

            watchThread.IsBackground = true;
            watchThread.Start();
        }

        private void OnDeviceMounted(object sender, OnDeviceMountedEvent e)
        {
            
            if (!this.isValidCameraDevice(e.Drive.Name)){
                return;
            }

            USBCameraDevice camera = USBCameraDeviceFactory.create(e.Drive.Name);
            camera.Index = this._indexIterator;
            Globals.CAMERAS_LIST.Push(camera);
        }

        private void OnDeviceDisconnected(object sender, OnDeviceRemoved e)
        {
            try
            {
                USBCameraDevice camera = Globals.CAMERAS_LIST.GetByDrive(e.Drive?.Name);
                if (camera == null) {
                    return;
                }

                Globals.CAMERAS_LIST.Delete(camera);
            }
            catch (Exception ex)
            {
                this._logger.error(ex.Message, ex);
            }
        }

        public void TryToMountDevice()
        {
            if (Globals.ALLOW_FS_MOUNTING)
            {
                new Thread(() => this.Mount()).Start();
                Thread.Sleep(2500);
            }
        }

        private bool isValidCameraDevice(string cameraVolumeLabel)
        {
            if (cameraVolumeLabel.Length > 0){
                cameraVolumeLabel = cameraVolumeLabel[0].ToString();
            }

            return File.Exists(cameraVolumeLabel + @":\\ID.txt");
        }


        private void onExceptionOccured(object sender, Exception exception)
        {
            this._logger.error(exception.Message, exception.ToString());
        }
    }
}
