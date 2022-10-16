namespace KTA_Visor_UI.component.custom.ClientsList
{
    partial class ClientsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsList));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.totalTextLbl = new System.Windows.Forms.Label();
            this.totalLbl = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshBtn = new System.Windows.Forms.PictureBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLbl = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshBtn)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.contentPanel);
            this.mainPanel.Controls.Add(this.panel5);
            this.mainPanel.Controls.Add(this.panel4);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 27);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(271, 412);
            this.mainPanel.TabIndex = 0;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 33);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(271, 356);
            this.contentPanel.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.totalTextLbl);
            this.panel5.Controls.Add(this.totalLbl);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 389);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(271, 23);
            this.panel5.TabIndex = 4;
            // 
            // totalTextLbl
            // 
            this.totalTextLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalTextLbl.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTextLbl.Location = new System.Drawing.Point(0, 0);
            this.totalTextLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalTextLbl.Name = "totalTextLbl";
            this.totalTextLbl.Size = new System.Drawing.Size(238, 23);
            this.totalTextLbl.TabIndex = 1;
            this.totalTextLbl.Text = "Total Clients: ";
            this.totalTextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalLbl
            // 
            this.totalLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.totalLbl.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLbl.Location = new System.Drawing.Point(238, 0);
            this.totalLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(33, 23);
            this.totalLbl.TabIndex = 2;
            this.totalLbl.Text = "0";
            this.totalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(271, 33);
            this.panel4.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.refreshBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(223, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(48, 33);
            this.panel1.TabIndex = 18;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshBtn.Image")));
            this.refreshBtn.Location = new System.Drawing.Point(15, 6);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(17, 18);
            this.refreshBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.refreshBtn.TabIndex = 17;
            this.refreshBtn.TabStop = false;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Silver;
            this.topPanel.Controls.Add(this.titleLbl);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(271, 27);
            this.topPanel.TabIndex = 1;
            // 
            // titleLbl
            // 
            this.titleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLbl.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.Location = new System.Drawing.Point(0, 0);
            this.titleLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.titleLbl.Size = new System.Drawing.Size(271, 27);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "Clients";
            this.titleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClientsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClientsList";
            this.Size = new System.Drawing.Size(271, 439);
            this.Load += new System.EventHandler(this.ClientsList_Load);
            this.mainPanel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.refreshBtn)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.PictureBox refreshBtn;
        private System.Windows.Forms.Label totalTextLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label totalLbl;
    }
}
