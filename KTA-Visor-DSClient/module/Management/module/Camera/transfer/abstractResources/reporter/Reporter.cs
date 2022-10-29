using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.helper;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.reporter
{
    public class Reporter
    {
        private readonly Settings _settings;
        private readonly KTA_REPORTER.Reporter _reporter;
        
        public Reporter(Settings settings)
        {
            this._settings = settings;
            this._reporter = new KTA_REPORTER.Reporter();
        }

        public FileInfo Report(USBCameraDevice camera, List<FileInfo> copied, List<FileInfo> duplicates, List<FileInfo> failed)
        {

            string reportHTML= EmbededFileHelper.Read("KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.reporter.template.TransferedFilesTemplate.html");

            string greenIcon = string.Format("{0}/assets/report/icons/icon-green.svg", this._settings.SettingsObj.app.backend?.api);
            string redIcon = string.Format("{0}/assets/report/icons/icon-red.svg", this._settings.SettingsObj.app.backend?.api);
            string orangeIcon = string.Format("{0}/assets/report/icons/icon-orange.svg", this._settings.SettingsObj.app.backend?.api);
            string currentDate = DateTime.Now.ToString("yyyy/M/dd h:m:s");

            string path = string.Format(
                "{0}\\report_{1}_{2}.html",
                this._settings?.SettingsObj?.app?.fileSystem?.filesPath,
                DateTime.Now.ToString("yyyy-M-dd_h_m_s"),
                camera.BadgeId
            );


            string succeedRows = this.generateRow(greenIcon, copied);
            string failedRows = this.generateRow(redIcon, failed);
            string duplicatedRows = this.generateRow(orangeIcon, duplicates);
           
            this._reporter.Assign(reportHTML, new Dictionary<string, string> {
                {"$CAMERA_CUSTOM_ID", camera.CustomId},
                {"$BADGE_ID", camera.BadgeId },
                {"$REPORT_DATE", currentDate},
                {"$SUCCESS_ICON", greenIcon},
                {"$FAIL_ICON", redIcon},
                {"$DUPLICATE_ICON", orangeIcon},
                
                {"$TOTAL_SUCCESS_FILES", copied.Count.ToString()},
                {"$TOTAL_FAILED_FILES", failed.Count.ToString()},
                {"$TOTAL_DUPLICATED_FILES", duplicates.Count.ToString()},

                {"$SUCCES_ROWS", succeedRows},
                {"$FAILED_ROWS", failedRows},
                {"$DUPLICATED_ROWS", duplicatedRows},
            });

            this._reporter.Report(path, KTA_REPORTER.enums.OutputFileTypeEnum.HTML);


            return new FileInfo(path);
        }


        private string generateRow(string icon, List<FileInfo> files)
        {
            StringBuilder stb = new StringBuilder();
            foreach (FileInfo file in files)
            {
                string rowHTML = EmbededFileHelper.Read("KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.reporter.template.component.Row.html");
                rowHTML = this._reporter.Assign(rowHTML, new Dictionary<string, string>() {
                    {"$ICON", icon},
                    {"$FILE_NAME", file.Name},
                    {"$FILE_DATE", file.CreationTime.ToString()},
                    {"$FILE_SIZE", FileSizeHelper.convertSize(file.Length)},
                });

                stb.Append(rowHTML);
            }
            return stb.ToString();
        }
    }
}
