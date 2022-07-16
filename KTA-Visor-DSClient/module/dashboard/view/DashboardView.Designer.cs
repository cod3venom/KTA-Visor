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
            this.footerPanel = new System.Windows.Forms.Panel();
            this.footer1 = new KTA_Visor_UI.component.custom.Footer.Footer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.fileHistoryPanel = new System.Windows.Forms.Panel();
            this.fileHistory = new KTA_Visor_DSClient.module.dashboard.componnets.FileHistory.FileHistory();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.loggerViewPanel = new System.Windows.Forms.Panel();
            this.loggerView = new KTA_Visor_UI.component.custom.LoggerView.LoggerView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.camerasPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.footerPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.fileHistoryPanel.SuspendLayout();
            this.loggerViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.footer1);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 789);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1440, 45);
            this.footerPanel.TabIndex = 15;
            // 
            // footer1
            // 
            this.footer1.AutoSize = true;
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footer1.Location = new System.Drawing.Point(0, 0);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(1440, 45);
            this.footer1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.topBar1);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1440, 53);
            this.panel3.TabIndex = 14;
            // 
            // topBar1
            // 
            this.topBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.topBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(1440, 53);
            this.topBar1.TabIndex = 0;
            this.topBar1.Title = "Window";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 736);
            this.panel1.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.bunifuImageButton1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 613);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(78, 123);
            this.panel4.TabIndex = 17;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(19, 18);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(36, 26);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 0;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(78, 53);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(14, 736);
            this.panel5.TabIndex = 17;
            // 
            // fileHistoryPanel
            // 
            this.fileHistoryPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.fileHistoryPanel.Controls.Add(this.fileHistory);
            this.fileHistoryPanel.Controls.Add(this.panel12);
            this.fileHistoryPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.fileHistoryPanel.Location = new System.Drawing.Point(1044, 67);
            this.fileHistoryPanel.Name = "fileHistoryPanel";
            this.fileHistoryPanel.Size = new System.Drawing.Size(396, 708);
            this.fileHistoryPanel.TabIndex = 18;
            // 
            // fileHistory
            // 
            this.fileHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileHistory.Location = new System.Drawing.Point(0, 0);
            this.fileHistory.Name = "fileHistory";
            this.fileHistory.Size = new System.Drawing.Size(382, 708);
            this.fileHistory.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(382, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(14, 708);
            this.panel12.TabIndex = 19;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(92, 775);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1348, 14);
            this.panel7.TabIndex = 19;
            // 
            // loggerViewPanel
            // 
            this.loggerViewPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.loggerViewPanel.Controls.Add(this.loggerView);
            this.loggerViewPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loggerViewPanel.Location = new System.Drawing.Point(92, 531);
            this.loggerViewPanel.Name = "loggerViewPanel";
            this.loggerViewPanel.Size = new System.Drawing.Size(938, 244);
            this.loggerViewPanel.TabIndex = 18;
            // 
            // loggerView
            // 
            this.loggerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggerView.Location = new System.Drawing.Point(0, 0);
            this.loggerView.Name = "loggerView";
            this.loggerView.ParentPanel = null;
            this.loggerView.Size = new System.Drawing.Size(938, 244);
            this.loggerView.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(1030, 67);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(14, 708);
            this.panel9.TabIndex = 18;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(92, 53);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1348, 14);
            this.panel10.TabIndex = 19;
            // 
            // camerasPanel
            // 
            this.camerasPanel.AutoScroll = true;
            this.camerasPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.camerasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.camerasPanel.Location = new System.Drawing.Point(92, 67);
            this.camerasPanel.Name = "camerasPanel";
            this.camerasPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.camerasPanel.Size = new System.Drawing.Size(938, 464);
            this.camerasPanel.TabIndex = 20;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(92, 517);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(938, 14);
            this.panel11.TabIndex = 21;
            // 
            // DashboardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1440, 834);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.camerasPanel);
            this.Controls.Add(this.loggerViewPanel);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.fileHistoryPanel);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.footerPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DashboardView_Load);
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.fileHistoryPanel.ResumeLayout(false);
            this.loggerViewPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel footerPanel;
        private KTA_Visor_UI.component.custom.Footer.Footer footer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.FlowLayoutPanel camerasPanel;
        private System.Windows.Forms.Panel loggerViewPanel;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel fileHistoryPanel;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel5;
        private componnets.FileHistory.FileHistory fileHistory;
        private System.Windows.Forms.Panel panel12;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private KTA_Visor_UI.component.custom.LoggerView.LoggerView loggerView;
    }
}