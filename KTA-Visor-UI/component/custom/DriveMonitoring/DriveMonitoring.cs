using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.DriveMonitoring
{
    public partial class DriveMonitoring : UserControl
    {
        private readonly BackgroundWorker _backgroundWorker;
        private string _driveLetter;
        private DriveInfo _drive;
        public DriveMonitoring()
        {
            InitializeComponent();
            this._backgroundWorker = new BackgroundWorker();
            this._driveLetter = "C:\\";
        }

        private void DriveMonitoring_Load(object sender, EventArgs e)
        {
        }

        public bool AllowMonitoring { get; set; }

        public void Start(string driveLetter)
        {
            this._driveLetter = driveLetter;
            this.AllowMonitoring = true;

            this._backgroundWorker.WorkerReportsProgress = true;
            this._backgroundWorker.DoWork += onDoWork;
            this._backgroundWorker.ProgressChanged += onProgressChanged;

            Thread workerThread = new Thread((ThreadStart)delegate
            {
                while(true)
                {
                    this._backgroundWorker.RunWorkerAsync();
                    Thread.Sleep(1000);
                }
            });
            workerThread.IsBackground = true;
            workerThread.Start();
 
        }

        private void onDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            this._drive = new DriveInfo(this._driveLetter);
            int percentage = (int)(100 * (double)this._drive.TotalFreeSpace / this._drive.TotalSize);
            worker.ReportProgress(percentage);
        }

        private void onProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string freeSpace = this.lengthToFileSize(this._drive.TotalFreeSpace);
                string totalSpace = this.lengthToFileSize(this._drive.TotalSize);

                this.driveLbl.Text = this._drive.Name;
                this.driveSpaceLbl.Text = String.Format("{0} / {1}", freeSpace, totalSpace);
                this.metroProgressBar1.Value = e.ProgressPercentage;
            });
        }

 

        public void Stop()
        {
            this.AllowMonitoring = false;
        }

 

        private string lengthToFileSize(double size)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };

            double mod = 1024.0;

            int i = 0;

            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size) + units[i];
        }
    }
}
