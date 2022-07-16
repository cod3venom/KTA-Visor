using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public FileItem(string name, string storage, bool diff)
        {
            InitializeComponent();

            this.Name = name;
            this.Storage = storage;
            this.Diff = diff;
        }

        private void FileItem_Load(object sender, EventArgs e)
        {

        }

        public string Name
        {
            get { return this.nameValue.Text;  }
            set { this.nameValue.Text = value; }
        }

        public string Storage
        {
            get { return this.storageValue.Text; }
            set { this.storageValue.Text = value; }
        }

        public bool Diff
        {
            get { return this.diffValue.Text == "true"; }
            set { this.diffValue.Text = value ? "true" : "false"; }
        }
    }
}
