using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.sub_window
{
    public partial class FileExplorerWindow : Form
    {
        public FileExplorerWindow()
        {
            InitializeComponent();
            this.topBar1.Parent = this;
            this.topBar1.onClose += onClose;
        }


        public FileExplorerWindow(string workinDirectory)
        {
            InitializeComponent();
            this.topBar1.Parent = this;
            this.topBar1.onClose += onClose;
            this.WorkingDirectory = workinDirectory;
        }
        public string WorkingDirectory
        {
            get { return this.fileExplorer1.WorkingDirectory; }
            set { this.fileExplorer1.WorkingDirectory = value; }
        }
        private void FileExplorerWindow_Load(object sender, EventArgs e)
        {

        }

        private void onClose(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
