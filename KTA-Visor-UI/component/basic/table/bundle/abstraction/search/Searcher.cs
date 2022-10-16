using KTA_Visor_UI.component.basic.table.bundle.abstraction.search.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.search
{
    public class Searcher
    {
        private readonly Table table;
        private string searchKeyword = "";
        public Searcher(Table table)
        {
            this.table = table;
            this.initialize();
        }

        private void initialize()
        {
            this.table.DataGridView.AllowUserToAddRows = false;
            this.table.DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.table.SearchTextBox.TextChanged += (delegate (object sender, EventArgs e)
            {
                this.searchKeyword = this.table.SearchTextBox.Text;

                if (this.searchKeyword == "")
                {
                    this.table.DataGridView.ClearSelection();
                    this.showAllRows();
                }
            });

            this.table.SearchTextBox.KeyDown += (delegate (object sender, KeyEventArgs e)
            {
                if (e.KeyValue != (int)Keys.Enter)
                    return;
                this.onStartSearching();
            });

            this.table.SearchButton.Click += (delegate (object sender, EventArgs e)
            {
                this.onStartSearching();
            });
        }

        private void onStartSearching()
        {
 
            List<DataGridViewRow> result = TableSearchingCommand.Execute(this.table, this.searchKeyword);
            this.handleSearch(result);
        }

        private void handleSearch(List<DataGridViewRow> result)
        {
            this.hideAllRows();
            foreach (DataGridViewRow row in result)
            {
                row.Selected = true;
                row.Visible = true;
            }
        }
        private void showAllRows()
        {
            foreach (DataGridViewRow row in this.table.DataGridView.Rows) {
                if (row.Visible) continue;
                row.Visible = true;
            }
        }

        private void hideAllRows()
        {
            foreach (DataGridViewRow row in this.table.DataGridView.Rows){
                if (!row.Visible) continue;
                row.Visible = false; 
            }
        }
    }
}
