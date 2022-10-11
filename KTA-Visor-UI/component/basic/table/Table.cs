using KTA_Visor_UI.component.basic.button;
using KTA_Visor_UI.component.basic.table.bundle;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.table
{
    public partial class Table : TableBundle
    {
        public event EventHandler OnAddButton;
        public event EventHandler OnEditButton;
        public event EventHandler OnDeleteButton;
        public event EventHandler OnRefreshData;

        public bool AllowProgressBar { get; set; } 

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;
 

        public Table() : base()
        {
            InitializeComponent();
            this.Table = this;
            this.Column = new bundle.abstraction.column.Column(this);
            this.Row = new bundle.abstraction.row.Row(this);
            this.AllowProgressBar = true;
        }

        

        private void Table_Load(object sender, EventArgs e)
        {

            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SetComboBoxHeight(columnFilterByCombobx.Handle, 25);
            SetComboBoxHeight(columnCombobx.Handle, 25);
            columnFilterByCombobx.Refresh();
            columnCombobx.Refresh(); 
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.hookEvents();
        }

        private void hookEvents()
        {
            this.addBtn.Click += onAddBtn;
            this.editBtn.Click += onEditBtn;
            this.deleteBtn.Click += onDeleteBtn;
            this.refreshTableBtn.Click += onRefreshDataBtn;
            this.DataGridView.RowsAdded += onRowAdded;
        }

 
        private void onRowAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!this.AllowProgressBar)
            {
                this.progressBar.Visible = false;
                return;
            }

            this.progressBar.Visible = true;
            this.progressBar.Start();
        }

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
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


        private void onRefreshDataBtn(object sender, EventArgs e)
        {
            this.OnRefreshData?.Invoke(this, new EventArgs());
            return;
        }

        public bool AllowAdd
        {
            get { return this.addBtn.Enabled; }
            set
            {
                this.addBtn.Enabled = value;
              //  this.addPanel.Visible = value;
            }
        }

        public bool AllowEdit
        {
            get { return this.editBtn.Enabled; }
            set
            {
                this.editBtn.Enabled= value;
                //this.editPanel.Visible = value;

            }
        }

        public bool AllowDelete
        {
            get { return this.deleteBtn.Enabled; }
            set
            {
                this.deleteBtn.Enabled = value;
                //this.deletePanel.Visible = value;
            }
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

        public  MetroTextBox SearchTextBox
        {
            get { return this.searchTxt; }
            set { this.searchTxt = value; }
        }

        public MetroFramework.Controls.MetroButton SearchButton
        {
            get { return this.searchBtn; }
            set { this.searchBtn = value; }
            
        }
        public ColumnTObject[] Columns
        {
            set 
            {
                this.Column.addMultiple(value); ;
            }
        }
        public ComboBox ColumnCombobx
        {
            get { return this.columnCombobx; }
            set { this.columnCombobx = value; }
        }

        public ComboBox ColumnSortByCombobx
        {
            get { return this.columnFilterByCombobx; }
            set { this.columnFilterByCombobx = value; }
        }
    }
}
