using KTA_Visor_UI.component.custom.FileList.components.HorizontalFileItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.FileList
{
    public partial class FileList : UserControl
    {
        private readonly List<FileItem> fileItems;

        public FileList()
        {
            InitializeComponent();

            this.fileItems = new List<FileItem>();
        }

        private void FileList_Load(object sender, EventArgs e)
        {
            foreach(FileItem item in fileItems)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.filesPanel.Controls.Add(item);
                });
            }
        }
         
        public FileList add(FileItem item)
        {
            this.fileItems.Add(item);

            this.Invoke((MethodInvoker)delegate
            {
                this.filesPanel.Controls.Add(item);
            });

            return this;
        }

        public FileList remove(FileItem item)
        {
            this.fileItems.Remove(item);

            this.Invoke((MethodInvoker)delegate
            {
                this.filesPanel.Controls.Remove(item);
            });
            return this;
        }
    }
}
