using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.shadowPanel
{
    public partial class CustomPanel : UserControl
    {
        private Color _borderColor;
        
        private bool _enableShadow;

        public CustomPanel()
        {
            InitializeComponent();
        }

        private const int CS_DROPSHADOW = 0x00020000;
        
        public bool Shadow
        {
            get { return this._enableShadow; }
            set { this._enableShadow = value; }
        }

        public Color BorderColor
        {
            get { return this._borderColor; }
            set {this._borderColor = value;}
        }

        public int BorderRadius
        {
            get { return this.mainElipse.ElipseRadius; }
            set { this.mainElipse.ElipseRadius = value;}
        }

        private void ShadowPanel_Load(object sender, EventArgs e)
        {

        }

        private void CustomPanel_Paint(object sender, PaintEventArgs e)
        {
            if (this._borderColor != null)
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, this._borderColor, ButtonBorderStyle.Outset);
            }
        }
    }
}
