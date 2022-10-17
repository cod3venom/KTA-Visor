﻿using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.station.view
{
    partial class StationView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StationView));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.camerasFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.metroContextMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.powerSupplyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutDownPowerSupplyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPowerSupplyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tunnelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectFromTunnelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTunnelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteDesktopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectRemoteDesktopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.table = new KTA_Visor_UI.component.basic.table.Table();
            this.tabControl.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 26);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1439, 273);
            this.tabControl.TabIndex = 2;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.camerasFlowPanel);
            this.tabPage.Location = new System.Drawing.Point(4, 23);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(1431, 246);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "Kamery";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // camerasFlowPanel
            // 
            this.camerasFlowPanel.AutoScroll = true;
            this.camerasFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.camerasFlowPanel.Location = new System.Drawing.Point(3, 3);
            this.camerasFlowPanel.Name = "camerasFlowPanel";
            this.camerasFlowPanel.Size = new System.Drawing.Size(1425, 240);
            this.camerasFlowPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Controls.Add(this.bunifuSeparator1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 602);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1439, 299);
            this.panel1.TabIndex = 3;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 0);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1439, 26);
            this.bunifuSeparator1.TabIndex = 3;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.powerSupplyMenuItem,
            this.tunnelMenuItem,
            this.remoteDesktopMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(149, 82);
            // 
            // powerSupplyMenuItem
            // 
            this.powerSupplyMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shutDownPowerSupplyMenuItem,
            this.resetPowerSupplyMenuItem});
            this.powerSupplyMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("powerSupplyMenuItem.Image")));
            this.powerSupplyMenuItem.Name = "powerSupplyMenuItem";
            this.powerSupplyMenuItem.Size = new System.Drawing.Size(148, 26);
            this.powerSupplyMenuItem.Text = "Zaśilanie";
            // 
            // shutDownPowerSupplyMenuItem
            // 
            this.shutDownPowerSupplyMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("shutDownPowerSupplyMenuItem.Image")));
            this.shutDownPowerSupplyMenuItem.Name = "shutDownPowerSupplyMenuItem";
            this.shutDownPowerSupplyMenuItem.Size = new System.Drawing.Size(138, 26);
            this.shutDownPowerSupplyMenuItem.Text = "Wyłączyć";
            // 
            // resetPowerSupplyMenuItem
            // 
            this.resetPowerSupplyMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resetPowerSupplyMenuItem.Image")));
            this.resetPowerSupplyMenuItem.Name = "resetPowerSupplyMenuItem";
            this.resetPowerSupplyMenuItem.Size = new System.Drawing.Size(138, 26);
            this.resetPowerSupplyMenuItem.Text = "Zresetowac";
            // 
            // tunnelMenuItem
            // 
            this.tunnelMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectFromTunnelMenuItem,
            this.resetTunnelMenuItem});
            this.tunnelMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tunnelMenuItem.Image")));
            this.tunnelMenuItem.Name = "tunnelMenuItem";
            this.tunnelMenuItem.Size = new System.Drawing.Size(148, 26);
            this.tunnelMenuItem.Text = "Tunel";
            // 
            // disconnectFromTunnelMenuItem
            // 
            this.disconnectFromTunnelMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("disconnectFromTunnelMenuItem.Image")));
            this.disconnectFromTunnelMenuItem.Name = "disconnectFromTunnelMenuItem";
            this.disconnectFromTunnelMenuItem.Size = new System.Drawing.Size(120, 26);
            this.disconnectFromTunnelMenuItem.Text = "Rozłącz";
            // 
            // resetTunnelMenuItem
            // 
            this.resetTunnelMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resetTunnelMenuItem.Image")));
            this.resetTunnelMenuItem.Name = "resetTunnelMenuItem";
            this.resetTunnelMenuItem.Size = new System.Drawing.Size(120, 26);
            this.resetTunnelMenuItem.Text = "Zresetuj";
            // 
            // remoteDesktopMenuItem
            // 
            this.remoteDesktopMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectRemoteDesktopMenuItem});
            this.remoteDesktopMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("remoteDesktopMenuItem.Image")));
            this.remoteDesktopMenuItem.Name = "remoteDesktopMenuItem";
            this.remoteDesktopMenuItem.Size = new System.Drawing.Size(148, 26);
            this.remoteDesktopMenuItem.Text = "Zdalny pulpit";
            // 
            // connectRemoteDesktopMenuItem
            // 
            this.connectRemoteDesktopMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("connectRemoteDesktopMenuItem.Image")));
            this.connectRemoteDesktopMenuItem.Name = "connectRemoteDesktopMenuItem";
            this.connectRemoteDesktopMenuItem.Size = new System.Drawing.Size(129, 26);
            this.connectRemoteDesktopMenuItem.Text = "Połącz się";
            // 
            // table
            // 
            this.table.AllowAdd = true;
            this.table.AllowDelete = true;
            this.table.AllowEdit = true;
            this.table.AllowProgressBar = true;
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Margin = new System.Windows.Forms.Padding(2);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(1439, 602);
            this.table.TabIndex = 4;
            this.table.Title = "title";
            // 
            // StationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StationView";
            this.Size = new System.Drawing.Size(1439, 901);
            this.Load += new System.EventHandler(this.StationViewPanel_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        public System.Windows.Forms.FlowLayoutPanel camerasFlowPanel;
        private ContextMenuStrip metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem powerSupplyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutDownPowerSupplyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetPowerSupplyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tunnelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectFromTunnelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetTunnelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteDesktopMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectRemoteDesktopMenuItem;
        private KTA_Visor_UI.component.basic.table.Table table;
    }
}