using KTA_Visor_UI.component.basic.topbar.events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.topbar
{
    public partial class TopBar : UserControl
    {
        private Form parent;

        public event EventHandler<EventArgs> onClose;
        public event EventHandler<EventArgs> onResize;
        public event EventHandler<EventArgs> onMaximize;
        public event EventHandler<EventArgs> onMinimize;

        public bool isToggled = false;

        private bool isMaximized = false;

        public Rectangle parentMinBounds;
        public Rectangle parentMaxBounds;

        public TopBar()
        {
            InitializeComponent();
        }

        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }

        }

        private void TopBar_Load(object sender, EventArgs e)
        {
            this.parentMinBounds = this.ParentForm.Bounds;
            this.parentMaxBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.closeBtn.Click += CloseBtn_Click;
            this.resizeBtn.Click += ResizeBtn_Click;
            this.minimizeBtn.Click += MinimizeBtn_Click;
        }
 

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.parent.Close();
            });
            this.onClose?.Invoke(sender, e);
        }

        private void ResizeBtn_Click(object sender, EventArgs e)
        {
            if (this.isMaximized)
            {
                this.ParentForm.Bounds = this.parentMinBounds;
                this.parent.WindowState = FormWindowState.Normal;
                this.isMaximized = false;
                this.onResize?.Invoke(sender, e);
            } else
            {
                this.ParentForm.Bounds = this.parentMaxBounds;
                this.isMaximized = true;
                this.onMaximize?.Invoke(sender, e);
            }
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.parent.WindowState = FormWindowState.Minimized;
            this.onMinimize?.Invoke(sender, e);
        }


        public Form Parent
        {
            get { return parent; }
            set { parent = value; }
        }

   

        public string Title
        {
            get { return this.titleLbl.Text; }
            set { this.titleLbl.Text = value; }
        }

       
        public Bunifu.Framework.UI.BunifuImageButton CloseButton
        {
            get { return this.closeBtn; }
        }

        public Bunifu.Framework.UI.BunifuImageButton ResizeButton
        {
            get { return this.resizeBtn; }
        }

        public Bunifu.Framework.UI.BunifuImageButton MinimizeButton
        {
            get { return this.minimizeBtn; }
        }
    }
}
