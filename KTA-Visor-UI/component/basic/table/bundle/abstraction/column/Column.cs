using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.@event;
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
            DataGridViewColumn columnUI = new DataGridViewColumn();
            switch(column.Type)
            {
                case "text":
                    columnUI = new DataGridViewTextBoxColumn();
                    break;

                case "checkbox":
                    columnUI = new DataGridViewCheckBoxColumn();
                    break;

                case "button":
                    columnUI = new DataGridViewButtonColumn();
                    break;

            }

            columnUI.Name = column.Name;
            columnUI.HeaderText = column.Name;
            columnUI.ReadOnly = column.ReadOnly;

            this.table.Columns.Add(columnUI);

            this.onColumnAdded?.Invoke(this, new ColumnEvent(column.Name, column.ID));
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Column remove(ColumnTObject column)
        {
            this.table.Columns.Remove(column.Name);
            return this;
        }
    }
}
