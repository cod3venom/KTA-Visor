using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.users.components.UserInfoBoard;
using KTA_Visor.module.Managemnt.module.users.components.UserInfoBoard.events;
using KTA_Visor.module.Managemnt.module.users.forms.CreateUser;
using KTA_Visor.module.Managemnt.module.users.forms.CreateUser.events;
using KTA_Visor.module.Managemnt.module.users.handler;
using KTA_Visor_UI.component.basic.table;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor_UI.component.basic.table.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Managemnt.module.users.view
{
    public partial class UsersView : UserControl, IControllerInterface
    {
        private readonly ColumnTObject[] Columns = new ColumnTObject[] {
            new ColumnTObject(0, "ID"),
            new ColumnTObject(0, "Imię"),
            new ColumnTObject(0, "Nazwisko"),
            new ColumnTObject(3, "Adres Email"),
            new ColumnTObject(2, "ID KAMERY"),
            new ColumnTObject(1, "NUMER ODZNAKI"),
            new ColumnTObject(4, "ZMODYFIKOWANO"),
            new ColumnTObject(5, "UTWORZONO")
        };

        private readonly UsersUIHandler _usersUIHandler;
        public UsersView()
        {
            InitializeComponent();
            this._usersUIHandler = new UsersUIHandler(this);
        }

        public void Watch(Request request)
        {
            
        }

        private void UsersView_Load(object sender, EventArgs e)
        {
            this.hookEvents();
            this.initialize();
        }

        private void hookEvents()
        {
            this.table.DataGridView.CellDoubleClick += onCellDoubleClick;
            this.table.OnRefreshData += onRefreshTableData;
            this.table.OnAddButton += onCreateUser;
            this.table.OnEditButton += onEditUser;
            this.table.OnDeleteButton += onDelete;
            this.UserInfoBoard.OnSaveUserChanges += onSaveUserChanges;
        }


        private void initialize()
        {
            this.userInfoTab.BringToFront();
            this.table.Columns = this.Columns;
            this._usersUIHandler.Load();
        }

        private void onCreateUser(object sender, EventArgs e)
        {

            CreateUserForm createUserForm = new CreateUserForm();
            createUserForm.OnCreateNewUser += (delegate (object _sender, OnCreateNewUserEvent _e)
            {
                this._usersUIHandler.Create(_e.Request);
                createUserForm.Close();
            });
            createUserForm.ShowDialog();
        }
        
        private void onEditUser(object sender, EventArgs e)
        {
            this._usersUIHandler.LoadSelectedUserById(this.SelectedUserId);
        }

        private void onDelete(object sender, EventArgs e)
        {
            this._usersUIHandler.Delete(this.SelectedUserId);
        }


        private void onSaveUserChanges(object sender, OnSaveUserFromBoardEvent e)
        {
            this._usersUIHandler.Edit(this.SelectedUserId, e.Request);
        }
 

        private void onRefreshTableData(object sender, EventArgs e)
        {
            this._usersUIHandler.Load(); 
        }

        private void onCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           this._usersUIHandler.LoadSelectedUserById(this.SelectedUserId);
        }

        public Table Table { get { return this.table; } }
        public UserInfoBoard UserInfoBoard { get { return this.userInfoBoard; } }
        public int SelectedUserId
        {
            get
            {
                if (this.Table.DataGridView.SelectedRows.Count == 0)
                    return 0;

                if (this.Table.DataGridView.SelectedRows[0].Cells[0]?.Value == null)
                    return 0;

                return Int32.Parse(this.Table.DataGridView.SelectedRows[0].Cells[0]?.Value.ToString());
            }
        }
    }
}
