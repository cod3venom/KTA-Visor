namespace KTA_Visor.module.Managemnt.module.auth.view.SignUpView
{
    partial class SignUpView
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
            this.firstNameLbl = new System.Windows.Forms.Label();
            this.lastNameLbl = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.signupPanel = new System.Windows.Forms.Panel();
            this.signInLink = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.signUpBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.passwordTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.emailTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lastNameText = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.firstNameTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.signupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // firstNameLbl
            // 
            this.firstNameLbl.AutoSize = true;
            this.firstNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.firstNameLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLbl.Location = new System.Drawing.Point(65, 64);
            this.firstNameLbl.Name = "firstNameLbl";
            this.firstNameLbl.Size = new System.Drawing.Size(51, 19);
            this.firstNameLbl.TabIndex = 4;
            this.firstNameLbl.Text = "Imię *";
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.lastNameLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLbl.Location = new System.Drawing.Point(65, 146);
            this.lastNameLbl.Name = "lastNameLbl";
            this.lastNameLbl.Size = new System.Drawing.Size(89, 19);
            this.lastNameLbl.TabIndex = 6;
            this.lastNameLbl.Text = "Nazwisko *";
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.BackColor = System.Drawing.Color.Transparent;
            this.emailLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLbl.Location = new System.Drawing.Point(65, 229);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(112, 19);
            this.emailLbl.TabIndex = 8;
            this.emailLbl.Text = "Adres e-mail *";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.BackColor = System.Drawing.Color.Transparent;
            this.passwordLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.Location = new System.Drawing.Point(65, 314);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(61, 19);
            this.passwordLbl.TabIndex = 10;
            this.passwordLbl.Text = "Hasło *";
            // 
            // signupPanel
            // 
            this.signupPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.signupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.signupPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signupPanel.Controls.Add(this.signInLink);
            this.signupPanel.Controls.Add(this.label1);
            this.signupPanel.Controls.Add(this.signUpBtn);
            this.signupPanel.Controls.Add(this.passwordTxt);
            this.signupPanel.Controls.Add(this.emailTxt);
            this.signupPanel.Controls.Add(this.lastNameText);
            this.signupPanel.Controls.Add(this.firstNameTxt);
            this.signupPanel.Controls.Add(this.topBar1);
            this.signupPanel.Controls.Add(this.lastNameLbl);
            this.signupPanel.Controls.Add(this.passwordLbl);
            this.signupPanel.Controls.Add(this.firstNameLbl);
            this.signupPanel.Controls.Add(this.emailLbl);
            this.signupPanel.Location = new System.Drawing.Point(410, 301);
            this.signupPanel.MaximumSize = new System.Drawing.Size(441, 509);
            this.signupPanel.Name = "signupPanel";
            this.signupPanel.Size = new System.Drawing.Size(441, 509);
            this.signupPanel.TabIndex = 12;
            // 
            // signInLink
            // 
            this.signInLink.AutoSize = true;
            this.signInLink.BackColor = System.Drawing.Color.Transparent;
            this.signInLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signInLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signInLink.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInLink.ForeColor = System.Drawing.Color.Gray;
            this.signInLink.Location = new System.Drawing.Point(248, 462);
            this.signInLink.Name = "signInLink";
            this.signInLink.Size = new System.Drawing.Size(86, 19);
            this.signInLink.TabIndex = 19;
            this.signInLink.Text = "Zaloguj się";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "Posiadasz już konto?";
            // 
            // signUpBtn
            // 
            this.signUpBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.signUpBtn.BackColor = System.Drawing.Color.Gray;
            this.signUpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.signUpBtn.BorderRadius = 0;
            this.signUpBtn.ButtonText = "Rejestracja";
            this.signUpBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signUpBtn.DisabledColor = System.Drawing.Color.Gray;
            this.signUpBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.signUpBtn.Iconimage = null;
            this.signUpBtn.Iconimage_right = null;
            this.signUpBtn.Iconimage_right_Selected = null;
            this.signUpBtn.Iconimage_Selected = null;
            this.signUpBtn.IconMarginLeft = 0;
            this.signUpBtn.IconMarginRight = 0;
            this.signUpBtn.IconRightVisible = true;
            this.signUpBtn.IconRightZoom = 0D;
            this.signUpBtn.IconVisible = true;
            this.signUpBtn.IconZoom = 90D;
            this.signUpBtn.IsTab = false;
            this.signUpBtn.Location = new System.Drawing.Point(69, 405);
            this.signUpBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Normalcolor = System.Drawing.Color.Gray;
            this.signUpBtn.OnHovercolor = System.Drawing.Color.Silver;
            this.signUpBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.signUpBtn.selected = false;
            this.signUpBtn.Size = new System.Drawing.Size(303, 37);
            this.signUpBtn.TabIndex = 17;
            this.signUpBtn.Text = "Rejestracja";
            this.signUpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.signUpBtn.Textcolor = System.Drawing.Color.White;
            this.signUpBtn.TextFont = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.passwordTxt.isPassword = true;
            this.passwordTxt.Location = new System.Drawing.Point(69, 337);
            this.passwordTxt.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(303, 37);
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
            this.emailTxt.Location = new System.Drawing.Point(69, 252);
            this.emailTxt.Margin = new System.Windows.Forms.Padding(4);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(303, 37);
            this.emailTxt.TabIndex = 15;
            this.emailTxt.Text = "levan@skillsforge.pl";
            this.emailTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lastNameText
            // 
            this.lastNameText.BorderColorFocused = System.Drawing.Color.White;
            this.lastNameText.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lastNameText.BorderColorMouseHover = System.Drawing.Color.White;
            this.lastNameText.BorderThickness = 1;
            this.lastNameText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lastNameText.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lastNameText.isPassword = false;
            this.lastNameText.Location = new System.Drawing.Point(69, 169);
            this.lastNameText.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameText.Name = "lastNameText";
            this.lastNameText.Size = new System.Drawing.Size(303, 37);
            this.lastNameText.TabIndex = 14;
            this.lastNameText.Text = "Ostrovski";
            this.lastNameText.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.firstNameTxt.Location = new System.Drawing.Point(69, 87);
            this.firstNameTxt.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameTxt.Name = "firstNameTxt";
            this.firstNameTxt.Size = new System.Drawing.Size(303, 37);
            this.firstNameTxt.TabIndex = 13;
            this.firstNameTxt.Text = "Levan";
            this.firstNameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.topBar1.Size = new System.Drawing.Size(439, 44);
            this.topBar1.TabIndex = 12;
            this.topBar1.Title = "";
            // 
            // SignUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1320, 847);
            this.Controls.Add(this.signupPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignUpView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignUpView";
            this.Load += new System.EventHandler(this.SignUpView_Load);
            this.signupPanel.ResumeLayout(false);
            this.signupPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.Label lastNameLbl;
        private System.Windows.Forms.Label firstNameLbl;
        private System.Windows.Forms.Panel signupPanel;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private System.Windows.Forms.Label signInLink;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton signUpBtn;
        private Bunifu.Framework.UI.BunifuMetroTextbox passwordTxt;
        private Bunifu.Framework.UI.BunifuMetroTextbox emailTxt;
        private Bunifu.Framework.UI.BunifuMetroTextbox lastNameText;
        private Bunifu.Framework.UI.BunifuMetroTextbox firstNameTxt;
    }
}