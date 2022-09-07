using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto
{
    public class ColumnTObject
    {
        
        public ColumnTObject(int id, string name, string type = "text", bool readOnly = true)
        {
            this.ID = id;
            this.Name = name;
            this.Type = type;
            this.ReadOnly = readOnly;
        }
       
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool ReadOnly { get; set; }
    }
}
