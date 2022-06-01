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

    }
}
