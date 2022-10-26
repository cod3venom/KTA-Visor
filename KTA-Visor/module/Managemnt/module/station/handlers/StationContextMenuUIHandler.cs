using KTA_Visor.module.Managemnt.module.station.command;
using KTA_Visor.module.Managemnt.module.station.view;
using KTA_Visor.module.Managemnt.module.station.window;
using KTA_Visor.module.Shared.Global;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Managemnt.module.station.handlers
{
    public class StationContextMenuUIHandler
    {
        private readonly StationView _stationView;
        private readonly ContextMenuStrip _contextMenuStrip;
        private readonly StationService _stationService;
        public StationContextMenuUIHandler(StationView stationView, ContextMenuStrip contextMenuStrip)
        {
            this._stationView = stationView;
            this._contextMenuStrip = contextMenuStrip;
            this._stationService = new StationService();
        }

        public void Handle()
        {
            this.hookEvents();
        }

        private void hookEvents()
        {
            this._stationView.Table.DataGridView.CellMouseDown += onHandleRowContextMenuOnRightMouseClick;
            this._stationView.resetPowerSupplyMenuItem.Click += onRestartStation;
            this._stationView.resetTunnelMenuItem.Click += onRestartConnection;
            this._stationView.connectRemoteDesktopMenuItem.Click += onConnectToRDP;
            this._stationView.deleteStationMenuItem.Click += onDeleteStation;
        }

        

        private void onRestartStation(Object sender, EventArgs e)
        {
            this.sendCommand(new Request("command://power-supply/restart"));
        }

        private void onRestartConnection(Object sender, EventArgs e)
        {
            this.sendCommand(new Request("command://tunnel/restart"));
        }

        private async void onConnectToRDP(Object sender, EventArgs e)
        {
            StationEntity stationEntity = await this._stationService.findByCustomId(this._stationView.StationId);
            new RDPClientWindow(stationEntity).ShowDialog();
        }

        private void onDeleteStation(object sender, EventArgs e)
        {
            this.sendCommand(new Request("command://station/delete"));
        }

        private void sendCommand(Request request)
        {
            TCPClientTObject client = Globals.Server.Clients.Get(this._stationView?.StationIp);
            if (client == null){
                return;
            }

            client.Send(request);
        }
        private void onHandleRowContextMenuOnRightMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right){
                return;
            }

            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridViewCell cell = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                cell.DataGridView.ClearSelection();
                cell.DataGridView.CurrentCell = cell;
                cell.Selected = true;
                Rectangle r = cell.DataGridView.CurrentCell.DataGridView.GetCellDisplayRectangle(
                    cell.DataGridView.CurrentCell.ColumnIndex,
                    cell.DataGridView.CurrentCell.RowIndex,
                    false
                );
                Point coordinates = new Point(r.X - (r.Width / 50), r.Y + r.Height);
                this._contextMenuStrip.Show(cell.DataGridView.CurrentCell.DataGridView, coordinates);
            }
        }
    }
}
