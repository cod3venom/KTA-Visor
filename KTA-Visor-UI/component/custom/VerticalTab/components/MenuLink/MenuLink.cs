using KTA_Visor_UI.component.custom.VerticalTab.components.MenuLink.events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.VerticalTab.components.MenuLink
{
    public partial class MenuLink : UserControl
    {
        public event EventHandler<MenuLinkClickEvent> OnClick;
        private bool enabled;
        private bool active;

        public MenuLink()
        {
            InitializeComponent();
        }

        public string Label
        {
            get { return this.labelLbl.Text; }
            set { this.labelLbl.Text = value; }
        }

        private void MenuLink_Load(object sender, EventArgs e)
        {
            this.Click += MenuLink_Click;
            this.labelLbl.Click += MenuLink_Click;
        }

        private void MenuLink_Click(object sender, EventArgs e)
        {
            if (this.active)
            {
                this.active = false;
                this.labelLbl.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3F3F46");
                this.OnClick?.Invoke(this, new MenuLinkClickEvent(this.labelLbl.Text));
                return;
            }
            if (!this.active)
            {
                this.active = true;
                this.labelLbl.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3F3F46");
                this.OnClick?.Invoke(this, new MenuLinkClickEvent(this.labelLbl.Text));
                return;
            }
        }
    }
}
