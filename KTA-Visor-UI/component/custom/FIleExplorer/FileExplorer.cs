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

namespace KTA_Visor_UI.component.custom.FIleExplorer
{
    public partial class FileExplorer : UserControl
    {
        public FileExplorer()
        {
            InitializeComponent();
        }

        public string WorkingDirectory { get; set; }


        private void FileExplorer_Load(object sender, EventArgs e)
        {
            this.currentLocationTxt.OnValueChanged += onCurrentLocationChanged;
            this.goBackBtn.Click += onGoBack;
            this.goForward.Click += onGoForward;
            this.currentLocationTxt.Text = this.WorkingDirectory;

            if (this.WorkingDirectory == "")
                return;
           // this.webBrowser1.Url = new Uri(this.WorkingDirectory);
        }

       

        private void onGoBack(object sender, EventArgs e)
        {
            if (!this.webBrowser1.CanGoBack) return;

            this.webBrowser1.GoBack();
        }

        private void onGoForward(object sender, EventArgs e)
        {

            if (!this.webBrowser1.CanGoForward) return;

            this.webBrowser1.GoForward();
        }

        private void onCurrentLocationChanged(object sender, EventArgs e)
        {
            if(File.Exists(this.currentLocationTxt.Text))
            {
                this.webBrowser1.Url = new Uri(this.currentLocationTxt.Text);
            }
        }
      
    }
}
