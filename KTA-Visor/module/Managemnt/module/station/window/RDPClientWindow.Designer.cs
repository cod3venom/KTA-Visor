namespace KTA_Visor.module.Managemnt.module.station.window
{
    partial class RDPClientWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RDPClientWindow));
            this.rdpClient = new AxMSTSCLib.AxMsRdpClient6();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stationIpTitleLbl = new System.Windows.Forms.Label();
            this.ipLbl = new System.Windows.Forms.Label();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.stationUserTitleLbl = new System.Windows.Forms.Label();
            this.disconnectBtn = new MetroFramework.Controls.MetroButton();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.rdpClient)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdpClient
            // 
            this.rdpClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdpClient.Enabled = true;
            this.rdpClient.Location = new System.Drawing.Point(20, 30);
            this.rdpClient.Name = "rdpClient";
            this.rdpClient.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdpClient.OcxState")));
            this.rdpClient.Size = new System.Drawing.Size(891, 450);
            this.rdpClient.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.userNameLbl);
            this.panel1.Controls.Add(this.stationUserTitleLbl);
            this.panel1.Controls.Add(this.ipLbl);
            this.panel1.Controls.Add(this.stationIpTitleLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(20, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 68);
            this.panel1.TabIndex = 1;
            // 
            // stationIpTitleLbl
            // 
            this.stationIpTitleLbl.AutoSize = true;
            this.stationIpTitleLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationIpTitleLbl.Location = new System.Drawing.Point(16, 15);
            this.stationIpTitleLbl.Name = "stationIpTitleLbl";
            this.stationIpTitleLbl.Size = new System.Drawing.Size(67, 16);
            this.stationIpTitleLbl.TabIndex = 0;
            this.stationIpTitleLbl.Text = "IP Adres: ";
            // 
            // ipLbl
            // 
            this.ipLbl.AutoSize = true;
            this.ipLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLbl.Location = new System.Drawing.Point(84, 16);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(13, 16);
            this.ipLbl.TabIndex = 1;
            this.ipLbl.Text = "-";
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLbl.Location = new System.Drawing.Point(100, 43);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(13, 16);
            this.userNameLbl.TabIndex = 3;
            this.userNameLbl.Text = "-";
            // 
            // stationUserTitleLbl
            // 
            this.stationUserTitleLbl.AutoSize = true;
            this.stationUserTitleLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationUserTitleLbl.Location = new System.Drawing.Point(16, 43);
            this.stationUserTitleLbl.Name = "stationUserTitleLbl";
            this.stationUserTitleLbl.Size = new System.Drawing.Size(84, 16);
            this.stationUserTitleLbl.TabIndex = 2;
            this.stationUserTitleLbl.Text = "Użytkownik:";
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.Enabled = false;
            this.disconnectBtn.Location = new System.Drawing.Point(12, 35);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(108, 25);
            this.disconnectBtn.TabIndex = 4;
            this.disconnectBtn.Text = "Rozłącz się";
            this.disconnectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.disconnectBtn.UseSelectable = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.disconnectBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(762, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(129, 68);
            this.panel2.TabIndex = 5;
            // 
            // RDPClientWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 568);
            this.Controls.Add(this.rdpClient);
            this.Controls.Add(this.panel1);
            this.DisplayHeader = false;
            this.Name = "RDPClientWindow";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "RDPClientWindow";
            this.Load += new System.EventHandler(this.RDPClientWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rdpClient)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxMSTSCLib.AxMsRdpClient6 rdpClient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label stationIpTitleLbl;
        private System.Windows.Forms.Label ipLbl;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Label stationUserTitleLbl;
        private MetroFramework.Controls.MetroButton disconnectBtn;
        private System.Windows.Forms.Panel panel2;
    }
}