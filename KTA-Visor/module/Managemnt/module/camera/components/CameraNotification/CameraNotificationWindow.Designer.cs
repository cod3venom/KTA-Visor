namespace KTA_Visor.module.Managemnt.module.camera.components.CameraNotification
{
    partial class CameraNotificationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraNotificationWindow));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.badgeLbl = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.openBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // badgeLbl
            // 
            this.badgeLbl.Font = new System.Drawing.Font("Inter SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.badgeLbl.Location = new System.Drawing.Point(46, 55);
            this.badgeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.badgeLbl.Name = "badgeLbl";
            this.badgeLbl.Size = new System.Drawing.Size(206, 13);
            this.badgeLbl.TabIndex = 7;
            this.badgeLbl.Text = "123456";
            this.badgeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(9, 46);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 37);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
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
            this.openBtn.Location = new System.Drawing.Point(192, 90);
            this.openBtn.Name = "openBtn";
            this.openBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.openBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.openBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.openBtn.selected = false;
            this.openBtn.Size = new System.Drawing.Size(60, 15);
            this.openBtn.TabIndex = 8;
            this.openBtn.Text = "Otwórz";
            this.openBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.openBtn.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(84)))), ((int)(((byte)(89)))));
            this.openBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // topBar1
            // 
            this.topBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(262, 28);
            this.topBar1.TabIndex = 0;
            this.topBar1.Title = "Window";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 10);
            this.panel1.TabIndex = 9;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // CameraNotificationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 125);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.badgeLbl);
            this.Controls.Add(this.topBar1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CameraNotificationWindow";
            this.Text = " ";
            this.Load += new System.EventHandler(this.CameraNotificationWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label badgeLbl;
        private Bunifu.Framework.UI.BunifuFlatButton openBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}