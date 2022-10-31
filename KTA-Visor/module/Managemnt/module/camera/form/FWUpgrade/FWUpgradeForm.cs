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
        private readonly StationService stationService;
        public FWUpgradeForm(CameraEntity.Camera camera)
        {
            InitializeComponent();
            this._camera = camera;
            this.stationService = new StationService();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

             using (Brush b = new SolidBrush(ColorTranslator.FromHtml("#222222")))
            {
                int borderWidth = 5;
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        private void FWUpgradeForm_Load(object sender, EventArgs e)
        {
            this.hookEvents();
            this.renderData();
        }

        private void hookEvents()
        {
            this.chooseImageBtn.Click += onChooseImageClick;
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

            string file = this.openFileDialog1.FileName;

            MessageBox.Show(file);
        }

        private async void upgrade()
        {

            StationEntity station = await this.stationService.findByCustomId(this._camera.stationId);
            TCPClientTObject client = Globals.Server.Clients.Find((TCPClientTObject _client) => _client.IpAddress == station?.data?.stationIp);
            
            if (client == null)
            {
                MetroMessageBox.Show(this, "Wybrana kamera nie jest znajduje się w sieći");
                return;
            }

            client.Send(new Request(
                "command://cameras/firmware/upgrade"    
            ));
        }
    }
}
