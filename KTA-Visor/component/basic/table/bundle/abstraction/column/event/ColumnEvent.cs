using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.component.basic.table.bundle.abstraction.column.dto
{
    public class ColumnEvent : EventArgs
    {
        private string _columnName;
        private int _columnId;

        public ColumnEvent(string columnName, int columnId)
        {
            ColumnName = columnName;
            ColumnId = columnId; ;
        }

        public string ColumnName { get => _columnName; set => _columnName = value; }

        public int ColumnId { get => _columnId; set => _columnId = value; }
    }
}
