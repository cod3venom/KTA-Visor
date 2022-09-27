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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.bunifuBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bunifuBtn.Name = "bunifuBtn";
            this.bunifuBtn.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.bunifuBtn.Size = new System.Drawing.Size(52, 57);
            this.bunifuBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bunifuBtn.TabIndex = 0;
            this.bunifuBtn.TabStop = false;
            this.bunifuBtn.WaitOnLoad = true;
            this.bunifuBtn.Zoom = 4;
            this.bunifuBtn.MouseEnter += new System.EventHandler(this.bunifuBtn_MouseEnter);
            this.bunifuBtn.MouseLeave += new System.EventHandler(this.bunifuBtn_MouseLeave);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.BackColor = System.Drawing.Color.Black;
            this.toolTip1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.StripAmpersands = true;
            // 
            // CircleImageButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuBtn);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CircleImageButton";
            this.Size = new System.Drawing.Size(52, 57);
            this.Load += new System.EventHandler(this.CircleImageButton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuBtn;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
