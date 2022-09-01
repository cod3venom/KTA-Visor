using KTA_Visor.module.Station.events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.station.view.forms
{
    public partial class StationCRUDForm : Form
    {
        public event EventHandler<OnStationCRUDEvent> OnCreateStationEvent;
        public event EventHandler<OnStationCRUDEvent> OnEditStationEvent;

        private string mode = "create";

        public StationCRUDForm()
        {
            InitializeComponent();
        }

        public StationCRUDForm(string stationCustomId, string stationIpAddress)
        {
            InitializeComponent();
            this.stationCustomIdTxt.Text = stationCustomId;
            this.stationIpAddressTxt.Text = stationIpAddress;
            this.mode = "edit";
        }

        private void StationCRUDForm_Load(object sender, EventArgs e)
        {
            this.topBar.Parent = this;
            this.topBar.onClose += onCloseCurrentForm;
            this.topBar.MinimizeButton.Visible = false;
            this.topBar.ResizeButton.Visible = false;
            this.saveBtn.OnClick += onSaveBtn;
        }

        private void onSaveBtn(object sender, EventArgs e)
        {
            if (this.mode == "create")
            {
                this.OnCreateStationEvent?.Invoke(this, new OnStationCRUDEvent(
                    this.stationCustomIdTxt.Text,
                    this.stationIpAddressTxt.Text
                ));
            }
            else if (this.mode == "edit")
            {
                this.OnEditStationEvent?.Invoke(this, new OnStationCRUDEvent(
                    this.stationCustomIdTxt.Text,
                    this.stationIpAddressTxt.Text
                ));
            }
        }

        private void onCloseCurrentForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
