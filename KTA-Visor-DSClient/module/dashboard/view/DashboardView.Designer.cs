namespace KTA_Visor_DSClient.module.dashboard.view
{
    partial class DashboardView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardView));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.numbersPanel = new System.Windows.Forms.Panel();
            this.tablePanel = new System.Windows.Forms.Panel();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.sidebarToggleBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuSeparator3 = new Bunifu.Framework.UI.BunifuSeparator();
            this.managementBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.panel5 = new System.Windows.Forms.Panel();
            this.fileSystemBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.table = new KTA_Visor_UI.component.basic.table.Table();
            this.connectedCamerasCard = new KTA_Visor_UI.component.custom.NumbersCard.NumbersCard();
            this.totalPortsCard = new KTA_Visor_UI.component.custom.NumbersCard.NumbersCard();
            this.usedSpaceCard = new KTA_Visor_UI.component.custom.NumbersCard.NumbersCard();
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.footer1 = new KTA_Visor_UI.component.custom.Footer.Footer();
            this.panel1.SuspendLayout();
            this.numbersPanel.SuspendLayout();
            this.tablePanel.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sidebarToggleBtn)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.topBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(282, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1106, 45);
            this.panel1.TabIndex = 0;
            // 
            // numbersPanel
            // 
            this.numbersPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(193)))), ((int)(((byte)(229)))));
            this.numbersPanel.Controls.Add(this.connectedCamerasCard);
            this.numbersPanel.Controls.Add(this.totalPortsCard);
            this.numbersPanel.Controls.Add(this.usedSpaceCard);
            this.numbersPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.numbersPanel.Location = new System.Drawing.Point(282, 98);
            this.numbersPanel.Name = "numbersPanel";
            this.numbersPanel.Size = new System.Drawing.Size(1106, 213);
            this.numbersPanel.TabIndex = 9;
            // 
            // tablePanel
            // 
            this.tablePanel.Controls.Add(this.table);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(282, 311);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Size = new System.Drawing.Size(1106, 299);
            this.tablePanel.TabIndex = 11;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.AutoScroll = true;
            this.sidebarPanel.Controls.Add(this.fileSystemBtn);
            this.sidebarPanel.Controls.Add(this.managementBtn);
            this.sidebarPanel.Controls.Add(this.panel5);
            this.sidebarPanel.Controls.Add(this.bunifuSeparator3);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(282, 610);
            this.sidebarPanel.TabIndex = 12;
            // 
            // sidebarToggleBtn
            // 
            this.sidebarToggleBtn.BackColor = System.Drawing.Color.Transparent;
            this.sidebarToggleBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sidebarToggleBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarToggleBtn.Image = ((System.Drawing.Image)(resources.GetObject("sidebarToggleBtn.Image")));
            this.sidebarToggleBtn.ImageActive = null;
            this.sidebarToggleBtn.Location = new System.Drawing.Point(0, 0);
            this.sidebarToggleBtn.Name = "sidebarToggleBtn";
            this.sidebarToggleBtn.Size = new System.Drawing.Size(84, 52);
            this.sidebarToggleBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.sidebarToggleBtn.TabIndex = 13;
            this.sidebarToggleBtn.TabStop = false;
            this.sidebarToggleBtn.Zoom = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.sidebarToggleBtn);
            this.panel3.Controls.Add(this.bunifuSeparator1);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(282, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1106, 53);
            this.panel3.TabIndex = 14;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.bunifuImageButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(0, 0);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(281, 45);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bunifuImageButton1.TabIndex = 2;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 0;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 52);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1106, 1);
            this.bunifuSeparator1.TabIndex = 4;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // bunifuSeparator3
            // 
            this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator3.Dock = System.Windows.Forms.DockStyle.Right;
            this.bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.bunifuSeparator3.LineThickness = 1;
            this.bunifuSeparator3.Location = new System.Drawing.Point(281, 0);
            this.bunifuSeparator3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuSeparator3.Name = "bunifuSeparator3";
            this.bunifuSeparator3.Size = new System.Drawing.Size(1, 610);
            this.bunifuSeparator3.TabIndex = 4;
            this.bunifuSeparator3.Transparency = 255;
            this.bunifuSeparator3.Vertical = true;
            // 
            // managementBtn
            // 
            this.managementBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.managementBtn.BackColor = System.Drawing.Color.Transparent;
            this.managementBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.managementBtn.BorderRadius = 0;
            this.managementBtn.ButtonText = "Management";
            this.managementBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.managementBtn.DisabledColor = System.Drawing.Color.Gray;
            this.managementBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.managementBtn.Font = new System.Drawing.Font("Inter SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managementBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.managementBtn.Iconimage = ((System.Drawing.Image)(resources.GetObject("managementBtn.Iconimage")));
            this.managementBtn.Iconimage_right = null;
            this.managementBtn.Iconimage_right_Selected = null;
            this.managementBtn.Iconimage_Selected = null;
            this.managementBtn.IconMarginLeft = 0;
            this.managementBtn.IconMarginRight = 0;
            this.managementBtn.IconRightVisible = true;
            this.managementBtn.IconRightZoom = 0D;
            this.managementBtn.IconVisible = true;
            this.managementBtn.IconZoom = 40D;
            this.managementBtn.IsTab = false;
            this.managementBtn.Location = new System.Drawing.Point(0, 45);
            this.managementBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.managementBtn.Name = "managementBtn";
            this.managementBtn.Normalcolor = System.Drawing.Color.Transparent;
            this.managementBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(108)))), ((int)(((byte)(149)))));
            this.managementBtn.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(193)))), ((int)(((byte)(229)))));
            this.managementBtn.selected = false;
            this.managementBtn.Size = new System.Drawing.Size(281, 61);
            this.managementBtn.TabIndex = 7;
            this.managementBtn.Text = "Management";
            this.managementBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.managementBtn.Textcolor = System.Drawing.Color.White;
            this.managementBtn.TextFont = new System.Drawing.Font("Inter SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(0, 44);
            this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(281, 1);
            this.bunifuSeparator2.TabIndex = 8;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bunifuSeparator2);
            this.panel5.Controls.Add(this.bunifuImageButton1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(281, 45);
            this.panel5.TabIndex = 9;
            // 
            // fileSystemBtn
            // 
            this.fileSystemBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.fileSystemBtn.BackColor = System.Drawing.Color.Transparent;
            this.fileSystemBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fileSystemBtn.BorderRadius = 0;
            this.fileSystemBtn.ButtonText = "File System";
            this.fileSystemBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fileSystemBtn.DisabledColor = System.Drawing.Color.Gray;
            this.fileSystemBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileSystemBtn.Font = new System.Drawing.Font("Inter SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSystemBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.fileSystemBtn.Iconimage = ((System.Drawing.Image)(resources.GetObject("fileSystemBtn.Iconimage")));
            this.fileSystemBtn.Iconimage_right = null;
            this.fileSystemBtn.Iconimage_right_Selected = null;
            this.fileSystemBtn.Iconimage_Selected = null;
            this.fileSystemBtn.IconMarginLeft = 0;
            this.fileSystemBtn.IconMarginRight = 0;
            this.fileSystemBtn.IconRightVisible = true;
            this.fileSystemBtn.IconRightZoom = 0D;
            this.fileSystemBtn.IconVisible = true;
            this.fileSystemBtn.IconZoom = 30D;
            this.fileSystemBtn.IsTab = false;
            this.fileSystemBtn.Location = new System.Drawing.Point(0, 106);
            this.fileSystemBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileSystemBtn.Name = "fileSystemBtn";
            this.fileSystemBtn.Normalcolor = System.Drawing.Color.Transparent;
            this.fileSystemBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(108)))), ((int)(((byte)(149)))));
            this.fileSystemBtn.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(193)))), ((int)(((byte)(229)))));
            this.fileSystemBtn.selected = false;
            this.fileSystemBtn.Size = new System.Drawing.Size(281, 61);
            this.fileSystemBtn.TabIndex = 10;
            this.fileSystemBtn.Text = "File System";
            this.fileSystemBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fileSystemBtn.Textcolor = System.Drawing.Color.White;
            this.fileSystemBtn.TextFont = new System.Drawing.Font("Inter SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // table
            // 
            this.table.AllowAdd = false;
            this.table.AllowDelete = false;
            this.table.AllowEdit = true;
            this.table.AllowSearch = true;
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.table.ShowAdd = false;
            this.table.ShowControls = false;
            this.table.ShowDelete = false;
            this.table.ShowEdit = false;
            this.table.Size = new System.Drawing.Size(1106, 299);
            this.table.TabIndex = 0;
            // 
            // connectedCamerasCard
            // 
            this.connectedCamerasCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.connectedCamerasCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.connectedCamerasCard.Label = "Connected cameras";
            this.connectedCamerasCard.Location = new System.Drawing.Point(19, 23);
            this.connectedCamerasCard.Name = "connectedCamerasCard";
            this.connectedCamerasCard.Number = "4";
            this.connectedCamerasCard.Size = new System.Drawing.Size(337, 156);
            this.connectedCamerasCard.TabIndex = 4;
            // 
            // totalPortsCard
            // 
            this.totalPortsCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPortsCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.totalPortsCard.Label = "Total Ports";
            this.totalPortsCard.Location = new System.Drawing.Point(402, 23);
            this.totalPortsCard.Name = "totalPortsCard";
            this.totalPortsCard.Number = "8";
            this.totalPortsCard.Size = new System.Drawing.Size(307, 156);
            this.totalPortsCard.TabIndex = 5;
            // 
            // usedSpaceCard
            // 
            this.usedSpaceCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usedSpaceCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.usedSpaceCard.Label = "Used Space";
            this.usedSpaceCard.Location = new System.Drawing.Point(749, 23);
            this.usedSpaceCard.Name = "usedSpaceCard";
            this.usedSpaceCard.Number = "160 GB";
            this.usedSpaceCard.Size = new System.Drawing.Size(335, 156);
            this.usedSpaceCard.TabIndex = 6;
            // 
            // topBar1
            // 
            this.topBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.topBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(1106, 45);
            this.topBar1.TabIndex = 0;
            this.topBar1.Title = "Window";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.footer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 610);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1388, 45);
            this.panel2.TabIndex = 15;
            // 
            // footer1
            // 
            this.footer1.AutoSize = true;
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footer1.Location = new System.Drawing.Point(0, 0);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(1388, 45);
            this.footer1.TabIndex = 0;
            // 
            // DashboardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(193)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1388, 655);
            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.numbersPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardView";
            this.Load += new System.EventHandler(this.DashboardView_Load);
            this.panel1.ResumeLayout(false);
            this.numbersPanel.ResumeLayout(false);
            this.tablePanel.ResumeLayout(false);
            this.sidebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sidebarToggleBtn)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private KTA_Visor_UI.component.custom.NumbersCard.NumbersCard usedSpaceCard;
        private KTA_Visor_UI.component.custom.NumbersCard.NumbersCard totalPortsCard;
        private KTA_Visor_UI.component.custom.NumbersCard.NumbersCard connectedCamerasCard;
        private System.Windows.Forms.Panel numbersPanel;
        private System.Windows.Forms.Panel tablePanel;
        private KTA_Visor_UI.component.basic.table.Table table;
        private System.Windows.Forms.Panel sidebarPanel;
        private Bunifu.Framework.UI.BunifuImageButton sidebarToggleBtn;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator3;
        private Bunifu.Framework.UI.BunifuFlatButton managementBtn;
        private System.Windows.Forms.Panel panel5;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuFlatButton fileSystemBtn;
        private System.Windows.Forms.Panel panel2;
        private KTA_Visor_UI.component.custom.Footer.Footer footer1;
    }
}