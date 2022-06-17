using KTA_Visor_UI.component.basic.table.bundle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table
{
    public partial class Table : UserControl
    {
        public readonly TableBundle bundle;

        private bool allowAdd = true;
        private bool allowEdit = true;
        private bool allowDelete = true;
        private bool allowSearch = true;


        private bool showAdd= true;
        private bool showEdit = true;
        private bool showDelete= true;
        private bool showControls = true;

        public Table()
        {
            InitializeComponent();
            this.bundle = new TableBundle(this);
        }

        public bool AllowAdd
        {
            get { return this.allowAdd; }
            set { this.allowAdd = value; }
        }

        public bool AllowEdit
        {
            get { return this.allowEdit; }
            set { this.allowEdit = value; }
        }

        public bool AllowDelete
        {
            get { return this.allowDelete; }
            set { this.allowDelete = value; }
        }

        public bool AllowSearch
        {
            get { return this.allowSearch; }
            set { this.allowSearch= value; }
        }

        public bool ShowControls
        {
            get { return this.showControls; }
            set { this.showControls = value; }
        }


        public bool ShowAdd
        {
            get { return this.showAdd; }
            set { this.showAdd = value; }
        }
        public bool ShowEdit
        {
            get { return this.showEdit; }
            set { this.showEdit = value; }
        }
        public bool ShowDelete
        {
            get { return this.showDelete; }
            set { this.showDelete = value; }
        }
        public DataGridView DataGridView
        {
            get { return this.dataGridView1 as DataGridView; }
        }

        private void Table_Load(object sender, EventArgs e)
        {
            this.addBtn.Enabled = this.allowAdd;
            this.addBtn.Visible = this.showAdd;

            this.editBtn.Enabled = this.allowEdit;
            this.editBtn.Visible = this.showEdit;

            this.deleteBtn.Enabled = this.allowDelete;
            this.deleteBtn.Visible = this.showDelete;

            this.searchInput.Enabled = this.AllowSearch;
            this.searchInput.Input.Enabled = this.AllowSearch;

            this.tableControlsContainer.Visible = this.showControls;

        }
    }
}
