using KTA_Visor.module.Shared.Global;
using KTAVisorAPISDK.module.station.entity;
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

namespace KTA_Visor.module.Managemnt.module.station.window
{
    public partial class RDPClientWindow : MetroForm
    {
        private readonly StationEntity _stationEntity;
        public RDPClientWindow(StationEntity stationEntity)
        {
            InitializeComponent();
            this._stationEntity = stationEntity;
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

        private void RDPClientWindow_Load(object sender, EventArgs e)
        {
            if (this._stationEntity.data == null)
            {
                MessageBox.Show("Wybrana stacja jest nie dostepna, skontaktuj się z Administratorem"); ;
                this.Close();
            }

            this.ipLbl.Text = this._stationEntity.data?.stationIp;
            this.userNameLbl.Text = this._stationEntity.data?.rdpUserName;

            this.rdpClient.Server = this._stationEntity.data?.stationIp;
            this.rdpClient.UserName = this._stationEntity.data?.rdpUserName;
            this.rdpClient.AdvancedSettings7.ClearTextPassword = this._stationEntity.data?.rdpPassword;
            this.rdpClient.AdvancedSettings7.EnableCredSspSupport = true;

            this.rdpClient.ColorDepth = 16;
            this.rdpClient.DesktopWidth= 1680;
            this.rdpClient.DesktopHeight = 720;
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;

            try
            {
                this.hookEvents();
                this.rdpClient.Connect();
            }
   
            catch(Exception ex)
            {
                Globals.Logger.error(ex.ToString(), ex);
                MessageBox.Show("Nie udało się nawiązać połączenie, skontaktuj się z Administratorem");
            }
        }

        private void hookEvents()
        {
            this.rdpClient.OnConnected += onConnected;
            this.rdpClient.OnDisconnected += onDisconnected;
            this.disconnectBtn.Click += onDisconnectClicked;
        }

        private void onConnected(object sender, EventArgs e)
        {
            this.disconnectBtn.Enabled = true;
        }

        private void onDisconnectClicked(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(this.rdpClient.Connected)){
                MessageBox.Show("Nie jesteś podłączony do stacji");
                return;
            }

            this.rdpClient.Disconnect();
        }

        private void onDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            this.Close();
        }
    }
}
