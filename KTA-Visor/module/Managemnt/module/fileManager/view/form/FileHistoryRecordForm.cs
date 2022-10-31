using KTAVisorAPISDK.module.fileManager.service;
using static KTAVisorAPISDK.module.fileManager.entity.FileItemEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KTAVisorAPISDK.module.fileManager.dto.request;
using MetroFramework.Forms;
using System.Diagnostics;
using System.IO;
using MetroFramework;

namespace KTA_Visor.module.Managemnt.module.fileManager.view.form
{
    public partial class FileHistoryRecordForm : MetroForm
    {
        public event EventHandler<EventArgs> OnClose;

        private readonly FileHistory _fileHistory;
        private readonly FileManagerService _fileManagerService;

        private readonly List<Control> _basedOnPermissionControls;
        private readonly bool _canEdit;

        public FileHistoryRecordForm(FileHistory fileHistory, bool canEdit = false)
        {
            InitializeComponent();

            this._fileHistory = fileHistory;
            this._fileManagerService = new FileManagerService();
            this._canEdit = canEdit;

            this._basedOnPermissionControls = new List<Control>{
                 this.stationIdTxt,
                this.cameraCustomIdTxt,
                this.badgeIdTxt,
                this.fileNameTxt,
                this.fileSourceTxt,
                this.fileDestPathTxt,
                this.fileSizeTxt,
                this.isEvidenceChk,
                this.isRemovableEvidenceChk,
                this.checkSumTxt,
                this.createdAtTxt,
                this.descriptionTxt,
                this.saveBtn
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
             using (Brush b = new SolidBrush(ColorTranslator.FromHtml("#222222"))){
                int borderWidth = 5;
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        private void FileHistoryRecordForm_Load(object sender, EventArgs e)
        {
            this.hookEvents();
            this.initializePermissions();
            this.renderData();
           
        }


        private void hookEvents()
        {
            this.playVideoBtn.Click += onPlay;
            this.saveBtn.Click += onSave;
        }

     
        private void renderData()
        {
            this.stationIdTxt.Text = this._fileHistory.stationId;
            this.cameraCustomIdTxt.Text = this._fileHistory.cameraCustomId;
            this.badgeIdTxt.Text = this._fileHistory.badgeId;
            this.fileNameTxt.Text = this._fileHistory.fileName;
            this.fileSourceTxt.Text = this._fileHistory.fileSourcePath;
            this.fileDestPathTxt.Text = this._fileHistory.fileDestPath;
            this.fileSizeTxt.Text = this._fileHistory.fileSize.ToString();
            this.isEvidenceChk.Checked = this._fileHistory.evidence;
            this.checkSumTxt.Text = this._fileHistory.checkSum;
            this.isRemovableEvidenceChk.Checked = this._fileHistory.removableEvidence;
            this.createdAtTxt.Text = this._fileHistory.createdAt.ToString();
            this.descriptionTxt.Text = this._fileHistory.description;
        }
        private void initializePermissions()
        {
            if (!this._canEdit){
                this._basedOnPermissionControls.ForEach((Control control) => control.Enabled = false);
            }
        }

        private void onPlay(object sender, EventArgs e)
        {
            if (!File.Exists(this._fileHistory.fileDestPath)){
                MetroMessageBox.Show(this, "Nagranie nie został odnależiony, skontaktuj się z Administratorem", "Nagranie");
                return;
            }

            Process.Start(this._fileHistory.fileDestPath);
        }

        private void onSave(object sender, EventArgs e)
        {
            this._fileHistory.evidence = this.isEvidenceChk.Checked;
            this._fileHistory.removableEvidence = this.isRemovableEvidenceChk.Checked;
            _ = this._fileManagerService.edit(this._fileHistory.id, new EditFileHistoryRequestTObject(
                    this._fileHistory.evidence,
                    this._fileHistory.removableEvidence,
                    this.descriptionTxt.Text
            ));

            this.Close();
            this.OnClose?.Invoke(sender, e);
        }
    }
}
