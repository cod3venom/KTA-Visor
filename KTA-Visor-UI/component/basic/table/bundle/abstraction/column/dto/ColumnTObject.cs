using KTA_Visor_UI.component.basic.table.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto
{
    public class ColumnTObject : DataGridViewColumn
    {
        
        public ColumnTObject(int id, string name, ColumnType type = ColumnType.TEXT, bool readOnly = true, int width = -1)
        {
            this.ID = id;
            this.Name = name;
            this.Type = type;
            this.ReadOnly = readOnly;
            this.Width = width;
        }
       
        public int ID { get; set; }
        public string Name { get; set; }
        public ColumnType Type { get; set; }
        public bool ReadOnly { get; set; }
        public int Width{ get; set; }

    }
}
