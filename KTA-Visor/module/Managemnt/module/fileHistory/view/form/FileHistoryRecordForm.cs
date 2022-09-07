using KTAVisorAPISDK.module.fileHistory.service;
using static KTAVisorAPISDK.module.fileHistory.entity.FileHistoryEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KTAVisorAPISDK.module.fileHistory.dto.request;

namespace KTA_Visor.module.Managemnt.module.fileHistory.view.form
{
    public partial class FileHistoryRecordForm : Form
    {
        public event EventHandler<EventArgs> OnClose;

        private readonly FileHistory fileHistory;

        private readonly FileHistoryService fileHistoryService;

        public FileHistoryRecordForm(FileHistory fileHistory)
        {
            InitializeComponent();

            this.topBar.Parent = this;
            this.fileHistory = fileHistory;
            this.fileHistoryService = new FileHistoryService();
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

            this.saveBtn.OnClick += onSave;
        }

        private void onSave(object sender, EventArgs e)
        {
            this.fileHistory.evidence = this.isEvidenceChk.Checked;
            this.fileHistory.removableEvidence = this.isRemovableEvidenceChk.Checked;
            _ = this.fileHistoryService.edit(this.fileHistory.id, new EditFileHistoryRequestTObject(
                    this.fileHistory.evidence,
                    this.fileHistory.removableEvidence,
                    this.descriptionTxt.Text
            ));

            this.Close();
            this.OnClose?.Invoke(sender, e);
        }
    }
}
