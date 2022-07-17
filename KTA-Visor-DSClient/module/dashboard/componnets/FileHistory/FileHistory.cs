using KTA_Visor_DSClient.module.dashboard.componnets.FileHistory.components.FileItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.dashboard.componnets.FileHistory
{
    public partial class FileHistory : UserControl
    {
        public FileHistory()
        {
            InitializeComponent();
        }

        private void FileHistory_Load(object sender, EventArgs e)
        {

        }

        public void addFile(FileInfo file, DirectoryInfo storage, bool diff)
        {
            FileItem item = new FileItem(file, storage, diff);
            item.Dock = DockStyle.Top;

            this.Invoke((MethodInvoker)delegate
            {
                this.historyListPanel.Controls.Add(item);
            });
        }
    }
}
