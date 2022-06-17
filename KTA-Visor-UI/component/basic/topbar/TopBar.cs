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

        public EventHandler<EventArgs> onClose;
        public EventHandler<EventArgs> onResize;
        public EventHandler<EventArgs> onMaximize;
        public EventHandler<EventArgs> onMinimize;

        public TopBar()
        {
            InitializeComponent();
        }

        private void TopBar_Load(object sender, EventArgs e)
        {
            this.closeBtn.Click += CloseBtn_Click;
            this.resizeBtn.Click += ResizeBtn_Click;
            this.minimizeBtn.Click += MinimizeBtn_Click;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.parent.Close();
            this.onClose?.Invoke(sender, e);
        }

        private void ResizeBtn_Click(object sender, EventArgs e)
        {
            if (this.parent.WindowState == FormWindowState.Maximized)
            {
                this.parent.WindowState = FormWindowState.Normal;
               // this.resizeBtn.Image = Properties.Resources.fullScreen;
                this.onResize?.Invoke(sender, e);
            } else
            {
                this.parent.WindowState = FormWindowState.Maximized;
                //this.resizeBtn.Image = Properties.Resources.resize;

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

        public Button CloseButton
        {
            get { return this.closeBtn; }
        }

        public Button ResizeButton
        {
            get { return this.resizeBtn; }
        }

        public Button MinimizeButton
        {
            get { return this.minimizeBtn; }
        }
    }
}
