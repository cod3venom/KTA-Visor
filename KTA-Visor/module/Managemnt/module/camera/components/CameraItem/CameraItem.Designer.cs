namespace KTA_Visor.module.Managemnt.module.Camera.component.CameraItem
{
    partial class CameraItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraItem));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusIcon = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cameraIndexLbl = new System.Windows.Forms.Label();
            this.settingsBtn = new MetroFramework.Controls.MetroButton();
            this.stationIdLbl = new System.Windows.Forms.Label();
            this.badgeIdLbl = new System.Windows.Forms.Label();
            this.cameraIdLbl = new System.Windows.Forms.Label();
            this.stationIdTextLbl = new System.Windows.Forms.Label();
            this.cameraIdTextLbl = new System.Windows.Forms.Label();
            this.badgeIdTextLbl = new System.Windows.Forms.Label();
            this.cameraItemMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.systemPlikówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFilesToUSBMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFilesToDVDMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetDriveDevicePathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.nasStorageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).BeginInit();
            this.panel3.SuspendLayout();
            this.cameraItemMenuStrip.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 98);
            this.panel2.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(94, 17);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 61);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 27);
            this.panel1.TabIndex = 3;
            // 
            // statusIcon
            // 
            this.statusIcon.Image = global::KTA_Visor.Properties.Resources.green_circle;
            this.statusIcon.Location = new System.Drawing.Point(9, 3);
            this.statusIcon.Margin = new System.Windows.Forms.Padding(2);
            this.statusIcon.Name = "statusIcon";
            this.statusIcon.Size = new System.Drawing.Size(21, 17);
            this.statusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.statusIcon.TabIndex = 1;
            this.statusIcon.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cameraIndexLbl);
            this.panel3.Controls.Add(this.settingsBtn);
            this.panel3.Controls.Add(this.stationIdLbl);
            this.panel3.Controls.Add(this.badgeIdLbl);
            this.panel3.Controls.Add(this.cameraIdLbl);
            this.panel3.Controls.Add(this.stationIdTextLbl);
            this.panel3.Controls.Add(this.cameraIdTextLbl);
            this.panel3.Controls.Add(this.badgeIdTextLbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 125);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 135);
            this.panel3.TabIndex = 5;
            // 
            // cameraIndexLbl
            // 
            this.cameraIndexLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.cameraIndexLbl.Font = new System.Drawing.Font("Inter SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraIndexLbl.Location = new System.Drawing.Point(248, 0);
            this.cameraIndexLbl.Name = "cameraIndexLbl";
            this.cameraIndexLbl.Size = new System.Drawing.Size(17, 112);
            this.cameraIndexLbl.TabIndex = 12;
            this.cameraIndexLbl.Text = "-1";
            this.cameraIndexLbl.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // settingsBtn
            // 
            this.settingsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingsBtn.Location = new System.Drawing.Point(0, 112);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(265, 23);
            this.settingsBtn.TabIndex = 13;
            this.settingsBtn.Text = "Ustawienia";
            this.settingsBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.settingsBtn.UseSelectable = true;
            // 
            // stationIdLbl
            // 
            this.stationIdLbl.AutoSize = true;
            this.stationIdLbl.Font = new System.Drawing.Font("Inter SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationIdLbl.Location = new System.Drawing.Point(70, 73);
            this.stationIdLbl.Name = "stationIdLbl";
            this.stationIdLbl.Size = new System.Drawing.Size(47, 14);
            this.stationIdLbl.TabIndex = 10;
            this.stationIdLbl.Text = "123456";
            // 
            // badgeIdLbl
            // 
            this.badgeIdLbl.AutoSize = true;
            this.badgeIdLbl.Font = new System.Drawing.Font("Inter SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.badgeIdLbl.Location = new System.Drawing.Point(70, 25);
            this.badgeIdLbl.Name = "badgeIdLbl";
            this.badgeIdLbl.Size = new System.Drawing.Size(47, 14);
            this.badgeIdLbl.TabIndex = 9;
            this.badgeIdLbl.Text = "123456";
            // 
            // cameraIdLbl
            // 
            this.cameraIdLbl.AutoSize = true;
            this.cameraIdLbl.Font = new System.Drawing.Font("Inter SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraIdLbl.Location = new System.Drawing.Point(70, 49);
            this.cameraIdLbl.Name = "cameraIdLbl";
            this.cameraIdLbl.Size = new System.Drawing.Size(47, 14);
            this.cameraIdLbl.TabIndex = 8;
            this.cameraIdLbl.Text = "123456";
            // 
            // stationIdTextLbl
            // 
            this.stationIdTextLbl.AutoSize = true;
            this.stationIdTextLbl.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationIdTextLbl.Location = new System.Drawing.Point(17, 73);
            this.stationIdTextLbl.Name = "stationIdTextLbl";
            this.stationIdTextLbl.Size = new System.Drawing.Size(53, 14);
            this.stationIdTextLbl.TabIndex = 7;
            this.stationIdTextLbl.Text = "ID Stacji:";
            // 
            // cameraIdTextLbl
            // 
            this.cameraIdTextLbl.AutoSize = true;
            this.cameraIdTextLbl.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraIdTextLbl.Location = new System.Drawing.Point(7, 49);
            this.cameraIdTextLbl.Name = "cameraIdTextLbl";
            this.cameraIdTextLbl.Size = new System.Drawing.Size(63, 14);
            this.cameraIdTextLbl.TabIndex = 6;
            this.cameraIdTextLbl.Text = "ID Kamery:";
            // 
            // badgeIdTextLbl
            // 
            this.badgeIdTextLbl.AutoSize = true;
            this.badgeIdTextLbl.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.badgeIdTextLbl.Location = new System.Drawing.Point(3, 25);
            this.badgeIdTextLbl.Name = "badgeIdTextLbl";
            this.badgeIdTextLbl.Size = new System.Drawing.Size(73, 14);
            this.badgeIdTextLbl.TabIndex = 5;
            this.badgeIdTextLbl.Text = "NR Odznaki: ";
            // 
            // cameraItemMenuStrip
            // 
            this.cameraItemMenuStrip.BackColor = System.Drawing.Color.Silver;
            this.cameraItemMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemPlikówToolStripMenuItem});
            this.cameraItemMenuStrip.Name = "cameraItemMenuStrip";
            this.cameraItemMenuStrip.Size = new System.Drawing.Size(151, 26);
            // 
            // systemPlikówToolStripMenuItem
            // 
            this.systemPlikówToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyFilesToUSBMenuItem,
            this.copyFilesToDVDMenuItem});
            this.systemPlikówToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemPlikówToolStripMenuItem.Image")));
            this.systemPlikówToolStripMenuItem.Name = "systemPlikówToolStripMenuItem";
            this.systemPlikówToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.systemPlikówToolStripMenuItem.Text = "System Plików";
            // 
            // copyFilesToUSBMenuItem
            // 
            this.copyFilesToUSBMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyFilesToUSBMenuItem.Image")));
            this.copyFilesToUSBMenuItem.Name = "copyFilesToUSBMenuItem";
            this.copyFilesToUSBMenuItem.Size = new System.Drawing.Size(211, 22);
            this.copyFilesToUSBMenuItem.Text = "Zgrywanie na Nosnik USB";
            // 
            // copyFilesToDVDMenuItem
            // 
            this.copyFilesToDVDMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyFilesToDVDMenuItem.Image")));
            this.copyFilesToDVDMenuItem.Name = "copyFilesToDVDMenuItem";
            this.copyFilesToDVDMenuItem.Size = new System.Drawing.Size(211, 22);
            this.copyFilesToDVDMenuItem.Text = "Zgrywanie na Nosnik DVD";
            // 
            // nasStorageFileDialog
            // 
            this.nasStorageFileDialog.FileName = "Wybierz pliki które chcesz skopiować";
            this.nasStorageFileDialog.Multiselect = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.statusIcon);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(228, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(37, 27);
            this.panel4.TabIndex = 2;
            // 
            // CameraItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ContextMenuStrip = this.cameraItemMenuStrip;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CameraItem";
            this.Size = new System.Drawing.Size(265, 260);
            this.Load += new System.EventHandler(this.CameraItem_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.cameraItemMenuStrip.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox statusIcon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ContextMenuStrip cameraItemMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem systemPlikówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFilesToUSBMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFilesToDVDMenuItem;
        private System.Windows.Forms.FolderBrowserDialog targetDriveDevicePathDialog;
        private System.Windows.Forms.OpenFileDialog nasStorageFileDialog;
        private System.Windows.Forms.Label stationIdLbl;
        private System.Windows.Forms.Label badgeIdLbl;
        private System.Windows.Forms.Label cameraIdLbl;
        private System.Windows.Forms.Label stationIdTextLbl;
        private System.Windows.Forms.Label cameraIdTextLbl;
        private System.Windows.Forms.Label badgeIdTextLbl;
        private System.Windows.Forms.Label cameraIndexLbl;
        private MetroFramework.Controls.MetroButton settingsBtn;
        private System.Windows.Forms.Panel panel4;
    }
}
