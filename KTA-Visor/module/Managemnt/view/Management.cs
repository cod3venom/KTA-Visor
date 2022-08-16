using KTA_Visor.module.Authentication.view;
using KTA_Visor.module.Station.controller;
using KTA_Visor.module.Management.station;
using KTA_Visor.module.Station.helper;
using KTA_Visor.module.Station.service;
using KTA_Visor.module.Station.view.StationVIew;
using KTA_Visor.module.Tunnel;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
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
using KTA_Visor.module.Station.components.StationItem;
using KTA_Visor.module.Station.components.StationItem.events;
using KTA_Visor.module.Station.components.ClientsList.components.ClientItem;
using KTA_Visor.module.Tunnel.view;
using KTA_Visor.module.Card.view;
using KTA_RFID_Keyboard.module.RFIDKeyboardReader;
using KTA_Visor.module.Managemnt.module.officer.view.OfficersViewPanel;
using KTA_Visor.module.Managemnt.module.camera.views.CameraViewPanel;

namespace KTA_Visor.module.Management.view
{
    public partial class Management : Form
    {
        
        private readonly KeyboardReader keyboardReader;

        private readonly TunnelSettingsView tunnelSettingsView;

        private readonly Tunnel.Tunnel tunnel;

   

        public Management()
        {
            InitializeComponent();
            this.loggerView.ParentPanel = this.loggerPanel;
            this.tunnelSettingsView = new TunnelSettingsView();
            this.keyboardReader = new KeyboardReader();

            this.tunnel = new Tunnel.Tunnel();
          
        }

        private void StationsView_Load(object sender, EventArgs e)
        {
            this.topBar.Parent = this;
            this.topBar.onClose += StationsView_OnClose;
            this.initialize();
        }

        private void initialize()
        {
            this.startTunnelServerMenuItem.Click += StartTunnel;
            this.stopTunnelServerMenuItem.Click += StopTunnel;
            this.tunnelSettingsBtn.OnClick += OpenTunnelSettings;
            this.tunnel.onMessageReceived += Tunnel_onMessageReceived;
            this.keyboardReader.Subscribe();
            this.keyboardReader.OnKeyboardInputChanged += KeyboardReader_OnKeyboardInputChanged; ;

            this.officersBtn.OnClick += onShowOfficersViewPanel;
            this.cameraBtn.OnClick += onShowCamerasViewPanel;

        }

        private void onShowOfficersViewPanel(object sender, EventArgs e)
        {
            this.contentPanel.Controls.Clear();
            OfficersPanelView panel = new OfficersPanelView();
            panel.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(panel);
        }


        private void onShowCamerasViewPanel(object sender, EventArgs e)
        {
            this.contentPanel.Controls.Clear();
            CamerasViewPanel panel = new CamerasViewPanel();
            panel.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(panel);
        }

        private void KeyboardReader_OnKeyboardInputChanged(object sender, KTA_RFID_Keyboard.module.reader.events.OnKeyboardReaderDataChanagedEvent e)
        {
            Console.WriteLine("detected:" + KeyboardReader.Input);
        }

        private void StartTunnel(object sender, EventArgs e)
        {
            this.tunnel.start();
            this.tunnelIndicator.running(true, "Uruchomiony");
        }

        private void StopTunnel(object sender, EventArgs e)
        {
            this.tunnel.stop();
            this.tunnelIndicator.running(false, "Wstrzymany");
        }

        private void OpenTunnelSettings(object sender, EventArgs e)
        {
            (new TunnelSettingsView()).ShowDialog();
        }

        private void Tunnel_onMessageReceived(object sender, TCPTunnel.module.server.events.TCPServerClientMessageReceivedEvent e)
        {
            this.loggerView.append(e.getRoute().ToString());
        }

        private void StationsView_OnClose(object sender, EventArgs e)
        {
            this.tunnel.stop();
        }

    }
}
