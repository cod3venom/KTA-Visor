using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Settings.view
{
    public partial class SettingsView : Form
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void SettingsView_Load(object sender, EventArgs e)
        {
            this.topBar1.Parent = this;
            this.browseNetworkDriveBtn.OnClick += OpenNetworkDriveDialog;
         }

        private void OpenNetworkDriveDialog(object sender, EventArgs e)
        {
            DialogResult result = networkDriveOpenFolderDialog.ShowDialog();
            if (result != DialogResult.OK) return;


            this.networkDriveLocationTextBox.Text = (string)networkDriveOpenFolderDialog.SelectedPath;
        }
    }
}
