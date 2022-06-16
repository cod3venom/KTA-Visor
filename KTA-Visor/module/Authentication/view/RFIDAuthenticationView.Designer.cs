namespace KTA_Visor.module.Authentication.view
{
    partial class RFIDAuthenticationView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RFIDAuthenticationView));
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.topBar = new KTA_Visor.component.basic.topbar.TopBar();
            this.label1 = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.authorizationLbl = new System.Windows.Forms.Label();
            this.bringTheCardLbl = new System.Windows.Forms.Label();
            this.footerLogo = new System.Windows.Forms.PictureBox();
            this.topBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.footerLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // topBarPanel
            // 
            this.topBarPanel.Controls.Add(this.topBar);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(0, 0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(1186, 49);
            this.topBarPanel.TabIndex = 0;
            // 
            // topBar
            // 
            this.topBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Parent = this;
            this.topBar.Size = new System.Drawing.Size(1186, 49);
            this.topBar.TabIndex = 0;
            this.topBar.Title = "Authentication";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 28F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(456, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "KTA-VISOR";
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(170)))));
            this.versionLbl.Location = new System.Drawing.Point(565, 290);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(72, 16);
            this.versionLbl.TabIndex = 2;
            this.versionLbl.Text = "ver-test.0-1";
            // 
            // authorizationLbl
            // 
            this.authorizationLbl.AutoSize = true;
            this.authorizationLbl.Font = new System.Drawing.Font("Inter", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorizationLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(170)))));
            this.authorizationLbl.Location = new System.Drawing.Point(543, 412);
            this.authorizationLbl.Name = "authorizationLbl";
            this.authorizationLbl.Size = new System.Drawing.Size(116, 21);
            this.authorizationLbl.TabIndex = 3;
            this.authorizationLbl.Text = "Autoryzacja";
            // 
            // bringTheCardLbl
            // 
            this.bringTheCardLbl.AutoSize = true;
            this.bringTheCardLbl.Font = new System.Drawing.Font("Inter SemiBold", 13.2F, System.Drawing.FontStyle.Bold);
            this.bringTheCardLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.bringTheCardLbl.Location = new System.Drawing.Point(462, 444);
            this.bringTheCardLbl.Name = "bringTheCardLbl";
            this.bringTheCardLbl.Size = new System.Drawing.Size(281, 26);
            this.bringTheCardLbl.TabIndex = 4;
            this.bringTheCardLbl.Text = "Przyłóż kartę do czytnika";
            // 
            // footerLogo
            // 
            this.footerLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.footerLogo.Image = ((System.Drawing.Image)(resources.GetObject("footerLogo.Image")));
            this.footerLogo.Location = new System.Drawing.Point(553, 664);
            this.footerLogo.Name = "footerLogo";
            this.footerLogo.Size = new System.Drawing.Size(81, 50);
            this.footerLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.footerLogo.TabIndex = 5;
            this.footerLogo.TabStop = false;
            // 
            // RFIDAuthenticationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 726);
            this.Controls.Add(this.footerLogo);
            this.Controls.Add(this.bringTheCardLbl);
            this.Controls.Add(this.authorizationLbl);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.topBarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RFIDAuthenticationView";
            this.Text = "RFIDAuthenticationView";
            this.Load += new System.EventHandler(this.RFIDAuthenticationView_Load);
            this.topBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.footerLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topBarPanel;
        private component.basic.topbar.TopBar topBar;
        private System.Windows.Forms.PictureBox footerLogo;
        private System.Windows.Forms.Label bringTheCardLbl;
        private System.Windows.Forms.Label authorizationLbl;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label label1;
    }
}