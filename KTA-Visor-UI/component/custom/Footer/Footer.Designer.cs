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
            ((System.ComponentModel.ISupportInitialize)(this.sfBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // sfBtn
            // 
            this.sfBtn.BackColor = System.Drawing.Color.Transparent;
            this.sfBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sfBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.sfBtn.Image = ((System.Drawing.Image)(resources.GetObject("sfBtn.Image")));
            this.sfBtn.ImageActive = null;
            this.sfBtn.Location = new System.Drawing.Point(986, 0);
            this.sfBtn.Name = "sfBtn";
            this.sfBtn.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.sfBtn.Size = new System.Drawing.Size(93, 47);
            this.sfBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sfBtn.TabIndex = 1;
            this.sfBtn.TabStop = false;
            this.sfBtn.Zoom = 10;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(1079, 0);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(41, 47);
            this.bunifuSeparator1.TabIndex = 2;
            this.bunifuSeparator1.Transparency = 0;
            this.bunifuSeparator1.Vertical = true;
            // 
            // Footer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.Controls.Add(this.sfBtn);
            this.Controls.Add(this.bunifuSeparator1);
            this.Name = "Footer";
            this.Size = new System.Drawing.Size(1120, 47);
            this.Load += new System.EventHandler(this.Footer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton sfBtn;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
    }
}
