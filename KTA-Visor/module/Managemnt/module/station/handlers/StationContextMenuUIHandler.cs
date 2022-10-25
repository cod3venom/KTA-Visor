using KTA_Visor.module.Managemnt.module.station.view;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.station.handlers
{
    public class StationContextMenuUIHandler
    {
        private readonly StationView _stationView;
        private readonly ContextMenuStrip _contextMenuStrip;
        public StationContextMenuUIHandler(StationView stationView, ContextMenuStrip contextMenuStrip)
        {
            this._stationView = stationView;
            this._contextMenuStrip = contextMenuStrip;
        }

        public void Handle()
        {
            this.hookEvents();
        }

        private void hookEvents()
        {
            this._stationView.Table.DataGridView.CellMouseDown += onCellMouseDownClick;
        }
 
        private void onCellMouseDownClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.deselectAllRows();

                DataGridViewRow row = this._stationView.Table.DataGridView.Rows[e.RowIndex];
                row.Selected = true;
                int currentMouseOverRow = this._stationView.Table.DataGridView.HitTest(e.X, e.Y).RowIndex;
                this._contextMenuStrip.Show(this._stationView.Table.DataGridView, new Point(e.X, e.Y));

            }
        }

        private void deselectAllRows()
        {
            this._stationView.Invoke((MethodInvoker)delegate
            {
                foreach (DataGridViewRow row in this._stationView.Table.DataGridView.Rows)
                {
                    row.Selected = false;
                }
            });
        }
    }
}
