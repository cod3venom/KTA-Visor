using KTALogger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_FileStorage_Watcher.shared.Global
{
    public class Globals
    {
        public static KTALogger.Logger Logger = new KTALogger.Logger(new DirectoryInfo(
          string.Format(
              "{0}\\kta_files_watcher\\kta_logger",
               Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        )));
    }
}
