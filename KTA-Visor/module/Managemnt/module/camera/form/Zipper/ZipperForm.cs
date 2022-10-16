using Ionic.Zip;
using KTA_Visor.module.Managemnt.module.camera.form.FileEncryption;
using KTA_Visor.module.Managemnt.module.camera.form.FileEncryption.events;
using MetroFramework;
using MetroFramework.Forms;
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

namespace KTA_Visor.module.Managemnt.module.camera.form.Zipper
{
    public partial class ZipperForm : MetroForm
    {
        private bool isHandleCreated = false;
        private readonly BackgroundWorker zipperBackgroundWorker;
        private string destinationPath = "";
        private string destinationDrivePath = "";
        private string[] files = new string[] { };
        private int totalCopiedFiles = 0;
        public ZipperForm()
        {
            InitializeComponent();
            this.zipperBackgroundWorker = new BackgroundWorker();
        }

        private void FilesCopyingForm_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // custom draw the top border
            using (Brush b = new SolidBrush(Color.DarkCyan))
            {
                int borderWidth = 5; // MetroFramework source code
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.isHandleCreated = true;
        }

        private string CurrentFile
        {
            set { this.currentFileLbl.Text = value; }
            get { return this.currentFileLbl.Text; }
        }

        private string FilesCounter
        {
            set { this.flesCounterLbl.Text = value;  }
            get { return this.flesCounterLbl.Text;  }
        }

        public async void Zip(string destinationDrivePath, string[] files)
        {

            await Task.Delay(1000);

            this.destinationDrivePath = destinationDrivePath;
            this.files = files;             
            this.destinationPath = string.Format("{0}\\archiwum_{1}.zip", destinationDrivePath, DateTime.Now.ToString("yyyy_M_D_H_m_s"));

            zipperBackgroundWorker.WorkerReportsProgress = true;
            zipperBackgroundWorker.DoWork += ZipperBackgroundWorker_DoWork;
            zipperBackgroundWorker.ProgressChanged += onProgressChanged;
            zipperBackgroundWorker.RunWorkerCompleted += ZipperBackgroundWorker_RunWorkerCompleted;
            zipperBackgroundWorker.RunWorkerAsync();
        }

      

        private void ZipperBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void ZipperBackgroundWorker_DoWork(object _sender, DoWorkEventArgs _e)
        {
            this.Invoke((MethodInvoker)delegate
            {
               
                FileEncryptionWithPasswordWindow fileEncryptionWindow = new FileEncryptionWithPasswordWindow();
                fileEncryptionWindow.OnPasswordAndRepeatedPasswordDoesntMatch += (delegate (object sender, EventArgs e)
                {
                    MetroMessageBox.Show(this, "Wprowadzone hasła są różne, proszę sprobować jeszcze raz", "Błąd");
                    return;
                });
                fileEncryptionWindow.OnPasswordLengthIsLessThanAllowed += (delegate (object sender, EventArgs e)
                {
                    MetroMessageBox.Show(this, "Minimum długość hasła to 8 znaków", "Błąd");
                    return;
                });

                fileEncryptionWindow.OnSaveFileEncryptionPasswords += (delegate (object sender, OnSaveFileEncryptionPasswordsEvent e)
                {

                    fileEncryptionWindow.Hide();

                    using (ZipFile zipFile = new ZipFile(this.destinationPath))
                    {

                        zipFile.Password = e.Password;
                        int currentIndex = 0;
                        foreach (string filePath in files)
                        {
                            if (!File.Exists(filePath))
                            {
                                continue;
                            }

                            currentIndex += 1;
                            FileInfo file = new FileInfo(filePath);

                            this.CurrentFile = file.FullName;
                            this.FilesCounter = String.Format("{0}/{1}", currentIndex, files.Length);

                            zipFile.AddFile(file.FullName);
                            totalCopiedFiles++;
                        }

                        zipFile.SaveProgress += onZipSave;
                        zipFile.Save(this.destinationPath);
                    }
                });

                fileEncryptionWindow.ShowDialog();
                if (totalCopiedFiles == 0)
                {
                    MetroMessageBox.Show(this, "Nie udało się skopiować żadnych plików", "Błąd przy kopiowaniu");
                    this.Close();
                    return;
                }

                MetroMessageBox.Show(this, string.Format("Skopiowano {0} plików", totalCopiedFiles.ToString()), "Kopowianie plików");
                this.Close();
            });
        }

        private void onZipSave(object sender, SaveProgressEventArgs e)
        {
            this.zipperBackgroundWorker.ReportProgress(e.EntriesSaved);
        }

 
        private void onProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!this.isHandleCreated){
                return;
            }
            this.Invoke((MethodInvoker)delegate
            {
                this.metroProgressBar.Value = e.ProgressPercentage;
            });
        }
    }
}
