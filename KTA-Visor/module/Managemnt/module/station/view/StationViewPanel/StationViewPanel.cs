using KTA_Visor.module.Managemnt.module.camera.components.CameraNotification;
using KTA_Visor.module.Managemnt.module.camera.components.CameraNotification.events;
using KTA_Visor.module.Managemnt.module.camera.form;
using KTA_Visor.module.Managemnt.module.station.view.StationCameraPanel;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.station.view.StationViewPanel
{
    public partial class StationViewPanel : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ColumnTObject[] Columns = new ColumnTObject[] {
            new ColumnTObject(0, "ID"),
            new ColumnTObject(1, "IDENTYFIKATOR STACJI"),
            new ColumnTObject(2, "IP ADRES"),
            new ColumnTObject(3, "AKTYWNY"),
            new ColumnTObject(4, "ZMODYFIKOWANO"),
            new ColumnTObject(5, "UTWORZONO")
        };

        private StationEntity station;
        private readonly StationService stationService;
        private readonly CameraService cameraService;

        private StationCamerasPanel camerasPanel;

        public StationViewPanel()
        {
            InitializeComponent();
            this.stationService = new StationService();
            this.cameraService = new CameraService();
            this.table.AllowAdd = false;
            this.table.DataGridView.CellDoubleClick += onDisplaySelectedStationCameras;
            this.table.bundle.column.addMultiple(this.Columns);
        }

        private void StationViewPanel_Load(object sender, EventArgs e)
        {
            Program.TunnelBackgroundWorker.OnClientConnected += onStationConnected;
            Program.TunnelBackgroundWorker.OnClientDisconnected += onStationDisconnected;
            this.table.DataGridView.Cursor = Cursors.Hand;
        }


        private async void onStationConnected(object sender, events.OnClientConnected e)
        {
            this.station = await this.stationService.findByCustomId(e.Client.AuthData.Identificator);
            this.addRecord(station);
        }

        private void onStationDisconnected(object sender, events.OnClientDisconnected e)
        {
            this.table.bundle.row.removeRow(e.Client.getIpAddress());
        }


        private async void onDisplaySelectedStationCameras(object sender, DataGridViewCellEventArgs e)
        {
            this.stationCamerasPanel = new StationCamerasPanel(this.SelectedStationId);
        }



        private void addRecord(dynamic station)
        {
            try
            {
                if (station == null)
                    return;

                if (station.data == null)
                    return;

                this.table.bundle.row.add(
                    station?.data?.id,
                    station?.data?.stationId,
                    station?.data?.stationIp,
                    station?.data?.active ? "Tak" : "Nie",
                    station?.data?.updatedAt,
                    station?.data?.createdAt
                );
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string SelectedStationId
        {
            get { return this.table.bundle.row.SelectedRow.Cells["ID"].Value == null ? "" :  this.table.bundle.row.SelectedRow.Cells["ID"].Value.ToString(); }
        }
    }
}
