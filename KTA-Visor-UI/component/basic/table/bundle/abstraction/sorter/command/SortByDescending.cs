using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.filter.command
{
    public class SortByDescending
    {
        public static void Execute(Table table, string columnName)
        {
            DataGridViewColumn column = table.DataGridView.Columns[columnName];
            table.DataGridView.Sort(column, System.ComponentModel.ListSortDirection.Descending);
        }
    }
}
