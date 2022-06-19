namespace KTA_Visor_UI.component.custom.VerticalTab.components.MenuLink
{
    partial class MenuLink
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
            this.labelLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelLbl
            // 
            this.labelLbl.AutoSize = true;
            this.labelLbl.Font = new System.Drawing.Font("Inter", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(170)))));
            this.labelLbl.Location = new System.Drawing.Point(9, 10);
            this.labelLbl.Name = "labelLbl";
            this.labelLbl.Size = new System.Drawing.Size(57, 21);
            this.labelLbl.TabIndex = 0;
            this.labelLbl.Text = "label1";
            // 
            // MenuLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.labelLbl);
            this.Name = "MenuLink";
            this.Size = new System.Drawing.Size(81, 39);
            this.Load += new System.EventHandler(this.MenuLink_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLbl;
    }
}
