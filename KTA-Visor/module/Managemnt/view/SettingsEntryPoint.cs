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


            this.recordingsFolderTxt.TextChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.fileSystem.recordingsPath = this.recordingsFolderTxt.Text;
            });


            this.recordingsFolderTxt.Click += (delegate (object sender, EventArgs e) {
                folderBrowserDialog1.ShowDialog();
                this.recordingsFolderTxt.Text = folderBrowserDialog1.SelectedPath;
                this.settings.SettingsObj.app.fileSystem.recordingsPath = folderBrowserDialog1.SelectedPath;
            });

            this.reportsFolderTxt.Click += (delegate (object sender, EventArgs e) {
                folderBrowserDialog1.ShowDialog();
                this.reportsFolderTxt.Text = folderBrowserDialog1.SelectedPath;
                this.settings.SettingsObj.app.fileSystem.reportsPath = folderBrowserDialog1.SelectedPath;
            });

            this.firmwaresDirTxt.Click += (delegate (object sender, EventArgs e) {
                folderBrowserDialog1.ShowDialog();
                this.firmwaresDirTxt.Text = folderBrowserDialog1.SelectedPath;
                this.settings.SettingsObj.app.fileSystem.firmwaresPath = folderBrowserDialog1.SelectedPath;
            });
            this.storageDriveLetterTxt.TextChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.fileSystem.storageDriveLetter = this.storageDriveLetterTxt.Text;
            });
            this.maxFileLivingDays.ValueChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.fileSystem.maxFileLivingDays = Int32.Parse(this.maxFileLivingDays.Text);
            });

            this.saveBtn.Click += onSave;
        }

      
        private void renderValues()
        {
            this.tunnelServerIpTxt.Text = this.settings.SettingsObj.app.tunnel.serverIp;
            this.tunnelPortTxt.Text = this.settings.SettingsObj.app.tunnel.serverPort.ToString();
            this.tunnelModeCombo.Items.AddRange(this.settings.SettingsObj.app.tunnel.modes);
            this.tunnelModeCombo.SelectedIndex = 0;

            this.recordingsFolderTxt.Text = this.settings.SettingsObj.app.fileSystem.recordingsPath;
            this.reportsFolderTxt.Text = this.settings.SettingsObj.app.fileSystem.reportsPath;
            this.firmwaresDirTxt.Text = this.settings.SettingsObj.app.fileSystem.firmwaresPath;
            this.storageDriveLetterTxt.Text = this.settings.SettingsObj.app.fileSystem.storageDriveLetter;
            if (this.settings.SettingsObj.app.fileSystem.maxFileLivingDays < this.maxFileLivingDays.Maximum)
            {
                this.settings.SettingsObj.app.fileSystem.maxFileLivingDays = (int)this.maxFileLivingDays.Maximum;
            }

            this.maxFileLivingDays.Value = this.settings.SettingsObj.app.fileSystem.maxFileLivingDays;
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
