using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.filter.command;
using MetroFramework;
using MetroFramework.Forms;
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
        private readonly Table _table;
        private readonly List<string> FilterOptions = new List<string>
        {
            "Rosnąco",
            "Malejąco",
        };
        private int SelectedColumnIndex = 0;
        private int SelectedFilterOptionIndex = 0;

        public Sorter(Table table)
        {
            this._table = table;
        }

        public void Handle()
        {
            this.initColumns();
        }
        private void initColumns()
        {

            foreach (ColumnTObject column in this._table.Columns)
            {
                this._table.ColumnCombobx.Items.Add(column.Name);
            }

            this.FilterOptions.ForEach(column => {

                this._table.ColumnSortByCombobx.Items.Add(column);
            });

            this._table.ColumnCombobx.SelectedIndex = 0;
            this._table.ColumnSortByCombobx.SelectedIndex = 0;

             
            this._table.ColumnCombobx.SelectedIndexChanged += (delegate (object sender, EventArgs e)
            {
                this.SelectedColumnIndex = this._table.ColumnCombobx.SelectedIndex;
            });

            this._table.ColumnSortByCombobx.SelectedIndexChanged += (delegate (object sender, EventArgs e)
            {
                this.SelectedFilterOptionIndex = this._table.ColumnSortByCombobx.SelectedIndex;
                this.onStartSorting();
            });
        }

        private void onStartSorting()
        {
            if (this.SelectedColumnIndex == -1)
            {
                MessageBox.Show("Proszę najpierw wybrać kolumnę na którą chcesz dokonać filtrowanie", "Błąd");
                return;
            }

            if (this._table.ColumnCombobx.SelectedValue == null || this._table.ColumnSortByCombobx.SelectedValue == null){
                return;
            }

            string columnName = this._table.ColumnCombobx.SelectedValue.ToString();
            string filterOption = this._table.ColumnSortByCombobx.SelectedValue.ToString();

            switch (filterOption)
            {
                case "Rosnąco":
                    SortByAscending.Execute(this._table, columnName);
                    break;

                case "Malejąco":
                    SortByDescending.Execute(this._table, columnName);
                    break;
            }
        }
    }
}
