using KTA_Visor_UI.component.basic.table.bundle.abstraction.column;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.filter;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.row;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle
{
    public abstract class AbstractResource : UserControl
    {
        
        protected Table Table { get; set; }

        public Column Column { get; set; }

        public Row Row { get; set; }
    }
}
