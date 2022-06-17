using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table.components.RowPosCounter
{
    public partial class PositionCounter : UserControl
    {
        public PositionCounter()
        {
            InitializeComponent();
        }

        public PositionCounter setTotalPos(int totalPos)
        {
            this.totalLbl.Text = totalPos.ToString();
            return this;
        }

        public PositionCounter setCurrentPosition(int pos)
        {
            this.currentLBL.Text = pos.ToString();
            return this;
        }
    }
}
