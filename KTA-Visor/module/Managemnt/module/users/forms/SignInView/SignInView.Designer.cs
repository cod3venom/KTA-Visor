using KTA_Visor_UI.component.basic.progressbar;

namespace KTA_Visor.module.Managemnt.module.users.forms.SignInView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignInView));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.signInPanel = new System.Windows.Forms.Panel();
            this.signInBtn = new MetroFramework.Controls.MetroButton();
            this.passwordTxt = new MetroFramework.Controls.MetroTextBox();
            this.emailTxt = new MetroFramework.Controls.MetroTextBox();
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.forgotPasswordLbl = new System.Windows.Forms.Label();
            this.signUpLink = new System.Windows.Forms.Label();
            this.questionLbl = new System.Windows.Forms.Label();
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
            this.signInPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.signInPanel.BackColor = System.Drawing.Color.White;
            this.signInPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signInPanel.Controls.Add(this.signInBtn);
            this.signInPanel.Controls.Add(this.passwordTxt);
            this.signInPanel.Controls.Add(this.emailTxt);
            this.signInPanel.Controls.Add(this.topBar1);
            this.signInPanel.Controls.Add(this.forgotPasswordLbl);
            this.signInPanel.Controls.Add(this.signUpLink);
            this.signInPanel.Controls.Add(this.questionLbl);
            this.signInPanel.Controls.Add(this.passwordLbl);
            this.signInPanel.Controls.Add(this.emailLbl);
            this.signInPanel.Location = new System.Drawing.Point(676, 194);
            this.signInPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.signInPanel.MaximumSize = new System.Drawing.Size(441, 755);
            this.signInPanel.Name = "signInPanel";
            this.signInPanel.Size = new System.Drawing.Size(441, 443);
            this.signInPanel.TabIndex = 13;
            // 
            // signInBtn
            // 
            this.signInBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signInBtn.Location = new System.Drawing.Point(76, 282);
            this.signInBtn.Margin = new System.Windows.Forms.Padding(4);
            this.signInBtn.Name = "signInBtn";
            this.signInBtn.Size = new System.Drawing.Size(299, 28);
            this.signInBtn.TabIndex = 24;
            this.signInBtn.Text = "Zaloguj się";
            this.signInBtn.Theme = MetroFramework.MetroThemeStyle.Light;
            this.signInBtn.UseSelectable = true;
            // 
            // passwordTxt
            // 
            // 
            // 
            // 
            this.passwordTxt.CustomButton.Image = null;
            this.passwordTxt.CustomButton.Location = new System.Drawing.Point(277, 2);
            this.passwordTxt.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTxt.CustomButton.Name = "";
            this.passwordTxt.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.passwordTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordTxt.CustomButton.TabIndex = 1;
            this.passwordTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordTxt.CustomButton.UseSelectable = true;
            this.passwordTxt.CustomButton.Visible = false;
            this.passwordTxt.Lines = new string[] {
        "admin123"};
            this.passwordTxt.Location = new System.Drawing.Point(72, 214);
            this.passwordTxt.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTxt.MaxLength = 32767;
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '●';
            this.passwordTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordTxt.SelectedText = "";
            this.passwordTxt.SelectionLength = 0;
            this.passwordTxt.SelectionStart = 0;
            this.passwordTxt.ShortcutsEnabled = true;
            this.passwordTxt.Size = new System.Drawing.Size(303, 28);
            this.passwordTxt.TabIndex = 23;
            this.passwordTxt.Text = "admin123";
            this.passwordTxt.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.passwordTxt.UseSelectable = true;
            this.passwordTxt.UseSystemPasswordChar = true;
            this.passwordTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.passwordTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // emailTxt
            // 
            // 
            // 
            // 
            this.emailTxt.CustomButton.Image = null;
            this.emailTxt.CustomButton.Location = new System.Drawing.Point(277, 2);
            this.emailTxt.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.emailTxt.CustomButton.Name = "";
            this.emailTxt.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.emailTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.emailTxt.CustomButton.TabIndex = 1;
            this.emailTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.emailTxt.CustomButton.UseSelectable = true;
            this.emailTxt.CustomButton.Visible = false;
            this.emailTxt.Lines = new string[] {
        "levan@skillsforge.pl"};
            this.emailTxt.Location = new System.Drawing.Point(72, 143);
            this.emailTxt.Margin = new System.Windows.Forms.Padding(4);
            this.emailTxt.MaxLength = 32767;
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.PasswordChar = '\0';
            this.emailTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailTxt.SelectedText = "";
            this.emailTxt.SelectionLength = 0;
            this.emailTxt.SelectionStart = 0;
            this.emailTxt.ShortcutsEnabled = true;
            this.emailTxt.Size = new System.Drawing.Size(303, 28);
            this.emailTxt.TabIndex = 22;
            this.emailTxt.Text = "levan@skillsforge.pl";
            this.emailTxt.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.emailTxt.UseSelectable = true;
            this.emailTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.emailTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            this.topBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(439, 44);
            this.topBar1.TabIndex = 21;
            this.topBar1.Title = "Logowanie";
            // 
            // forgotPasswordLbl
            // 
            this.forgotPasswordLbl.AutoSize = true;
            this.forgotPasswordLbl.BackColor = System.Drawing.Color.Transparent;
            this.forgotPasswordLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forgotPasswordLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forgotPasswordLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotPasswordLbl.ForeColor = System.Drawing.Color.Gray;
            this.forgotPasswordLbl.Location = new System.Drawing.Point(219, 246);
            this.forgotPasswordLbl.Name = "forgotPasswordLbl";
            this.forgotPasswordLbl.Size = new System.Drawing.Size(147, 19);
            this.forgotPasswordLbl.TabIndex = 20;
            this.forgotPasswordLbl.Text = "Nie pamiętam hasła";
            this.forgotPasswordLbl.Visible = false;
            // 
            // signUpLink
            // 
            this.signUpLink.AutoSize = true;
            this.signUpLink.BackColor = System.Drawing.Color.Transparent;
            this.signUpLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signUpLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signUpLink.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpLink.ForeColor = System.Drawing.Color.Gray;
            this.signUpLink.Location = new System.Drawing.Point(256, 320);
            this.signUpLink.Name = "signUpLink";
            this.signUpLink.Size = new System.Drawing.Size(111, 19);
            this.signUpLink.TabIndex = 19;
            this.signUpLink.Text = "Zarejestruj się";
            // 
            // questionLbl
            // 
            this.questionLbl.AutoSize = true;
            this.questionLbl.BackColor = System.Drawing.Color.Transparent;
            this.questionLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.questionLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLbl.Location = new System.Drawing.Point(88, 320);
            this.questionLbl.Name = "questionLbl";
            this.questionLbl.Size = new System.Drawing.Size(163, 19);
            this.questionLbl.TabIndex = 18;
            this.questionLbl.Text = "Nie posiadasz  konta?";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.BackColor = System.Drawing.Color.Transparent;
            this.passwordLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.Location = new System.Drawing.Point(68, 188);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(61, 19);
            this.passwordLbl.TabIndex = 10;
            this.passwordLbl.Text = "Hasło *";
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.BackColor = System.Drawing.Color.Transparent;
            this.emailLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLbl.Location = new System.Drawing.Point(72, 121);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(112, 19);
            this.emailLbl.TabIndex = 8;
            this.emailLbl.Text = "Adres e-mail *";
            // 
            // SignInView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1809, 996);
            this.Controls.Add(this.signInPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SignInView";
            this.Padding = new System.Windows.Forms.Padding(27, 37, 27, 25);
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
        private System.Windows.Forms.Label questionLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.Label forgotPasswordLbl;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private MetroFramework.Controls.MetroButton signInBtn;
        private MetroFramework.Controls.MetroTextBox passwordTxt;
        private MetroFramework.Controls.MetroTextBox emailTxt;
    }
}