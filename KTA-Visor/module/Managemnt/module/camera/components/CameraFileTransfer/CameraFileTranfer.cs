using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.camera.components.CameraFileTransfer
{
    public partial class CameraFileTranfer : UserControl
    {
        
        public CameraFileTranfer()
        {
            InitializeComponent();
            this.Worker = new BackgroundWorker();
        }

        private void CameraFileTranfer_Load(object sender, EventArgs e)
        {
            this.Worker.WorkerReportsProgress = true;
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.ProgressChanged += onProgressChanged;
        }
 
        private void onProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.progressBar.Value = e.ProgressPercentage;
            });
            
        }

        public string FileName 
        { 
            set { this.fileNameLbl.Text = value; }
            get { return this.fileNameLbl.Text; }
        }

        public int Progress { get; set; }

        public BackgroundWorker Worker { get; set; }
    }
}
