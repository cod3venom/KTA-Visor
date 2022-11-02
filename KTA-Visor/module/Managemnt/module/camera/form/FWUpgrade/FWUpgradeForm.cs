using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Shared.Global;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Managemnt.module.camera.form.FWUpgrade
{
    public partial class FWUpgradeForm : MetroForm
    {
        private readonly CameraEntity.Camera _camera;
        private readonly install.settings.Settings _settings;
        private readonly StationService stationService;
        public FWUpgradeForm(CameraEntity.Camera camera)
        {
            InitializeComponent();
            this._camera = camera;
            this._settings = new install.settings.Settings();
            this.stationService = new StationService();
        }

        private void FWUpgradeForm_Load(object sender, EventArgs e)
        {
            this.hookEvents();
            this.renderData();
        }

        private void hookEvents()
        {
            this.chooseImageBtn.Click += onChooseImageClick;
            Globals.Server.OnMessageReceivedFromClient += onRequestReceived;
        }
 

        private void renderData()
        {
            this.stationIdLbl.Text = this._camera?.stationId;
            this.camIdLbl.Text = this._camera?.cameraCustomId;
            this.badgeIdLbl.Text = this._camera?.badgeId;
        }
        private void onChooseImageClick(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();

            FileInfo firmware = new FileInfo(this.openFileDialog1.FileName);
            string destPath = string.Format("{0}\\{1}", this._settings.SettingsObj.app.fileSystem.firmwaresPath, firmware.Name);
            firmware.CopyTo(destPath, true);

            this.upgrade(new FileInfo(destPath));
        }

        private async void upgrade(FileInfo firmware)
        {

            StationEntity station = await this.stationService.findByCustomId(this._camera.stationId);
            TCPClientTObject client = Globals.Server.Clients.Find((TCPClientTObject _client) => _client.IpAddress == station?.data?.stationIp);
            
            if (client == null)
            {
                MetroMessageBox.Show(this, "Wybrana kamera nie jest znajduje się w sieći");
                return;
            }

            dynamic payload = new ExpandoObject();
            payload.firmware = firmware;
            payload.camera = this._camera;

            client.Send(new Request(
                "command://cameras/firmware/upgrade",
                payload
            ));

            this.Close();
        }



        private void onRequestReceived(object sender, OnMessageReceivedFromClient e)
        {
            switch (e.Request?.Endpoint)
            {
                case "command://cameras/firmware/upgrade/started":
                    this.onSuccessfullyStartedFWUpgradingProcedureNotification(e.Request);
                    break;
                case "command://cameras/firmware/upgrade/failed":
                    this.oFailedToStartFWUpgradingProcedureNotification(e.Request);
                    break;
            }
        }
        
        private void onSuccessfullyStartedFWUpgradingProcedureNotification(Request request)
        {
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(this, "Proces Aktualizacji systemu kamery zostało rozpoczęte, proszę poczekać chwile.");
                this.Close();
            });
        }

        private void oFailedToStartFWUpgradingProcedureNotification(Request request)
        {
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(this, "Nie udało się rozpocząc Proces Aktualizacji systemu kamery.");
                this.Close();
            });
        }

    }
}
