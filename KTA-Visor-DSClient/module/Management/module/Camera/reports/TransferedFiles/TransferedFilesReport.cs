using KTA_REPORTER;
using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.helper;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.module.Management.module.Camera.transfer.events;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.station.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.reports.TransferedFiles
{
    public class TransferedFilesReport 
    {
  
        private readonly Reporter _reporter;
        private readonly Settings _settings;
        private readonly KTALogger.Logger _logger;
        private OnFilesTransferingFinishedEvent _event;

        public TransferedFilesReport(KTALogger.Logger logger)
        {
            this._reporter = new Reporter();
            this._settings = new Settings();
            this._logger = logger;
        }

        public void Report(OnFilesTransferingFinishedEvent e)
        {
            this._event = e;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string template = EmbededFileHelper.Read("KTA_Visor_DSClient.module.Management.module.Camera.reports.TransferedFiles.TransferedFilesTemplate.html");
            string path = string.Format(
                "{0}\\report_{1}_{2}.html", 
                this._settings?.SettingsObj?.app?.fileSystem?.filesPath,
                DateTime.Now.ToString("yyyy-M-dd_h_m_s_i"),
                e.Camera.BadgeId
            );

            string copied = String.Join("<br/>", e.Copied);
            string duplicates = String.Join("<br/>", e.Duplicates);
            string failed = String.Join("<br/>", e.Failed);

            parameters.Add("$ID", e.Camera?.ID);
            parameters.Add("$BADGE", e.Camera?.BadgeId);
            parameters.Add("$CARD", e.Camera?.CardId);
            parameters.Add("$COPIED", copied);
            parameters.Add("$DUPLICATES", duplicates);
            parameters.Add("$FAILED", failed);
            
            this._reporter.Assign(template, parameters);
            this._reporter.Report(path, KTA_REPORTER.enums.OutputFileTypeEnum.HTML);


            this._logger.success(this.ToString());
            Console.WriteLine(path);
        }

        public override string ToString()
        {
              return new StringBuilder()
                .Append(Environment.NewLine)
                .Append(string.Format("==================================== TRANSFERING HAS BEEN FINISHED FOR {0} ====================================", this._event.Camera.Drive?.Name))
                .Append(Environment.NewLine)
                .Append("Copied files: ")
                .Append(Environment.NewLine)
                .Append(String.Join(Environment.NewLine, this._event.Copied))
                .Append(Environment.NewLine)
                .Append("Duplicated files: ")
                .Append(Environment.NewLine)
                .Append(String.Join(Environment.NewLine, this._event.Duplicates))
                .Append(Environment.NewLine)
                .Append("Failed files: ")
                .Append(Environment.NewLine)
                .Append(String.Join(Environment.NewLine, this._event.Failed))
                .Append(Environment.NewLine)
                .Append("===============================================================================================================")

                .ToString();
        }
    }
}
