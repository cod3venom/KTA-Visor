using KTA_Visor_UI.component.basic.progressbar;

namespace KTA_Visor.module.Managemnt.module.auth.view.ForgotPasswordView
{
    partial class ForgotPasswordView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPasswordView));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.signInPanel = new System.Windows.Forms.Panel();
            this.sendRecoveryCodeBtn = new MetroFramework.Controls.MetroButton();
            this.emailTxt = new MetroFramework.Controls.MetroTextBox();
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.emailLbl = new System.Windows.Forms.Label();
            this.loginBtn = new MetroFramework.Controls.MetroButton();
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
            this.signInPanel.Controls.Add(this.loginBtn);
            this.signInPanel.Controls.Add(this.sendRecoveryCodeBtn);
            this.signInPanel.Controls.Add(this.emailTxt);
            this.signInPanel.Controls.Add(this.topBar1);
            this.signInPanel.Controls.Add(this.emailLbl);
            this.signInPanel.Location = new System.Drawing.Point(676, 194);
            this.signInPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.signInPanel.MaximumSize = new System.Drawing.Size(441, 755);
            this.signInPanel.Name = "signInPanel";
            this.signInPanel.Size = new System.Drawing.Size(441, 443);
            this.signInPanel.TabIndex = 13;
            // 
            // sendRecoveryCodeBtn
            // 
            this.sendRecoveryCodeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendRecoveryCodeBtn.Location = new System.Drawing.Point(70, 271);
            this.sendRecoveryCodeBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendRecoveryCodeBtn.Name = "sendRecoveryCodeBtn";
            this.sendRecoveryCodeBtn.Size = new System.Drawing.Size(299, 28);
            this.sendRecoveryCodeBtn.TabIndex = 24;
            this.sendRecoveryCodeBtn.Text = "Przypomnij";
            this.sendRecoveryCodeBtn.Theme = MetroFramework.MetroThemeStyle.Light;
            this.sendRecoveryCodeBtn.UseSelectable = true;
            // 
            // emailTxt
            // 
            // 
            // 
            // 
            this.emailTxt.CustomButton.Image = null;
            this.emailTxt.CustomButton.Location = new System.Drawing.Point(369, 2);
            this.emailTxt.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.emailTxt.CustomButton.Name = "";
            this.emailTxt.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.emailTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.emailTxt.CustomButton.TabIndex = 1;
            this.emailTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.emailTxt.CustomButton.UseSelectable = true;
            this.emailTxt.CustomButton.Visible = false;
            this.emailTxt.Lines = new string[] {
        "levan@skillsforge.pl"};
            this.emailTxt.Location = new System.Drawing.Point(70, 211);
            this.emailTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.BackColor = System.Drawing.Color.Transparent;
            this.emailLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLbl.Location = new System.Drawing.Point(70, 189);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(112, 19);
            this.emailLbl.TabIndex = 8;
            this.emailLbl.Text = "Adres e-mail *";
            // 
            // loginBtn
            // 
            this.loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBtn.Location = new System.Drawing.Point(70, 307);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(299, 28);
            this.loginBtn.TabIndex = 25;
            this.loginBtn.Text = "Zaloguj się";
            this.loginBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loginBtn.UseSelectable = true;
            // 
            // ForgotPasswordView
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
            this.Name = "ForgotPasswordView";
            this.Padding = new System.Windows.Forms.Padding(27, 37, 27, 25);
            this.Text = "SignInView";
            this.signInPanel.ResumeLayout(false);
            this.signInPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel signInPanel;
        private System.Windows.Forms.Label emailLbl;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private MetroFramework.Controls.MetroButton sendRecoveryCodeBtn;
        private MetroFramework.Controls.MetroTextBox emailTxt;
        private MetroFramework.Controls.MetroButton loginBtn;
    }
}