namespace KTA_Visor_UI.component.custom.Security.FileEncryption
{
    partial class FileEncryptionWithPasswordWindow
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse();
            this.filePasswordtxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.filePasswordRepeatTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveBtn = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.repeatPasswordLbl = new System.Windows.Forms.Label();
            this.showHidePasswordBtn = new System.Windows.Forms.Button();
            this.showHideRepeatedPasswordBtn = new System.Windows.Forms.Button();
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // filePasswordtxt
            // 
            this.filePasswordtxt.BorderColorFocused = System.Drawing.Color.White;
            this.filePasswordtxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.filePasswordtxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.filePasswordtxt.BorderThickness = 1;
            this.filePasswordtxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.filePasswordtxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePasswordtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.filePasswordtxt.isPassword = true;
            this.filePasswordtxt.Location = new System.Drawing.Point(113, 58);
            this.filePasswordtxt.Margin = new System.Windows.Forms.Padding(4);
            this.filePasswordtxt.Name = "filePasswordtxt";
            this.filePasswordtxt.Size = new System.Drawing.Size(227, 30);
            this.filePasswordtxt.TabIndex = 16;
            this.filePasswordtxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // filePasswordRepeatTxt
            // 
            this.filePasswordRepeatTxt.BorderColorFocused = System.Drawing.Color.White;
            this.filePasswordRepeatTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.filePasswordRepeatTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.filePasswordRepeatTxt.BorderThickness = 1;
            this.filePasswordRepeatTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.filePasswordRepeatTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePasswordRepeatTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.filePasswordRepeatTxt.isPassword = true;
            this.filePasswordRepeatTxt.Location = new System.Drawing.Point(113, 96);
            this.filePasswordRepeatTxt.Margin = new System.Windows.Forms.Padding(4);
            this.filePasswordRepeatTxt.Name = "filePasswordRepeatTxt";
            this.filePasswordRepeatTxt.Size = new System.Drawing.Size(227, 30);
            this.filePasswordRepeatTxt.TabIndex = 17;
            this.filePasswordRepeatTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 205);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 35);
            this.panel1.TabIndex = 20;
            // 
            // saveBtn
            // 
            this.saveBtn.Active = false;
            this.saveBtn.Location = new System.Drawing.Point(292, 5);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(109, 25);
            this.saveBtn.TabIndex = 19;
            this.saveBtn.Title = "Save";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(31, 65);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(36, 13);
            this.passwordLbl.TabIndex = 21;
            this.passwordLbl.Text = "Hasło";
            // 
            // repeatPasswordLbl
            // 
            this.repeatPasswordLbl.AutoSize = true;
            this.repeatPasswordLbl.Location = new System.Drawing.Point(31, 106);
            this.repeatPasswordLbl.Name = "repeatPasswordLbl";
            this.repeatPasswordLbl.Size = new System.Drawing.Size(75, 13);
            this.repeatPasswordLbl.TabIndex = 22;
            this.repeatPasswordLbl.Text = "Powtórz hasło";
            // 
            // showHidePasswordBtn
            // 
            this.showHidePasswordBtn.BackgroundImage = global::KTA_Visor_UI.Properties.Resources.show;
            this.showHidePasswordBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showHidePasswordBtn.Location = new System.Drawing.Point(348, 58);
            this.showHidePasswordBtn.Name = "showHidePasswordBtn";
            this.showHidePasswordBtn.Size = new System.Drawing.Size(30, 30);
            this.showHidePasswordBtn.TabIndex = 23;
            this.showHidePasswordBtn.UseVisualStyleBackColor = true;
            // 
            // showHideRepeatedPasswordBtn
            // 
            this.showHideRepeatedPasswordBtn.BackgroundImage = global::KTA_Visor_UI.Properties.Resources.show;
            this.showHideRepeatedPasswordBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showHideRepeatedPasswordBtn.Location = new System.Drawing.Point(348, 96);
            this.showHideRepeatedPasswordBtn.Name = "showHideRepeatedPasswordBtn";
            this.showHideRepeatedPasswordBtn.Size = new System.Drawing.Size(30, 30);
            this.showHideRepeatedPasswordBtn.TabIndex = 24;
            this.showHideRepeatedPasswordBtn.UseVisualStyleBackColor = true;
            // 
            // topBar1
            // 
            this.topBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(412, 36);
            this.topBar1.TabIndex = 18;
            this.topBar1.Title = "Window";
            // 
            // FileEncryptionWithPasswordWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 240);
            this.Controls.Add(this.showHideRepeatedPasswordBtn);
            this.Controls.Add(this.showHidePasswordBtn);
            this.Controls.Add(this.repeatPasswordLbl);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.topBar1);
            this.Controls.Add(this.filePasswordRepeatTxt);
            this.Controls.Add(this.filePasswordtxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FileEncryptionWithPasswordWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileEncryptionWithPasswordWindow";
            this.Load += new System.EventHandler(this.FileEncryptionWithPasswordWindow_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private basic.topbar.TopBar topBar1;
        private Bunifu.Framework.UI.BunifuMetroTextbox filePasswordRepeatTxt;
        private Bunifu.Framework.UI.BunifuMetroTextbox filePasswordtxt;
        private System.Windows.Forms.Label repeatPasswordLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Panel panel1;
        private basic.button.PrimaryButton saveBtn;
        private System.Windows.Forms.Button showHidePasswordBtn;
        private System.Windows.Forms.Button showHideRepeatedPasswordBtn;
    }
}