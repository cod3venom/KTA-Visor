using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.row.dto
{
    public class CellTObject : DataGridViewCell
    {
        private string value;

        public CellTObject(string value)
        {
            this.value = value;
        }

        public string getValue()
        {
            return this.value;
        }

        public CellTObject setValue(string value)
        {
           this.value = value;

            return this;
        }
    }
}
