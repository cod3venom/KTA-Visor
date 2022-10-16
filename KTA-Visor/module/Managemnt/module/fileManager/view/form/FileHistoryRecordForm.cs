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

namespace KTA_Visor.module.Managemnt.module.fileManager.view.form
{
    public partial class FileHistoryRecordForm : MetroForm
    {
        public event EventHandler<EventArgs> OnClose;

        private readonly FileHistory fileHistory;

        private readonly FileManagerService fileManagerService;

        public FileHistoryRecordForm(FileHistory fileHistory)
        {
            InitializeComponent();

            this.fileHistory = fileHistory;
            this.fileManagerService = new FileManagerService();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush b = new SolidBrush(Color.DarkCyan)){
                int borderWidth = 5;
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        private void FileHistoryRecordForm_Load(object sender, EventArgs e)
        {
            this.stationIdTxt.Text = fileHistory.stationId;
            this.cameraCustomIdTxt.Text = fileHistory.cameraCustomId;
            this.badgeIdTxt.Text = fileHistory.badgeId;
            this.fileNameTxt.Text = fileHistory.fileName;
            this.fileSourceTxt.Text = fileHistory.fileSourcePath;
            this.fileDestPathTxt.Text = fileHistory.fileDestPath;
            this.fileSizeTxt.Text = fileHistory.fileSize.ToString();
            this.isEvidenceChk.Checked = this.fileHistory.evidence;
            this.isRemovableEvidenceChk.Checked = this.fileHistory.removableEvidence;
            this.createdAtTxt.Text = fileHistory.createdAt.ToString();

            this.saveBtn.Click += onSave;
        }

        private void onSave(object sender, EventArgs e)
        {
            this.fileHistory.evidence = this.isEvidenceChk.Checked;
            this.fileHistory.removableEvidence = this.isRemovableEvidenceChk.Checked;
            _ = this.fileManagerService.edit(this.fileHistory.id, new EditFileHistoryRequestTObject(
                    this.fileHistory.evidence,
                    this.fileHistory.removableEvidence,
                    this.descriptionTxt.Text
            ));

            this.Close();
            this.OnClose?.Invoke(sender, e);
        }
    }
}
