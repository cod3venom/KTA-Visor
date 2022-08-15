namespace KTA_Visor.module.Station.components.StationItem
{
    partial class StationItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StationItem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.openBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ipAddressLbl = new System.Windows.Forms.Label();
            this.stationNameLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 107);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(314, 107);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.openBtn);
            this.panel2.Controls.Add(this.ipAddressLbl);
            this.panel2.Controls.Add(this.stationNameLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(314, 94);
            this.panel2.TabIndex = 1;
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
            this.openBtn.Location = new System.Drawing.Point(82, 64);
            this.openBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openBtn.Name = "openBtn";
            this.openBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.openBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.openBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.openBtn.selected = false;
            this.openBtn.Size = new System.Drawing.Size(138, 26);
            this.openBtn.TabIndex = 7;
            this.openBtn.Text = "Otwórz";
            this.openBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.openBtn.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(84)))), ((int)(((byte)(89)))));
            this.openBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ipAddressLbl
            // 
            this.ipAddressLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ipAddressLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressLbl.Location = new System.Drawing.Point(0, 19);
            this.ipAddressLbl.Name = "ipAddressLbl";
            this.ipAddressLbl.Size = new System.Drawing.Size(314, 16);
            this.ipAddressLbl.TabIndex = 6;
            this.ipAddressLbl.Text = "127.0.0.1";
            this.ipAddressLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stationNameLbl
            // 
            this.stationNameLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.stationNameLbl.Font = new System.Drawing.Font("Inter SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationNameLbl.Location = new System.Drawing.Point(0, 0);
            this.stationNameLbl.Name = "stationNameLbl";
            this.stationNameLbl.Size = new System.Drawing.Size(314, 19);
            this.stationNameLbl.TabIndex = 5;
            this.stationNameLbl.Text = "Stacja 1";
            this.stationNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StationItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "StationItem";
            this.Size = new System.Drawing.Size(314, 201);
            this.Load += new System.EventHandler(this.StationItem_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuFlatButton openBtn;
        private System.Windows.Forms.Label ipAddressLbl;
        private System.Windows.Forms.Label stationNameLbl;
    }
}
