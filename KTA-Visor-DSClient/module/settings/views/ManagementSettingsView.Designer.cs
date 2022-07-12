namespace KTA_Visor_DSClient.module.settings.views
{
    partial class ManagementSettingsView
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.ipTxt = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.ipLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.portLbl = new System.Windows.Forms.Label();
            this.portTxt = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.autoReconnectChck = new System.Windows.Forms.CheckBox();
            this.saveBtn = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // topBar1
            // 
            this.topBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.topBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(800, 44);
            this.topBar1.TabIndex = 0;
            this.topBar1.Title = "Window";
            // 
            // ipTxt
            // 
            this.ipTxt.BorderColor = System.Drawing.Color.SeaGreen;
            this.ipTxt.Location = new System.Drawing.Point(153, 95);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Size = new System.Drawing.Size(246, 22);
            this.ipTxt.TabIndex = 1;
            // 
            // ipLbl
            // 
            this.ipLbl.AutoSize = true;
            this.ipLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLbl.ForeColor = System.Drawing.Color.White;
            this.ipLbl.Location = new System.Drawing.Point(72, 101);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(63, 16);
            this.ipLbl.TabIndex = 2;
            this.ipLbl.Text = "Server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter Medium", 6F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Connection";
            // 
            // portLbl
            // 
            this.portLbl.AutoSize = true;
            this.portLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLbl.ForeColor = System.Drawing.Color.White;
            this.portLbl.Location = new System.Drawing.Point(57, 130);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(78, 16);
            this.portLbl.TabIndex = 5;
            this.portLbl.Text = "Server Port";
            // 
            // portTxt
            // 
            this.portTxt.BorderColor = System.Drawing.Color.SeaGreen;
            this.portTxt.Location = new System.Drawing.Point(153, 127);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(246, 22);
            this.portTxt.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Auto reconnect";
            // 
            // autoReconnectChck
            // 
            this.autoReconnectChck.AutoSize = true;
            this.autoReconnectChck.Location = new System.Drawing.Point(153, 155);
            this.autoReconnectChck.Name = "autoReconnectChck";
            this.autoReconnectChck.Size = new System.Drawing.Size(18, 17);
            this.autoReconnectChck.TabIndex = 9;
            this.autoReconnectChck.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Active = false;
            this.saveBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.saveBtn.Location = new System.Drawing.Point(655, 0);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(145, 40);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Title = "Save";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 40);
            this.panel1.TabIndex = 11;
            // 
            // ManagementSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(193)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.autoReconnectChck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portLbl);
            this.Controls.Add(this.portTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ipLbl);
            this.Controls.Add(this.ipTxt);
            this.Controls.Add(this.topBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManagementSettingsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ManagementView";
            this.Load += new System.EventHandler(this.ManagementView_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private System.Windows.Forms.Label portLbl;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox portTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ipLbl;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox ipTxt;
        private System.Windows.Forms.CheckBox autoReconnectChck;
        private System.Windows.Forms.Label label1;
        private KTA_Visor_UI.component.basic.button.PrimaryButton saveBtn;
        private System.Windows.Forms.Panel panel1;
    }
}