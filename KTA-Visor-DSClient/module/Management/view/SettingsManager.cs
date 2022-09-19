using KTA_Visor_DSClient.install.settings;
using KTA_Visor_UI.component.custom.MessageWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.Management.view
{
    public partial class SettingsManager : Form
    {
        private readonly KTALogger.Logger logger;
        private readonly Settings settings;
        
        public SettingsManager (KTALogger.Logger logger, Settings settings)
        {
            InitializeComponent();
            this.logger = logger;
            this.settings = settings;
            this.topBar.Parent = this;
            this.topBar.onClose += onClose;
        }
 
        private void SettingsManager_Load(object sender, EventArgs e)
        {
            this.releaseNameLbl.Text = this.settings.SettingsObj?.app?.releaseName;
            this.hookControls();
        }

        private void hookControls()
        {

            this.stationIdTxt.Text = this.settings.SettingsObj?.app?.station?.stationId;
            this.stationIpTxt.Text = this.settings.SettingsObj?.app?.station?.ipAddress;
            this.ipTxt.Text = this.settings.SettingsObj?.app?.management?.serverIp;
            this.portTxt.Text = this.settings.SettingsObj?.app?.management?.serverPort.ToString();
            this.autoReconnectChck.Checked = this.settings.SettingsObj.app.management.autoReconnect;
            this.storageLocationTxt.Text = this.settings.SettingsObj?.app?.fileSystem?.filesPath;
            this.autoCopyChk.Checked = this.settings.SettingsObj.app.fileSystem.autoCopy;
            this.usbRelayPort.Text = this.settings.SettingsObj?.app?.usbRelay?.COMport;
            this.apiTxt.Text = this.settings.SettingsObj?.app?.backend?.api;
            this.stationIdTxt.TextChanged += (delegate (object sender, EventArgs e){
                this.settings.SettingsObj.app.station.stationId = this.stationIdTxt.Text;
            });
            this.stationIpTxt.TextChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.station.ipAddress = this.stationIpTxt.Text;
            });

            this.ipTxt.TextChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.management.serverIp = this.ipTxt.Text;
            });
            this.portTxt.TextChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.management.serverPort = Int32.Parse(this.portTxt.Text);
            });
            this.autoReconnectChck.CheckedChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.management.autoReconnect = this.autoReconnectChck.Checked;
            });

            this.storageLocationTxt.TextChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.fileSystem.filesPath = this.storageLocationTxt.Text;
            });
            this.autoCopyChk.CheckedChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.fileSystem.autoCopy = this.autoCopyChk.Checked;
            });

            this.usbRelayPort.TextChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.usbRelay.COMport = this.usbRelayPort.Text;
            });

            this.apiTxt.TextChanged += (delegate (object sender, EventArgs e) {
                this.settings.SettingsObj.app.backend.api = this.apiTxt.Text;
            });
            this.saveBtn.OnClick += onSave;
        }

        private void onSave(object sender, EventArgs e)
        {
            if (this.settings.SettingsObj.app?.station?.stationId == ""){
                new AlertWindow("ID Stacji zostało zle wygenerowane, proszę spróbować jeszcze raz");
                return;
            }
            if (this.settings.SettingsObj.app?.station?.ipAddress == "")
            {
                new AlertWindow("IP Adres Stacji zostało zle wpisane, proszę spróbować jeszcze raz");
                return;
            }
            if (this.settings.SettingsObj.app?.management?.serverIp== "")
            {
                new AlertWindow("IP Adres Menedżera zostało zle wpisane, proszę spróbować jeszcze raz");
                return;
            }
            if (this.settings.SettingsObj.app?.management?.serverPort == 0)
            {
                new AlertWindow("IP Adres Menedżera zostało zle wpisane, proszę spróbować jeszcze raz");
                return;
            }
            if (this.settings.SettingsObj.app?.backend?.api== "")
            {
                new AlertWindow("HOST do API zostało zle wpisane, proszę spróbować jeszcze raz");
                return;
            }

            this.settings.SettingsObj.app.installed = true;
            this.settings.SettingsObj.app.configured = true;
            this.settings.Save(this.settings.SettingsObj);
            Application.Restart();
        }

        private void onClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
