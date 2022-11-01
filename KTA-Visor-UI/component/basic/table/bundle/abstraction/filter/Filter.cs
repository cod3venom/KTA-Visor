using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.filter
{
    public class Filter
    {
        private readonly Table _table;
        public Filter(Table table)
        {
            this._table = table;
        }

        public void Handle()
        {
            this.initColumns();
            this.initOperators();
            this.hookEvents();
        }

        private void initColumns()
        {
            foreach (ColumnTObject column in this._table.Columns)
            {
                this._table.ColumnFilterByCombobox.Items.Add(column.Name);
            }
            this._table.ColumnFilterByCombobox.SelectedIndex = 0;
        }

        private void initOperators()
        {
            this._table.ColumnFilterOperatorByCombobx.Items.Add("=");
            this._table.ColumnFilterOperatorByCombobx.Items.Add(">");
            this._table.ColumnFilterOperatorByCombobx.Items.Add("<");
            this._table.ColumnFilterOperatorByCombobx.Items.Add(">=");
            this._table.ColumnFilterOperatorByCombobx.Items.Add("=<");
            this._table.ColumnFilterOperatorByCombobx.Items.Add("%");
        }


        private void hookEvents()
        {
            this._table.FilterButton.Click += onStartFiltering;
            this._table.FilterKeywordTextBox.OnValueChanged += onFilteringKeywordChanged;
            this._table.FilterKeywordTextBox.KeyDown += onFilteringKeydown;
        }

        private void onFilteringKeydown(object sender, KeyEventArgs e)
        {
           if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) && this._table.FilterKeywordTextBox.Text != "")
            {
                this.onStartFiltering(sender, e);
            }
        }

        private void onFilteringKeywordChanged(object sender, EventArgs e)
        {
            if (this._table.FilterKeywordTextBox.Text == "")
            {
                this.flushFilterQuery();
            }
        }

        private void onStartFiltering(object sender, EventArgs e)
        {
            string filteringColumnName = this._table.ColumnFilterByCombobox.SelectedItem.ToString();
            string targetOperator = this._table.ColumnFilterOperatorByCombobx.SelectedItem.ToString();
            string keyword = this._table.FilterKeywordTextBox.Text;

            switch(targetOperator)
            {
                case "=":
                    this.executeFitlerQuery(string.Format("{0} = '{1}'", filteringColumnName, keyword));
                    break;
                case ">":
                    this.executeFitlerQuery(string.Format("{0} > '{1}'", filteringColumnName, keyword));
                    break;
                case "<":
                    this.executeFitlerQuery(string.Format("{0} < '{1}'", filteringColumnName, keyword));
                    break;
                case ">=":
                    this.executeFitlerQuery(string.Format("{0} >= '{1}'", filteringColumnName, keyword));
                    break;
                case "=<":
                    this.executeFitlerQuery(string.Format("{0} =< '{1}'", filteringColumnName, keyword));
                    break;
                case "%":
                    this.executeFitlerQuery(string.Format("{0} LIKE '%{1}%'", filteringColumnName, keyword));
                    break;
            }
        }

        private void executeFitlerQuery(string query)
        {
            try
            {
                (this._table.DataGridView.DataSource as DataTable).DefaultView.RowFilter = query;
            }
            catch(EvaluateException ex)
            {
            }
        }

        private void flushFilterQuery()
        {
            (this._table.DataGridView.DataSource as DataTable).DefaultView.RowFilter = "";
        }
    }
}
