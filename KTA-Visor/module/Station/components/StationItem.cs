using KTA_Visor.module.Station.components.events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Station.components
{
    public partial class StationItem : UserControl
    {
        private int id;

        public event EventHandler<StationItemActionEvent> OnLogin;
        public event EventHandler<StationItemActionEvent> OnViewCamers;
        public event EventHandler<StationItemActionEvent> OnSettings;
        public event EventHandler<StationItemActionEvent> OnRestart;
        public event EventHandler<StationItemActionEvent> OnShutDown;

        public StationItem()
        {
            InitializeComponent();
        }

        private void StationItem_Load(object sender, EventArgs e)
        {
            this.itemMenu.ItemClicked += ItemMenu_ItemClicked;
        }

        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        public string Name 
        { 
            get { return this.label1.Text; }
            set { this.label1.Text = value; } 
        }


        private void ItemMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            switch (e.ClickedItem.Name)
            {
                case "login":
                    this.OnLogin?.Invoke(this, new StationItemActionEvent(this.Id, this.Name));
                    break;

                case "cameras":
                    this.OnViewCamers?.Invoke(this, new StationItemActionEvent(this.Id, this.Name));
                    break;

                case "settings":
                    this.OnSettings?.Invoke(this, new StationItemActionEvent(this.Id, this.Name));
                    break;

                case "restart":
                    this.OnRestart?.Invoke(this, new StationItemActionEvent(this.Id, this.Name));
                    break;

                case "shutdown":
                    this.OnShutDown?.Invoke(this, new StationItemActionEvent(this.Id, this.Name));
                    break;
            }
        }

        private void StationItem_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.White) return;

            this.BackColor = Color.White;

        }

        private void StationItem_MouseEnter(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Silver) return;

            this.BackColor = Color.Silver;
        }
    }
}
