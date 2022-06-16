using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.component.basic.table.bundle.abstraction.row.dto
{
    public class RowTObject : DataGridViewRow
    {
        private string[] cells;

        public RowTObject(CellTObject[] values)
        {
            this.cells = new string[values.Length];
            this.addCells(values);
        }


        private void addCells(CellTObject[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                cells[i] = values[i].getValue();
            }

        }

        public string[] getCells()
        {
            return this.cells;
        }
    }
}
