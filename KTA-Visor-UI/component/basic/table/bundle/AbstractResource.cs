using KTA_Visor_UI.component.basic.table.bundle.abstraction.column;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.row;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_UI.component.basic.table.bundle
{
    public abstract class AbstractResource
    {
        private readonly Table table;

        public readonly Column column;

        public readonly Row row;
        public AbstractResource(Table table)
        {
            this.table = table;
            this.column = new Column(table.DataGridView);
            this.row = new Row(table.DataGridView);
        }
    }
}
