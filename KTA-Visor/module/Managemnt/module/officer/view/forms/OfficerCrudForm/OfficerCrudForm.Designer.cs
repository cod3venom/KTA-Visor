namespace KTA_Visor.module.Managemnt.module.officer.view.forms.OfficerCrudForm
{
    partial class OfficerCrudForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.firstNameTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.firstNameLbl = new System.Windows.Forms.Label();
            this.cameraIdLbl = new System.Windows.Forms.Label();
            this.lastNameTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lastNameLbl = new System.Windows.Forms.Label();
            this.cardIdLbl = new System.Windows.Forms.Label();
            this.saveBtn = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.camCustomIdTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.cardCustomIdTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.badgeIdTxxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.badgeIdLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // topBar1
            // 
            this.topBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(800, 44);
            this.topBar1.TabIndex = 0;
            this.topBar1.Title = "Window";
            // 
            // firstNameTxt
            // 
            this.firstNameTxt.BorderColorFocused = System.Drawing.Color.White;
            this.firstNameTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.firstNameTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.firstNameTxt.BorderThickness = 1;
            this.firstNameTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.firstNameTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.firstNameTxt.isPassword = false;
            this.firstNameTxt.Location = new System.Drawing.Point(74, 100);
            this.firstNameTxt.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameTxt.Name = "firstNameTxt";
            this.firstNameTxt.Size = new System.Drawing.Size(303, 37);
            this.firstNameTxt.TabIndex = 17;
            this.firstNameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // firstNameLbl
            // 
            this.firstNameLbl.AutoSize = true;
            this.firstNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.firstNameLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLbl.Location = new System.Drawing.Point(70, 77);
            this.firstNameLbl.Name = "firstNameLbl";
            this.firstNameLbl.Size = new System.Drawing.Size(51, 19);
            this.firstNameLbl.TabIndex = 16;
            this.firstNameLbl.Text = "Imię *";
            // 
            // cameraIdLbl
            // 
            this.cameraIdLbl.AutoSize = true;
            this.cameraIdLbl.BackColor = System.Drawing.Color.Transparent;
            this.cameraIdLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraIdLbl.Location = new System.Drawing.Point(70, 164);
            this.cameraIdLbl.Name = "cameraIdLbl";
            this.cameraIdLbl.Size = new System.Drawing.Size(82, 19);
            this.cameraIdLbl.TabIndex = 18;
            this.cameraIdLbl.Text = "ID Kamery";
            // 
            // lastNameTxt
            // 
            this.lastNameTxt.BorderColorFocused = System.Drawing.Color.White;
            this.lastNameTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lastNameTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.lastNameTxt.BorderThickness = 1;
            this.lastNameTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lastNameTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lastNameTxt.isPassword = false;
            this.lastNameTxt.Location = new System.Drawing.Point(425, 100);
            this.lastNameTxt.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameTxt.Name = "lastNameTxt";
            this.lastNameTxt.Size = new System.Drawing.Size(303, 37);
            this.lastNameTxt.TabIndex = 21;
            this.lastNameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.lastNameLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLbl.Location = new System.Drawing.Point(421, 77);
            this.lastNameLbl.Name = "lastNameLbl";
            this.lastNameLbl.Size = new System.Drawing.Size(89, 19);
            this.lastNameLbl.TabIndex = 20;
            this.lastNameLbl.Text = "Nazwisko *";
            // 
            // cardIdLbl
            // 
            this.cardIdLbl.AutoSize = true;
            this.cardIdLbl.BackColor = System.Drawing.Color.Transparent;
            this.cardIdLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardIdLbl.Location = new System.Drawing.Point(421, 164);
            this.cardIdLbl.Name = "cardIdLbl";
            this.cardIdLbl.Size = new System.Drawing.Size(66, 19);
            this.cardIdLbl.TabIndex = 22;
            this.cardIdLbl.Text = "ID Karty";
            // 
            // saveBtn
            // 
            this.saveBtn.Active = false;
            this.saveBtn.Location = new System.Drawing.Point(676, 407);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(112, 31);
            this.saveBtn.TabIndex = 25;
            this.saveBtn.Title = "Save";
            // 
            // camCustomIdTxt
            // 
            this.camCustomIdTxt.BorderColorFocused = System.Drawing.Color.White;
            this.camCustomIdTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.camCustomIdTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.camCustomIdTxt.BorderThickness = 1;
            this.camCustomIdTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.camCustomIdTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.camCustomIdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.camCustomIdTxt.isPassword = false;
            this.camCustomIdTxt.Location = new System.Drawing.Point(74, 187);
            this.camCustomIdTxt.Margin = new System.Windows.Forms.Padding(4);
            this.camCustomIdTxt.Name = "camCustomIdTxt";
            this.camCustomIdTxt.Size = new System.Drawing.Size(303, 37);
            this.camCustomIdTxt.TabIndex = 26;
            this.camCustomIdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // cardCustomIdTxt
            // 
            this.cardCustomIdTxt.BorderColorFocused = System.Drawing.Color.White;
            this.cardCustomIdTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cardCustomIdTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.cardCustomIdTxt.BorderThickness = 1;
            this.cardCustomIdTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cardCustomIdTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardCustomIdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cardCustomIdTxt.isPassword = true;
            this.cardCustomIdTxt.Location = new System.Drawing.Point(425, 187);
            this.cardCustomIdTxt.Margin = new System.Windows.Forms.Padding(4);
            this.cardCustomIdTxt.Name = "cardCustomIdTxt";
            this.cardCustomIdTxt.Size = new System.Drawing.Size(303, 37);
            this.cardCustomIdTxt.TabIndex = 27;
            this.cardCustomIdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // badgeIdTxxt
            // 
            this.badgeIdTxxt.BorderColorFocused = System.Drawing.Color.White;
            this.badgeIdTxxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.badgeIdTxxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.badgeIdTxxt.BorderThickness = 1;
            this.badgeIdTxxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.badgeIdTxxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.badgeIdTxxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.badgeIdTxxt.isPassword = false;
            this.badgeIdTxxt.Location = new System.Drawing.Point(74, 274);
            this.badgeIdTxxt.Margin = new System.Windows.Forms.Padding(4);
            this.badgeIdTxxt.Name = "badgeIdTxxt";
            this.badgeIdTxxt.Size = new System.Drawing.Size(303, 37);
            this.badgeIdTxxt.TabIndex = 29;
            this.badgeIdTxxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // badgeIdLbl
            // 
            this.badgeIdLbl.AutoSize = true;
            this.badgeIdLbl.BackColor = System.Drawing.Color.Transparent;
            this.badgeIdLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.badgeIdLbl.Location = new System.Drawing.Point(70, 251);
            this.badgeIdLbl.Name = "badgeIdLbl";
            this.badgeIdLbl.Size = new System.Drawing.Size(116, 19);
            this.badgeIdLbl.TabIndex = 28;
            this.badgeIdLbl.Text = "Numer odznaki";
            // 
            // OfficerCrudForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.badgeIdTxxt);
            this.Controls.Add(this.badgeIdLbl);
            this.Controls.Add(this.cardCustomIdTxt);
            this.Controls.Add(this.camCustomIdTxt);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cardIdLbl);
            this.Controls.Add(this.lastNameTxt);
            this.Controls.Add(this.lastNameLbl);
            this.Controls.Add(this.cameraIdLbl);
            this.Controls.Add(this.firstNameTxt);
            this.Controls.Add(this.firstNameLbl);
            this.Controls.Add(this.topBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OfficerCrudForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OfficerCrudForm";
            this.Load += new System.EventHandler(this.OfficerCrudForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private System.Windows.Forms.Label cardIdLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox lastNameTxt;
        private System.Windows.Forms.Label lastNameLbl;
        private System.Windows.Forms.Label cameraIdLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox firstNameTxt;
        private System.Windows.Forms.Label firstNameLbl;
        public KTA_Visor_UI.component.basic.button.PrimaryButton saveBtn;
        private Bunifu.Framework.UI.BunifuMetroTextbox cardCustomIdTxt;
        private Bunifu.Framework.UI.BunifuMetroTextbox camCustomIdTxt;
        private Bunifu.Framework.UI.BunifuMetroTextbox badgeIdTxxt;
        private System.Windows.Forms.Label badgeIdLbl;
    }
}