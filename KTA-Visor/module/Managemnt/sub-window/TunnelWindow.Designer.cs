namespace KTA_Visor.module.Managemnt.sub_window
{
    partial class TunnelWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TunnelWindow));
            this.panel3 = new System.Windows.Forms.Panel();
            this.stopBtn = new System.Windows.Forms.PictureBox();
            this.startBtn = new System.Windows.Forms.PictureBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeBtn = new MetroFramework.Controls.MetroButton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startBtn)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.stopBtn);
            this.panel3.Controls.Add(this.startBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(23, 35);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(697, 40);
            this.panel3.TabIndex = 4;
            // 
            // stopBtn
            // 
            this.stopBtn.Image = ((System.Drawing.Image)(resources.GetObject("stopBtn.Image")));
            this.stopBtn.Location = new System.Drawing.Point(35, 10);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(23, 24);
            this.stopBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.stopBtn.TabIndex = 6;
            this.stopBtn.TabStop = false;
            // 
            // startBtn
            // 
            this.startBtn.Image = ((System.Drawing.Image)(resources.GetObject("startBtn.Image")));
            this.startBtn.Location = new System.Drawing.Point(6, 10);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(23, 24);
            this.startBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.startBtn.TabIndex = 5;
            this.startBtn.TabStop = false;
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.Color.White;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(23, 75);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(697, 257);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.closeBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(23, 332);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 33);
            this.panel1.TabIndex = 5;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(599, 6);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(85, 23);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "Zamknij";
            this.closeBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.closeBtn.UseSelectable = true;
            // 
            // TunnelWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 387);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.DisplayHeader = false;
            this.Font = new System.Drawing.Font("Inter", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TunnelWindow";
            this.Padding = new System.Windows.Forms.Padding(23, 35, 23, 22);
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "TunnelWindow";
            this.Load += new System.EventHandler(this.TunnelWindow_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stopBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startBtn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton closeBtn;
        private System.Windows.Forms.PictureBox startBtn;
        private System.Windows.Forms.PictureBox stopBtn;
    }
}