using KTA_Visor.component.basic.table.bundle.abstraction.row.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.component.basic.table.bundle.abstraction.row
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
            this.table.Rows.Add(row.getCells());
            return this;
        }
    }
}
