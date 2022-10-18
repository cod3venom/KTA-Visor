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
            this.panel4 = new System.Windows.Forms.Panel();
            this.statusIcon = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.settingsBtn = new MetroFramework.Controls.MetroButton();
            this.badgeIdLbl = new System.Windows.Forms.Label();
            this.cameraIdLbl = new System.Windows.Forms.Label();
            this.cameraIdTextLbl = new System.Windows.Forms.Label();
            this.badgeIdTextLbl = new System.Windows.Forms.Label();
            this.cameraItemMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.oprogramowanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upgradeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetDriveDevicePathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.nasStorageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).BeginInit();
            this.panel3.SuspendLayout();
            this.cameraItemMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 84);
            this.panel2.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(88, 9);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(65, 71);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 33);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.statusIcon);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(199, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(49, 33);
            this.panel4.TabIndex = 2;
            // 
            // statusIcon
            // 
            this.statusIcon.Image = global::KTA_Visor.Properties.Resources.green_circle;
            this.statusIcon.Location = new System.Drawing.Point(12, 4);
            this.statusIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statusIcon.Name = "statusIcon";
            this.statusIcon.Size = new System.Drawing.Size(28, 21);
            this.statusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.statusIcon.TabIndex = 1;
            this.statusIcon.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.settingsBtn);
            this.panel3.Controls.Add(this.badgeIdLbl);
            this.panel3.Controls.Add(this.cameraIdLbl);
            this.panel3.Controls.Add(this.cameraIdTextLbl);
            this.panel3.Controls.Add(this.badgeIdTextLbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 117);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(248, 127);
            this.panel3.TabIndex = 5;
            // 
            // settingsBtn
            // 
            this.settingsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingsBtn.Location = new System.Drawing.Point(0, 99);
            this.settingsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(248, 28);
            this.settingsBtn.TabIndex = 13;
            this.settingsBtn.Text = "Ustawienia";
            this.settingsBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.settingsBtn.UseSelectable = true;
            // 
            // badgeIdLbl
            // 
            this.badgeIdLbl.AutoSize = true;
            this.badgeIdLbl.Font = new System.Drawing.Font("Inter SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.badgeIdLbl.Location = new System.Drawing.Point(93, 27);
            this.badgeIdLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.badgeIdLbl.Name = "badgeIdLbl";
            this.badgeIdLbl.Size = new System.Drawing.Size(60, 17);
            this.badgeIdLbl.TabIndex = 9;
            this.badgeIdLbl.Text = "123456";
            // 
            // cameraIdLbl
            // 
            this.cameraIdLbl.AutoSize = true;
            this.cameraIdLbl.Font = new System.Drawing.Font("Inter SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraIdLbl.Location = new System.Drawing.Point(93, 56);
            this.cameraIdLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cameraIdLbl.Name = "cameraIdLbl";
            this.cameraIdLbl.Size = new System.Drawing.Size(60, 17);
            this.cameraIdLbl.TabIndex = 8;
            this.cameraIdLbl.Text = "123456";
            // 
            // cameraIdTextLbl
            // 
            this.cameraIdTextLbl.AutoSize = true;
            this.cameraIdTextLbl.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraIdTextLbl.Location = new System.Drawing.Point(9, 56);
            this.cameraIdTextLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cameraIdTextLbl.Name = "cameraIdTextLbl";
            this.cameraIdTextLbl.Size = new System.Drawing.Size(80, 17);
            this.cameraIdTextLbl.TabIndex = 6;
            this.cameraIdTextLbl.Text = "ID Kamery:";
            // 
            // badgeIdTextLbl
            // 
            this.badgeIdTextLbl.AutoSize = true;
            this.badgeIdTextLbl.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.badgeIdTextLbl.Location = new System.Drawing.Point(4, 27);
            this.badgeIdTextLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.badgeIdTextLbl.Name = "badgeIdTextLbl";
            this.badgeIdTextLbl.Size = new System.Drawing.Size(95, 17);
            this.badgeIdTextLbl.TabIndex = 5;
            this.badgeIdTextLbl.Text = "NR Odznaki: ";
            // 
            // cameraItemMenuStrip
            // 
            this.cameraItemMenuStrip.BackColor = System.Drawing.Color.Silver;
            this.cameraItemMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cameraItemMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oprogramowanieToolStripMenuItem});
            this.cameraItemMenuStrip.Name = "cameraItemMenuStrip";
            this.cameraItemMenuStrip.Size = new System.Drawing.Size(215, 58);
            // 
            // oprogramowanieToolStripMenuItem
            // 
            this.oprogramowanieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upgradeMenuItem});
            this.oprogramowanieToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("oprogramowanieToolStripMenuItem.Image")));
            this.oprogramowanieToolStripMenuItem.Name = "oprogramowanieToolStripMenuItem";
            this.oprogramowanieToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.oprogramowanieToolStripMenuItem.Text = "Oprogramowanie";
            // 
            // upgradeMenuItem
            // 
            this.upgradeMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("upgradeMenuItem.Image")));
            this.upgradeMenuItem.Name = "upgradeMenuItem";
            this.upgradeMenuItem.Size = new System.Drawing.Size(224, 26);
            this.upgradeMenuItem.Text = "Aktualizacja";
            // 
            // nasStorageFileDialog
            // 
            this.nasStorageFileDialog.FileName = "Wybierz pliki które chcesz skopiować";
            this.nasStorageFileDialog.Multiselect = true;
            // 
            // CameraItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ContextMenuStrip = this.cameraItemMenuStrip;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CameraItem";
            this.Size = new System.Drawing.Size(248, 244);
            this.Load += new System.EventHandler(this.CameraItem_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.cameraItemMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox statusIcon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ContextMenuStrip cameraItemMenuStrip;
        private System.Windows.Forms.FolderBrowserDialog targetDriveDevicePathDialog;
        private System.Windows.Forms.OpenFileDialog nasStorageFileDialog;
        private System.Windows.Forms.Label badgeIdLbl;
        private System.Windows.Forms.Label cameraIdLbl;
        private System.Windows.Forms.Label cameraIdTextLbl;
        private System.Windows.Forms.Label badgeIdTextLbl;
        private MetroFramework.Controls.MetroButton settingsBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem oprogramowanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upgradeMenuItem;
    }
}
