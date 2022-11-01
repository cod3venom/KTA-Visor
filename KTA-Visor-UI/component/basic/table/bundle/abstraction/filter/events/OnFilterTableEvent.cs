using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.bundle.abstraction.filter.events
{
    public class OnFilterTableEvent : EventArgs
    {
        public OnFilterTableEvent(DataGridViewColumn targetColumn, string operatorType, string keyword)
        {
            this.TargetColumn = targetColumn;
            this.OperatorType = operatorType;
            this.Keyword = keyword;
        }

        public DataGridViewColumn TargetColumn { get; set; }
        public string OperatorType { get; set; }
        public string Keyword { get; set; }

    }
}
