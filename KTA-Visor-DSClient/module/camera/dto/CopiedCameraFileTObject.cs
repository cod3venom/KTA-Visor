using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.camera.dto
{
    public class CopiedCameraFileTObject
    {
        public CopiedCameraFileTObject(FileInfo file, bool diff)
        {
            this.File = file;
            this.Directory = new DirectoryInfo(file.DirectoryName);
            this.Diff = diff;
        }

        public FileInfo File { get; set; }

        public DirectoryInfo Directory { get; set; }  

        public bool Diff { get; set; }
    }
}
