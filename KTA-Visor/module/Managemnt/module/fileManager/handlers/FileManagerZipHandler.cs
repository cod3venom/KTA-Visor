using KTA_Visor.module.Managemnt.module.fileManager.handlers.form.Zipper;
using KTA_Visor.module.Managemnt.module.fileManager.interfaces;
using KTA_Visor.module.Managemnt.module.fileManager.view;
using KTAVisorAPISDK.module.fileManager.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.fileManager.handlers
{
    public class FileManagerZipHandler : IFileManagerUIHandler
    {

        public static string HandlerName = "FileManagerZipHandler";

        private readonly FileManagerView _fileManager;
        private readonly FileManagerService _fileManagerService;
        public FileManagerZipHandler(FileManagerView  fileManager)
        {
            this._fileManager = fileManager;
        }

        public string GetName()
        {
            return FileManagerZipHandler.HandlerName;
        }

        public void Handle()
        {
            this.hookEvents();
        }

        private void hookEvents()
        {
            this._fileManager.CopyToUSB.Click += onCopyToUSB;
        }

        private void onCopyToUSB (object sender, EventArgs e)
        {
            ZipperForm zipper = new ZipperForm(this._fileManager.SelectedFiles);
            zipper.ShowDialog();
        }

 
        public void Load()
        {
            throw new NotImplementedException();
        }
    }
}
