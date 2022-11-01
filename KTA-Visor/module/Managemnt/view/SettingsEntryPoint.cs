using KTA_Visor.install.settings;
using KTA_Visor_UI.component.custom.MessageWindow;
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

namespace KTA_Visor.module.Managemnt.view
{
    public partial class SettingsEntryPoint : MetroForm
    {
        private readonly Settings settings;
        public SettingsEntryPoint()
        {
            InitializeComponent();
            this.settings = new Settings();
        }

        private void SettingsEntryPoint_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.releaseNameLbl.Text = this.settings.SettingsObj.app.releaseName;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.hookControls();
            this.renderValues();
        }
        private void hookControls()
        {
            this.tunnelServerIpTxt.TextChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.tunnel.serverIp = this.tunnelServerIpTxt.Text;
            });

            this.tunnelPortTxt.TextChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.tunnel.serverPort = Int32.Parse(this.tunnelPortTxt.Text);
            });

            this.tunnelModeCombo.SelectedIndexChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.tunnel.serverMode = this.tunnelModeCombo.SelectedItem.ToString();
            });



            this.apiTxt.TextChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.api.url = this.apiTxt.Text;
            });


            this.fileSystemPathTxt.TextChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.fileSystem.recordingsPath = this.fileSystemPathTxt.Text;
            });

            this.fileSystemPathTxt.Click += (delegate (object sender, EventArgs e) {
                folderBrowserDialog1.ShowDialog();
                this.fileSystemPathTxt.Text = folderBrowserDialog1.SelectedPath;
                this.settings.SettingsObj.app.fileSystem.recordingsPath = folderBrowserDialog1.SelectedPath;
            });
            this.saveBtn.Click += onSave;
        }

      
        private void renderValues()
        {
            this.tunnelServerIpTxt.Text = this.settings.SettingsObj.app.tunnel.serverIp;
            this.tunnelPortTxt.Text = this.settings.SettingsObj.app.tunnel.serverPort.ToString();
            this.tunnelModeCombo.Items.AddRange(this.settings.SettingsObj.app.tunnel.modes);
            this.tunnelModeCombo.SelectedIndex = 0;

            this.fileSystemPathTxt.Text = this.settings.SettingsObj.app.fileSystem.recordingsPath;
            this.apiTxt.Text = this.settings.SettingsObj.app.api.url;
        }

        private void onSave(object sender, EventArgs e)
        {
            this.settings.SettingsObj.app.configured = true;
            this.settings.Save(this.settings.SettingsObj);

            new AlertWindow("Ustawienia zostały pomyślnie zapisane", "success");
            Application.Restart();
        }

    }
}
