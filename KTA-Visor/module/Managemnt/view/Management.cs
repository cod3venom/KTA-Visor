
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using System;
using System.Windows.Forms;
using KTA_RFID_Keyboard.module.RFIDKeyboardReader;
using KTA_Visor.module.Managemnt.module.officer.view.OfficersViewPanel;
using KTA_Visor.module.Managemnt.module.camera.views.CameraViewPanel;
using KTA_Visor.module.Managemnt.module.station.view.StationViewPanel;
using KTA_Visor.module.Managemnt.module.tunnel.view.TunnelSettingsPanelView;

namespace KTA_Visor.module.Management.view
{
    public partial class Management : Form
    {
        
        private readonly KeyboardReader keyboardReader;
   

        public Management()
        {
            InitializeComponent();
            this.loggerView.ParentPanel = this.loggerPanel;
            this.keyboardReader = new KeyboardReader();
        }

        private void StationsView_Load(object sender, EventArgs e)
        {
            this.topBar.Parent = this;
            this.topBar.onClose += StationsView_OnClose;
            this.initialize();
        }

        private void initialize()
        {
            this.tunnelSettingsBtn.OnClick += onShowTunnelSettings;
            this.officersBtn.OnClick += onShowOfficersViewPanel;
            this.cameraBtn.OnClick += onShowCamerasViewPanel;
            this.stationBtn.OnClick += onShowStationsPanel;

            this.startTunnelServerMenuItem.Click += StartTunnel;
            this.stopTunnelServerMenuItem.Click += StopTunnel;
            Program.Tunnel.onMessageReceived += Tunnel_onMessageReceived;
            this.keyboardReader.Subscribe();
            this.keyboardReader.OnKeyboardInputChanged += KeyboardReader_OnKeyboardInputChanged; ;

        }


        private void onShowTunnelSettings(object sender, EventArgs e)
        {
            this.contentPanel.Controls.Clear();
            TunnelSettingsViewPanel panel = new TunnelSettingsViewPanel();
            panel.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(panel);
        }

        private void onShowStationsPanel(object sender, EventArgs e)
        {
            this.contentPanel.Controls.Clear();
            StationViewPanel panel = new StationViewPanel();
            panel.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(panel);
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
            Program.Tunnel.start();
            this.tunnelIndicator.running(true, "Uruchomiony");
        }

        private void StopTunnel(object sender, EventArgs e)
        {
            Program.Tunnel.stop();
            this.tunnelIndicator.running(false, "Wstrzymany");
        }

        private void StationsView_OnClose(object sender, EventArgs e)
        {
            Program.Tunnel.stop();
            Environment.Exit(-1);
        }

        private void Tunnel_onMessageReceived(object sender, TCPTunnel.module.server.events.TCPServerClientMessageReceivedEvent e)
        {
            this.loggerView.append(e.getRoute().ToString());
        }

    }
}
