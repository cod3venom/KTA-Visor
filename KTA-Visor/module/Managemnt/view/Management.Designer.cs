namespace KTA_Visor.module.Management.view
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
            this.tunnelMenuStrip = new System.Windows.Forms.MenuStrip();
            this.tunnelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTunnelServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTunnelServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartTunnelServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topBar = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.filesHistoryBtn = new KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton();
            this.stationBtn = new KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.tunnelIndicator = new KTA_Visor_UI.component.basic.StatusIndicator.StatusIndicator();
            this.footer1 = new KTA_Visor_UI.component.custom.Footer.Footer();
            this.panel6 = new System.Windows.Forms.Panel();
            this.loggerPanel = new System.Windows.Forms.Panel();
            this.loggerView = new KTA_Visor_UI.component.custom.LoggerView.LoggerView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.topBarPanel.SuspendLayout();
            this.tunnelMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.topBarPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(1152, 58);
            this.topBarPanel.TabIndex = 0;
            // 
            // cardMenuStrip
            // 
            this.cardMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.cardMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.cardMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cardMenuStrip.Location = new System.Drawing.Point(62, 35);
            this.cardMenuStrip.Name = "cardMenuStrip";
            this.cardMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.cardMenuStrip.Size = new System.Drawing.Size(202, 24);
            this.cardMenuStrip.TabIndex = 2;
            this.cardMenuStrip.Text = "Card ID";
            // 
            // tunnelMenuStrip
            // 
            this.tunnelMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tunnelMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.tunnelMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tunnelMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tunnelToolStripMenuItem});
            this.tunnelMenuStrip.Location = new System.Drawing.Point(0, 35);
            this.tunnelMenuStrip.Name = "tunnelMenuStrip";
            this.tunnelMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.tunnelMenuStrip.Size = new System.Drawing.Size(57, 24);
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
            this.tunnelToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.tunnelToolStripMenuItem.Text = "Tunel";
            // 
            // startTunnelServerMenuItem
            // 
            this.startTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startTunnelServerMenuItem.Image")));
            this.startTunnelServerMenuItem.Name = "startTunnelServerMenuItem";
            this.startTunnelServerMenuItem.Size = new System.Drawing.Size(129, 22);
            this.startTunnelServerMenuItem.Text = "Uruchom";
            // 
            // stopTunnelServerMenuItem
            // 
            this.stopTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopTunnelServerMenuItem.Image")));
            this.stopTunnelServerMenuItem.Name = "stopTunnelServerMenuItem";
            this.stopTunnelServerMenuItem.Size = new System.Drawing.Size(129, 22);
            this.stopTunnelServerMenuItem.Text = "Zatrzymaj";
            // 
            // restartTunnelServerMenuItem
            // 
            this.restartTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restartTunnelServerMenuItem.Image")));
            this.restartTunnelServerMenuItem.Name = "restartTunnelServerMenuItem";
            this.restartTunnelServerMenuItem.Size = new System.Drawing.Size(129, 22);
            this.restartTunnelServerMenuItem.Text = "Zresetuj";
            // 
            // topBar
            // 
            this.topBar.AllowClose = true;
            this.topBar.AllowMinimize = true;
            this.topBar.AllowResize = true;
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.topBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.topBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar.Description = "Window";
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Margin = new System.Windows.Forms.Padding(2);
            this.topBar.Name = "topBar";
            this.topBar.Parent = null;
            this.topBar.Size = new System.Drawing.Size(1152, 35);
            this.topBar.TabIndex = 0;
            this.topBar.Title = "Window";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.panel1.Controls.Add(this.filesHistoryBtn);
            this.panel1.Controls.Add(this.stationBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 609);
            this.panel1.TabIndex = 1;
            // 
            // filesHistoryBtn
            // 
            this.filesHistoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.filesHistoryBtn.Icon = ((System.Drawing.Image)(resources.GetObject("filesHistoryBtn.Icon")));
            this.filesHistoryBtn.Location = new System.Drawing.Point(14, 97);
            this.filesHistoryBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.filesHistoryBtn.Name = "filesHistoryBtn";
            this.filesHistoryBtn.Size = new System.Drawing.Size(56, 56);
            this.filesHistoryBtn.TabIndex = 5;
            // 
            // stationBtn
            // 
            this.stationBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.stationBtn.Icon = ((System.Drawing.Image)(resources.GetObject("stationBtn.Icon")));
            this.stationBtn.Location = new System.Drawing.Point(13, 28);
            this.stationBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stationBtn.Name = "stationBtn";
            this.stationBtn.Size = new System.Drawing.Size(56, 56);
            this.stationBtn.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(101, 58);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1040, 11);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(90, 58);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 609);
            this.panel3.TabIndex = 3;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.tunnelIndicator);
            this.footerPanel.Controls.Add(this.footer1);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(101, 639);
            this.footerPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1051, 28);
            this.footerPanel.TabIndex = 3;
            // 
            // tunnelIndicator
            // 
            this.tunnelIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.tunnelIndicator.Icon = ((System.Drawing.Image)(resources.GetObject("tunnelIndicator.Icon")));
            this.tunnelIndicator.Label = "Status";
            this.tunnelIndicator.Location = new System.Drawing.Point(2, 5);
            this.tunnelIndicator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tunnelIndicator.Name = "tunnelIndicator";
            this.tunnelIndicator.Size = new System.Drawing.Size(182, 18);
            this.tunnelIndicator.TabIndex = 1;
            // 
            // footer1
            // 
            this.footer1.AutoSize = true;
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footer1.Location = new System.Drawing.Point(0, 0);
            this.footer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(1051, 28);
            this.footer1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1141, 58);
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(11, 581);
            this.panel6.TabIndex = 5;
            // 
            // loggerPanel
            // 
            this.loggerPanel.Controls.Add(this.loggerView);
            this.loggerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loggerPanel.Location = new System.Drawing.Point(101, 433);
            this.loggerPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loggerPanel.Name = "loggerPanel";
            this.loggerPanel.Size = new System.Drawing.Size(1029, 195);
            this.loggerPanel.TabIndex = 5;
            // 
            // loggerView
            // 
            this.loggerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggerView.Location = new System.Drawing.Point(0, 0);
            this.loggerView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loggerView.Name = "loggerView";
            this.loggerView.ParentPanel = null;
            this.loggerView.Size = new System.Drawing.Size(1029, 195);
            this.loggerView.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(101, 628);
            this.panel10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1040, 11);
            this.panel10.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(1130, 69);
            this.panel7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(11, 559);
            this.panel7.TabIndex = 8;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(101, 422);
            this.panel8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1029, 11);
            this.panel8.TabIndex = 9;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(101, 69);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1029, 353);
            this.contentPanel.TabIndex = 10;
            // 
            // Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1152, 667);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.loggerPanel);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.topBarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.tunnelMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StationsView";
            this.Load += new System.EventHandler(this.StationsView_Load);
            this.topBarPanel.ResumeLayout(false);
            this.topBarPanel.PerformLayout();
            this.tunnelMenuStrip.ResumeLayout(false);
            this.tunnelMenuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel footerPanel;
        private KTA_Visor_UI.component.custom.Footer.Footer footer1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel loggerPanel;
        private System.Windows.Forms.Panel panel10;
        private KTA_Visor_UI.component.custom.LoggerView.LoggerView loggerView;
        private System.Windows.Forms.MenuStrip tunnelMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tunnelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startTunnelServerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTunnelServerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartTunnelServerMenuItem;
        private System.Windows.Forms.MenuStrip cardMenuStrip;
        private System.Windows.Forms.Panel panel7;
        private KTA_Visor_UI.component.basic.StatusIndicator.StatusIndicator tunnelIndicator;
        private System.Windows.Forms.Panel panel8;
        private KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton stationBtn;
        private System.Windows.Forms.Panel contentPanel;
        private KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton filesHistoryBtn;
    }
}