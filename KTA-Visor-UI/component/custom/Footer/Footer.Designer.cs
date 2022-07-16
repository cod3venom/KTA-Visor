namespace KTA_Visor_UI.component.custom.Footer
{
    partial class Footer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Footer));
            this.sfBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sfBtn)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sfBtn
            // 
            this.sfBtn.BackColor = System.Drawing.Color.Transparent;
            this.sfBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sfBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.sfBtn.Image = ((System.Drawing.Image)(resources.GetObject("sfBtn.Image")));
            this.sfBtn.ImageActive = null;
            this.sfBtn.Location = new System.Drawing.Point(1004, 0);
            this.sfBtn.Name = "sfBtn";
            this.sfBtn.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.sfBtn.Size = new System.Drawing.Size(103, 35);
            this.sfBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.sfBtn.TabIndex = 1;
            this.sfBtn.TabStop = false;
            this.sfBtn.Zoom = 10;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(1107, 0);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(13, 35);
            this.bunifuSeparator1.TabIndex = 2;
            this.bunifuSeparator1.Transparency = 0;
            this.bunifuSeparator1.Vertical = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 35);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 35);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(84)))), ((int)(((byte)(89)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(150, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(1004, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "KTA-Visor all rights reserved 2022 ©";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Footer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sfBtn);
            this.Controls.Add(this.bunifuSeparator1);
            this.Name = "Footer";
            this.Size = new System.Drawing.Size(1120, 35);
            this.Load += new System.EventHandler(this.Footer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfBtn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton sfBtn;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}
