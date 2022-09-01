namespace KTA_Visor_DSClient.module.Management.module.Camera.component.CameraItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraItem));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.batteryLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.openBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.badgeLbl = new System.Windows.Forms.Label();
            this.cameraDriveLbl = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(201, 83);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.batteryLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 33);
            this.panel1.TabIndex = 3;
            // 
            // batteryLbl
            // 
            this.batteryLbl.AutoSize = true;
            this.batteryLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batteryLbl.Location = new System.Drawing.Point(162, 10);
            this.batteryLbl.Name = "batteryLbl";
            this.batteryLbl.Size = new System.Drawing.Size(32, 16);
            this.batteryLbl.TabIndex = 0;
            this.batteryLbl.Text = "10%";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cameraDriveLbl);
            this.panel3.Controls.Add(this.badgeLbl);
            this.panel3.Controls.Add(this.openBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(201, 121);
            this.panel3.TabIndex = 5;
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
            this.openBtn.Location = new System.Drawing.Point(36, 86);
            this.openBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openBtn.Name = "openBtn";
            this.openBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.openBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.openBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.openBtn.selected = false;
            this.openBtn.Size = new System.Drawing.Size(138, 26);
            this.openBtn.TabIndex = 4;
            this.openBtn.Text = "Otwórz";
            this.openBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.openBtn.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(84)))), ((int)(((byte)(89)))));
            this.openBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // badgeLbl
            // 
            this.badgeLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.badgeLbl.Font = new System.Drawing.Font("Inter SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.badgeLbl.Location = new System.Drawing.Point(0, 0);
            this.badgeLbl.Name = "badgeLbl";
            this.badgeLbl.Size = new System.Drawing.Size(201, 16);
            this.badgeLbl.TabIndex = 5;
            this.badgeLbl.Text = "123456";
            this.badgeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cameraDriveLbl
            // 
            this.cameraDriveLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.cameraDriveLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraDriveLbl.Location = new System.Drawing.Point(0, 16);
            this.cameraDriveLbl.Name = "cameraDriveLbl";
            this.cameraDriveLbl.Size = new System.Drawing.Size(201, 16);
            this.cameraDriveLbl.TabIndex = 2;
            this.cameraDriveLbl.Text = "F:\\";
            this.cameraDriveLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(69, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(62, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(70, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(62, 0);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(130, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // CameraItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "CameraItem";
            this.Size = new System.Drawing.Size(201, 237);
            this.Load += new System.EventHandler(this.CameraItem_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label batteryLbl;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuFlatButton openBtn;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label cameraDriveLbl;
        private System.Windows.Forms.Label badgeLbl;
    }
}
