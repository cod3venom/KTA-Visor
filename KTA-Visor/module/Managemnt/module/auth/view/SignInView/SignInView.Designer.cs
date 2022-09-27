namespace KTA_Visor.module.Managemnt.module.auth.view.SignInView
{
    partial class SignInView
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
            this.signInPanel = new System.Windows.Forms.Panel();
            this.signUpLink = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.signInBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.passwordTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.emailTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.signInPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // signInPanel
            // 
            this.signInPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.signInPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.signInPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signInPanel.Controls.Add(this.signUpLink);
            this.signInPanel.Controls.Add(this.label1);
            this.signInPanel.Controls.Add(this.signInBtn);
            this.signInPanel.Controls.Add(this.passwordTxt);
            this.signInPanel.Controls.Add(this.emailTxt);
            this.signInPanel.Controls.Add(this.topBar1);
            this.signInPanel.Controls.Add(this.passwordLbl);
            this.signInPanel.Controls.Add(this.emailLbl);
            this.signInPanel.Location = new System.Drawing.Point(324, 153);
            this.signInPanel.Margin = new System.Windows.Forms.Padding(2);
            this.signInPanel.MaximumSize = new System.Drawing.Size(331, 414);
            this.signInPanel.Name = "signInPanel";
            this.signInPanel.Size = new System.Drawing.Size(331, 414);
            this.signInPanel.TabIndex = 13;
            // 
            // signUpLink
            // 
            this.signUpLink.AutoSize = true;
            this.signUpLink.BackColor = System.Drawing.Color.Transparent;
            this.signUpLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signUpLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signUpLink.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpLink.ForeColor = System.Drawing.Color.Gray;
            this.signUpLink.Location = new System.Drawing.Point(182, 266);
            this.signUpLink.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.signUpLink.Name = "signUpLink";
            this.signUpLink.Size = new System.Drawing.Size(86, 15);
            this.signUpLink.TabIndex = 19;
            this.signUpLink.Text = "Zarejestruj się";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 266);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nie posiadasz  konta?";
            // 
            // signInBtn
            // 
            this.signInBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.signInBtn.BackColor = System.Drawing.Color.Gray;
            this.signInBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.signInBtn.BorderRadius = 0;
            this.signInBtn.ButtonText = "Zaloguj się";
            this.signInBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signInBtn.DisabledColor = System.Drawing.Color.Gray;
            this.signInBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.signInBtn.Iconimage = null;
            this.signInBtn.Iconimage_right = null;
            this.signInBtn.Iconimage_right_Selected = null;
            this.signInBtn.Iconimage_Selected = null;
            this.signInBtn.IconMarginLeft = 0;
            this.signInBtn.IconMarginRight = 0;
            this.signInBtn.IconRightVisible = true;
            this.signInBtn.IconRightZoom = 0D;
            this.signInBtn.IconVisible = true;
            this.signInBtn.IconZoom = 90D;
            this.signInBtn.IsTab = false;
            this.signInBtn.Location = new System.Drawing.Point(52, 215);
            this.signInBtn.Name = "signInBtn";
            this.signInBtn.Normalcolor = System.Drawing.Color.Gray;
            this.signInBtn.OnHovercolor = System.Drawing.Color.Silver;
            this.signInBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.signInBtn.selected = false;
            this.signInBtn.Size = new System.Drawing.Size(227, 30);
            this.signInBtn.TabIndex = 17;
            this.signInBtn.Text = "Zaloguj się";
            this.signInBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.signInBtn.Textcolor = System.Drawing.Color.White;
            this.signInBtn.TextFont = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // passwordTxt
            // 
            this.passwordTxt.BorderColorFocused = System.Drawing.Color.White;
            this.passwordTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.passwordTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.passwordTxt.BorderThickness = 1;
            this.passwordTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.passwordTxt.isPassword = false;
            this.passwordTxt.Location = new System.Drawing.Point(52, 167);
            this.passwordTxt.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(227, 30);
            this.passwordTxt.TabIndex = 16;
            this.passwordTxt.Text = "admin123";
            this.passwordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // emailTxt
            // 
            this.emailTxt.BorderColorFocused = System.Drawing.Color.White;
            this.emailTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.emailTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.emailTxt.BorderThickness = 1;
            this.emailTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.emailTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.emailTxt.isPassword = false;
            this.emailTxt.Location = new System.Drawing.Point(52, 100);
            this.emailTxt.Margin = new System.Windows.Forms.Padding(4);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(227, 30);
            this.emailTxt.TabIndex = 15;
            this.emailTxt.Text = "levan@skillsforge.pl";
            this.emailTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // topBar1
            // 
            this.topBar1.AllowClose = true;
            this.topBar1.AllowMinimize = true;
            this.topBar1.AllowResize = true;
            this.topBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Description = "";
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Margin = new System.Windows.Forms.Padding(2);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(329, 36);
            this.topBar1.TabIndex = 12;
            this.topBar1.Title = "Logowanie";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.BackColor = System.Drawing.Color.Transparent;
            this.passwordLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.Location = new System.Drawing.Point(49, 148);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(48, 15);
            this.passwordLbl.TabIndex = 10;
            this.passwordLbl.Text = "Hasło *";
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.BackColor = System.Drawing.Color.Transparent;
            this.emailLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLbl.Location = new System.Drawing.Point(49, 81);
            this.emailLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(87, 15);
            this.emailLbl.TabIndex = 8;
            this.emailLbl.Text = "Adres e-mail *";
            // 
            // SignInView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(990, 688);
            this.Controls.Add(this.signInPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SignInView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignInView";
            this.Load += new System.EventHandler(this.SignInView_Load);
            this.signInPanel.ResumeLayout(false);
            this.signInPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel signInPanel;
        private System.Windows.Forms.Label signUpLink;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton signInBtn;
        private Bunifu.Framework.UI.BunifuMetroTextbox passwordTxt;
        private Bunifu.Framework.UI.BunifuMetroTextbox emailTxt;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label emailLbl;
    }
}