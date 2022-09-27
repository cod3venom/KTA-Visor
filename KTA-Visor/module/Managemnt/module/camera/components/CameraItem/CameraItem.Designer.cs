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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.batteryLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.stationIdLbl = new System.Windows.Forms.Label();
            this.badgeIdLbl = new System.Windows.Forms.Label();
            this.cameraIdLbl = new System.Windows.Forms.Label();
            this.stationIdTextLbl = new System.Windows.Forms.Label();
            this.cameraIdTextLbl = new System.Windows.Forms.Label();
            this.badgeIdTextLbl = new System.Windows.Forms.Label();
            this.openBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.cameraItemMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.systemPlikówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFilesToUSBMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFilesToDVDMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetDriveDevicePathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.nasStorageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cameraIndexLbl = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.cameraItemMenuStrip.SuspendLayout();
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
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.batteryLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 27);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(207, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // batteryLbl
            // 
            this.batteryLbl.AutoSize = true;
            this.batteryLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batteryLbl.Location = new System.Drawing.Point(231, 8);
            this.batteryLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.batteryLbl.Name = "batteryLbl";
            this.batteryLbl.Size = new System.Drawing.Size(28, 14);
            this.batteryLbl.TabIndex = 0;
            this.batteryLbl.Text = "10%";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cameraIndexLbl);
            this.panel3.Controls.Add(this.stationIdLbl);
            this.panel3.Controls.Add(this.badgeIdLbl);
            this.panel3.Controls.Add(this.cameraIdLbl);
            this.panel3.Controls.Add(this.stationIdTextLbl);
            this.panel3.Controls.Add(this.cameraIdTextLbl);
            this.panel3.Controls.Add(this.badgeIdTextLbl);
            this.panel3.Controls.Add(this.openBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 125);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 135);
            this.panel3.TabIndex = 5;
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
            // openBtn
            // 
            this.openBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.openBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.openBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openBtn.BorderRadius = 0;
            this.openBtn.ButtonText = "Otwórz";
            this.openBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openBtn.DisabledColor = System.Drawing.Color.Gray;
            this.openBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.openBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(84)))), ((int)(((byte)(89)))));
            this.openBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.openBtn.Iconimage = null;
            this.openBtn.Iconimage_right = null;
            this.openBtn.Iconimage_right_Selected = null;
            this.openBtn.Iconimage_Selected = null;
            this.openBtn.IconMarginLeft = 0;
            this.openBtn.IconMarginRight = 0;
            this.openBtn.IconRightVisible = true;
            this.openBtn.IconRightZoom = 0D;
            this.openBtn.IconVisible = true;
            this.openBtn.IconZoom = 90D;
            this.openBtn.IsTab = false;
            this.openBtn.Location = new System.Drawing.Point(0, 114);
            this.openBtn.Name = "openBtn";
            this.openBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.openBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.openBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.openBtn.selected = false;
            this.openBtn.Size = new System.Drawing.Size(265, 21);
            this.openBtn.TabIndex = 4;
            this.openBtn.Text = "Otwórz";
            this.openBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.openBtn.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(84)))), ((int)(((byte)(89)))));
            this.openBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // cameraIndexLbl
            // 
            this.cameraIndexLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.cameraIndexLbl.Font = new System.Drawing.Font("Inter SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraIndexLbl.Location = new System.Drawing.Point(248, 0);
            this.cameraIndexLbl.Name = "cameraIndexLbl";
            this.cameraIndexLbl.Size = new System.Drawing.Size(17, 114);
            this.cameraIndexLbl.TabIndex = 12;
            this.cameraIndexLbl.Text = "-1";
            this.cameraIndexLbl.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.cameraItemMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label batteryLbl;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuFlatButton openBtn;
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
    }
}
