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
            this.systemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dziennikZdarzeńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oNasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bezpieczeństwoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wylogujSięToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userProfileCard = new KTA_Visor_UI.component.custom.User.UserProfile.UserProfileCard();
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
            this.topBarPanel.Controls.Add(this.tunnelMenuStrip);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(315, 11);
            this.topBarPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(933, 28);
            this.topBarPanel.TabIndex = 0;
            // 
            // tunnelMenuStrip
            // 
            this.tunnelMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tunnelMenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tunnelMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tunnelMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tunnelToolStripMenuItem,
            this.kontoToolStripMenuItem,
            this.systemToolStripMenuItem1,
            this.pomocToolStripMenuItem});
            this.tunnelMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.tunnelMenuStrip.Name = "tunnelMenuStrip";
            this.tunnelMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.tunnelMenuStrip.Size = new System.Drawing.Size(933, 28);
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
            this.tunnelToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.tunnelToolStripMenuItem.Text = "Tunel";
            // 
            // startTunnelServerMenuItem
            // 
            this.startTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startTunnelServerMenuItem.Image")));
            this.startTunnelServerMenuItem.Name = "startTunnelServerMenuItem";
            this.startTunnelServerMenuItem.Size = new System.Drawing.Size(133, 26);
            this.startTunnelServerMenuItem.Text = "Uruchom";
            // 
            // stopTunnelServerMenuItem
            // 
            this.stopTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopTunnelServerMenuItem.Image")));
            this.stopTunnelServerMenuItem.Name = "stopTunnelServerMenuItem";
            this.stopTunnelServerMenuItem.Size = new System.Drawing.Size(133, 26);
            this.stopTunnelServerMenuItem.Text = "Zatrzymaj";
            // 
            // restartTunnelServerMenuItem
            // 
            this.restartTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restartTunnelServerMenuItem.Image")));
            this.restartTunnelServerMenuItem.Name = "restartTunnelServerMenuItem";
            this.restartTunnelServerMenuItem.Size = new System.Drawing.Size(133, 26);
            this.restartTunnelServerMenuItem.Text = "Zresetuj";
            // 
            // systemToolStripMenuItem1
            // 
            this.systemToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logsMenuItem,
            this.dziennikZdarzeńToolStripMenuItem});
            this.systemToolStripMenuItem1.Name = "systemToolStripMenuItem1";
            this.systemToolStripMenuItem1.Size = new System.Drawing.Size(57, 24);
            this.systemToolStripMenuItem1.Text = "System";
            // 
            // logsMenuItem
            // 
            this.logsMenuItem.Name = "logsMenuItem";
            this.logsMenuItem.Size = new System.Drawing.Size(162, 22);
            this.logsMenuItem.Text = "Logi";
            // 
            // dziennikZdarzeńToolStripMenuItem
            // 
            this.dziennikZdarzeńToolStripMenuItem.Name = "dziennikZdarzeńToolStripMenuItem";
            this.dziennikZdarzeńToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.dziennikZdarzeńToolStripMenuItem.Text = "Dziennik zdarzeń";
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionMenuItem,
            this.oNasToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // versionMenuItem
            // 
            this.versionMenuItem.Name = "versionMenuItem";
            this.versionMenuItem.Size = new System.Drawing.Size(109, 22);
            this.versionMenuItem.Text = "Wersja";
            // 
            // oNasToolStripMenuItem
            // 
            this.oNasToolStripMenuItem.Name = "oNasToolStripMenuItem";
            this.oNasToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.oNasToolStripMenuItem.Text = "O nas";
            // 
            // kontoToolStripMenuItem
            // 
            this.kontoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilToolStripMenuItem,
            this.bezpieczeństwoToolStripMenuItem,
            this.wylogujSięToolStripMenuItem});
            this.kontoToolStripMenuItem.Name = "kontoToolStripMenuItem";
            this.kontoToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.kontoToolStripMenuItem.Text = "Konto";
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.profilToolStripMenuItem.Text = "Profil";
            // 
            // bezpieczeństwoToolStripMenuItem
            // 
            this.bezpieczeństwoToolStripMenuItem.Name = "bezpieczeństwoToolStripMenuItem";
            this.bezpieczeństwoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bezpieczeństwoToolStripMenuItem.Text = "Bezpieczeństwo";
            // 
            // wylogujSięToolStripMenuItem
            // 
            this.wylogujSięToolStripMenuItem.Name = "wylogujSięToolStripMenuItem";
            this.wylogujSięToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wylogujSięToolStripMenuItem.Text = "Wyloguj się";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.panel1.Controls.Add(this.userProfileCard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 788);
            this.panel1.TabIndex = 1;
            // 
            // userProfileCard
            // 
            this.userProfileCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userProfileCard.FirstAndLastName = "Imię i Nazwisko";
            this.userProfileCard.Location = new System.Drawing.Point(0, 0);
            this.userProfileCard.Name = "userProfileCard";
            this.userProfileCard.Size = new System.Drawing.Size(304, 788);
            this.userProfileCard.TabIndex = 8;
            this.userProfileCard.Version = "1.2.3.v.5";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(315, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(944, 11);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(304, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 788);
            this.panel3.TabIndex = 3;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.tunnelIndicator);
            this.footerPanel.Controls.Add(this.footer1);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(315, 760);
            this.footerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(955, 28);
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
            this.footer1.Size = new System.Drawing.Size(955, 28);
            this.footer1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1259, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(11, 760);
            this.panel6.TabIndex = 5;
            // 
            // loggerPanel
            // 
            this.loggerPanel.Controls.Add(this.loggerView);
            this.loggerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loggerPanel.Location = new System.Drawing.Point(315, 554);
            this.loggerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loggerPanel.Name = "loggerPanel";
            this.loggerPanel.Size = new System.Drawing.Size(933, 195);
            this.loggerPanel.TabIndex = 5;
            // 
            // loggerView
            // 
            this.loggerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggerView.Location = new System.Drawing.Point(0, 0);
            this.loggerView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loggerView.Name = "loggerView";
            this.loggerView.ParentPanel = null;
            this.loggerView.Size = new System.Drawing.Size(933, 195);
            this.loggerView.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(315, 749);
            this.panel10.Margin = new System.Windows.Forms.Padding(2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(944, 11);
            this.panel10.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(1248, 11);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(11, 738);
            this.panel7.TabIndex = 8;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(315, 543);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(933, 11);
            this.panel8.TabIndex = 9;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(315, 11);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(2);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(933, 532);
            this.contentPanel.TabIndex = 10;
            // 
            // Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1270, 788);
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
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dziennikZdarzeńToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oNasToolStripMenuItem;
        private KTA_Visor_UI.component.custom.User.UserProfile.UserProfileCard userProfileCard;
        private System.Windows.Forms.ToolStripMenuItem kontoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bezpieczeństwoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wylogujSięToolStripMenuItem;
    }
}