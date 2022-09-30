namespace KTA_Visor_UI.component.basic.progressbar
{
    partial class FullScreenHorizontalLoader
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
            this.improvedProgressBar1 = new KTA_Visor_UI.component.basic.progressbar.ImprovedProgressBar();
            this.SuspendLayout();
            // 
            // improvedProgressBar1
            // 
            this.improvedProgressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(185)))), ((int)(((byte)(11)))));
            this.improvedProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(185)))), ((int)(((byte)(11)))));
            this.improvedProgressBar1.Location = new System.Drawing.Point(330, 362);
            this.improvedProgressBar1.Name = "improvedProgressBar1";
            this.improvedProgressBar1.Size = new System.Drawing.Size(380, 23);
            this.improvedProgressBar1.TabIndex = 0;
            // 
            // FullScreenHorizontalLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.improvedProgressBar1);
            this.Name = "FullScreenHorizontalLoader";
            this.Size = new System.Drawing.Size(1115, 927);
            this.ResumeLayout(false);

        }

        #endregion
        private ImprovedProgressBar improvedProgressBar1;
    }
}
