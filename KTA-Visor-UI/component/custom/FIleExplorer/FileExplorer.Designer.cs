namespace KTA_Visor_UI.component.custom.FIleExplorer
{
    partial class FileExplorer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.goForward = new System.Windows.Forms.Button();
            this.currentLocationTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.goBackBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.goForward);
            this.panel1.Controls.Add(this.currentLocationTxt);
            this.panel1.Controls.Add(this.goBackBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1065, 49);
            this.panel1.TabIndex = 0;
            // 
            // goForward
            // 
            this.goForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.goForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goForward.Font = new System.Drawing.Font("Inter Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goForward.Location = new System.Drawing.Point(37, 6);
            this.goForward.Name = "goForward";
            this.goForward.Size = new System.Drawing.Size(28, 30);
            this.goForward.TabIndex = 17;
            this.goForward.Text = ">";
            this.goForward.UseVisualStyleBackColor = false;
            // 
            // currentLocationTxt
            // 
            this.currentLocationTxt.BorderColorFocused = System.Drawing.Color.White;
            this.currentLocationTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.currentLocationTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.currentLocationTxt.BorderThickness = 1;
            this.currentLocationTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.currentLocationTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLocationTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.currentLocationTxt.isPassword = false;
            this.currentLocationTxt.Location = new System.Drawing.Point(72, 6);
            this.currentLocationTxt.Margin = new System.Windows.Forms.Padding(4);
            this.currentLocationTxt.Name = "currentLocationTxt";
            this.currentLocationTxt.Size = new System.Drawing.Size(989, 30);
            this.currentLocationTxt.TabIndex = 16;
            this.currentLocationTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // goBackBtn
            // 
            this.goBackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.goBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBackBtn.Font = new System.Drawing.Font("Inter Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackBtn.Location = new System.Drawing.Point(3, 6);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(28, 30);
            this.goBackBtn.TabIndex = 0;
            this.goBackBtn.Text = "<";
            this.goBackBtn.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.webBrowser1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1065, 545);
            this.panel2.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1065, 545);
            this.webBrowser1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 594);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1065, 56);
            this.panel3.TabIndex = 1;
            // 
            // FileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FileExplorer";
            this.Size = new System.Drawing.Size(1065, 650);
            this.Load += new System.EventHandler(this.FileExplorer_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuMetroTextbox currentLocationTxt;
        private System.Windows.Forms.Button goForward;
        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}
