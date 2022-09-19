using KTA_Visor_UI.component.basic.table.bundle.abstraction.row.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.row
{
    public class Row
    {
        private readonly DataGridView table;

        public Row(DataGridView table)
        {
            this.table = table;
        }


        public DataGridViewRow SelectedRow
        {
            get
            {
                return this.table.CurrentRow;
            }
        }

        public DataGridViewCell FindSelectedRowCell(string columnName)
        {
            return this.SelectedRow.Cells[columnName];
        }

        public DataGridViewRowCollection Rows
        {
            get { return this.table.Rows; }
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
            return this.Rows[rowIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Row add(RowTObject row)
        {
           try
            {
                this.table.Invoke(new Action(() => {
                    this.table.Rows.Add(row.getCells());
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
        public Row add(params object[] values)
        {
            try
            {
                this.table.Invoke(new Action(() => {
                    this.table.Rows.Add(values);
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
        /// <param name="value"></param>
        /// <returns></returns>
        public Row removeRow(string value)
        {
            foreach (DataGridViewRow row in this.table.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value?.ToString().ToLower() == value?.ToLower())
                    {
                        this.table.Invoke(new Action(() =>
                        {
                            if (table.IsDisposed)
                                return;

                            this.table.Rows.Remove(row);
                        }));
                    }
                }
            }

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Row clear()
        {
            this.table.Rows.Clear();
            return this;
        }
    }
}
