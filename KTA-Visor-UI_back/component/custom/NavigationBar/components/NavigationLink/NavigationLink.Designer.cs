namespace KTA_Visor_UI.component.custom.NavigationBar.components
{
    partial class NavigationLink
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
            this.linkLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("Inter Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(128)))), ((int)(((byte)(226)))));
            this.linkLabel.Location = new System.Drawing.Point(8, 9);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(62, 20);
            this.linkLabel.TabIndex = 0;
            this.linkLabel.Text = "label1";
            this.linkLabel.MouseEnter += new System.EventHandler(this.linkLabel_MouseEnter);
            this.linkLabel.MouseLeave += new System.EventHandler(this.linkLabel_MouseLeave);
            // 
            // NavigationLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.linkLabel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "NavigationLink";
            this.Size = new System.Drawing.Size(78, 39);
            this.Load += new System.EventHandler(this.NavigationLink_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label linkLabel;
    }
}
