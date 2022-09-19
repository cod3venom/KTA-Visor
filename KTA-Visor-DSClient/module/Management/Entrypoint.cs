using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.module.Management.clientTunnel;
using KTA_Visor_DSClient.module.Management.clientTunnel.events;
using KTA_Visor_DSClient.module.Management.events;
using KTA_Visor_DSClient.module.Management.module.Camera.service;
using KTA_Visor_DSClient.module.Management.view;
using KTA_Visor_DSClient.module.Shared;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.module.client.events;

namespace KTA_Visor_DSClient.module.Management
{
    public partial class Entrypoint : Form
    {
        public event EventHandler<OnExceptionOccuredEvent> OnExceptionOccured;

        private Settings settings;
        private readonly BootLoader bootLoader;
        private readonly SettingsManager settingsManagerView;
        private readonly CameraDevicesWatcher cameraDevicesWatcher;
        private ClientTunnel client;
        private GlobalController globalController;
        public Entrypoint()
        {
            InitializeComponent();
            this.settings = new Settings();
            this.bootLoader = new BootLoader();
            this.settingsManagerView = new SettingsManager(Globals.Logger, this.settings);
            this.cameraDevicesWatcher = new CameraDevicesWatcher();
        }

        private void Entry_Load(object sender, EventArgs e)
        {
            try
            {


                this.bootLoader.Load();

                if (!this.settings.SettingsObj.app.installed && !this.settings.SettingsObj.app.configured)
                {
                    this.settingsManagerView.ShowDialog();
                    return;
                }


                this.cameraDevicesWatcher.OnCameraConnectedEvent += (delegate (object _sender, CameraConnectedEvent _e)
                {
                    Globals.Logger.print(String.Format("Camera {0} has been connected", _e.Camera.ID));
                    this.cameraDevicesWatcher.TryToMountDevice();
                    Globals.CAMERAS_LIST.Add(_e.Camera);
                });

                this.cameraDevicesWatcher.OnCameraDisconnectedEvent += (delegate (object _sender, CameraDisconnectedEvent _e)
                {
                    Globals.Logger.print(String.Format("Camera {0} has been disconnected", _e.Camera.ID));
                    this.cameraDevicesWatcher.TryToMountDevice();

                    Globals.CAMERAS_LIST.Remove(_e.Camera);

                });

                this.cameraDevicesWatcher.OnCameraConnectedOrDisconnected += (delegate (object _sender, EventArgs _e)
                {
                    Globals.Logger.print("Camera device action detected in docking station");
                    this.cameraDevicesWatcher.TryToMountDevice();

                });


                Thread thr = new Thread((ThreadStart)delegate
                {
                    this.cameraDevicesWatcher.Start();

                    this.cameraDevicesWatcher.LoadConnectedDevices();
                });
                thr.IsBackground = true;
                thr.Start();


                this.client = new ClientTunnel();
                this.globalController = new GlobalController(this.client);

                this.client.OnRequestReceivedInTunnelEvent += (delegate (object _sender, TCPClientMessageReceivedEvent _e) {
                    globalController.Watch(_e.Request);
                });

                this.client.Connect();
            }
            catch (Exception ex)
            {
                Globals.Logger.error(ex.Message, ex);
            }
        }
    }
}
