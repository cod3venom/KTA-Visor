using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.components.basic.table
{
    public partial class Table : UserControl
    {
        
        public Table()
        {
            InitializeComponent();
        }
        
        private void Table_Load(object sender, EventArgs e)
        {

        }

        public DataGridViewColumnCollection Columns
        {
            get { return this.dataGrid.Columns; }
        }

        public DataGridViewRowCollection Rows
        {
            get { return this.dataGrid.Rows; } 
        }


        public Table addColumn(string columnName)
        {
            this.dataGrid.Columns.Add(columnName, columnName);
            return this;
        }

        public Table addColumns(string[] columns)
        {
            foreach (string columnName in columns)
            {
                this.dataGrid.Columns.Add(columnName, columnName);
            }
            return this;
        }


        public Table removeColumn(string columnName)
        {
            this.dataGrid.Columns.Remove(columnName);
            return this;
        }


        

        public Table addRow(string[] row)
        {
            this.dataGrid.Invoke(new Action(() => {
                this.dataGrid.Rows.Add(row); 
            }));

            return this;
        }

        public DataGridViewRow findRow(string needle)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in this.dataGrid.Rows)
            {
                if (row.Cells.Count == 0) continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell is null) continue;
                    if (cell.Value is null) continue;
                    if (!cell.Value.ToString().Contains(needle)) continue ;
                    rowIndex = row.Index;
                    break;
                }
            }
            if (rowIndex == -1) return null; 

            return this.dataGrid.Rows[rowIndex];
        }

        public Table removeRow(int rowId)
        {
            this.dataGrid.Invoke(new Action(() => {
                this.dataGrid.Rows.RemoveAt(rowId);
            }));

            return this;
        }

    }
}
