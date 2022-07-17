using KTA_Visor.install.settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Tunnel.view
{
    public partial class TunnelSettingsView : Form
    {
        private readonly Settings settings;
        public TunnelSettingsView()
        {
            InitializeComponent();
            this.settings = new Settings();

            this.topBar1.Title = this.settings.SettingsObj.app.tunnel.title;
            this.topBar1.Parent = this;
            this.topBar1.MinimizeButton.Visible = false;
            this.topBar1.ResizeButton.Visible = false;
        }

        private void TunnelSettings_Load(object sender, EventArgs e)
        {
            this.closeBtn.OnClick += OnCloseSettings;
            this.saveBtn.OnClick += OnSaveSettings;
            this.handleProgressBar();
            this.renderValues();
        }

      

        private void renderValues()
        {
            this.ipTxt.Text = this.settings.SettingsObj.app.tunnel.serverIp;
            this.portTxt.Text = this.settings.SettingsObj.app.tunnel.serverPort.ToString() ;
            this.modeComboBox.Items.AddRange(this.settings.SettingsObj.app.tunnel.modes);

            for( int i = 0; i < this.modeComboBox.Items.Count; i++)
            {
                if (this.modeComboBox.Items[i].ToString() != this.settings.SettingsObj.app.tunnel.serverMode) continue;

                this.modeComboBox.SelectedIndex = i;
                break;
            }
        }
        private void handleProgressBar()
        {
            this.fieldsPanel.Visible = false;
            
            this.horizontalProgressBar.ProgressColor = System.Drawing.ColorTranslator.FromHtml("#E3E5E8");
            this.horizontalProgressBar.Transition = 1;
            this.horizontalProgressBar.OnProgressFinished += OnProgressBarFinished;
            this.horizontalProgressBar.start();

        }

        private void OnProgressBarFinished(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.horizontalProgressBar.Visible = false;
                this.fieldsPanel.Visible = true;
            });
        }

        private void OnCloseSettings(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnSaveSettings(object sender, EventArgs e)
        {
            int port = 0;
            Int32.TryParse(portTxt.Text, out port);
            this.settings.SettingsObj.app.tunnel.serverIp = this.ipTxt.Text;
            this.settings.SettingsObj.app.tunnel.serverPort = port;

            switch(this.modeComboBox.SelectedItem.ToString())
            {
                case "DEBUG":
                    this.settings.SettingsObj.app.tunnel.serverMode = "DEBUG";
                break;
                case "PRODUCTION":
                    this.settings.SettingsObj.app.tunnel.serverMode = "PRODUCTION";
                    break;
            }

            this.settings.Save();
            this.Close();
        }

    }
}
