namespace KTA_Visor.component.custom.VerticalTab
{
    partial class VerticalTab
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.currentScreenLbl = new System.Windows.Forms.Label();
            this.breadCrumbsLbl = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.menuItemsListContainer = new System.Windows.Forms.Panel();
            this.menuTitleLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.verticalSeparator1 = new KTA_Visor.component.basic.separator.VerticalSeparator();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.verticalSeparator2 = new KTA_Visor.component.basic.separator.VerticalSeparator();
            this.topPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.currentScreenLbl);
            this.topPanel.Controls.Add(this.breadCrumbsLbl);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(894, 64);
            this.topPanel.TabIndex = 0;
            // 
            // currentScreenLbl
            // 
            this.currentScreenLbl.AutoSize = true;
            this.currentScreenLbl.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentScreenLbl.Location = new System.Drawing.Point(151, 32);
            this.currentScreenLbl.Name = "currentScreenLbl";
            this.currentScreenLbl.Size = new System.Drawing.Size(99, 20);
            this.currentScreenLbl.TabIndex = 1;
            this.currentScreenLbl.Text = " / Kamera 1";
            // 
            // breadCrumbsLbl
            // 
            this.breadCrumbsLbl.AutoSize = true;
            this.breadCrumbsLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breadCrumbsLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(170)))));
            this.breadCrumbsLbl.Location = new System.Drawing.Point(35, 33);
            this.breadCrumbsLbl.Name = "breadCrumbsLbl";
            this.breadCrumbsLbl.Size = new System.Drawing.Size(120, 19);
            this.breadCrumbsLbl.TabIndex = 0;
            this.breadCrumbsLbl.Text = "Stacje / Stacja 1";
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.menuPanel);
            this.leftPanel.Controls.Add(this.panel1);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 64);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(178, 478);
            this.leftPanel.TabIndex = 1;
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.menuItemsListContainer);
            this.menuPanel.Controls.Add(this.menuTitleLbl);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(177, 478);
            this.menuPanel.TabIndex = 1;
            // 
            // menuItemsListContainer
            // 
            this.menuItemsListContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuItemsListContainer.Location = new System.Drawing.Point(3, 71);
            this.menuItemsListContainer.Name = "menuItemsListContainer";
            this.menuItemsListContainer.Size = new System.Drawing.Size(152, 404);
            this.menuItemsListContainer.TabIndex = 3;
            // 
            // menuTitleLbl
            // 
            this.menuTitleLbl.AutoSize = true;
            this.menuTitleLbl.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTitleLbl.Location = new System.Drawing.Point(35, 30);
            this.menuTitleLbl.Name = "menuTitleLbl";
            this.menuTitleLbl.Size = new System.Drawing.Size(104, 20);
            this.menuTitleLbl.TabIndex = 2;
            this.menuTitleLbl.Text = "Lista kamer";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.verticalSeparator1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(177, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 478);
            this.panel1.TabIndex = 0;
            // 
            // verticalSeparator1
            // 
            this.verticalSeparator1.AutoSize = true;
            this.verticalSeparator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.verticalSeparator1.Location = new System.Drawing.Point(1, 0);
            this.verticalSeparator1.Name = "verticalSeparator1";
            this.verticalSeparator1.Size = new System.Drawing.Size(0, 478);
            this.verticalSeparator1.TabIndex = 0;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.verticalSeparator2);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(178, 64);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(716, 478);
            this.rightPanel.TabIndex = 1;
            // 
            // verticalSeparator2
            // 
            this.verticalSeparator2.Dock = System.Windows.Forms.DockStyle.Left;
            this.verticalSeparator2.Location = new System.Drawing.Point(0, 0);
            this.verticalSeparator2.Name = "verticalSeparator2";
            this.verticalSeparator2.Size = new System.Drawing.Size(1, 478);
            this.verticalSeparator2.TabIndex = 0;
            // 
            // VerticalTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "VerticalTab";
            this.Size = new System.Drawing.Size(894, 542);
            this.Load += new System.EventHandler(this.VerticalTab_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel panel1;
        private basic.separator.VerticalSeparator verticalSeparator1;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label currentScreenLbl;
        private System.Windows.Forms.Label breadCrumbsLbl;
        private System.Windows.Forms.Label menuTitleLbl;
        private System.Windows.Forms.Panel menuItemsListContainer;
        private basic.separator.VerticalSeparator verticalSeparator2;
    }
}
