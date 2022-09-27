using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_UI.component.basic.table.bundle
{
    public class TableBundle : AbstractResource
    {

        public TableBundle():base()
        {
        }

        protected Table Table { get; set; }
 
    }
}
