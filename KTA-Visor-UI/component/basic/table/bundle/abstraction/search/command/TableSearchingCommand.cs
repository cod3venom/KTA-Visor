using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.search.command
{
    public class TableSearchingCommand
    {
        public static List<DataGridViewRow> Execute(Table table, string keyword)
        {
            List<DataGridViewRow> results = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in table.DataGridView.Rows)
            {
               foreach(DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null) continue;

                    if (cell.Value.ToString().Contains(keyword))
                    {
                        results.Add(row);
                    }
                }
            }
            return results;
        }
    }
}
