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
            this.components = new System.ComponentModel.Container();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.filePasswordtxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.filePasswordRepeatTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.repeatPasswordLbl = new System.Windows.Forms.Label();
            this.showHidePasswordBtn = new System.Windows.Forms.Button();
            this.showHideRepeatedPasswordBtn = new System.Windows.Forms.Button();
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
            this.filePasswordtxt.Location = new System.Drawing.Point(151, 71);
            this.filePasswordtxt.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.filePasswordtxt.Name = "filePasswordtxt";
            this.filePasswordtxt.Size = new System.Drawing.Size(303, 37);
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
            this.filePasswordRepeatTxt.Location = new System.Drawing.Point(151, 118);
            this.filePasswordRepeatTxt.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.filePasswordRepeatTxt.Name = "filePasswordRepeatTxt";
            this.filePasswordRepeatTxt.Size = new System.Drawing.Size(303, 37);
            this.filePasswordRepeatTxt.TabIndex = 17;
            this.filePasswordRepeatTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(27, 247);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 23);
            this.panel1.TabIndex = 20;
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(41, 80);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(46, 16);
            this.passwordLbl.TabIndex = 21;
            this.passwordLbl.Text = "Hasło";
            // 
            // repeatPasswordLbl
            // 
            this.repeatPasswordLbl.AutoSize = true;
            this.repeatPasswordLbl.Location = new System.Drawing.Point(41, 130);
            this.repeatPasswordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.repeatPasswordLbl.Name = "repeatPasswordLbl";
            this.repeatPasswordLbl.Size = new System.Drawing.Size(93, 16);
            this.repeatPasswordLbl.TabIndex = 22;
            this.repeatPasswordLbl.Text = "Powtórz hasło";
            // 
            // showHidePasswordBtn
            // 
            this.showHidePasswordBtn.BackgroundImage = global::KTA_Visor_UI.Properties.Resources.show;
            this.showHidePasswordBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showHidePasswordBtn.Location = new System.Drawing.Point(464, 71);
            this.showHidePasswordBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.showHidePasswordBtn.Name = "showHidePasswordBtn";
            this.showHidePasswordBtn.Size = new System.Drawing.Size(40, 37);
            this.showHidePasswordBtn.TabIndex = 23;
            this.showHidePasswordBtn.UseVisualStyleBackColor = true;
            // 
            // showHideRepeatedPasswordBtn
            // 
            this.showHideRepeatedPasswordBtn.BackgroundImage = global::KTA_Visor_UI.Properties.Resources.show;
            this.showHideRepeatedPasswordBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showHideRepeatedPasswordBtn.Location = new System.Drawing.Point(464, 118);
            this.showHideRepeatedPasswordBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.showHideRepeatedPasswordBtn.Name = "showHideRepeatedPasswordBtn";
            this.showHideRepeatedPasswordBtn.Size = new System.Drawing.Size(40, 37);
            this.showHideRepeatedPasswordBtn.TabIndex = 24;
            this.showHideRepeatedPasswordBtn.UseVisualStyleBackColor = true;
            // 
            // FileEncryptionWithPasswordWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 295);
            this.Controls.Add(this.showHideRepeatedPasswordBtn);
            this.Controls.Add(this.showHidePasswordBtn);
            this.Controls.Add(this.repeatPasswordLbl);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.filePasswordRepeatTxt);
            this.Controls.Add(this.filePasswordtxt);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FileEncryptionWithPasswordWindow";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "FileEncryptionWithPasswordWindow";
            this.Load += new System.EventHandler(this.FileEncryptionWithPasswordWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuMetroTextbox filePasswordRepeatTxt;
        private Bunifu.Framework.UI.BunifuMetroTextbox filePasswordtxt;
        private System.Windows.Forms.Label repeatPasswordLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button showHidePasswordBtn;
        private System.Windows.Forms.Button showHideRepeatedPasswordBtn;
    }
}