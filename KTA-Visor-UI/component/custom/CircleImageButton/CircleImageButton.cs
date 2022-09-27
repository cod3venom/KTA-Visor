using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            this.bunifuBtn.Click += BunifuBtn_Click;
            this.bunifuBtn.MouseEnter += onMouseEnter;
            this.bunifuBtn.MouseLeave += onMouseLeave;
 
        }
 
        private void onMouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.Show(this.Label, this.bunifuBtn, new Point(this.bunifuBtn.Location.X + 50, this.bunifuBtn.Location.Y + 25));
        }


        private void onMouseLeave(object sender, EventArgs e)
        {
            this.toolTip1.Hide(this.bunifuBtn);
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

        public string Label { get; set; }
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
