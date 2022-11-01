using Bunifu.Framework.UI;
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

        private ColumnTObject[] _columns;

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;


        public Table()
        {
            InitializeComponent();
            this.TableC = this;
            this.Column = new bundle.abstraction.column.Column(this);
            this.Row = new bundle.abstraction.row.Row(this);
            this.AllowProgressBar = true;
            this.DataTable = new DataTable();
        }

        private void Table_Load(object sender, EventArgs e)
        {
            this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.DataSource = this.DataTable;

            SetComboBoxHeight(columnSortByCombobx.Handle, 25);
            SetComboBoxHeight(columnCombobx.Handle, 25);
            columnSortByCombobx.Refresh();
            columnCombobx.Refresh();
            this.hookEvents();
        }

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }


        private void hookEvents()
        {
            this.searchTxt.Click += (delegate (object sender, EventArgs e)
            {
                if (this.searchTxt.Text == "...") {
                    this.searchTxt.Text = "";
                }
            });

            this.addBtn.Click += (delegate (object sender, EventArgs e) {
                this.OnAddButton?.Invoke(this, EventArgs.Empty);
            });

            this.editBtn.Click += (delegate (object sender, EventArgs e) {
                this.OnEditButton?.Invoke(this, EventArgs.Empty);
            });

            this.deleteBtn.Click += (delegate (object sender, EventArgs e) {
                this.OnDeleteButton?.Invoke(this, EventArgs.Empty);
            });

            this.refreshBtn.Click += (delegate (object sender, EventArgs e){
                this.OnRefreshData?.Invoke(this, EventArgs.Empty);
            });

        }
        public bool AllowAdd
        {
            get { return this.addBtn.Enabled; }
            set { this.addBtn.Enabled = value; }
        }

        public bool AllowEdit
        {
            get { return this.editBtn.Enabled; }
            set { this.editBtn.Enabled = value; }
        }

        public bool AllowDelete
        {
            get { return this.deleteBtn.Enabled; }
            set { this.deleteBtn.Enabled = value; }
        }

        public Bunifu.Framework.UI.BunifuCustomDataGrid DataGridView
        {
            get { return this.dataGridView; }
            set { this.dataGridView = value; }
        }

        public string Title
        {
            set { this.titleLbl.Text = value; }
            get { return this.titleLbl.Text; }
        }

        public MetroTextBox SearchTextBox
        {
            get { return this.searchTxt; }
            set { this.searchTxt = value; }
        }

        public MetroButton SearchButton
        {
            get { return this.searchBtn; }
            set { this.searchBtn = value; }

        }
        public ColumnTObject[] Columns
        {
            set
            {
                if (value == null)
                {
                    return;
                }

                this._columns = value;
                this.Column.addMultiple(value); ;
            }
            get { return this._columns; }
        }

        public MetroComboBox ColumnCombobx
        {
            get { return this.columnCombobx; }
            set { this.columnCombobx = value; }
        }

        public MetroComboBox ColumnSortByCombobx
        {
            get { return this.columnSortByCombobx; }
            set { this.columnSortByCombobx = value; }
        }

        public MetroComboBox ColumnFilterByCombobox
        {
            get { return this.columnFilterByCombobox; }
            set { this.columnFilterByCombobox = value; }
        }

        public MetroComboBox ColumnFilterOperatorByCombobx
        {
            get { return this.operatorCombobox; }
            set { this.operatorCombobox = value; }
        }

        public BunifuMaterialTextbox FilterKeywordTextBox
        {
            get { return this.filterKeywordTxt; }
            set { this.filterKeywordTxt = value; }
        }

        public MetroButton FilterButton { get { return this.filterBtn; } }

        public DataTable DataTable { get; set; }

        public bool IsMultipleRecordsAreSelected
        {
            get
            {
                if (this.DataGridView.SelectedRows.Count == 0 || this.DataGridView.SelectedRows.Count == 1)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
