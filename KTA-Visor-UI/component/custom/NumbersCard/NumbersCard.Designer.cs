namespace KTA_Visor_UI.component.custom.NumbersCard
{
    partial class NumbersCard
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.numberLbl = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // numberLbl
            // 
            this.numberLbl.BackColor = System.Drawing.Color.Transparent;
            this.numberLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numberLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.numberLbl.Font = new System.Drawing.Font("Inter", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberLbl.ForeColor = System.Drawing.Color.White;
            this.numberLbl.Location = new System.Drawing.Point(0, 0);
            this.numberLbl.Name = "numberLbl";
            this.numberLbl.Size = new System.Drawing.Size(532, 76);
            this.numberLbl.TabIndex = 0;
            this.numberLbl.Text = "8";
            this.numberLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numberLbl.MouseEnter += new System.EventHandler(this.numberLbl_MouseEnter);
            this.numberLbl.MouseLeave += new System.EventHandler(this.numberLbl_MouseLeave);
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label.Font = new System.Drawing.Font("Inter", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(0, 76);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(532, 53);
            this.label.TabIndex = 1;
            this.label.Text = "Label";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.label.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(532, 129);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.MouseEnter += new System.EventHandler(this.mainPanel_MouseEnter);
            this.mainPanel.MouseLeave += new System.EventHandler(this.mainPanel_MouseLeave);
            // 
            // NumbersCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.Controls.Add(this.numberLbl);
            this.Controls.Add(this.label);
            this.Controls.Add(this.mainPanel);
            this.Name = "NumbersCard";
            this.Size = new System.Drawing.Size(532, 129);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label numberLbl;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel mainPanel;
    }
}
