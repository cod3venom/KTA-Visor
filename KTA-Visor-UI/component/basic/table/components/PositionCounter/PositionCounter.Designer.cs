namespace KTA_Visor_UI.component.basic.table.components.RowPosCounter
{
    partial class PositionCounter
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
            this.currentLBL = new System.Windows.Forms.Label();
            this.totalLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // currentLBL
            // 
            this.currentLBL.AutoSize = true;
            this.currentLBL.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLBL.Location = new System.Drawing.Point(7, 5);
            this.currentLBL.Name = "currentLBL";
            this.currentLBL.Size = new System.Drawing.Size(18, 19);
            this.currentLBL.TabIndex = 0;
            this.currentLBL.Text = "0";
            // 
            // totalLbl
            // 
            this.totalLbl.AutoSize = true;
            this.totalLbl.Font = new System.Drawing.Font("Inter", 9F);
            this.totalLbl.Location = new System.Drawing.Point(37, 5);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(34, 19);
            this.totalLbl.TabIndex = 1;
            this.totalLbl.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter", 9F);
            this.label3.Location = new System.Drawing.Point(24, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "/";
            // 
            // PositionCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.totalLbl);
            this.Controls.Add(this.currentLBL);
            this.Name = "PositionCounter";
            this.Size = new System.Drawing.Size(77, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentLBL;
        private System.Windows.Forms.Label totalLbl;
        private System.Windows.Forms.Label label3;
    }
}
