using KTA_Visor.module.Managemnt.module.station.dto;
using KTA_Visor.module.Managemnt.module.station.entity;
using KTA_Visor.module.Managemnt.module.station.service;
using KTA_Visor.module.Managemnt.module.station.view.forms;
using KTA_Visor.module.Station.events;
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

namespace KTA_Visor.module.Managemnt.module.station.view.StationViewPanel
{
    public partial class StationViewPanel : UserControl
    {
        private readonly ColumnTObject[] Columns = new ColumnTObject[] {
            new ColumnTObject(0, "ID"),
            new ColumnTObject(1, "IDENTYFIKATOR STACJI"),
            new ColumnTObject(2, "IP ADRES"),
            new ColumnTObject(3, "ZMODYFIKOWANO"),
            new ColumnTObject(4, "UTWORZONO")
        };

        private readonly StationService stationService;
        
        private StationCRUDForm stationCRUDForm;

        /// <summary>
        /// 
        /// </summary>
        public StationViewPanel()
        {
            InitializeComponent();
            this.stationService = new StationService();
            this.table.OnAddButton += onClickAddNewStation;
            this.table.OnEditButton += onClickEditStation;
            this.table.OnDeleteButton += onClickDeleteStation;
            this.table.bundle.column.addMultiple(this.Columns);
        }

        
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StationViewPanel_Load(object sender, EventArgs e)
        {
            this.fetchStations();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClickAddNewStation(object sender, EventArgs e)
        {
            this.stationCRUDForm = new StationCRUDForm();
            this.stationCRUDForm.OnCreateStationEvent += (async delegate (object _sender, OnStationCRUDEvent evt)
            {
                await this.stationService.create(new CreateStationRequestTObject(evt.stationCustomId, evt.stationIpAddress));
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
        private async void onClickEditStation(object sender, EventArgs e)
        {
            string selectedStationId = this.getSelectedCameraId();
            StationEntity stationEntity = await this.stationService.findById(selectedStationId);
            this.stationCRUDForm = new StationCRUDForm(stationEntity.data.stationId, stationEntity.data.stationIp);
            this.stationCRUDForm.OnEditStationEvent += (async delegate (object _sender, OnStationCRUDEvent evt)
            {
                await this.stationService.edit(stationEntity.data.id, new EditStationRequestTObject(evt.stationCustomId, evt.stationIpAddress));
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
                string selectedStationId = this.getSelectedCameraId();
                this.stationService.delete(selectedStationId);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private async void fetchStations()
        {
            StationsEntity stationsEntity= await this.stationService.all();
            this.table.DataGridView.Rows.Clear();

            foreach (var station in stationsEntity.data)
            {
                this.table.bundle.row.add(
                    station.id,
                    station.stationId,
                    station.stationIp,
                    station.updatedAt,
                    station.createdAt
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string getSelectedCameraId()
        {
            return this.table.bundle.row.selectedRow.Cells["ID"].Value.ToString();
        }
    }
}
