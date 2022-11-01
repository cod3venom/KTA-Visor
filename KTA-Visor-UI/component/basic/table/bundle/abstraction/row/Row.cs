using KTA_Visor_UI.component.basic.table.bundle.abstraction.row.dto;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.row
{
    public class Row : Searcher
    {
        private readonly Table table;

        public event EventHandler<EventArgs> OnRowAdded;

        public Row(Table table): base(table)
        {
            this.table = table;
        }


        public DataGridViewRow SelectedRow
        {
            get
            {
                return this.table.DataGridView.CurrentRow;
            }
        }

        public DataGridViewCell FindSelectedRowCell(string columnName)
        {
            return this.SelectedRow.Cells[columnName];
        }

        public DataGridViewRowCollection Rows
        {
            get { return this.table.DataGridView.Rows; }
        }

        public DataGridViewSelectedRowCollection SelectedRows
        {
            get { return this.table.DataGridView.SelectedRows; }
        }

        public DataGridViewRow FindRowByCellValue(string value)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in this.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals(value))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            if (rowIndex == -1)
                return null;
            return this.Rows[rowIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Row Add(RowTObject row)
        {
           try
            {
                this.table.Invoke(new Action(() => {
                    this.table.DataGridView.Rows.Add(row.getCells());
                    this.OnRowAdded?.Invoke(this, EventArgs.Empty);
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public Row Add(params object[] values)
        {
            try
            {
                new Thread((ThreadStart) =>
                {
                    this.table.Invoke((MethodInvoker)delegate {
                        this.table.DataTable.Rows.Add(values);
                        //this.table.DataGridView.Rows.Add(values);
                    });
                }).Start();
            }
             catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Row Remove(string value)
        {
            try
            {
                foreach (DataGridViewRow row in this.table.DataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value?.ToString().ToLower() == value?.ToLower())
                        {
                            this.table.Invoke(new Action(() =>
                            {
                                if (table.IsDisposed)
                                    return;

                                try
                                {
                                    this.table.DataGridView.Rows.Remove(row);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }));
                        }
                    }
                }
                return this;
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Row clear()
        {
            this.table.DataGridView.Rows.Clear();
            return this;
        }
    }
}
