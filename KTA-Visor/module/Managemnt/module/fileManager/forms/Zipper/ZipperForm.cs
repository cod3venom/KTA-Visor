﻿using Ionic.Zip;
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

namespace KTA_Visor.module.Managemnt.module.fileManager.handlers.form.Zipper
{
    public partial class ZipperForm : MetroForm
    {

        private readonly List<string> _filesToZip;
        private readonly BackgroundWorker _zipperBackgroundWorker;
        private ZipPasswordForm _passwordForm;
        private string _zipPassword = "";
        private string _destinationFilePath;
        public ZipperForm(List<string> filesToZip)
        {
            InitializeComponent();
            this._filesToZip = filesToZip;
            this._passwordForm = new ZipPasswordForm();
            this._zipperBackgroundWorker = new BackgroundWorker();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush b = new SolidBrush(Color.DarkCyan))
            {
                int borderWidth = 5;
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        private string CurrentFile
        {
            set { this.currentFileLbl.Text = value; }
            get { return this.currentFileLbl.Text; }
        }
 

        private void FilesCopyingForm_Load(object sender, EventArgs e)
        {
            this._passwordForm = new ZipPasswordForm();
            this.destinationFolder.ShowDialog();
            this._destinationFilePath = String.Format(
                "{0}\\{1}_archiwum.zip",
                this.destinationFolder.SelectedPath,
                DateTime.Now.ToString("dd-MM-yyyy_h-mm-ss_tt")
            );

            this.hookEvents();
        }

        private void hookEvents()
        {
            this.closeBtn.Click += onClose;
            this._passwordForm.OnPasswordAndRepeatedPasswordDoesntMatch += onPasswordsDoesntMatch;
            this._passwordForm.OnPasswordAreOk += onPasswordsAreOk;
            this._passwordForm.ShowDialog();
        }
 

        private void onPasswordsDoesntMatch(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Wprowadziłeś błędne hasła", "Hasło");
            this._passwordForm.Close();
        }


        private void onPasswordsAreOk(object sender, events.OnPasswordsAreOkEvent e)
        {
            this._zipPassword = e.Password;
            this._zipperBackgroundWorker.DoWork += onStartZipping;
            this._zipperBackgroundWorker.RunWorkerAsync();
        }
 

        private void onStartZipping(object sender, DoWorkEventArgs e)
        {
            using(ZipFile zip = new ZipFile(this._destinationFilePath))
            {
                if (this._zipPassword!= ""){
                    zip.Password = this._zipPassword;
                }

                this.combineFiles(zip, sender as BackgroundWorker);

                zip.Save(this._destinationFilePath);
            }

            MetroMessageBox.Show(this, "Proces kopiowania został zakonczony", "Kopiowanie nagrań");
            this.onClose();
        }

        private void combineFiles(ZipFile zip, BackgroundWorker worker)
        {
            ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 10 };
            Parallel.ForEach(this._filesToZip, async (file, state, index) =>
            {
                if (File.Exists(file))
                {
                    zip.AddFile(file, @"");

                    this.Invoke((MethodInvoker)delegate{
                        this.CurrentFile = new FileInfo(file).Name;
                        this.metroProgressBar.Value = (100 * (int)index) / this._filesToZip.Count;
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate {
                        MessageBox.Show(String.Format("Scieżka do pliku {0} nie została odnależiona", file));
                    });
                }
            });
        }
 
        private void onClose(object sender = null, EventArgs e = null)
        {
            this.Invoke((MethodInvoker)delegate{
                this.Close();
            });
        }
    }
}