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
using KTA_Visor_DSClient.kernel.generator;

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
            this.stationIdTxt.Text = this.settings.SettingsObj.app.station.stationId;
            this.stationIpTxt.Text = this.settings.SettingsObj.app.station.ipAddress;

            this.ipTxt.Text = this.ipTxt.Text.PadLeft(this.ipTxt.Text.Length + 5);
            this.portTxt.Text = this.portTxt.Text.PadLeft(this.portTxt.Text.Length + 5);

            this.ipTxt.Text = this.settings?.SettingsObj?.app?.management?.serverIp;
            this.portTxt.Text = this.settings?.SettingsObj?.app?.management?.serverPort.ToString();
            this.autoReconnectChck.Checked = this.settings.SettingsObj.app.management.autoReconnect;

            this.storageLocationTxt.Text = this.settings.SettingsObj.app.fileSystem.filesPath;
            this.autoCopyChk.Checked = this.settings.SettingsObj.app.fileSystem.autoCopy;

            this.storageLocationTxt.Click += onBrowseStorageLocation;
            this.saveBtn.OnClick += onSaveSettings;

            this.sstationGenBtn.Click += (delegate (object _sender, EventArgs ev)
            {
                this.stationIdTxt.Text = RandomData.RandomString(15);
            });
        }

        private void onBrowseStorageLocation(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() != DialogResult.OK)
                MessageBox.Show("Unable to select location, plese try another folder");

            this.storageLocationTxt.Text = folderDialog.SelectedPath;
        }

        private void onSaveSettings(object sender, EventArgs e)
        {
            this.settings.SettingsObj.app.station.stationId = this.stationIdTxt.Text;
            this.settings.SettingsObj.app.station.ipAddress = this.stationIpTxt.Text;

            this.settings.SettingsObj.app.management.serverIp = this.ipTxt.Text;
            this.settings.SettingsObj.app.management.serverPort = Int32.Parse(this.portTxt.Text);
            this.settings.SettingsObj.app.management.autoReconnect = this.autoReconnectChck.Checked;

            this.settings.SettingsObj.app.fileSystem.filesPath = this.storageLocationTxt.Text;
            this.settings.SettingsObj.app.fileSystem.autoCopy = this.autoCopyChk.Checked;

            this.settings.Save(this.settings.SettingsObj);
             
        }
    }
}
