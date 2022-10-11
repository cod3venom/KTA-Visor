using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.filter.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.filter
{
    public class Sorter
    {
        private readonly Table table;
        private readonly List<string> FilterOptions = new List<string>
        {
            "Rosnąco",
            "Malejąco",
        };
        private ColumnTObject[] columns;
        private int SelectedColumnIndex = 0;
        private int SelectedFilterOptionIndex = 0;

        public Sorter(Table table)
        {
            this.table = table;
        }

        public void InitColumns(ColumnTObject[] columns)
        {
            this.columns = columns;

            foreach (ColumnTObject column in this.columns)
            {
                this.table.ColumnCombobx.Items.Add(column.Name);
            }

            this.FilterOptions.ForEach(column => {

                this.table.ColumnSortByCombobx.Items.Add(column);
            });

            this.table.ColumnCombobx.SelectedIndex = 0;
            this.table.ColumnSortByCombobx.SelectedIndex = 0;

             
            this.table.ColumnCombobx.SelectedIndexChanged += (delegate (object sender, EventArgs e)
            {
                this.SelectedColumnIndex = this.table.ColumnCombobx.SelectedIndex;
            });

            this.table.ColumnSortByCombobx.SelectedIndexChanged += (delegate (object sender, EventArgs e)
            {
                this.SelectedFilterOptionIndex = this.table.ColumnSortByCombobx.SelectedIndex;
                this.onStartSorting();
            });
        }

        private void onStartSorting()
        {
            if (this.SelectedColumnIndex == -1)
            {
                MessageBox.Show("Proszę najpierw wybrać kolumnę na którą chcesz dokonać filtrowanie");
                return;
            }


            string columnName = this.table.ColumnCombobx.SelectedValue.ToString();
            string filterOption = this.table.ColumnSortByCombobx.SelectedValue.ToString();

            switch (filterOption)
            {
                case "Rosnąco":
                    SortByAscending.Execute(this.table, columnName);
                    break;

                case "Malejąco":
                    SortByDescending.Execute(this.table, columnName);
                    break;
            }
        }
    }
}
