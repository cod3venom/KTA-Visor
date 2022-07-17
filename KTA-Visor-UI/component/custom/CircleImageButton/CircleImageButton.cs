using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.CircleImageButton
{
    public partial class CircleImageButton : UserControl
    {
        public event EventHandler<EventArgs> OnClick;

        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private static Cursor handCursor = new Cursor(Properties.Resources.hand_cursor.Handle);
        
        public CircleImageButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }


        private void CircleImageButton_Load(object sender, EventArgs e)
        {
            //this.bunifuBtn.Cursor = CircleImageButton.handCursor;

            this.bunifuBtn.Click += BunifuBtn_Click;
        }

        private void BunifuBtn_Click(object sender, EventArgs e)
        {
            this.OnClick?.Invoke(sender, e);
        }

        public Image Icon
        {
            get { return this.bunifuBtn.Image; }
            set { this.bunifuBtn.Image = value; }
        }

        private void bunifuBtn_MouseEnter(object sender, EventArgs e)
        {

            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#B0BEC5");
            this.bunifuBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#B0BEC5");
            this.bunifuBtn.Zoom = 5;
        }

        private void bunifuBtn_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFF");
            this.bunifuBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFF");

            this.bunifuBtn.Zoom = 0;
        }
    }
}
