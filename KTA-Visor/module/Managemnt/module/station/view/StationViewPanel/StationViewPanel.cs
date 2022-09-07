using KTA_Visor.module.Managemnt.module.station.view.forms;
using KTA_Visor.module.Station.events;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTAVisorAPISDK.module.station.dto;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        /// <summary>
        /// 
        /// </summary>
        private readonly StationService stationService;
        
        /// <summary>
        /// 
        /// </summary>
        private StationCRUDForm stationCRUDForm;

        /// <summary>
        /// 
        /// </summary>
        public StationViewPanel()
        {
            InitializeComponent();
            this.stationService = new StationService();
            this.table.AllowAdd = false;
            this.table.OnEditButton += onClickEditStation;
            this.table.OnDeleteButton += onClickDeleteStation;
            this.table.DataGridView.CellDoubleClick += onOpenStation;
            this.table.bundle.column.addMultiple(this.Columns);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StationViewPanel_Load(object sender, EventArgs e)
        {
            Program.TunnelBackgroundWorker.OnClientConnected += onStationConnected;
            Program.TunnelBackgroundWorker.OnClientDisconnected += onStationDisconnected;
            this.table.DataGridView.Cursor = Cursors.Hand;
        }

        private void onOpenSelectedStation(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void onStationConnected(object sender, events.OnClientConnected e)
        {
            StationEntity station = await this.stationService.findByCustomId(e.Client.AuthData.Identificator);
            this.addSingleRecord(station);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void onStationDisconnected(object sender, events.OnClientDisconnected e)
        {
            this.table.bundle.row.removeRow(e.Client.getIpAddress());
        }
 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void onClickEditStation(object sender, EventArgs e)
        {
            StationEntity stationEntity = await this.stationService.findById(this.SelectedStationId);
            this.stationCRUDForm = new StationCRUDForm(stationEntity.data.stationId, stationEntity.data.stationIp);
            this.stationCRUDForm.OnEditStationEvent += (async delegate (object _sender, OnStationCRUDEvent evt)
            {
                await this.stationService.edit(stationEntity.data.id, new EditStationRequestTObject(evt.stationId, evt.stationIpAddress));
                this.stationCRUDForm.Close();
                this.fetchStations();
            });
            this.stationCRUDForm.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClickDeleteStation(object sender, EventArgs e)
        {
            try
            {
                this.stationService.delete(this.SelectedStationId);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void onOpenStation(object sender, DataGridViewCellEventArgs e)
        {
            (new StationCamerasForm(this.SelectedStationId)).ShowDialog();
        }


        /// <summary>
        /// 
        /// </summary>
        private async void fetchStations()
        {
            StationEntity stationEntity= await this.stationService.all();
            this.table.DataGridView.Rows.Clear();

            foreach (var station in stationEntity.datas)
            {
                this.addSingleRecord(station);
            }
        }

        private void addSingleRecord(dynamic station)
        {
            if (station == null)
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string SelectedStationId
        {
            get { return this.table.bundle.row.SelectedRow.Cells["ID"].Value.ToString(); }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string SelectStationCustomId
        {
            get { return this.table.bundle.row.SelectedRow.Cells["ID"].Value.ToString(); }
        }

    }
}
