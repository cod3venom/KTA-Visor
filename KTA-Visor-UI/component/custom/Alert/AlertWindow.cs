using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.MessageWindow
{
    public partial class AlertWindow : Form
    {
        public event EventHandler<EventArgs> OnOk;
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public AlertWindow()
        {
            InitializeComponent();
        }

        public AlertWindow(string type, string title, string message)
        {
            InitializeComponent();
            
            this.Type = type;
            this.Title = title;
            this.Message = message;
            this.calibrateIcon();
            this.ShowDialog();
        }

        public string Type { get; set; }
        public string Title
        {
            set { this.titleLbl.Text = value; }
            get { return this.titleLbl.Text; }
        }

        public string Message
        {
            set { this.messageLbl.Text = value; } 
            get { return this.messageLbl.Text; }
        }

        public Bitmap Icon { get; set; }

        private void AlertWindow_Load(object sender, EventArgs e)
        {
            this.okBtn.OnClick += (delegate (object s, EventArgs ev) { 
                this.OnOk?.Invoke(this, new EventArgs());
                this.Close();
            });
        }

        private void calibrateIcon()
        {
            switch(this.Type)
            {
                case "error":
                    this.Icon = Properties.Resources.error;
                    break;

                case "info":
                    this.Icon = Properties.Resources.info;
                    break;

                case "success":
                    this.Icon = Properties.Resources.success;
                    break;
            }
        }
    }
}
