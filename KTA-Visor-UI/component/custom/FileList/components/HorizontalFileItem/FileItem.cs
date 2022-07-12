using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.FileList.components.HorizontalFileItem
{
    public partial class FileItem : UserControl
    {
        public FileItem()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get { return this.fileNameTxt.Text; }
            set { this.fileNameTxt.Text = value; }
        }

        public string CreatedAt
        {
            get { return this.fileDateTxt.Text; }
            set { this.fileDateTxt.Text = value; }
        }

        public string FileSize
        {
            get { return this.fileSize.Text; }
            set { this.fileSize.Text = value; }
        }

        private void HorizontalFileItem_Load(object sender, EventArgs e)
        {

        }
    }
}
