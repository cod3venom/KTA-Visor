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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RFIDAuthenticationView));
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.label1 = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.authorizationLbl = new System.Windows.Forms.Label();
            this.bringTheCardLbl = new System.Windows.Forms.Label();
            this.footerLogo = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.authPanel = new System.Windows.Forms.Panel();
            this.topBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.footerLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // topBarPanel
            // 
            this.topBarPanel.Controls.Add(this.topBar1);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(0, 0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(1294, 49);
            this.topBarPanel.TabIndex = 0;
            // 
            // topBar1
            // 
            this.topBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(1294, 49);
            this.topBar1.TabIndex = 0;
            this.topBar1.Title = "Window";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Inter", 28F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(484, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "KTA-VISOR";
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.BackColor = System.Drawing.Color.White;
            this.versionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(170)))));
            this.versionLbl.Location = new System.Drawing.Point(586, 340);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(72, 16);
            this.versionLbl.TabIndex = 2;
            this.versionLbl.Text = "ver-test.0-1";
            // 
            // authorizationLbl
            // 
            this.authorizationLbl.AutoSize = true;
            this.authorizationLbl.BackColor = System.Drawing.Color.White;
            this.authorizationLbl.Font = new System.Drawing.Font("Inter", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorizationLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(170)))));
            this.authorizationLbl.Location = new System.Drawing.Point(566, 461);
            this.authorizationLbl.Name = "authorizationLbl";
            this.authorizationLbl.Size = new System.Drawing.Size(116, 21);
            this.authorizationLbl.TabIndex = 3;
            this.authorizationLbl.Text = "Autoryzacja";
            // 
            // bringTheCardLbl
            // 
            this.bringTheCardLbl.AutoSize = true;
            this.bringTheCardLbl.BackColor = System.Drawing.Color.White;
            this.bringTheCardLbl.Font = new System.Drawing.Font("Inter SemiBold", 13.2F, System.Drawing.FontStyle.Bold);
            this.bringTheCardLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.bringTheCardLbl.Location = new System.Drawing.Point(489, 495);
            this.bringTheCardLbl.Name = "bringTheCardLbl";
            this.bringTheCardLbl.Size = new System.Drawing.Size(281, 26);
            this.bringTheCardLbl.TabIndex = 4;
            this.bringTheCardLbl.Text = "Przyłóż kartę do czytnika";
            // 
            // footerLogo
            // 
            this.footerLogo.BackColor = System.Drawing.Color.Transparent;
            this.footerLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.footerLogo.Image = ((System.Drawing.Image)(resources.GetObject("footerLogo.Image")));
            this.footerLogo.Location = new System.Drawing.Point(578, 664);
            this.footerLogo.Name = "footerLogo";
            this.footerLogo.Size = new System.Drawing.Size(81, 50);
            this.footerLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.footerLogo.TabIndex = 5;
            this.footerLogo.TabStop = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this.authPanel;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1292, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 677);
            this.panel3.TabIndex = 8;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.White;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(589, 222);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(71, 71);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 9;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 2;
            // 
            // authPanel
            // 
            this.authPanel.BackColor = System.Drawing.Color.White;
            this.authPanel.Location = new System.Drawing.Point(418, 176);
            this.authPanel.Name = "authPanel";
            this.authPanel.Size = new System.Drawing.Size(417, 456);
            this.authPanel.TabIndex = 10;
            // 
            // RFIDAuthenticationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1294, 726);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.footerLogo);
            this.Controls.Add(this.bringTheCardLbl);
            this.Controls.Add(this.authorizationLbl);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.authPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RFIDAuthenticationView";
            this.Text = "RFIDAuthenticationView";
            this.Load += new System.EventHandler(this.RFIDAuthenticationView_Load);
            this.topBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.footerLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topBarPanel;
        private System.Windows.Forms.PictureBox footerLogo;
        private System.Windows.Forms.Label bringTheCardLbl;
        private System.Windows.Forms.Label authorizationLbl;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label label1;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.Panel authPanel;
    }
}