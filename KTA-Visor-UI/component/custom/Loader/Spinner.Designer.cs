namespace KTA_Visor_UI.component.custom.Spinner
{
    partial class Spinner
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
            this.spinnerBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // spinnerBox
            // 
            this.spinnerBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinnerBox.Image = global::KTA_Visor_UI.Properties.Resources.Spinner1;
            this.spinnerBox.Location = new System.Drawing.Point(0, 0);
            this.spinnerBox.Name = "spinnerBox";
            this.spinnerBox.Size = new System.Drawing.Size(56, 54);
            this.spinnerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spinnerBox.TabIndex = 0;
            this.spinnerBox.TabStop = false;
            // 
            // Spinner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spinnerBox);
            this.Name = "Spinner";
            this.Size = new System.Drawing.Size(56, 54);
            this.Load += new System.EventHandler(this.Spinner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinnerBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox spinnerBox;
    }
}
