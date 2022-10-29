namespace KTA_Visor.module.Managemnt.module.cardReader.window
{
    partial class CardModeAuthChecker
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
            this.passwordTxt = new MetroFramework.Controls.MetroTextBox();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.authorizeBtn = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordTxt
            // 
            // 
            // 
            // 
            this.passwordTxt.CustomButton.Image = null;
            this.passwordTxt.CustomButton.Location = new System.Drawing.Point(281, 1);
            this.passwordTxt.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordTxt.CustomButton.Name = "";
            this.passwordTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.passwordTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordTxt.CustomButton.TabIndex = 1;
            this.passwordTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordTxt.CustomButton.UseSelectable = true;
            this.passwordTxt.CustomButton.Visible = false;
            this.passwordTxt.Lines = new string[] {
        "admin123"};
            this.passwordTxt.Location = new System.Drawing.Point(157, 123);
            this.passwordTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordTxt.MaxLength = 32767;
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '*';
            this.passwordTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordTxt.SelectedText = "";
            this.passwordTxt.SelectionLength = 0;
            this.passwordTxt.SelectionStart = 0;
            this.passwordTxt.ShortcutsEnabled = true;
            this.passwordTxt.Size = new System.Drawing.Size(303, 23);
            this.passwordTxt.TabIndex = 23;
            this.passwordTxt.Text = "admin123";
            this.passwordTxt.UseSelectable = true;
            this.passwordTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(90, 127);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(46, 16);
            this.passwordLbl.TabIndex = 26;
            this.passwordLbl.Text = "Hasło";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.authorizeBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(20, 238);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 37);
            this.panel1.TabIndex = 25;
            // 
            // authorizeBtn
            // 
            this.authorizeBtn.Location = new System.Drawing.Point(392, 7);
            this.authorizeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.authorizeBtn.Name = "authorizeBtn";
            this.authorizeBtn.Size = new System.Drawing.Size(100, 23);
            this.authorizeBtn.TabIndex = 2;
            this.authorizeBtn.Text = "Autoryzacja";
            this.authorizeBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.authorizeBtn.UseSelectable = true;
            // 
            // CardModeAuthChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 295);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.panel1);
            this.DisplayHeader = false;
            this.Name = "CardModeAuthChecker";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Load += new System.EventHandler(this.CardModeAuthCheckerWindow_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox passwordTxt;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton authorizeBtn;
    }
}