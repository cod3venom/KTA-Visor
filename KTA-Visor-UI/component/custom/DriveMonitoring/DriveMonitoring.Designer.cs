namespace KTA_Visor_UI.component.custom.DriveMonitoring
{
    partial class DriveMonitoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriveMonitoring));
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.driveSpaceLbl = new System.Windows.Forms.Label();
            this.driveLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Location = new System.Drawing.Point(13, 22);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(289, 23);
            this.metroProgressBar1.TabIndex = 0;
            // 
            // driveSpaceLbl
            // 
            this.driveSpaceLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.driveSpaceLbl.Font = new System.Drawing.Font("Inter", 8.25F);
            this.driveSpaceLbl.Location = new System.Drawing.Point(0, 48);
            this.driveSpaceLbl.Name = "driveSpaceLbl";
            this.driveSpaceLbl.Size = new System.Drawing.Size(320, 24);
            this.driveSpaceLbl.TabIndex = 2;
            this.driveSpaceLbl.Text = "106GB/250GB";
            this.driveSpaceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // driveLbl
            // 
            this.driveLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.driveLbl.Location = new System.Drawing.Point(0, 0);
            this.driveLbl.Name = "driveLbl";
            this.driveLbl.Size = new System.Drawing.Size(320, 19);
            this.driveLbl.TabIndex = 1;
            this.driveLbl.Text = "NAS";
            this.driveLbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(291, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // DriveMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.driveSpaceLbl);
            this.Controls.Add(this.driveLbl);
            this.Name = "DriveMonitoring";
            this.Size = new System.Drawing.Size(320, 72);
            this.Load += new System.EventHandler(this.DriveMonitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private System.Windows.Forms.Label driveLbl;
        private System.Windows.Forms.Label driveSpaceLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
