namespace KTA_Visor_UI.component.basic.topbar
{
    partial class TopBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopBar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.titleLbl = new System.Windows.Forms.Label();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.minimizeBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.resizeBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.closeBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl3 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.descriptionLbl);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 44);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.titleLbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 42);
            this.panel3.TabIndex = 2;
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.titleLbl.Font = new System.Drawing.Font("Inter ExtraBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(150)))), ((int)(((byte)(158)))));
            this.titleLbl.Location = new System.Drawing.Point(2, 10);
            this.titleLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(56, 14);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "KTAvisor";
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.descriptionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionLbl.Font = new System.Drawing.Font("Inter Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(150)))), ((int)(((byte)(158)))));
            this.descriptionLbl.Location = new System.Drawing.Point(0, 0);
            this.descriptionLbl.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Padding = new System.Windows.Forms.Padding(150, 0, 0, 0);
            this.descriptionLbl.Size = new System.Drawing.Size(825, 42);
            this.descriptionLbl.TabIndex = 1;
            this.descriptionLbl.Text = "Window";
            this.descriptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(115)))), ((int)(((byte)(119)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(825, 2);
            this.panel4.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.minimizeBtn);
            this.panel2.Controls.Add(this.resizeBtn);
            this.panel2.Controls.Add(this.closeBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(825, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(118, 44);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(115)))), ((int)(((byte)(119)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 42);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(118, 2);
            this.panel5.TabIndex = 6;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.Color.Transparent;
            this.minimizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("minimizeBtn.Image")));
            this.minimizeBtn.ImageActive = null;
            this.minimizeBtn.Location = new System.Drawing.Point(16, 10);
            this.minimizeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(15, 16);
            this.minimizeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimizeBtn.TabIndex = 5;
            this.minimizeBtn.TabStop = false;
            this.minimizeBtn.Zoom = 1;
            // 
            // resizeBtn
            // 
            this.resizeBtn.BackColor = System.Drawing.Color.Transparent;
            this.resizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("resizeBtn.Image")));
            this.resizeBtn.ImageActive = null;
            this.resizeBtn.Location = new System.Drawing.Point(53, 10);
            this.resizeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.resizeBtn.Name = "resizeBtn";
            this.resizeBtn.Size = new System.Drawing.Size(15, 16);
            this.resizeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resizeBtn.TabIndex = 4;
            this.resizeBtn.TabStop = false;
            this.resizeBtn.Zoom = 1;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.ImageActive = null;
            this.closeBtn.Location = new System.Drawing.Point(89, 10);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(15, 16);
            this.closeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeBtn.TabIndex = 3;
            this.closeBtn.TabStop = false;
            this.closeBtn.Zoom = 1;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.descriptionLbl;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuDragControl3
            // 
            this.bunifuDragControl3.Fixed = true;
            this.bunifuDragControl3.Horizontal = true;
            this.bunifuDragControl3.TargetControl = this.panel2;
            this.bunifuDragControl3.Vertical = true;
            // 
            // TopBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TopBar";
            this.Size = new System.Drawing.Size(943, 44);
            this.Load += new System.EventHandler(this.TopBar_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
        private Bunifu.Framework.UI.BunifuImageButton closeBtn;
        private Bunifu.Framework.UI.BunifuImageButton minimizeBtn;
        private Bunifu.Framework.UI.BunifuImageButton resizeBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}
