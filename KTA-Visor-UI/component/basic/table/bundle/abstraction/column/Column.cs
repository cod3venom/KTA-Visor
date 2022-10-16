﻿using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.@event;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.column
{
    public class Column: Sorter
    {
  
        private readonly Table table;


        public Column(Table  table): base(table)
        {
            this.table = table;
        }

        public ColumnTObject[] Columns { get; set; }

 
        public Column addMultiple(ColumnTObject[] columns)
        {            
            this.InitColumns(columns);

            foreach (var item in columns)
            {
                this.add(item);
            }
            return this;
        }

        public Column add(ColumnTObject column)
        {
            DataGridViewColumn columnUI = new DataGridViewColumn();
            switch(column.Type)
            {
                case enums.ColumnType.TEXT:
                    columnUI = new DataGridViewTextBoxColumn();
                    break;

                case enums.ColumnType.CHECKBOX:
                    columnUI = new DataGridViewCheckBoxColumn();
                    break;

                case enums.ColumnType.BUTTON:
                    columnUI = new DataGridViewButtonColumn();
                    break;

                case enums.ColumnType.IMAGE:
                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    columnUI = imageColumn;
                    break;

            }

            columnUI.Name = column.Name;
            columnUI.HeaderText = column.Name;
            columnUI.ReadOnly = column.ReadOnly;

            if (column.Width != - 1)
            {
                columnUI.Width = column.Width;
            }

            this.table.DataGridView.Columns.Add(columnUI);

            return this;
        }

    }
}
