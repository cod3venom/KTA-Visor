using KTA_Visor_DSClient.module.Management.module.Reporter.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.station.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Reporter.reporters
{
    public class AutoCopyReport : IReporterInterface
    {
        public static string Name = "AutoCopyReport";

        private List<FileInfo> _copiedFiles;
        private List<string> _notCopiedFiles;
        private USBCameraDevice _camera;
        private CameraEntity _cameraEntity;
        private StationEntity _station;
        private dynamic _dynamicReport;
        public AutoCopyReport()
        {
            this._copiedFiles = new List<FileInfo>();
            this._notCopiedFiles = new List<string>();
            this._camera = new USBCameraDevice(new DriveInfo("C"));
            this._cameraEntity = new CameraEntity();
            this._station = new StationEntity();
        }

        public void Report(dynamic report)
        {
            this._dynamicReport = report;
            this.parse();
        }

        private void parse()
        {
            if (this._dynamicReport?.copiedFiles != null)
            {
                this._copiedFiles = this._dynamicReport.copiedFiles;
            }

            if (this._dynamicReport?.notCopiedFiles != null)
            {
                this._notCopiedFiles = this._dynamicReport.notCopiedFiles;
            }

            if (this._dynamicReport?.camera != null)
            {
                this._camera = this._dynamicReport.camera;
            }

            if (this._dynamicReport.cameraEntity != null)
            {
                this._cameraEntity = this._dynamicReport.cameraEntity;
            }

            if (this._dynamicReport?.station != null)
            {
                this._station = this._dynamicReport.station;
            }


        }
    }
}
