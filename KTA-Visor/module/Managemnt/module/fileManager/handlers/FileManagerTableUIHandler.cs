using KTA_Visor.kernel.helper;
using KTA_Visor.kernel.module.ThreadPool;
using KTA_Visor.module.Managemnt.module.fileManager.interfaces;
using KTA_Visor.module.Managemnt.module.fileManager.view;
using KTA_Visor.module.Managemnt.module.fileManager.view.form;
using KTAVisorAPISDK.module.fileManager.entity;
using KTAVisorAPISDK.module.fileManager.service;
using KTAVisorAPISDK.module.user.abstraction;
using KTAVisorAPISDK.module.user.consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KTAVisorAPISDK.module.fileManager.entity.FileItemEntity;

namespace KTA_Visor.module.Managemnt.module.fileManager.handlers
{
    public class FileManagerTableUIHandler : IFileManagerUIHandler
    {
        public static string HandlerName = "FileManagerTableUIHandler";
        private readonly FileManagerView _fileManager;
        private readonly FileManagerService _fileManagerService;

        public FileManagerTableUIHandler(FileManagerView _fileManager)
        {
            this._fileManager = _fileManager;
            this._fileManagerService = new FileManagerService();
        }

        public string GetName()
        {
            return FileManagerUIHandler.HandlerName;
        }

        public void Handle()
        {
            this.initializeUI();
        }
 
        private void initializeUI()
        {
            this._fileManager.Table.AllowAdd = false;

            if (this._fileManager.User.data.roles[0] == UserRole.ROLE_USER)
            {
                this._fileManager.Table.AllowEdit = false;
                this._fileManager.Table.AllowDelete = false;
                this._fileManager.RecordMenu.Enabled = false;
            }
        }

        public void Load()
        {
        }
    }
}
