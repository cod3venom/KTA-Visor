using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto
{
    public class ColumnTObject
    {
        private  int id;

        private string name;
    
        public ColumnTObject(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int getId()
        {
            return id;
        }

        public ColumnTObject setId(int id)
        {
            this.id = id;

            return this;
        }

        public string getName()
        {
            return name;
        }

        public ColumnTObject setName(string name)
        {
            this.name= name;

            return this;
        }
    }
}
