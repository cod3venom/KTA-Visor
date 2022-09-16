
using KTA_Visor_DSClient.module.Management.module.Camera.dto;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.fileHistory.dto.request;
using KTAVisorAPISDK.module.fileHistory.service;
using Splicer.Renderer;
using Splicer.Timeline;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.command.filesystem
{
    public class MergeCopiedVideosIntoOneCommand
    {
        public static Dictionary<string, CopiedCameraFileTObject> Execute(Dictionary<string, FileInfo> files, string networkDriveLocation)
        {
            Dictionary<string, CopiedCameraFileTObject> copiedFiles = new Dictionary<string, CopiedCameraFileTObject>();

            if (networkDriveLocation == null || networkDriveLocation == "")
                return copiedFiles;

            DirectoryInfo directory = new DirectoryInfo(networkDriveLocation);
            if (!directory.Exists)
                throw new Exception("Network drive location does not exists");

            Globals.IS_ALL_COPYING_PROCESS_ARE_END = false;


            FileInfo destFile = new FileInfo(String.Format("{0}\\{1}", networkDriveLocation, DateTime.Now.ToString("yyyy_M_D_H_m_s") + ".mp4"));


            using (ITimeline timeline = new DefaultTimeline())
            {
                IGroup group = timeline.AddVideoGroup(32, 720, 576);

                foreach (KeyValuePair<string, FileInfo> kvp in files)
                {
                    FileInfo file = kvp.Value;

                    group.AddTrack().AddVideo(file.FullName);
                }


                using (AviFileRenderer renderer = new AviFileRenderer(timeline, destFile.FullName))
                {
                    renderer.Render();
                }
            }

            Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;
            return copiedFiles;
        }
    }
}
