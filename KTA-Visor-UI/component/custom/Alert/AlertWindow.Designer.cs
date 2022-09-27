namespace KTA_Visor_UI.component.custom.MessageWindow
{
    partial class AlertWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertWindow));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.messageLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.okBtn = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.iconDrag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.labelDrag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.cancelBtn = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.titleLbl);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 32);
            this.panel1.TabIndex = 0;
            // 
            // titleLbl
            // 
            this.titleLbl.BackColor = System.Drawing.Color.Silver;
            this.titleLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.ForeColor = System.Drawing.Color.Black;
            this.titleLbl.Location = new System.Drawing.Point(38, 0);
            this.titleLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.titleLbl.Size = new System.Drawing.Size(399, 32);
            this.titleLbl.TabIndex = 23;
            this.titleLbl.Text = "title";
            this.titleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(28, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 32);
            this.panel4.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.messageLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 101);
            this.panel2.TabIndex = 1;
            // 
            // messageLbl
            // 
            this.messageLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLbl.ForeColor = System.Drawing.Color.Black;
            this.messageLbl.Location = new System.Drawing.Point(0, 0);
            this.messageLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Padding = new System.Windows.Forms.Padding(4, 8, 0, 0);
            this.messageLbl.Size = new System.Drawing.Size(437, 101);
            this.messageLbl.TabIndex = 24;
            this.messageLbl.Text = "Message";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cancelBtn);
            this.panel3.Controls.Add(this.okBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 102);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(437, 31);
            this.panel3.TabIndex = 2;
            // 
            // okBtn
            // 
            this.okBtn.Active = false;
            this.okBtn.Location = new System.Drawing.Point(360, 6);
            this.okBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(73, 20);
            this.okBtn.TabIndex = 0;
            this.okBtn.Title = "OK";
            // 
            // iconDrag
            // 
            this.iconDrag.Fixed = true;
            this.iconDrag.Horizontal = true;
            this.iconDrag.TargetControl = this.pictureBox1;
            this.iconDrag.Vertical = true;
            // 
            // labelDrag
            // 
            this.labelDrag.Fixed = true;
            this.labelDrag.Horizontal = true;
            this.labelDrag.TargetControl = this.titleLbl;
            this.labelDrag.Vertical = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Active = false;
            this.cancelBtn.Location = new System.Drawing.Point(271, 6);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(73, 20);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Title = "Zamknij";
            // 
            // AlertWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 133);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AlertWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MessageWindow";
            this.Load += new System.EventHandler(this.AlertWindow_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label messageLbl;
        private basic.button.PrimaryButton okBtn;
        private Bunifu.Framework.UI.BunifuDragControl iconDrag;
        private Bunifu.Framework.UI.BunifuDragControl labelDrag;
        private System.Windows.Forms.Panel panel4;
        private basic.button.PrimaryButton cancelBtn;
    }
}