using System;
using System.Collections.Generic;
using System.ComponentModel;
using KTA_Visor_DSClient.install.settings;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.Management.module.SettingsManager.view.SettingsPanelView
{
    public partial class SettingsPanelView : UserControl
    {
        private readonly Settings settings;

        public SettingsPanelView()
        {
            InitializeComponent();
            this.settings = new Settings();
        }

        private void SettingsPanelView_Load(object sender, EventArgs e)
        {
            this.serialNumberTxt.Text = this.settings.SettingsObj.app.station.serialNumber;
            this.stationIpTxt.Text = this.settings.SettingsObj.app.station.ipAddress;

            this.ipTxt.Text = this.ipTxt.Text.PadLeft(this.ipTxt.Text.Length + 5);
            this.portTxt.Text = this.portTxt.Text.PadLeft(this.portTxt.Text.Length + 5);

            this.ipTxt.Text = this.settings?.SettingsObj?.app?.management?.serverIp;
            this.portTxt.Text = this.settings?.SettingsObj?.app?.management?.serverPort.ToString();
            this.autoReconnectChck.Checked = this.settings.SettingsObj.app.management.autoReconnect;

            this.storageLocationTxt.Text = this.settings.SettingsObj.app.fileSystem.networkStorage;
            this.autoCopyChk.Checked = this.settings.SettingsObj.app.fileSystem.autoCopy;

            this.storageLocationTxt.Click += onBrowseStorageLocation;
            this.saveBtn.OnClick += onSaveSettings;
        }

        private void onBrowseStorageLocation(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() != DialogResult.OK)
                MessageBox.Show("Unable to select location, plese try another folder");

            this.storageLocationTxt.Text = folderDialog.SelectedPath;
        }

        private void onSaveSettings(object sender, EventArgs e)
        {
            this.settings.Save(this.settings.SettingsObj);
             
        }
    }
}
