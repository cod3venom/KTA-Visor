using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.@event;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.filter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.column
{
    public class Column
    {
  
        private readonly Table table;
        private readonly Sorter _sorter;
        private readonly Filter _filter;

        public Column(Table  table)
        {
            this.table = table;
            this._sorter = new Sorter(table);
            this._filter = new Filter(table);
        }

        public ColumnTObject[] Columns { get; set; }

 
        public Column addMultiple(ColumnTObject[] columns)
        {            
            foreach (var item in columns)
            {
                this.add(item);
            }

            this._sorter.Handle();
            this._filter.Handle();
            return this;
        }

        public Column add(ColumnTObject column)
        {
            DataGridViewColumn columnUI = new DataGridViewColumn();
            Type columnTypeOf = typeof(string);
            switch(column.Type)
            {
                case enums.ColumnType.TEXT:
                    columnUI = new DataGridViewTextBoxColumn();
                    columnTypeOf = typeof(string);
                    break;

                case enums.ColumnType.CHECKBOX:
                    columnUI = new DataGridViewCheckBoxColumn();
                    columnTypeOf = typeof(DataGridViewCheckBoxColumn);
                    break;

                case enums.ColumnType.BUTTON:
                    columnUI = new DataGridViewButtonColumn();
                    break;

                case enums.ColumnType.IMAGE:
                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    columnUI = imageColumn;
                    columnTypeOf = typeof(Bitmap);
                    break;

            }

            columnUI.Name = column.Name;
            columnUI.HeaderText = column.Name;
            columnUI.Visible = column.Visible;
            columnUI.ReadOnly = column.ReadOnly;

            if (column.Width != - 1)
            {
                columnUI.Width = column.Width;
            }

            this.table.DataTable.Columns.Add(column.Name, columnTypeOf);
            //this.table.DataGridView.Columns.Add(columnUI);

            return this;
        }

    }
}
