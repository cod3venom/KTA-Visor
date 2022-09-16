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



        public Table()
        {
            InitializeComponent();
            this.bundle = new TableBundle(this);
        }

        public bool AllowAdd
        {
            get { return this.addBtn.Visible; }
            set { this.addBtn.Visible = value; }
        }

        public bool AllowEdit
        {
            get { return this.editBtn.Visible; }
            set { this.editBtn.Visible = value; }
        }

        public bool AllowDelete
        {
            get { return this.deleteBtn.Visible; }
            set { this.deleteBtn.Visible = value; }
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
