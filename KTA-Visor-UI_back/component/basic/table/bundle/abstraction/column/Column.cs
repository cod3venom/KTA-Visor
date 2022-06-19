using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.column
{
    public class Column
    {
        public event EventHandler<ColumnEvent> onColumnAdded;

        public event EventHandler<ColumnEvent> onColumnRemoved;

        public event EventHandler<ColumnEvent> onColumnClicked;

        private readonly DataGridView table;

        public Column(DataGridView table)
        {
            this.table = table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public Column addMultiple(ColumnTObject[] columns)
        {
            foreach (var item in columns)
            {
                this.add(item);
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public Column add(ColumnTObject column)
        {
            this.table.Columns.Add(column.getName(), column.getName());

            this.onColumnAdded?.Invoke(this, new ColumnEvent(column.getName(), column.getId()));
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Column remove(ColumnTObject column)
        {
            this.table.Columns.Remove(column.getName());
            return this;
        }
    }
}
