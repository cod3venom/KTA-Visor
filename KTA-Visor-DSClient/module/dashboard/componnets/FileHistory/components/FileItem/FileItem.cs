using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.dashboard.componnets.FileHistory.components.FileItem
{
    public partial class FileItem : UserControl
    {
        public FileItem()
        {
            InitializeComponent();
        }
        private readonly FileInfo file;
        private readonly DirectoryInfo storage;

        public FileItem(FileInfo file, DirectoryInfo storage, bool diff)
        {
            InitializeComponent();

            this.file = file;
            this.storage = storage;

            this.Name = file.Name;
            this.Storage = storage.Name ;
            this.Diff = diff;
        }


        private void FileItem_Load(object sender, EventArgs e)
        {
            this.Click += OpenFile;
            this.nameLbl.Click += OpenFile;
            this.nameValue.Click += OpenFile;
            this.storageLbl.Click += OpenFile;
            this.storageValue.Click += OpenFile;
            this.diffLbl.Click += OpenFile;
            this.diffValue.Click += OpenFile;
            this.dateLbl.Click += OpenFile;
            this.footerPanel.Click += OpenFile;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
               
                Process.Start(this.file.FullName);
            });
        }

        public string Name
        {
            get { return this.nameValue.Text;  }
            set { this.nameValue.Text = value; }
        }

        public string Storage
        {
            get { return this.storageValue.Text; }
            set { this.storageValue.Text = value.ToString().Substring(0, 10); }
        }

        public bool Diff
        {
            get { return this.diffValue.Text == "true"; }
            set { this.diffValue.Text = value ? "true" : "false"; }
        }
    }
}
