namespace KTA_Visor_UI.component.custom.LoggerView
{
    partial class LoggerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoggerView));
            this.topPanel = new System.Windows.Forms.Panel();
            this.maximizePanel = new System.Windows.Forms.Panel();
            this.maximizeBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.minimizePanel = new System.Windows.Forms.Panel();
            this.minimizeBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clearBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.logPanel = new System.Windows.Forms.Panel();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.topPanel.SuspendLayout();
            this.maximizePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeBtn)).BeginInit();
            this.minimizePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clearBtn)).BeginInit();
            this.logPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.topPanel.Controls.Add(this.maximizePanel);
            this.topPanel.Controls.Add(this.minimizePanel);
            this.topPanel.Controls.Add(this.panel3);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1052, 37);
            this.topPanel.TabIndex = 0;
            // 
            // maximizePanel
            // 
            this.maximizePanel.Controls.Add(this.maximizeBtn);
            this.maximizePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximizePanel.Location = new System.Drawing.Point(968, 0);
            this.maximizePanel.Name = "maximizePanel";
            this.maximizePanel.Size = new System.Drawing.Size(42, 37);
            this.maximizePanel.TabIndex = 3;
            this.maximizePanel.Visible = false;
            // 
            // maximizeBtn
            // 
            this.maximizeBtn.BackColor = System.Drawing.Color.Transparent;
            this.maximizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maximizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("maximizeBtn.Image")));
            this.maximizeBtn.ImageActive = null;
            this.maximizeBtn.Location = new System.Drawing.Point(9, 9);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(20, 20);
            this.maximizeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.maximizeBtn.TabIndex = 0;
            this.maximizeBtn.TabStop = false;
            this.maximizeBtn.Zoom = 10;
            this.maximizeBtn.Click += new System.EventHandler(this.maximizeBtn_Click);
            // 
            // minimizePanel
            // 
            this.minimizePanel.Controls.Add(this.minimizeBtn);
            this.minimizePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizePanel.Location = new System.Drawing.Point(1010, 0);
            this.minimizePanel.Name = "minimizePanel";
            this.minimizePanel.Size = new System.Drawing.Size(42, 37);
            this.minimizePanel.TabIndex = 2;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.Color.Transparent;
            this.minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("minimizeBtn.Image")));
            this.minimizeBtn.ImageActive = null;
            this.minimizeBtn.Location = new System.Drawing.Point(8, 9);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(20, 20);
            this.minimizeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimizeBtn.TabIndex = 0;
            this.minimizeBtn.TabStop = false;
            this.minimizeBtn.Zoom = 10;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.clearBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(42, 37);
            this.panel3.TabIndex = 1;
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.Color.Transparent;
            this.clearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearBtn.Image = ((System.Drawing.Image)(resources.GetObject("clearBtn.Image")));
            this.clearBtn.ImageActive = null;
            this.clearBtn.Location = new System.Drawing.Point(6, 9);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(20, 20);
            this.clearBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clearBtn.TabIndex = 0;
            this.clearBtn.TabStop = false;
            this.clearBtn.Zoom = 10;
            this.clearBtn.Click += new System.EventHandler(this.cleanBtn_Click);
            // 
            // logPanel
            // 
            this.logPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.logPanel.Controls.Add(this.richTextBox);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPanel.Location = new System.Drawing.Point(0, 37);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(1052, 221);
            this.logPanel.TabIndex = 1;
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(0, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox.Size = new System.Drawing.Size(1052, 221);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // LoggerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "LoggerView";
            this.Size = new System.Drawing.Size(1052, 258);
            this.Load += new System.EventHandler(this.LoggerView_Load);
            this.topPanel.ResumeLayout(false);
            this.maximizePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.maximizeBtn)).EndInit();
            this.minimizePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clearBtn)).EndInit();
            this.logPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuImageButton clearBtn;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.Panel minimizePanel;
        private Bunifu.Framework.UI.BunifuImageButton minimizeBtn;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Panel maximizePanel;
        private Bunifu.Framework.UI.BunifuImageButton maximizeBtn;
    }
}
