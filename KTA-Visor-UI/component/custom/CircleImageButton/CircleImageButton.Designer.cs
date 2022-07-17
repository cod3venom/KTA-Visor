namespace KTA_Visor_UI.component.custom.CircleImageButton
{
    partial class CircleImageButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CircleImageButton));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuBtn = new Bunifu.Framework.UI.BunifuImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 70;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuBtn
            // 
            this.bunifuBtn.BackColor = System.Drawing.Color.White;
            this.bunifuBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuBtn.Image = ((System.Drawing.Image)(resources.GetObject("bunifuBtn.Image")));
            this.bunifuBtn.ImageActive = null;
            this.bunifuBtn.Location = new System.Drawing.Point(0, 0);
            this.bunifuBtn.Name = "bunifuBtn";
            this.bunifuBtn.Padding = new System.Windows.Forms.Padding(8);
            this.bunifuBtn.Size = new System.Drawing.Size(70, 70);
            this.bunifuBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bunifuBtn.TabIndex = 0;
            this.bunifuBtn.TabStop = false;
            this.bunifuBtn.WaitOnLoad = true;
            this.bunifuBtn.Zoom = 4;
            this.bunifuBtn.MouseEnter += new System.EventHandler(this.bunifuBtn_MouseEnter);
            this.bunifuBtn.MouseLeave += new System.EventHandler(this.bunifuBtn_MouseLeave);
            // 
            // CircleImageButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuBtn);
            this.Name = "CircleImageButton";
            this.Size = new System.Drawing.Size(70, 70);
            this.Load += new System.EventHandler(this.CircleImageButton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuBtn;
    }
}
