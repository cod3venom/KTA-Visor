using KTA_Visor_DSClient.install.settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.settings.views
{
    public partial class ManagementSettingsView : Form
    {
        private readonly Settings settings;

        public ManagementSettingsView()
        {
            InitializeComponent();
            this.topBar1.Parent = this;
            this.topBar1.Title = "Management";
            this.settings = new Settings();
        }

        private void ManagementView_Load(object sender, EventArgs e)
        {
            this.render();
        }

        private void render()
        {
            this.ipTxt.Text = this.ipTxt.Text.PadLeft(this.ipTxt.Text.Length + 5);
            this.portTxt.Text = this.portTxt.Text.PadLeft(this.portTxt.Text.Length + 5);

            this.ipTxt.Text = this.settings?.SettingsObj?.app?.management?.serverIp;
            this.portTxt.Text = this.settings?.SettingsObj?.app?.management?.serverPort.ToString();
            this.autoReconnectChck.Checked = this.settings.SettingsObj.app.management.autoReconnect;

            this.saveBtn.OnClick += onSaveSettings;
        }

        private void onSaveSettings(object sender, EventArgs e)
        {
            int port = 0;

            Int32.TryParse(this.portTxt.Text, out port);
            this.settings.SettingsObj.app.management.serverIp = this.ipTxt.Text;
            this.settings.SettingsObj.app.management.serverPort = port;
            this.settings.SettingsObj.app.management.autoReconnect = this.autoReconnectChck.Checked;

            this.settings.Save(this.settings.SettingsObj);
            this.Close();
        }
    }
}
