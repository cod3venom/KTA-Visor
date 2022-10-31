namespace KTA_Visor.module.Managemnt.module.users.view
{
    partial class UsersView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.userInfoTab = new MetroFramework.Controls.MetroTabPage();
            this.table = new KTA_Visor_UI.component.basic.table.Table();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.userInfoBoard = new KTA_Visor.module.Managemnt.module.users.components.UserInfoBoard.UserInfoBoard();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.userInfoTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuSeparator1);
            this.panel1.Controls.Add(this.table);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 316);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 316);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 409);
            this.panel2.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.userInfoTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(984, 409);
            this.tabControl.TabIndex = 0;
            this.tabControl.UseSelectable = true;
            // 
            // userInfoTab
            // 
            this.userInfoTab.Controls.Add(this.userInfoBoard);
            this.userInfoTab.HorizontalScrollbarBarColor = true;
            this.userInfoTab.HorizontalScrollbarHighlightOnWheel = false;
            this.userInfoTab.HorizontalScrollbarSize = 10;
            this.userInfoTab.Location = new System.Drawing.Point(4, 38);
            this.userInfoTab.Name = "userInfoTab";
            this.userInfoTab.Size = new System.Drawing.Size(976, 367);
            this.userInfoTab.Style = MetroFramework.MetroColorStyle.Black;
            this.userInfoTab.TabIndex = 0;
            this.userInfoTab.Text = "Dane użytkownika";
            this.userInfoTab.Theme = MetroFramework.MetroThemeStyle.Light;
            this.userInfoTab.VerticalScrollbarBarColor = true;
            this.userInfoTab.VerticalScrollbarHighlightOnWheel = false;
            this.userInfoTab.VerticalScrollbarSize = 10;
            // 
            // table
            // 
            this.table.AllowAdd = true;
            this.table.AllowDelete = true;
            this.table.AllowEdit = true;
            this.table.AllowProgressBar = true;
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(984, 316);
            this.table.TabIndex = 0;
            this.table.Title = "Tabela";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 306);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(984, 10);
            this.bunifuSeparator1.TabIndex = 4;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // userInfoBoard
            // 
            this.userInfoBoard.BadgeId = "";
            this.userInfoBoard.CamCustomId = "";
            this.userInfoBoard.CardId = "";
            this.userInfoBoard.CreatedAt = "-";
            this.userInfoBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userInfoBoard.Email = "";
            this.userInfoBoard.FirstName = "";
            this.userInfoBoard.LastName = "";
            this.userInfoBoard.Location = new System.Drawing.Point(0, 0);
            this.userInfoBoard.Name = "userInfoBoard";
            this.userInfoBoard.Password = "";
            this.userInfoBoard.RepeatedPassword = "";
            this.userInfoBoard.Size = new System.Drawing.Size(976, 367);
            this.userInfoBoard.TabIndex = 50;
            this.userInfoBoard.UpdatedAt = "-";
            // 
            // UsersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "UsersView";
            this.Size = new System.Drawing.Size(984, 725);
            this.Load += new System.EventHandler(this.UsersView_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.userInfoTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private KTA_Visor_UI.component.basic.table.Table table;
        private MetroFramework.Controls.MetroTabControl tabControl;
        private MetroFramework.Controls.MetroTabPage userInfoTab;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private components.UserInfoBoard.UserInfoBoard userInfoBoard;
    }
}
