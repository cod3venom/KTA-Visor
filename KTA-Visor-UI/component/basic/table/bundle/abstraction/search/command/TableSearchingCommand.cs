using System.Collections.Generic;
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

                    if (cell.Value.ToString().ToLower().Contains(keyword.ToLower()))
                    {
                        results.Add(row);
                    }
                }
            }
            return results;
        }
    }
}
