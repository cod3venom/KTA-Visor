using MetroFramework.Forms;
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
    public partial class FileExplorerWindow : MetroForm
    {
        public FileExplorerWindow()
        {
            InitializeComponent();
        }

        public FileExplorerWindow(string workinDirectory)
        {
            InitializeComponent();
            this.WorkingDirectory = workinDirectory;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush b = new SolidBrush(Color.DarkCyan)){
                int borderWidth = 5;
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        public string WorkingDirectory
        {
            get { return this.fileExplorer1.WorkingDirectory; }
            set { this.fileExplorer1.WorkingDirectory = value; }
        }
    }
}
