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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpView));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.firstNameLbl = new System.Windows.Forms.Label();
            this.lastNameLbl = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.signupPanel = new System.Windows.Forms.Panel();
            this.signUpBtn = new MetroFramework.Controls.MetroButton();
            this.firstNameTxt = new MetroFramework.Controls.MetroTextBox();
            this.passwordTxt = new MetroFramework.Controls.MetroTextBox();
            this.signInLink = new System.Windows.Forms.Label();
            this.emailTxt = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lastNameText = new MetroFramework.Controls.MetroTextBox();
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
            this.firstNameLbl.Location = new System.Drawing.Point(49, 52);
            this.firstNameLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.firstNameLbl.Name = "firstNameLbl";
            this.firstNameLbl.Size = new System.Drawing.Size(39, 15);
            this.firstNameLbl.TabIndex = 4;
            this.firstNameLbl.Text = "Imię *";
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.lastNameLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLbl.Location = new System.Drawing.Point(49, 119);
            this.lastNameLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lastNameLbl.Name = "lastNameLbl";
            this.lastNameLbl.Size = new System.Drawing.Size(72, 15);
            this.lastNameLbl.TabIndex = 6;
            this.lastNameLbl.Text = "Nazwisko *";
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.BackColor = System.Drawing.Color.Transparent;
            this.emailLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLbl.Location = new System.Drawing.Point(49, 186);
            this.emailLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(87, 15);
            this.emailLbl.TabIndex = 8;
            this.emailLbl.Text = "Adres e-mail *";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.BackColor = System.Drawing.Color.Transparent;
            this.passwordLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.Location = new System.Drawing.Point(49, 255);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(48, 15);
            this.passwordLbl.TabIndex = 10;
            this.passwordLbl.Text = "Hasło *";
            // 
            // signupPanel
            // 
            this.signupPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.signupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.signupPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signupPanel.Controls.Add(this.signUpBtn);
            this.signupPanel.Controls.Add(this.firstNameTxt);
            this.signupPanel.Controls.Add(this.passwordTxt);
            this.signupPanel.Controls.Add(this.signInLink);
            this.signupPanel.Controls.Add(this.emailTxt);
            this.signupPanel.Controls.Add(this.label1);
            this.signupPanel.Controls.Add(this.lastNameText);
            this.signupPanel.Controls.Add(this.topBar1);
            this.signupPanel.Controls.Add(this.lastNameLbl);
            this.signupPanel.Controls.Add(this.passwordLbl);
            this.signupPanel.Controls.Add(this.firstNameLbl);
            this.signupPanel.Controls.Add(this.emailLbl);
            this.signupPanel.Location = new System.Drawing.Point(334, 140);
            this.signupPanel.Margin = new System.Windows.Forms.Padding(2);
            this.signupPanel.MaximumSize = new System.Drawing.Size(331, 414);
            this.signupPanel.Name = "signupPanel";
            this.signupPanel.Size = new System.Drawing.Size(331, 414);
            this.signupPanel.TabIndex = 12;
            // 
            // signUpBtn
            // 
            this.signUpBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signUpBtn.Location = new System.Drawing.Point(55, 328);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Size = new System.Drawing.Size(224, 23);
            this.signUpBtn.TabIndex = 27;
            this.signUpBtn.Text = "Zarejestruj się";
            this.signUpBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.signUpBtn.UseSelectable = true;
            // 
            // firstNameTxt
            // 
            // 
            // 
            // 
            this.firstNameTxt.CustomButton.Image = null;
            this.firstNameTxt.CustomButton.Location = new System.Drawing.Point(205, 1);
            this.firstNameTxt.CustomButton.Name = "";
            this.firstNameTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.firstNameTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.firstNameTxt.CustomButton.TabIndex = 1;
            this.firstNameTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.firstNameTxt.CustomButton.UseSelectable = true;
            this.firstNameTxt.CustomButton.Visible = false;
            this.firstNameTxt.Lines = new string[0];
            this.firstNameTxt.Location = new System.Drawing.Point(52, 70);
            this.firstNameTxt.MaxLength = 32767;
            this.firstNameTxt.Name = "firstNameTxt";
            this.firstNameTxt.PasswordChar = '\0';
            this.firstNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.firstNameTxt.SelectedText = "";
            this.firstNameTxt.SelectionLength = 0;
            this.firstNameTxt.SelectionStart = 0;
            this.firstNameTxt.ShortcutsEnabled = true;
            this.firstNameTxt.Size = new System.Drawing.Size(227, 23);
            this.firstNameTxt.TabIndex = 23;
            this.firstNameTxt.UseSelectable = true;
            this.firstNameTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.firstNameTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // passwordTxt
            // 
            // 
            // 
            // 
            this.passwordTxt.CustomButton.Image = null;
            this.passwordTxt.CustomButton.Location = new System.Drawing.Point(205, 1);
            this.passwordTxt.CustomButton.Name = "";
            this.passwordTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.passwordTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordTxt.CustomButton.TabIndex = 1;
            this.passwordTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordTxt.CustomButton.UseSelectable = true;
            this.passwordTxt.CustomButton.Visible = false;
            this.passwordTxt.Lines = new string[0];
            this.passwordTxt.Location = new System.Drawing.Point(52, 273);
            this.passwordTxt.MaxLength = 32767;
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '\0';
            this.passwordTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordTxt.SelectedText = "";
            this.passwordTxt.SelectionLength = 0;
            this.passwordTxt.SelectionStart = 0;
            this.passwordTxt.ShortcutsEnabled = true;
            this.passwordTxt.Size = new System.Drawing.Size(227, 23);
            this.passwordTxt.TabIndex = 26;
            this.passwordTxt.UseSelectable = true;
            this.passwordTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.passwordTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // signInLink
            // 
            this.signInLink.AutoSize = true;
            this.signInLink.BackColor = System.Drawing.Color.Transparent;
            this.signInLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signInLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signInLink.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInLink.ForeColor = System.Drawing.Color.Gray;
            this.signInLink.Location = new System.Drawing.Point(211, 367);
            this.signInLink.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.signInLink.Name = "signInLink";
            this.signInLink.Size = new System.Drawing.Size(68, 15);
            this.signInLink.TabIndex = 19;
            this.signInLink.Text = "Zaloguj się";
            // 
            // emailTxt
            // 
            // 
            // 
            // 
            this.emailTxt.CustomButton.Image = null;
            this.emailTxt.CustomButton.Location = new System.Drawing.Point(205, 1);
            this.emailTxt.CustomButton.Name = "";
            this.emailTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.emailTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.emailTxt.CustomButton.TabIndex = 1;
            this.emailTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.emailTxt.CustomButton.UseSelectable = true;
            this.emailTxt.CustomButton.Visible = false;
            this.emailTxt.Lines = new string[0];
            this.emailTxt.Location = new System.Drawing.Point(52, 204);
            this.emailTxt.MaxLength = 32767;
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.PasswordChar = '\0';
            this.emailTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailTxt.SelectedText = "";
            this.emailTxt.SelectionLength = 0;
            this.emailTxt.SelectionStart = 0;
            this.emailTxt.ShortcutsEnabled = true;
            this.emailTxt.Size = new System.Drawing.Size(227, 23);
            this.emailTxt.TabIndex = 25;
            this.emailTxt.UseSelectable = true;
            this.emailTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.emailTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 367);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Posiadasz już konto?";
            // 
            // lastNameText
            // 
            // 
            // 
            // 
            this.lastNameText.CustomButton.Image = null;
            this.lastNameText.CustomButton.Location = new System.Drawing.Point(205, 1);
            this.lastNameText.CustomButton.Name = "";
            this.lastNameText.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.lastNameText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.lastNameText.CustomButton.TabIndex = 1;
            this.lastNameText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lastNameText.CustomButton.UseSelectable = true;
            this.lastNameText.CustomButton.Visible = false;
            this.lastNameText.Lines = new string[0];
            this.lastNameText.Location = new System.Drawing.Point(52, 137);
            this.lastNameText.MaxLength = 32767;
            this.lastNameText.Name = "lastNameText";
            this.lastNameText.PasswordChar = '\0';
            this.lastNameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lastNameText.SelectedText = "";
            this.lastNameText.SelectionLength = 0;
            this.lastNameText.SelectionStart = 0;
            this.lastNameText.ShortcutsEnabled = true;
            this.lastNameText.Size = new System.Drawing.Size(227, 23);
            this.lastNameText.TabIndex = 24;
            this.lastNameText.UseSelectable = true;
            this.lastNameText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lastNameText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // topBar1
            // 
            this.topBar1.AllowClose = true;
            this.topBar1.AllowMinimize = false;
            this.topBar1.AllowResize = false;
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
            this.topBar1.Title = "Rejestracja";
            // 
            // SignUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(990, 688);
            this.Controls.Add(this.signupPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private MetroFramework.Controls.MetroTextBox passwordTxt;
        private MetroFramework.Controls.MetroTextBox emailTxt;
        private MetroFramework.Controls.MetroTextBox lastNameText;
        private MetroFramework.Controls.MetroTextBox firstNameTxt;
        private MetroFramework.Controls.MetroButton signUpBtn;
    }
}