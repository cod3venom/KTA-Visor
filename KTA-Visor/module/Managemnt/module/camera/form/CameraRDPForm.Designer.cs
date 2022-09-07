namespace KTA_Visor.module.Managemnt.module.camera.form
{
    partial class CameraRDPForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraRDPForm));
            this.topBar = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.footerPanel = new System.Windows.Forms.Panel();
            this.primaryButton1 = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.rdpClient = new AxMSTSCLib.AxMsRdpClient6();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdpClient)).BeginInit();
            this.SuspendLayout();
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Parent = null;
            this.topBar.Size = new System.Drawing.Size(1131, 44);
            this.topBar.TabIndex = 0;
            this.topBar.Title = "Window";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.primaryButton1);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 551);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1131, 38);
            this.footerPanel.TabIndex = 3;
            // 
            // primaryButton1
            // 
            this.primaryButton1.Active = false;
            this.primaryButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.primaryButton1.Location = new System.Drawing.Point(986, 0);
            this.primaryButton1.Name = "primaryButton1";
            this.primaryButton1.Size = new System.Drawing.Size(145, 38);
            this.primaryButton1.TabIndex = 0;
            this.primaryButton1.Title = "Zamknij";
            // 
            // rdpClient
            // 
            this.rdpClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdpClient.Enabled = true;
            this.rdpClient.Location = new System.Drawing.Point(0, 44);
            this.rdpClient.Name = "rdpClient";
            this.rdpClient.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdpClient.OcxState")));
            this.rdpClient.Size = new System.Drawing.Size(1131, 507);
            this.rdpClient.TabIndex = 4;
            // 
            // CameraRDPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 589);
            this.Controls.Add(this.rdpClient);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.topBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CameraRDPForm";
            this.Text = "CameraRDPForm";
            this.Load += new System.EventHandler(this.CameraRDPForm_Load);
            this.footerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdpClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KTA_Visor_UI.component.basic.topbar.TopBar topBar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel footerPanel;
        private KTA_Visor_UI.component.basic.button.PrimaryButton primaryButton1;
        private AxMSTSCLib.AxMsRdpClient6 rdpClient;
    }
}