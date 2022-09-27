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
            this.tunnelMenuStrip = new System.Windows.Forms.MenuStrip();
            this.tunnelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTunnelServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTunnelServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartTunnelServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.logoutbtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.loggerPanel = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.loggerView = new KTA_Visor_UI.component.custom.LoggerView.LoggerView();
            this.tunnelIndicator = new KTA_Visor_UI.component.basic.StatusIndicator.StatusIndicator();
            this.footer1 = new KTA_Visor_UI.component.custom.Footer.Footer();
            this.filesHistoryBtn = new KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton();
            this.stationBtn = new KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton();
            this.systemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dziennikZdarzeńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oNasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarPanel.SuspendLayout();
            this.tunnelMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoutbtn)).BeginInit();
            this.footerPanel.SuspendLayout();
            this.loggerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBarPanel
            // 
            this.topBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.topBarPanel.Controls.Add(this.tunnelMenuStrip);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(101, 11);
            this.topBarPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(1029, 28);
            this.topBarPanel.TabIndex = 0;
            // 
            // tunnelMenuStrip
            // 
            this.tunnelMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tunnelMenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tunnelMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tunnelMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tunnelToolStripMenuItem,
            this.systemToolStripMenuItem1,
            this.pomocToolStripMenuItem});
            this.tunnelMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.tunnelMenuStrip.Name = "tunnelMenuStrip";
            this.tunnelMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.tunnelMenuStrip.Size = new System.Drawing.Size(1029, 28);
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
            this.startTunnelServerMenuItem.Size = new System.Drawing.Size(184, 26);
            this.startTunnelServerMenuItem.Text = "Uruchom";
            // 
            // stopTunnelServerMenuItem
            // 
            this.stopTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopTunnelServerMenuItem.Image")));
            this.stopTunnelServerMenuItem.Name = "stopTunnelServerMenuItem";
            this.stopTunnelServerMenuItem.Size = new System.Drawing.Size(184, 26);
            this.stopTunnelServerMenuItem.Text = "Zatrzymaj";
            // 
            // restartTunnelServerMenuItem
            // 
            this.restartTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restartTunnelServerMenuItem.Image")));
            this.restartTunnelServerMenuItem.Name = "restartTunnelServerMenuItem";
            this.restartTunnelServerMenuItem.Size = new System.Drawing.Size(184, 26);
            this.restartTunnelServerMenuItem.Text = "Zresetuj";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.filesHistoryBtn);
            this.panel1.Controls.Add(this.stationBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 667);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.logoutbtn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 567);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(90, 100);
            this.panel4.TabIndex = 7;
            // 
            // logoutbtn
            // 
            this.logoutbtn.BackColor = System.Drawing.Color.Transparent;
            this.logoutbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutbtn.Image = ((System.Drawing.Image)(resources.GetObject("logoutbtn.Image")));
            this.logoutbtn.ImageActive = null;
            this.logoutbtn.Location = new System.Drawing.Point(21, 17);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(42, 47);
            this.logoutbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoutbtn.TabIndex = 6;
            this.logoutbtn.TabStop = false;
            this.logoutbtn.Zoom = 10;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(101, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1040, 11);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(90, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 667);
            this.panel3.TabIndex = 3;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.tunnelIndicator);
            this.footerPanel.Controls.Add(this.footer1);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(101, 639);
            this.footerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1051, 28);
            this.footerPanel.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1141, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(11, 639);
            this.panel6.TabIndex = 5;
            // 
            // loggerPanel
            // 
            this.loggerPanel.Controls.Add(this.loggerView);
            this.loggerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loggerPanel.Location = new System.Drawing.Point(101, 433);
            this.loggerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loggerPanel.Name = "loggerPanel";
            this.loggerPanel.Size = new System.Drawing.Size(1029, 195);
            this.loggerPanel.TabIndex = 5;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(101, 628);
            this.panel10.Margin = new System.Windows.Forms.Padding(2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1040, 11);
            this.panel10.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(1130, 11);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(11, 617);
            this.panel7.TabIndex = 8;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(101, 422);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1029, 11);
            this.panel8.TabIndex = 9;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(101, 11);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(2);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1029, 411);
            this.contentPanel.TabIndex = 10;
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
            // filesHistoryBtn
            // 
            this.filesHistoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.filesHistoryBtn.Icon = ((System.Drawing.Image)(resources.GetObject("filesHistoryBtn.Icon")));
            this.filesHistoryBtn.Label = "Meneżer plików";
            this.filesHistoryBtn.Location = new System.Drawing.Point(14, 97);
            this.filesHistoryBtn.Margin = new System.Windows.Forms.Padding(2);
            this.filesHistoryBtn.Name = "filesHistoryBtn";
            this.filesHistoryBtn.Size = new System.Drawing.Size(56, 56);
            this.filesHistoryBtn.TabIndex = 5;
            // 
            // stationBtn
            // 
            this.stationBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.stationBtn.Icon = ((System.Drawing.Image)(resources.GetObject("stationBtn.Icon")));
            this.stationBtn.Label = "Stacje";
            this.stationBtn.Location = new System.Drawing.Point(13, 28);
            this.stationBtn.Margin = new System.Windows.Forms.Padding(2);
            this.stationBtn.Name = "stationBtn";
            this.stationBtn.Size = new System.Drawing.Size(56, 56);
            this.stationBtn.TabIndex = 3;
            // 
            // systemToolStripMenuItem1
            // 
            this.systemToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logsMenuItem,
            this.dziennikZdarzeńToolStripMenuItem});
            this.systemToolStripMenuItem1.Name = "systemToolStripMenuItem1";
            this.systemToolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem1.Text = "System";
            // 
            // logsMenuItem
            // 
            this.logsMenuItem.Name = "logsMenuItem";
            this.logsMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logsMenuItem.Text = "Logi";
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionMenuItem,
            this.oNasToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // dziennikZdarzeńToolStripMenuItem
            // 
            this.dziennikZdarzeńToolStripMenuItem.Name = "dziennikZdarzeńToolStripMenuItem";
            this.dziennikZdarzeńToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dziennikZdarzeńToolStripMenuItem.Text = "Dziennik zdarzeń";
            // 
            // versionMenuItem
            // 
            this.versionMenuItem.Name = "versionMenuItem";
            this.versionMenuItem.Size = new System.Drawing.Size(180, 22);
            this.versionMenuItem.Text = "Wersja";
            // 
            // oNasToolStripMenuItem
            // 
            this.oNasToolStripMenuItem.Name = "oNasToolStripMenuItem";
            this.oNasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.oNasToolStripMenuItem.Text = "O nas";
            // 
            // Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1152, 667);
            this.Controls.Add(this.topBarPanel);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.tunnelMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StationsView";
            this.Load += new System.EventHandler(this.StationsView_Load);
            this.topBarPanel.ResumeLayout(false);
            this.topBarPanel.PerformLayout();
            this.tunnelMenuStrip.ResumeLayout(false);
            this.tunnelMenuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoutbtn)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.loggerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topBarPanel;
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
        private System.Windows.Forms.Panel panel7;
        private KTA_Visor_UI.component.basic.StatusIndicator.StatusIndicator tunnelIndicator;
        private System.Windows.Forms.Panel panel8;
        private KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton stationBtn;
        private System.Windows.Forms.Panel contentPanel;
        private KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton filesHistoryBtn;
        private Bunifu.Framework.UI.BunifuImageButton logoutbtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dziennikZdarzeńToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oNasToolStripMenuItem;
    }
}