namespace KTA_Visor_UI.component.custom.HorizontalProgressBar
{
    partial class HorizontalProgressBar
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
            this.bunifuProgressBar = new Bunifu.Framework.UI.BunifuProgressBar();
            this.bunifuElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.percentageLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bunifuProgressBar
            // 
            this.bunifuProgressBar.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar.BorderRadius = 0;
            this.bunifuProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuProgressBar.Location = new System.Drawing.Point(0, 0);
            this.bunifuProgressBar.MaximumValue = 100;
            this.bunifuProgressBar.Name = "bunifuProgressBar";
            this.bunifuProgressBar.ProgressColor = System.Drawing.Color.White;
            this.bunifuProgressBar.Size = new System.Drawing.Size(232, 22);
            this.bunifuProgressBar.TabIndex = 0;
            this.bunifuProgressBar.Value = 0;
            // 
            // bunifuElipse
            // 
            this.bunifuElipse.ElipseRadius = 5;
            this.bunifuElipse.TargetControl = this;
            // 
            // percentageLbl
            // 
            this.percentageLbl.BackColor = System.Drawing.Color.Transparent;
            this.percentageLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.percentageLbl.Font = new System.Drawing.Font("Inter Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentageLbl.ForeColor = System.Drawing.Color.White;
            this.percentageLbl.Location = new System.Drawing.Point(0, 0);
            this.percentageLbl.Name = "percentageLbl";
            this.percentageLbl.Size = new System.Drawing.Size(232, 13);
            this.percentageLbl.TabIndex = 1;
            this.percentageLbl.Text = "0%";
            this.percentageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.percentageLbl.Visible = false;
            // 
            // HorizontalProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.Controls.Add(this.percentageLbl);
            this.Controls.Add(this.bunifuProgressBar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HorizontalProgressBar";
            this.Size = new System.Drawing.Size(232, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse;
        private System.Windows.Forms.Label percentageLbl;
    }
}
