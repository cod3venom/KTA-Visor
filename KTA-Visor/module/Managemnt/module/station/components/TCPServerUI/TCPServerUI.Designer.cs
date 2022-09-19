namespace KTA_Visor.module.Station.components.TCPServerUI
{
    partial class TCPServerUI
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
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.serverStatuslbl = new System.Windows.Forms.Label();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.stopListeningBtn = new System.Windows.Forms.Button();
            this.startListeningBTN = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(193)))), ((int)(((byte)(229)))));
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Font = new System.Drawing.Font("Inter SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.Location = new System.Drawing.Point(0, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(1265, 398);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.serverStatuslbl);
            this.panel1.Controls.Add(this.bunifuSeparator2);
            this.panel1.Controls.Add(this.bunifuSeparator1);
            this.panel1.Controls.Add(this.stopListeningBtn);
            this.panel1.Controls.Add(this.startListeningBTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1265, 62);
            this.panel1.TabIndex = 3;
            // 
            // serverStatuslbl
            // 
            this.serverStatuslbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverStatuslbl.AutoSize = true;
            this.serverStatuslbl.Font = new System.Drawing.Font("Inter SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverStatuslbl.ForeColor = System.Drawing.Color.White;
            this.serverStatuslbl.Location = new System.Drawing.Point(1199, 22);
            this.serverStatuslbl.Name = "serverStatuslbl";
            this.serverStatuslbl.Size = new System.Drawing.Size(47, 16);
            this.serverStatuslbl.TabIndex = 1;
            this.serverStatuslbl.Text = "Status";
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(0, 60);
            this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(1265, 1);
            this.bunifuSeparator2.TabIndex = 3;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 61);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1265, 1);
            this.bunifuSeparator1.TabIndex = 2;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // stopListeningBtn
            // 
            this.stopListeningBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.stopListeningBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(67)))), ((int)(((byte)(53)))));
            this.stopListeningBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopListeningBtn.Enabled = false;
            this.stopListeningBtn.FlatAppearance.BorderSize = 0;
            this.stopListeningBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopListeningBtn.Font = new System.Drawing.Font("Inter SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopListeningBtn.ForeColor = System.Drawing.Color.White;
            this.stopListeningBtn.Location = new System.Drawing.Point(160, 13);
            this.stopListeningBtn.Name = "stopListeningBtn";
            this.stopListeningBtn.Size = new System.Drawing.Size(130, 34);
            this.stopListeningBtn.TabIndex = 1;
            this.stopListeningBtn.Text = "Stop";
            this.stopListeningBtn.UseVisualStyleBackColor = false;
            // 
            // startListeningBTN
            // 
            this.startListeningBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.startListeningBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(210)))), ((int)(((byte)(149)))));
            this.startListeningBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startListeningBTN.FlatAppearance.BorderSize = 0;
            this.startListeningBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startListeningBTN.Font = new System.Drawing.Font("Inter SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startListeningBTN.ForeColor = System.Drawing.Color.White;
            this.startListeningBTN.Location = new System.Drawing.Point(15, 13);
            this.startListeningBTN.Name = "startListeningBTN";
            this.startListeningBTN.Size = new System.Drawing.Size(130, 34);
            this.startListeningBTN.TabIndex = 0;
            this.startListeningBTN.Text = "Start";
            this.startListeningBTN.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(193)))), ((int)(((byte)(229)))));
            this.panel2.Controls.Add(this.richTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1265, 398);
            this.panel2.TabIndex = 4;
            // 
            // TCPServerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TCPServerUI";
            this.Size = new System.Drawing.Size(1265, 460);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label serverStatuslbl;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Button stopListeningBtn;
        private System.Windows.Forms.Button startListeningBTN;
        private System.Windows.Forms.Panel panel2;
    }
}
