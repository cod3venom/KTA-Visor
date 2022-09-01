using System;

namespace KTA_Visor_DSClient.module.Management.view
{
    partial class ManagementView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagementView));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.topBar = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.restartTunelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectFromTunelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToTunelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tunnelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tunnelMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cardMenuStrip = new System.Windows.Forms.MenuStrip();
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.loggerViewPanel = new System.Windows.Forms.Panel();
            this.loggerView = new KTA_Visor_UI.component.custom.LoggerView.LoggerView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.fileHistoryPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.settingsBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.camerasBtn = new KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton();
            this.powerSupplyBtn = new KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton();
            this.footer1 = new KTA_Visor_UI.component.custom.Footer.Footer();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelsContainer = new System.Windows.Forms.Panel();
            this.deviceWatcheBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.tunnelMenuStrip.SuspendLayout();
            this.cardMenuStrip.SuspendLayout();
            this.topBarPanel.SuspendLayout();
            this.loggerViewPanel.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel12.SuspendLayout();
            this.fileHistoryPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBtn)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
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
            this.topBar.Size = new System.Drawing.Size(1165, 44);
            this.topBar.TabIndex = 0;
            this.topBar.Title = "Window";
            // 
            // restartTunelMenuItem
            // 
            this.restartTunelMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restartTunelMenuItem.Image")));
            this.restartTunelMenuItem.Name = "restartTunelMenuItem";
            this.restartTunelMenuItem.Size = new System.Drawing.Size(171, 26);
            this.restartTunelMenuItem.Text = "Restart";
            // 
            // disconnectFromTunelMenuItem
            // 
            this.disconnectFromTunelMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("disconnectFromTunelMenuItem.Image")));
            this.disconnectFromTunelMenuItem.Name = "disconnectFromTunelMenuItem";
            this.disconnectFromTunelMenuItem.Size = new System.Drawing.Size(171, 26);
            this.disconnectFromTunelMenuItem.Text = "Disconnect";
            // 
            // connectToTunelMenuItem
            // 
            this.connectToTunelMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("connectToTunelMenuItem.Image")));
            this.connectToTunelMenuItem.Name = "connectToTunelMenuItem";
            this.connectToTunelMenuItem.Size = new System.Drawing.Size(171, 26);
            this.connectToTunelMenuItem.Text = "Connect";
            // 
            // tunnelToolStripMenuItem
            // 
            this.tunnelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToTunelMenuItem,
            this.disconnectFromTunelMenuItem,
            this.restartTunelMenuItem});
            this.tunnelToolStripMenuItem.Font = new System.Drawing.Font("Inter Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tunnelToolStripMenuItem.Name = "tunnelToolStripMenuItem";
            this.tunnelToolStripMenuItem.Size = new System.Drawing.Size(70, 26);
            this.tunnelToolStripMenuItem.Text = "Tunnel";
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
            this.tunnelMenuStrip.Size = new System.Drawing.Size(80, 30);
            this.tunnelMenuStrip.TabIndex = 1;
            this.tunnelMenuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(159, 26);
            this.toolStripMenuItem3.Text = "Test Card";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(159, 26);
            this.toolStripMenuItem2.Text = "Sign Card";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Inter Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(75, 26);
            this.toolStripMenuItem1.Text = "Card ID";
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
            this.cardMenuStrip.Size = new System.Drawing.Size(85, 30);
            this.cardMenuStrip.TabIndex = 2;
            this.cardMenuStrip.Text = "Card ID";
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
            this.topBarPanel.Size = new System.Drawing.Size(1165, 72);
            this.topBarPanel.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(127, 398);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(628, 14);
            this.panel11.TabIndex = 32;
            // 
            // loggerViewPanel
            // 
            this.loggerViewPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.loggerViewPanel.Controls.Add(this.loggerView);
            this.loggerViewPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loggerViewPanel.Location = new System.Drawing.Point(127, 412);
            this.loggerViewPanel.Name = "loggerViewPanel";
            this.loggerViewPanel.Size = new System.Drawing.Size(628, 244);
            this.loggerViewPanel.TabIndex = 27;
            // 
            // loggerView
            // 
            this.loggerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggerView.Location = new System.Drawing.Point(0, 0);
            this.loggerView.Name = "loggerView";
            this.loggerView.ParentPanel = null;
            this.loggerView.Size = new System.Drawing.Size(628, 244);
            this.loggerView.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(755, 81);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(14, 575);
            this.panel9.TabIndex = 28;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel14);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(127, 656);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(642, 14);
            this.panel7.TabIndex = 30;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel6);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(382, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(14, 589);
            this.panel12.TabIndex = 19;
            // 
            // fileHistoryPanel
            // 
            this.fileHistoryPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.fileHistoryPanel.Controls.Add(this.panel2);
            this.fileHistoryPanel.Controls.Add(this.panel12);
            this.fileHistoryPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.fileHistoryPanel.Location = new System.Drawing.Point(769, 81);
            this.fileHistoryPanel.Name = "fileHistoryPanel";
            this.fileHistoryPanel.Size = new System.Drawing.Size(396, 589);
            this.fileHistoryPanel.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel13);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(113, 81);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(14, 589);
            this.panel5.TabIndex = 26;
            // 
            // settingsBtn
            // 
            this.settingsBtn.BackColor = System.Drawing.Color.Transparent;
            this.settingsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.ImageActive = null;
            this.settingsBtn.Location = new System.Drawing.Point(19, 18);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(36, 26);
            this.settingsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.settingsBtn.TabIndex = 0;
            this.settingsBtn.TabStop = false;
            this.settingsBtn.Zoom = 10;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.settingsBtn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 466);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(113, 123);
            this.panel4.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.panel1.Controls.Add(this.camerasBtn);
            this.panel1.Controls.Add(this.powerSupplyBtn);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 589);
            this.panel1.TabIndex = 25;
            // 
            // camerasBtn
            // 
            this.camerasBtn.BackColor = System.Drawing.Color.White;
            this.camerasBtn.Icon = ((System.Drawing.Image)(resources.GetObject("camerasBtn.Icon")));
            this.camerasBtn.Location = new System.Drawing.Point(32, 23);
            this.camerasBtn.Name = "camerasBtn";
            this.camerasBtn.Size = new System.Drawing.Size(46, 49);
            this.camerasBtn.TabIndex = 19;
            // 
            // powerSupplyBtn
            // 
            this.powerSupplyBtn.BackColor = System.Drawing.Color.White;
            this.powerSupplyBtn.Icon = ((System.Drawing.Image)(resources.GetObject("powerSupplyBtn.Icon")));
            this.powerSupplyBtn.Location = new System.Drawing.Point(32, 90);
            this.powerSupplyBtn.Name = "powerSupplyBtn";
            this.powerSupplyBtn.Size = new System.Drawing.Size(46, 49);
            this.powerSupplyBtn.TabIndex = 18;
            // 
            // footer1
            // 
            this.footer1.AutoSize = true;
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footer1.Location = new System.Drawing.Point(0, 0);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(1165, 45);
            this.footer1.TabIndex = 0;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.footer1);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 670);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1165, 45);
            this.footerPanel.TabIndex = 24;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 5;
            this.bunifuElipse2.TargetControl = this;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 79);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1165, 2);
            this.panel10.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.topBarPanel);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1165, 79);
            this.panel3.TabIndex = 23;
            // 
            // panelsContainer
            // 
            this.panelsContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.panelsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelsContainer.Location = new System.Drawing.Point(127, 81);
            this.panelsContainer.Name = "panelsContainer";
            this.panelsContainer.Size = new System.Drawing.Size(628, 317);
            this.panelsContainer.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 575);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 14);
            this.panel2.TabIndex = 31;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 575);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(14, 14);
            this.panel6.TabIndex = 32;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 109);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(113, 14);
            this.panel8.TabIndex = 32;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.White;
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 575);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(14, 14);
            this.panel13.TabIndex = 32;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.White;
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(642, 14);
            this.panel14.TabIndex = 32;
            // 
            // ManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 715);
            this.Controls.Add(this.panelsContainer);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.loggerViewPanel);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.fileHistoryPanel);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManagementView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagementView";
            this.Load += new System.EventHandler(this.ManagementView_Load);
            this.tunnelMenuStrip.ResumeLayout(false);
            this.tunnelMenuStrip.PerformLayout();
            this.cardMenuStrip.ResumeLayout(false);
            this.cardMenuStrip.PerformLayout();
            this.topBarPanel.ResumeLayout(false);
            this.topBarPanel.PerformLayout();
            this.loggerViewPanel.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.fileHistoryPanel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settingsBtn)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel loggerViewPanel;
        private KTA_Visor_UI.component.custom.LoggerView.LoggerView loggerView;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel fileHistoryPanel;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuImageButton settingsBtn;
        private System.Windows.Forms.Panel footerPanel;
        private KTA_Visor_UI.component.custom.Footer.Footer footer1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel topBarPanel;
        private System.Windows.Forms.MenuStrip cardMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.MenuStrip tunnelMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tunnelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToTunelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectFromTunelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartTunelMenuItem;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton powerSupplyBtn;
        private System.Windows.Forms.Panel panelsContainer;
        private KTA_Visor_UI.component.custom.CircleImageButton.CircleImageButton camerasBtn;
        private System.ComponentModel.BackgroundWorker deviceWatcheBackgroundWorker;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel8;
    }
}