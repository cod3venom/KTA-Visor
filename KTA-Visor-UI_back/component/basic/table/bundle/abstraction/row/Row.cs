using KTA_Visor_UI.component.basic.table.bundle.abstraction.row.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.row
{
    public class Row
    {
        private readonly DataGridView table;

        public Row(DataGridView table)
        {
            this.table = table;
        }

        public Row add(RowTObject row)
        {
            this.table.Invoke(new Action(() => {
                this.table.Rows.Add(row.getCells());
            }));
            
            return this;
        }

        public Row add(params object[] values)
        {
            this.table.Invoke(new Action(() => {
                this.table.Rows.Add(values);
            }));

            return this;
        }

        public Row removeRow(string value)
        {
            foreach (DataGridViewRow row in this.table.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != value) continue;

                    this.table.Invoke(new Action(() =>
                    {
                        this.table.Rows.Remove(row);
                    }));
                }
            }

            return this;
        }
    }
}
