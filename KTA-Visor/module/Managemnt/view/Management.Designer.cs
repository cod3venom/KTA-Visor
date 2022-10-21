using System.Windows.Forms;

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
            this.kontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sideBar = new KTA_Visor_UI.component.custom.User.UserProfile.UserProfileCard();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.footer1 = new KTA_Visor_UI.component.custom.Footer.Footer();
            this.clientsManagerPanel = new System.Windows.Forms.Panel();
            this.loggerPanel = new System.Windows.Forms.Panel();
            this.loggerView = new KTA_Visor_UI.component.custom.LoggerView.LoggerView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.cardModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTunnelServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTunnelServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartTunnelServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.securityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaFabryczneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tunnelIndicator = new KTA_Visor_UI.component.basic.StatusIndicator.StatusIndicator();
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
            this.topBarPanel.Location = new System.Drawing.Point(463, 52);
            this.topBarPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(936, 35);
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
            this.tunnelMenuStrip.Size = new System.Drawing.Size(936, 35);
            this.tunnelMenuStrip.TabIndex = 1;
            this.tunnelMenuStrip.Text = "menuStrip1";
            // 
            // tunnelToolStripMenuItem
            // 
            this.tunnelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startTunnelServerMenuItem,
            this.stopTunnelServerMenuItem,
            this.restartTunnelServerMenuItem});
            this.tunnelToolStripMenuItem.Font = new System.Drawing.Font("Inter", 9F);
            this.tunnelToolStripMenuItem.Name = "tunnelToolStripMenuItem";
            this.tunnelToolStripMenuItem.Size = new System.Drawing.Size(63, 31);
            this.tunnelToolStripMenuItem.Text = "Tunel";
            // 
            // kontoToolStripMenuItem
            // 
            this.kontoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileMenuItem,
            this.securityMenuItem,
            this.logoutMenuItem});
            this.kontoToolStripMenuItem.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kontoToolStripMenuItem.Name = "kontoToolStripMenuItem";
            this.kontoToolStripMenuItem.Size = new System.Drawing.Size(64, 31);
            this.kontoToolStripMenuItem.Text = "Konto";
            // 
            // logoutMenuItem
            // 
            this.logoutMenuItem.BackColor = System.Drawing.Color.Red;
            this.logoutMenuItem.ForeColor = System.Drawing.Color.White;
            this.logoutMenuItem.Name = "logoutMenuItem";
            this.logoutMenuItem.Size = new System.Drawing.Size(224, 26);
            this.logoutMenuItem.Text = "Wyloguj się";
            // 
            // systemToolStripMenuItem1
            // 
            this.systemToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cardModeMenuItem,
            this.logsMenuItem,
            this.ustawieniaFabryczneToolStripMenuItem});
            this.systemToolStripMenuItem1.Font = new System.Drawing.Font("Inter", 9F);
            this.systemToolStripMenuItem1.Name = "systemToolStripMenuItem1";
            this.systemToolStripMenuItem1.Size = new System.Drawing.Size(76, 31);
            this.systemToolStripMenuItem1.Text = "System";
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionMenuItem,
            this.aboutUsMenuItem});
            this.pomocToolStripMenuItem.Font = new System.Drawing.Font("Inter", 9F);
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(72, 31);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // versionMenuItem
            // 
            this.versionMenuItem.Name = "versionMenuItem";
            this.versionMenuItem.Size = new System.Drawing.Size(224, 26);
            this.versionMenuItem.Text = "Wersja";
            // 
            // aboutUsMenuItem
            // 
            this.aboutUsMenuItem.Name = "aboutUsMenuItem";
            this.aboutUsMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aboutUsMenuItem.Text = "O nas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.panel1.Controls.Add(this.sideBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(25, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 908);
            this.panel1.TabIndex = 1;
            // 
            // sideBar
            // 
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideBar.FirstAndLastName = "Imię i Nazwisko";
            this.sideBar.Location = new System.Drawing.Point(0, 0);
            this.sideBar.Margin = new System.Windows.Forms.Padding(5);
            this.sideBar.Name = "sideBar";
            this.sideBar.Size = new System.Drawing.Size(424, 908);
            this.sideBar.TabIndex = 8;
            this.sideBar.Version = "1.2.3.v.5";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(25, 38);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1632, 14);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(449, 52);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(14, 908);
            this.panel3.TabIndex = 3;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.tunnelIndicator);
            this.footerPanel.Controls.Add(this.footer1);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(463, 925);
            this.footerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(948, 35);
            this.footerPanel.TabIndex = 3;
            // 
            // footer1
            // 
            this.footer1.AutoSize = true;
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footer1.Location = new System.Drawing.Point(0, 0);
            this.footer1.Margin = new System.Windows.Forms.Padding(2);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(948, 35);
            this.footer1.TabIndex = 0;
            // 
            // clientsManagerPanel
            // 
            this.clientsManagerPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.clientsManagerPanel.Location = new System.Drawing.Point(1411, 52);
            this.clientsManagerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.clientsManagerPanel.Name = "clientsManagerPanel";
            this.clientsManagerPanel.Size = new System.Drawing.Size(246, 908);
            this.clientsManagerPanel.TabIndex = 5;
            // 
            // loggerPanel
            // 
            this.loggerPanel.Controls.Add(this.loggerView);
            this.loggerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loggerPanel.Location = new System.Drawing.Point(463, 667);
            this.loggerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loggerPanel.Name = "loggerPanel";
            this.loggerPanel.Size = new System.Drawing.Size(936, 244);
            this.loggerPanel.TabIndex = 5;
            // 
            // loggerView
            // 
            this.loggerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggerView.Location = new System.Drawing.Point(0, 0);
            this.loggerView.Margin = new System.Windows.Forms.Padding(2);
            this.loggerView.Name = "loggerView";
            this.loggerView.ParentPanel = null;
            this.loggerView.Size = new System.Drawing.Size(936, 244);
            this.loggerView.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(463, 911);
            this.panel10.Margin = new System.Windows.Forms.Padding(2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(948, 14);
            this.panel10.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(1399, 52);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(12, 859);
            this.panel7.TabIndex = 8;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(463, 653);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(936, 14);
            this.panel8.TabIndex = 9;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(463, 52);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(2);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(936, 601);
            this.contentPanel.TabIndex = 10;
            // 
            // cardModeMenuItem
            // 
            this.cardModeMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cardModeMenuItem.Image")));
            this.cardModeMenuItem.Name = "cardModeMenuItem";
            this.cardModeMenuItem.Size = new System.Drawing.Size(248, 26);
            this.cardModeMenuItem.Text = "Tryb Karty";
            // 
            // startTunnelServerMenuItem
            // 
            this.startTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startTunnelServerMenuItem.Image")));
            this.startTunnelServerMenuItem.Name = "startTunnelServerMenuItem";
            this.startTunnelServerMenuItem.Size = new System.Drawing.Size(161, 26);
            this.startTunnelServerMenuItem.Text = "Uruchom";
            // 
            // stopTunnelServerMenuItem
            // 
            this.stopTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopTunnelServerMenuItem.Image")));
            this.stopTunnelServerMenuItem.Name = "stopTunnelServerMenuItem";
            this.stopTunnelServerMenuItem.Size = new System.Drawing.Size(161, 26);
            this.stopTunnelServerMenuItem.Text = "Zatrzymaj";
            // 
            // restartTunnelServerMenuItem
            // 
            this.restartTunnelServerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restartTunnelServerMenuItem.Image")));
            this.restartTunnelServerMenuItem.Name = "restartTunnelServerMenuItem";
            this.restartTunnelServerMenuItem.Size = new System.Drawing.Size(161, 26);
            this.restartTunnelServerMenuItem.Text = "Zresetuj";
            // 
            // profileMenuItem
            // 
            this.profileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("profileMenuItem.Image")));
            this.profileMenuItem.Name = "profileMenuItem";
            this.profileMenuItem.Size = new System.Drawing.Size(224, 26);
            this.profileMenuItem.Text = "Profil";
            // 
            // securityMenuItem
            // 
            this.securityMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("securityMenuItem.Image")));
            this.securityMenuItem.Name = "securityMenuItem";
            this.securityMenuItem.Size = new System.Drawing.Size(224, 26);
            this.securityMenuItem.Text = "Bezpieczeństwo";
            // 
            // logsMenuItem
            // 
            this.logsMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logsMenuItem.Image")));
            this.logsMenuItem.Name = "logsMenuItem";
            this.logsMenuItem.Size = new System.Drawing.Size(248, 26);
            this.logsMenuItem.Text = "Logi";
            // 
            // ustawieniaFabryczneToolStripMenuItem
            // 
            this.ustawieniaFabryczneToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ustawieniaFabryczneToolStripMenuItem.Image")));
            this.ustawieniaFabryczneToolStripMenuItem.Name = "ustawieniaFabryczneToolStripMenuItem";
            this.ustawieniaFabryczneToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.ustawieniaFabryczneToolStripMenuItem.Text = "Ustawienia Fabryczne";
            // 
            // tunnelIndicator
            // 
            this.tunnelIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.tunnelIndicator.Icon = ((System.Drawing.Image)(resources.GetObject("tunnelIndicator.Icon")));
            this.tunnelIndicator.Label = "Status";
            this.tunnelIndicator.Location = new System.Drawing.Point(2, 6);
            this.tunnelIndicator.Margin = new System.Windows.Forms.Padding(2);
            this.tunnelIndicator.Name = "tunnelIndicator";
            this.tunnelIndicator.Size = new System.Drawing.Size(228, 22);
            this.tunnelIndicator.TabIndex = 1;
            // 
            // Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1682, 985);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.loggerPanel);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.clientsManagerPanel);
            this.Controls.Add(this.panel2);
            this.DisplayHeader = false;
            this.DoubleBuffered = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.tunnelMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Management";
            this.Padding = new System.Windows.Forms.Padding(25, 38, 25, 25);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Black;
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
        private System.Windows.Forms.Panel clientsManagerPanel;
        private System.Windows.Forms.Panel loggerPanel;
        private System.Windows.Forms.Panel panel10;
        private KTA_Visor_UI.component.custom.LoggerView.LoggerView loggerView;
        private System.Windows.Forms.MenuStrip tunnelMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem startTunnelServerMenuItem;
        public System.Windows.Forms.ToolStripMenuItem stopTunnelServerMenuItem;
        public System.Windows.Forms.ToolStripMenuItem restartTunnelServerMenuItem;
        private System.Windows.Forms.Panel panel7;
        private KTA_Visor_UI.component.basic.StatusIndicator.StatusIndicator tunnelIndicator;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel contentPanel;
        public System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem logsMenuItem;
        public System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem versionMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutUsMenuItem;
        private KTA_Visor_UI.component.custom.User.UserProfile.UserProfileCard sideBar;
        public System.Windows.Forms.ToolStripMenuItem kontoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem profileMenuItem;
        public System.Windows.Forms.ToolStripMenuItem securityMenuItem;
        public System.Windows.Forms.ToolStripMenuItem logoutMenuItem;
        public ToolStripMenuItem ustawieniaFabryczneToolStripMenuItem;
        public ToolStripMenuItem tunnelToolStripMenuItem;
        public ToolStripMenuItem cardModeMenuItem;
    }
}