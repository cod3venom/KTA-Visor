namespace KTA_Visor.module.Managemnt.module.cardReader.window
{
    partial class CardModeWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardModeWindow));
            this.cardModeLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.closeBtn = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cardIdtxt = new System.Windows.Forms.TextBox();
            this.cardTxtPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cardTxtPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardModeLbl
            // 
            this.cardModeLbl.AutoSize = true;
            this.cardModeLbl.Font = new System.Drawing.Font("Inter", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardModeLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(180)))), ((int)(((byte)(243)))));
            this.cardModeLbl.Location = new System.Drawing.Point(582, 6);
            this.cardModeLbl.Name = "cardModeLbl";
            this.cardModeLbl.Size = new System.Drawing.Size(194, 34);
            this.cardModeLbl.TabIndex = 0;
            this.cardModeLbl.Text = "TRYB KARTY";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cardTxtPanel);
            this.panel1.Controls.Add(this.cardModeLbl);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 478);
            this.panel1.TabIndex = 1;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.closeBtn);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(20, 508);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(780, 52);
            this.footerPanel.TabIndex = 2;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(617, 17);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(129, 23);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "Zamknij";
            this.closeBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.closeBtn.UseSelectable = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(780, 478);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cardIdtxt
            // 
            this.cardIdtxt.Location = new System.Drawing.Point(17, 21);
            this.cardIdtxt.Name = "cardIdtxt";
            this.cardIdtxt.Size = new System.Drawing.Size(194, 22);
            this.cardIdtxt.TabIndex = 1;
            this.cardIdtxt.UseSystemPasswordChar = true;
            // 
            // cardTxtPanel
            // 
            this.cardTxtPanel.Controls.Add(this.cardIdtxt);
            this.cardTxtPanel.Location = new System.Drawing.Point(272, 203);
            this.cardTxtPanel.Name = "cardTxtPanel";
            this.cardTxtPanel.Size = new System.Drawing.Size(231, 61);
            this.cardTxtPanel.TabIndex = 2;
            // 
            // CardModeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 580);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.footerPanel);
            this.DisplayHeader = false;
            this.DoubleBuffered = false;
            this.Name = "CardModeWindow";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "CardModeWindow";
            this.Load += new System.EventHandler(this.CardModeWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cardTxtPanel.ResumeLayout(false);
            this.cardTxtPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label cardModeLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel footerPanel;
        private MetroFramework.Controls.MetroButton closeBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox cardIdtxt;
        private System.Windows.Forms.Panel cardTxtPanel;
    }
}