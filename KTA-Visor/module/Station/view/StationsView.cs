using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Station.view
{
    public partial class StationsView : Form
    {
        public StationsView()
        {
            InitializeComponent();
        }

        private void StationsView_Load(object sender, EventArgs e)
        {
            this.topBar1.Parent = this;
        }
    }
}
