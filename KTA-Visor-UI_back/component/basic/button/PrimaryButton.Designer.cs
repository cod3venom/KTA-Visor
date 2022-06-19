namespace KTA_Visor_UI.component.basic.button
{
    partial class PrimaryButton
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
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button.FlatAppearance.BorderSize = 0;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button.Font = new System.Drawing.Font("Inter", 8.2F);
            this.button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.button.Location = new System.Drawing.Point(0, 0);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(145, 31);
            this.button.TabIndex = 0;
            this.button.Text = "Save";
            this.button.UseVisualStyleBackColor = false;
            this.button.MouseHover += new System.EventHandler(this.button_MouseHover);
            // 
            // PrimaryButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button);
            this.Name = "PrimaryButton";
            this.Size = new System.Drawing.Size(145, 31);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button;
    }
}
