using KTA_Visor.module.Station.controller;
using KTA_Visor.module.Management.station;
using KTA_Visor.module.Station.events;
using KTA_Visor.module.Station.service;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_UI.component.custom.FileList.components.HorizontalFileItem;
using KTA_Visor_UI.component.custom.Sidebar.events;
using KTA_Visor_UI.component.custom.SideBar.components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Station.view.StationVIew
{
    public partial class SingleStationView : Form
    {
        
        /// <summary>
        /// 
        /// </summary>
        private readonly StationTObject station;

        /// <summary>
        /// 
        /// </summary>
        private readonly Tunnel.Tunnel tunnel;

        /// <summary>
        /// 
        /// </summary>
        private readonly SingleStationViewController controller;
        
        /// <summary>
        /// 
        /// </summary>
        private readonly SingleStationViewService singleStationViewService;



        public SingleStationView()
        {
            InitializeComponent();
        }

        public SingleStationView(StationTObject station, Tunnel.Tunnel tunnel)
        {
            InitializeComponent();

            this.topBar.Parent = this;
            this.station = station;
            this.tunnel = tunnel;
            this.singleStationViewService = new SingleStationViewService(this.station, this);
            this.controller = new SingleStationViewController(this, this.singleStationViewService);
            
        }

        private void SingleStationView_Load(object sender, EventArgs e)
        {
            this.tunnel.onMessageReceived += Tunnel_onMessageReceived;
            this.askFrCameras();
        }

        private void setBreadCrumbs(string cameraName)
        {
            this.breadCrumbsLbl.Text = String.Format("Stacje / {0} /", this.station.Name);
            this.currentCameraLbl.Text = "/" + cameraName;
        }

        private void askFrCameras()
        {
            this.singleStationViewService.askForCameras();
            this.singleStationViewService.onCamerasReceived += onCamerasReceived;
            this.singleStationViewService.onCameraFilesReceived += onCameraFilesReceived;
            this.singleStationViewService.onSelectedCameraFilesReceived += onSelectedCameraFilesReceived;
        }

        

        private void onCamerasReceived(object sender, StationCamerasListReceivedEvent e)
        {

           foreach(KeyValuePair<string, USBCameraDevice> obj in e.Cameras)
           {
                USBCameraDevice camera = obj.Value;

                SidebarMenuItem item = new SidebarMenuItem();
                item.ExtraObject = camera;
                item.Label = "Kamera - " + camera.BadgeId;
                item.Dock = DockStyle.Top;
                item.onClick += onCameraSelect;
                this.sidebar.add(item);
            }

            this.sidebar.load();
            
        }

        private void onCameraSelect(object sender, SideBarItemClickedEvent e)
        {
            if (!typeof(USBCameraDevice).IsInstanceOfType(e.Item.ExtraObject)) return;
            
            USBCameraDevice camera = (USBCameraDevice)e.Item.ExtraObject;
            this.singleStationViewService.askForFilesFromSelectedCamera(camera?.Drive?.Name);

            this.setBreadCrumbs(e.Item.Label);
            this.sidebar.MenuItems.ForEach(item => item.setActive(e.Item.Label));
        }

        private void onCameraFilesReceived(object sender, StationCameraFilesReceivedEvent e)
        {

            foreach (KeyValuePair<string, FileInfo> obj in e.Files)
            {
                FileInfo file = obj.Value;
 
                FileItem fileItem = new FileItem();
                fileItem.Name = file.Name;
                fileItem.FileSize = file.Length.ToString();
                fileItem.CreatedAt = file.CreationTime.ToString();
                fileItem.Dock = DockStyle.Top;
                this.fileList.add(fileItem);
                
            }
        }

        private void onSelectedCameraFilesReceived(object sender, StationCameraFilesReceivedEvent e)
        {
            this.onCameraFilesReceived(sender, e);
        }

        private void Tunnel_onMessageReceived(object sender, TCPTunnel.module.server.events.TCPServerClientMessageReceivedEvent e)
        {
            this.controller.StartWatching(e.getRoute());
        }
    }
}
