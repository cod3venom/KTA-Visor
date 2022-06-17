namespace KTA_Visor_UI.component.custom.NavigationBar
{
    partial class NavigationBar
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
            this.titleLbl = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.versionLbl = new System.Windows.Forms.Label();
            this.middlePanel = new System.Windows.Forms.Panel();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.loggedInLabel = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.linksContainer = new System.Windows.Forms.Panel();
            this.horizontalSeparator1 = new KTA_Visor_UI.component.basic.table.components.HorizontalSeparator.HorizontalSeparator();
            this.leftPanel.SuspendLayout();
            this.middlePanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Inter SemiBold", 24.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.titleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(128)))), ((int)(((byte)(226)))));
            this.titleLbl.Location = new System.Drawing.Point(80, 29);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(248, 50);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "KTA-VISOR";
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.versionLbl);
            this.leftPanel.Controls.Add(this.titleLbl);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(377, 147);
            this.leftPanel.TabIndex = 1;
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.BackColor = System.Drawing.Color.Transparent;
            this.versionLbl.Font = new System.Drawing.Font("Inter Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(170)))));
            this.versionLbl.Location = new System.Drawing.Point(242, 79);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(109, 19);
            this.versionLbl.TabIndex = 1;
            this.versionLbl.Text = "ver-test.0-1";
            // 
            // middlePanel
            // 
            this.middlePanel.Controls.Add(this.usernameLbl);
            this.middlePanel.Controls.Add(this.loggedInLabel);
            this.middlePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.middlePanel.Location = new System.Drawing.Point(377, 0);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Size = new System.Drawing.Size(273, 147);
            this.middlePanel.TabIndex = 2;
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.BackColor = System.Drawing.Color.Transparent;
            this.usernameLbl.Font = new System.Drawing.Font("Inter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(128)))), ((int)(((byte)(226)))));
            this.usernameLbl.Location = new System.Drawing.Point(41, 46);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(169, 28);
            this.usernameLbl.TabIndex = 3;
            this.usernameLbl.Text = "janek-123-231";
            // 
            // loggedInLabel
            // 
            this.loggedInLabel.AutoSize = true;
            this.loggedInLabel.BackColor = System.Drawing.Color.Transparent;
            this.loggedInLabel.Font = new System.Drawing.Font("Inter Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loggedInLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(170)))));
            this.loggedInLabel.Location = new System.Drawing.Point(43, 15);
            this.loggedInLabel.Name = "loggedInLabel";
            this.loggedInLabel.Size = new System.Drawing.Size(112, 16);
            this.loggedInLabel.TabIndex = 2;
            this.loggedInLabel.Text = "ZALOGOWANO";
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.linksContainer);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(683, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(387, 147);
            this.rightPanel.TabIndex = 3;
            // 
            // linksContainer
            // 
            this.linksContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linksContainer.Location = new System.Drawing.Point(21, 59);
            this.linksContainer.Name = "linksContainer";
            this.linksContainer.Size = new System.Drawing.Size(343, 33);
            this.linksContainer.TabIndex = 0;
            // 
            // horizontalSeparator1
            // 
            this.horizontalSeparator1.BackColor = System.Drawing.Color.Silver;
            this.horizontalSeparator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horizontalSeparator1.Location = new System.Drawing.Point(0, 147);
            this.horizontalSeparator1.Name = "horizontalSeparator1";
            this.horizontalSeparator1.Size = new System.Drawing.Size(1070, 1);
            this.horizontalSeparator1.TabIndex = 4;
            // 
            // NavigationBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(240)))), ((int)(((byte)(251)))));
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.middlePanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.horizontalSeparator1);
            this.Name = "NavigationBar";
            this.Size = new System.Drawing.Size(1070, 148);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.middlePanel.ResumeLayout(false);
            this.middlePanel.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Panel middlePanel;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.Label loggedInLabel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel linksContainer;
        private basic.table.components.HorizontalSeparator.HorizontalSeparator horizontalSeparator1;
    }
}
