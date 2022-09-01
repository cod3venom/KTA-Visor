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
        public event EventHandler OnAddButton;
        public event EventHandler OnEditButton;
        public event EventHandler OnDeleteButton;

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

 

        public Bunifu.Framework.UI.BunifuCustomDataGrid DataGridView
        {
            get { return this.dataGridView1; }
            set { this.dataGridView1 = value; }
        }

        public string Title
        {
            set { this.titleLbl.Text = value; }
            get { return this.titleLbl.Text; }
        }

        private void Table_Load(object sender, EventArgs e)
        {

            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.addBtn.Click += onAddBtn;
            this.editBtn.Click += onEditBtn;
            this.deleteBtn.Click += onDeleteBtn;

            this.addPanel.Visible = this.allowAdd;
            this.editPanel.Visible = this.allowEdit;
            this.deletePanel.Visible = this.allowDelete;
        }

        private void onAddBtn(object sender, EventArgs e)
        {
            this.OnAddButton?.Invoke(this, new EventArgs());
        }

        private void onEditBtn(object sender, EventArgs e)
        {
            this.OnEditButton?.Invoke(this, e);
        }

        private void onDeleteBtn(object sender, EventArgs e)
        {
            this.OnDeleteButton?.Invoke(this, e);
        }
    }
}
