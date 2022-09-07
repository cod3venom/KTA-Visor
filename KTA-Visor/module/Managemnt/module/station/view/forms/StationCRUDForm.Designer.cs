namespace KTA_Visor.module.Managemnt.module.station.view.forms
{
    partial class StationCRUDForm
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
            this.topBar = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.stationIdTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.stationIdLbl = new System.Windows.Forms.Label();
            this.stationIpAddressTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.stationIpAddressLbl = new System.Windows.Forms.Label();
            this.saveBtn = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.SuspendLayout();
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Parent = null;
            this.topBar.Size = new System.Drawing.Size(800, 44);
            this.topBar.TabIndex = 2;
            this.topBar.Title = "Window";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // stationIdTxt
            // 
            this.stationIdTxt.BorderColorFocused = System.Drawing.Color.White;
            this.stationIdTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stationIdTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.stationIdTxt.BorderThickness = 1;
            this.stationIdTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.stationIdTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationIdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stationIdTxt.isPassword = false;
            this.stationIdTxt.Location = new System.Drawing.Point(29, 105);
            this.stationIdTxt.Margin = new System.Windows.Forms.Padding(4);
            this.stationIdTxt.Name = "stationIdTxt";
            this.stationIdTxt.Size = new System.Drawing.Size(303, 37);
            this.stationIdTxt.TabIndex = 21;
            this.stationIdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // stationIdLbl
            // 
            this.stationIdLbl.AutoSize = true;
            this.stationIdLbl.BackColor = System.Drawing.Color.Transparent;
            this.stationIdLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationIdLbl.Location = new System.Drawing.Point(25, 82);
            this.stationIdLbl.Name = "stationIdLbl";
            this.stationIdLbl.Size = new System.Drawing.Size(141, 19);
            this.stationIdLbl.TabIndex = 20;
            this.stationIdLbl.Text = "Identyfikator Stacji";
            // 
            // stationIpAddressTxt
            // 
            this.stationIpAddressTxt.BorderColorFocused = System.Drawing.Color.White;
            this.stationIpAddressTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stationIpAddressTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.stationIpAddressTxt.BorderThickness = 1;
            this.stationIpAddressTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.stationIpAddressTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationIpAddressTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stationIpAddressTxt.isPassword = false;
            this.stationIpAddressTxt.Location = new System.Drawing.Point(398, 105);
            this.stationIpAddressTxt.Margin = new System.Windows.Forms.Padding(4);
            this.stationIpAddressTxt.Name = "stationIpAddressTxt";
            this.stationIpAddressTxt.Size = new System.Drawing.Size(303, 37);
            this.stationIpAddressTxt.TabIndex = 23;
            this.stationIpAddressTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // stationIpAddressLbl
            // 
            this.stationIpAddressLbl.AutoSize = true;
            this.stationIpAddressLbl.BackColor = System.Drawing.Color.Transparent;
            this.stationIpAddressLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationIpAddressLbl.Location = new System.Drawing.Point(394, 82);
            this.stationIpAddressLbl.Name = "stationIpAddressLbl";
            this.stationIpAddressLbl.Size = new System.Drawing.Size(112, 19);
            this.stationIpAddressLbl.TabIndex = 22;
            this.stationIpAddressLbl.Text = "IP Adres Stacji";
            // 
            // saveBtn
            // 
            this.saveBtn.Active = false;
            this.saveBtn.Location = new System.Drawing.Point(676, 407);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(112, 31);
            this.saveBtn.TabIndex = 27;
            this.saveBtn.Title = "Zapisz";
            // 
            // StationCRUDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.stationIpAddressTxt);
            this.Controls.Add(this.stationIpAddressLbl);
            this.Controls.Add(this.stationIdTxt);
            this.Controls.Add(this.stationIdLbl);
            this.Controls.Add(this.topBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StationCRUDForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StationCRUDForm";
            this.Load += new System.EventHandler(this.StationCRUDForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KTA_Visor_UI.component.basic.topbar.TopBar topBar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuMetroTextbox stationIpAddressTxt;
        private System.Windows.Forms.Label stationIpAddressLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox stationIdTxt;
        private System.Windows.Forms.Label stationIdLbl;
        public KTA_Visor_UI.component.basic.button.PrimaryButton saveBtn;
    }
}