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
        public event EventHandler<EventArgs> OnCancel;

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

        public AlertWindow(string type, string title, string message, bool allowcancel = false)
        {
            InitializeComponent();
            
            this.Type = type;
            this.Title = title;
            this.Message = message;
            this.AllowCancel = allowcancel;
            this.calibrateIcon();
            this.ShowDialog();
        }

        public AlertWindow(string message, string type="info", bool allowcancel = false)
        {
            InitializeComponent();
            this.Type = "info";
            this.Title = "";
            this.Message = message;
            this.AllowCancel = allowcancel;
            this.calibrateIcon();
            this.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static AlertWindow Show(string message, string type = "info", string title = "", bool allowCancel = false)
        {
            AlertWindow alert = new AlertWindow(type, title, message, allowCancel);
            alert.ShowDialog();
            return alert;
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
        public bool AllowCancel
        {
            get { return this.cancelBtn.Visible; }
            set { this.cancelBtn.Visible = value; }
        }

        private void AlertWindow_Load(object sender, EventArgs e)
        {
            this.okBtn.OnClick += (delegate (object s, EventArgs ev) { 
                this.OnOk?.Invoke(this, new EventArgs());
                this.Close();
            });

            this.cancelBtn.OnClick += (delegate (object s, EventArgs ev) {
                this.OnCancel?.Invoke(this, new EventArgs());
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
