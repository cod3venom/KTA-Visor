namespace KTA_Visor_DSClient_Config_Manager
{
    partial class Home
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
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.idTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.idLbl = new System.Windows.Forms.Label();
            this.ipAddressTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.ipAddressLbl = new System.Windows.Forms.Label();
            this.primaryButton1 = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBar1
            // 
            this.topBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(800, 44);
            this.topBar1.TabIndex = 0;
            this.topBar1.Title = "Docking Station Config Manager";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.primaryButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 54);
            this.panel1.TabIndex = 1;
            // 
            // idTxt
            // 
            this.idTxt.BorderColorFocused = System.Drawing.Color.White;
            this.idTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.idTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.idTxt.BorderThickness = 1;
            this.idTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.idTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.idTxt.isPassword = false;
            this.idTxt.Location = new System.Drawing.Point(33, 94);
            this.idTxt.Margin = new System.Windows.Forms.Padding(4);
            this.idTxt.Name = "idTxt";
            this.idTxt.Size = new System.Drawing.Size(303, 37);
            this.idTxt.TabIndex = 17;
            this.idTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.BackColor = System.Drawing.Color.Transparent;
            this.idLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLbl.Location = new System.Drawing.Point(29, 71);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(67, 19);
            this.idLbl.TabIndex = 16;
            this.idLbl.Text = "ID Stacji";
            // 
            // ipAddressTxt
            // 
            this.ipAddressTxt.BorderColorFocused = System.Drawing.Color.White;
            this.ipAddressTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ipAddressTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.ipAddressTxt.BorderThickness = 1;
            this.ipAddressTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ipAddressTxt.isPassword = false;
            this.ipAddressTxt.Location = new System.Drawing.Point(33, 175);
            this.ipAddressTxt.Margin = new System.Windows.Forms.Padding(4);
            this.ipAddressTxt.Name = "ipAddressTxt";
            this.ipAddressTxt.Size = new System.Drawing.Size(303, 37);
            this.ipAddressTxt.TabIndex = 19;
            this.ipAddressTxt.Text = "levan@skillsforge.pl";
            this.ipAddressTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ipAddressLbl
            // 
            this.ipAddressLbl.AutoSize = true;
            this.ipAddressLbl.BackColor = System.Drawing.Color.Transparent;
            this.ipAddressLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressLbl.Location = new System.Drawing.Point(29, 152);
            this.ipAddressLbl.Name = "ipAddressLbl";
            this.ipAddressLbl.Size = new System.Drawing.Size(69, 19);
            this.ipAddressLbl.TabIndex = 18;
            this.ipAddressLbl.Text = "IP Adres";
            // 
            // primaryButton1
            // 
            this.primaryButton1.Active = false;
            this.primaryButton1.Location = new System.Drawing.Point(643, 11);
            this.primaryButton1.Name = "primaryButton1";
            this.primaryButton1.Size = new System.Drawing.Size(145, 31);
            this.primaryButton1.TabIndex = 0;
            this.primaryButton1.Title = "Zapisz";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ipAddressTxt);
            this.Controls.Add(this.ipAddressLbl);
            this.Controls.Add(this.idTxt);
            this.Controls.Add(this.idLbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.topBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuMetroTextbox ipAddressTxt;
        private System.Windows.Forms.Label ipAddressLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox idTxt;
        private System.Windows.Forms.Label idLbl;
        private KTA_Visor_UI.component.basic.button.PrimaryButton primaryButton1;
    }
}

