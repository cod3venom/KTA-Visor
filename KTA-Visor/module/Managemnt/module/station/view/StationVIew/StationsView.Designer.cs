namespace KTA_Visor.module.Station.view
{
    partial class Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Management));
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.cardMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tunnelMenuStrip = new System.Windows.Forms.MenuStrip();
            this.tunnelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTunnelServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTunnelServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartTunnelServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topBar = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tunnelSettingsBtn = new KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton();
            this.cardBtn = new KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.clientsList = new KTA_Visor.module.Station.components.ClientsList.ClientsList();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.tunnelIndicator = new KTA_Visor_UI.component.basic.StatusIndicator.StatusIndicator();
            this.footer1 = new KTA_Visor_UI.component.custom.Footer.Footer();
            this.panel6 = new System.Windows.Forms.Panel();
            this.loggerPanel = new System.Windows.Forms.Panel();
            this.loggerView = new KTA_Visor_UI.component.custom.LoggerView.LoggerView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.stationsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.topBarPanel.SuspendLayout();
            this.cardMenuStrip.SuspendLayout();
            this.tunnelMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.loggerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBarPanel
            // 
            this.topBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.topBarPanel.Controls.Add(this.cardMenuStrip);
            this.topBarPanel.Controls.Add(this.tunnelMenuStrip);
            this.topBarPanel.Controls.Add(this.topBar);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(0, 0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(1440, 72);
            this.topBarPanel.TabIndex = 0;
            // 
            // cardMenuStrip
            // 
            this.cardMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.cardMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.cardMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cardMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cardMenuStrip.Location = new System.Drawing.Point(78, 44);
            this.cardMenuStrip.Name = "cardMenuStrip";
            this.cardMenuStrip.Size = new System.Drawing.Size(83, 27);
            this.cardMenuStrip.TabIndex = 2;
            this.cardMenuStrip.Text = "Card ID";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Inter Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(75, 23);
            this.toolStripMenuItem1.Text = "Card ID";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(159, 26);
            this.toolStripMenuItem2.Text = "Sign Card";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(159, 26);
            this.toolStripMenuItem3.Text = "Test Card";
            // 
            // tunnelMenuStrip
            // 
            this.tunnelMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tunnelMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.tunnelMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tunnelMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tunnelToolStripMenuItem});
            this.tunnelMenuStrip.Location = new System.Drawing.Point(0, 44);
            this.tunnelMenuStrip.Name = "tunnelMenuStrip";
            this.tunnelMenuStrip.Size = new System.Drawing.Size(78, 27);
            this.tunnelMenuStrip.TabIndex = 1;
            this.tunnelMenuStrip.Text = "menuStrip1";
            // 
            // tunnelToolStripMenuItem
            // 
            this.tunnelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startTunnelServerMenuItem,
            this.stopTunnelServerMenuItem,
            this.restartTunnelServerMenuItem});
            this.tunnelToolStripMenuItem.Font = new System.Drawing.Font("Inter Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tunnelToolStripMenuItem.Name = "tunnelToolStripMenuItem";
            this.tunnelToolStripMenuItem.Size = new System.Drawing.Size(70, 23);
            this.tunnelToolStripMenuItem.Text = "Tunnel";
            // 
            // startTunnelServerMenuItem
            // 
            this.startTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startTunnelServerMenuItem.Image")));
            this.startTunnelServerMenuItem.Name = "startTunnelServerMenuItem";
            this.startTunnelServerMenuItem.Size = new System.Drawing.Size(142, 26);
            this.startTunnelServerMenuItem.Text = "Start";
            // 
            // stopTunnelServerMenuItem
            // 
            this.stopTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopTunnelServerMenuItem.Image")));
            this.stopTunnelServerMenuItem.Name = "stopTunnelServerMenuItem";
            this.stopTunnelServerMenuItem.Size = new System.Drawing.Size(142, 26);
            this.stopTunnelServerMenuItem.Text = "Stop";
            // 
            // restartTunnelServerMenuItem
            // 
            this.restartTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restartTunnelServerMenuItem.Image")));
            this.restartTunnelServerMenuItem.Name = "restartTunnelServerMenuItem";
            this.restartTunnelServerMenuItem.Size = new System.Drawing.Size(142, 26);
            this.restartTunnelServerMenuItem.Text = "Restart";
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.topBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.topBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Parent = null;
            this.topBar.Size = new System.Drawing.Size(1440, 44);
            this.topBar.TabIndex = 0;
            this.topBar.Title = "Window";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.panel1.Controls.Add(this.tunnelSettingsBtn);
            this.panel1.Controls.Add(this.cardBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 762);
            this.panel1.TabIndex = 1;
            // 
            // tunnelSettingsBtn
            // 
            this.tunnelSettingsBtn.BackColor = System.Drawing.Color.White;
            this.tunnelSettingsBtn.Icon = ((System.Drawing.Image)(resources.GetObject("tunnelSettingsBtn.Icon")));
            this.tunnelSettingsBtn.Location = new System.Drawing.Point(23, 14);
            this.tunnelSettingsBtn.Name = "tunnelSettingsBtn";
            this.tunnelSettingsBtn.Size = new System.Drawing.Size(70, 70);
            this.tunnelSettingsBtn.TabIndex = 1;
            // 
            // cardBtn
            // 
            this.cardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.cardBtn.Icon = ((System.Drawing.Image)(resources.GetObject("cardBtn.Icon")));
            this.cardBtn.Location = new System.Drawing.Point(23, 104);
            this.cardBtn.Name = "cardBtn";
            this.cardBtn.Size = new System.Drawing.Size(70, 70);
            this.cardBtn.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(127, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1299, 14);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(113, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(14, 762);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.clientsList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1189, 86);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(237, 699);
            this.panel4.TabIndex = 4;
            // 
            // clientsList
            // 
            this.clientsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientsList.Location = new System.Drawing.Point(0, 0);
            this.clientsList.Name = "clientsList";
            this.clientsList.Size = new System.Drawing.Size(237, 699);
            this.clientsList.TabIndex = 0;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.tunnelIndicator);
            this.footerPanel.Controls.Add(this.footer1);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(127, 799);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1313, 35);
            this.footerPanel.TabIndex = 3;
            // 
            // tunnelIndicator
            // 
            this.tunnelIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.tunnelIndicator.Icon = ((System.Drawing.Image)(resources.GetObject("tunnelIndicator.Icon")));
            this.tunnelIndicator.Label = "Status";
            this.tunnelIndicator.Location = new System.Drawing.Point(3, 6);
            this.tunnelIndicator.Name = "tunnelIndicator";
            this.tunnelIndicator.Size = new System.Drawing.Size(227, 23);
            this.tunnelIndicator.TabIndex = 1;
            // 
            // footer1
            // 
            this.footer1.AutoSize = true;
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footer1.Location = new System.Drawing.Point(0, 0);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(1313, 35);
            this.footer1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1426, 72);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(14, 727);
            this.panel6.TabIndex = 5;
            // 
            // loggerPanel
            // 
            this.loggerPanel.Controls.Add(this.loggerView);
            this.loggerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loggerPanel.Location = new System.Drawing.Point(127, 541);
            this.loggerPanel.Name = "loggerPanel";
            this.loggerPanel.Size = new System.Drawing.Size(1048, 244);
            this.loggerPanel.TabIndex = 5;
            // 
            // loggerView
            // 
            this.loggerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggerView.Location = new System.Drawing.Point(0, 0);
            this.loggerView.Name = "loggerView";
            this.loggerView.ParentPanel = null;
            this.loggerView.Size = new System.Drawing.Size(1048, 244);
            this.loggerView.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(127, 785);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1299, 14);
            this.panel10.TabIndex = 6;
            // 
            // stationsFlowLayoutPanel
            // 
            this.stationsFlowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.stationsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stationsFlowLayoutPanel.Location = new System.Drawing.Point(127, 86);
            this.stationsFlowLayoutPanel.Name = "stationsFlowLayoutPanel";
            this.stationsFlowLayoutPanel.Size = new System.Drawing.Size(1048, 441);
            this.stationsFlowLayoutPanel.TabIndex = 7;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(1175, 86);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(14, 699);
            this.panel7.TabIndex = 8;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(127, 527);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1048, 14);
            this.panel8.TabIndex = 9;
            // 
            // StationsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1440, 834);
            this.Controls.Add(this.stationsFlowLayoutPanel);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.loggerPanel);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.topBarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.tunnelMenuStrip;
            this.Name = "StationsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StationsView";
            this.Load += new System.EventHandler(this.StationsView_Load);
            this.topBarPanel.ResumeLayout(false);
            this.topBarPanel.PerformLayout();
            this.cardMenuStrip.ResumeLayout(false);
            this.cardMenuStrip.PerformLayout();
            this.tunnelMenuStrip.ResumeLayout(false);
            this.tunnelMenuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.loggerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topBarPanel;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel footerPanel;
        private KTA_Visor_UI.component.custom.Footer.Footer footer1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel loggerPanel;
        private System.Windows.Forms.Panel panel10;
        private KTA_Visor_UI.component.custom.LoggerView.LoggerView loggerView;
        private System.Windows.Forms.FlowLayoutPanel stationsFlowLayoutPanel;
        private components.ClientsList.ClientsList clientsList;
        private KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton cardBtn;
        private KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton tunnelSettingsBtn;
        private System.Windows.Forms.MenuStrip tunnelMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tunnelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startTunnelServerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTunnelServerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartTunnelServerMenuItem;
        private System.Windows.Forms.MenuStrip cardMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Panel panel7;
        private KTA_Visor_UI.component.basic.StatusIndicator.StatusIndicator tunnelIndicator;
        private System.Windows.Forms.Panel panel8;
    }
}