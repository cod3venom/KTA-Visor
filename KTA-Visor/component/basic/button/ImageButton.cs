using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.component.basic.button
{
    public partial class ImageButton : UserControl
    {
        public ImageButton()
        {
            InitializeComponent();
        }

        public int BorderRadius
        {
            get { return this.bunifuElipse1.ElipseRadius; }
            set { this.bunifuElipse1.ElipseRadius = value; }
        }

        public Bunifu.Framework.UI.BunifuImageButton Button
        {
            get { return this.button; }
            set { this.button = value; }
        }

        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { 
                this.BackColor = value; 
                this.button.BackColor = value;
            }
        }
        private void ImageButton_Load(object sender, EventArgs e)
        {
            
        }
    }
}
