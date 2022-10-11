namespace KTA_Visor_UI.component.basic.progressbar
{
    partial class ImprovedProgressBarWithPercentage
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
            this.percentageLbl = new System.Windows.Forms.Label();
            this.improvedProgressBar1 = new KTA_Visor_UI.component.basic.progressbar.ImprovedProgressBar();
            this.SuspendLayout();
            // 
            // percentageLbl
            // 
            this.percentageLbl.BackColor = System.Drawing.Color.Transparent;
            this.percentageLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.percentageLbl.Font = new System.Drawing.Font("Inter Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentageLbl.Location = new System.Drawing.Point(365, 0);
            this.percentageLbl.Name = "percentageLbl";
            this.percentageLbl.Size = new System.Drawing.Size(47, 28);
            this.percentageLbl.TabIndex = 1;
            this.percentageLbl.Text = "0%";
            this.percentageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // improvedProgressBar1
            // 
            this.improvedProgressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(185)))), ((int)(((byte)(11)))));
            this.improvedProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.improvedProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(185)))), ((int)(((byte)(11)))));
            this.improvedProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.improvedProgressBar1.Name = "improvedProgressBar1";
            this.improvedProgressBar1.Size = new System.Drawing.Size(412, 28);
            this.improvedProgressBar1.TabIndex = 0;
            // 
            // ImprovedProgressBarWithPercentage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.percentageLbl);
            this.Controls.Add(this.improvedProgressBar1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "ImprovedProgressBarWithPercentage";
            this.Size = new System.Drawing.Size(412, 28);
            this.Load += new System.EventHandler(this.ImprovedProgressBarWithTitle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ImprovedProgressBar improvedProgressBar1;
        private System.Windows.Forms.Label percentageLbl;
    }
}
