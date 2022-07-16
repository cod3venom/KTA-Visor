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
            this.SuspendLayout();
            // 
            // bunifuProgressBar
            // 
            this.bunifuProgressBar.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar.BorderRadius = 0;
            this.bunifuProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuProgressBar.Location = new System.Drawing.Point(0, 0);
            this.bunifuProgressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuProgressBar.MaximumValue = 100;
            this.bunifuProgressBar.Name = "bunifuProgressBar";
            this.bunifuProgressBar.ProgressColor = System.Drawing.Color.White;
            this.bunifuProgressBar.Size = new System.Drawing.Size(310, 10);
            this.bunifuProgressBar.TabIndex = 0;
            this.bunifuProgressBar.Value = 0;
            // 
            // bunifuElipse
            // 
            this.bunifuElipse.ElipseRadius = 5;
            this.bunifuElipse.TargetControl = this;
            // 
            // HorizontalProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.Controls.Add(this.bunifuProgressBar);
            this.Name = "HorizontalProgressBar";
            this.Size = new System.Drawing.Size(310, 10);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse;
    }
}
