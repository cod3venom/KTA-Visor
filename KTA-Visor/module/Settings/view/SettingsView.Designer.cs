namespace KTA_Visor.module.Settings.view
{
    partial class SettingsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.topBar1 = new KTA_Visor.component.basic.topbar.TopBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControll = new System.Windows.Forms.TabControl();
            this.managementServerSettingsPage = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.secondaryButton1 = new KTA_Visor.component.basic.button.SecondaryButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusLblValue = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.portLbl = new System.Windows.Forms.Label();
            this.ipLbl = new System.Windows.Forms.Label();
            this.primaryButton1 = new KTA_Visor.component.basic.button.PrimaryButton();
            this.fileSystemSettingsPage = new System.Windows.Forms.TabPage();
            this.browseNetworkDriveBtn = new KTA_Visor.component.basic.button.SecondaryButton();
            this.networkDriveLbl = new System.Windows.Forms.Label();
            this.networkDriveLocationTextBox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.advancedSettingsPage = new System.Windows.Forms.TabPage();
            this.networkDriveOpenFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.managementServerIpAddressDroPDown = new Bunifu.Framework.UI.BunifuDropdown();
            this.managementServerPortTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.secondaryButton2 = new KTA_Visor.component.basic.button.SecondaryButton();
            this.primaryButton2 = new KTA_Visor.component.basic.button.PrimaryButton();
            this.secondaryButton3 = new KTA_Visor.component.basic.button.SecondaryButton();
            this.primaryButton3 = new KTA_Visor.component.basic.button.PrimaryButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControll.SuspendLayout();
            this.managementServerSettingsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.fileSystemSettingsPage.SuspendLayout();
            this.advancedSettingsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.topBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 34);
            this.panel1.TabIndex = 0;
            // 
            // topBar1
            // 
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(800, 32);
            this.topBar1.TabIndex = 0;
            this.topBar1.Title = "Settings";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 416);
            this.panel2.TabIndex = 1;
            // 
            // tabControll
            // 
            this.tabControll.Controls.Add(this.managementServerSettingsPage);
            this.tabControll.Controls.Add(this.fileSystemSettingsPage);
            this.tabControll.Controls.Add(this.advancedSettingsPage);
            this.tabControll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControll.Location = new System.Drawing.Point(0, 0);
            this.tabControll.Name = "tabControll";
            this.tabControll.SelectedIndex = 0;
            this.tabControll.Size = new System.Drawing.Size(800, 416);
            this.tabControll.TabIndex = 0;
            // 
            // managementServerSettingsPage
            // 
            this.managementServerSettingsPage.BackColor = System.Drawing.Color.White;
            this.managementServerSettingsPage.Controls.Add(this.managementServerPortTxt);
            this.managementServerSettingsPage.Controls.Add(this.managementServerIpAddressDroPDown);
            this.managementServerSettingsPage.Controls.Add(this.pictureBox2);
            this.managementServerSettingsPage.Controls.Add(this.label1);
            this.managementServerSettingsPage.Controls.Add(this.secondaryButton1);
            this.managementServerSettingsPage.Controls.Add(this.pictureBox1);
            this.managementServerSettingsPage.Controls.Add(this.statusLblValue);
            this.managementServerSettingsPage.Controls.Add(this.statusLbl);
            this.managementServerSettingsPage.Controls.Add(this.portLbl);
            this.managementServerSettingsPage.Controls.Add(this.ipLbl);
            this.managementServerSettingsPage.Controls.Add(this.primaryButton1);
            this.managementServerSettingsPage.Location = new System.Drawing.Point(4, 25);
            this.managementServerSettingsPage.Name = "managementServerSettingsPage";
            this.managementServerSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.managementServerSettingsPage.Size = new System.Drawing.Size(792, 387);
            this.managementServerSettingsPage.TabIndex = 0;
            this.managementServerSettingsPage.Text = "Management";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 190);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(170)))));
            this.label1.Location = new System.Drawing.Point(32, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(670, 112);
            this.label1.TabIndex = 10;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // secondaryButton1
            // 
            this.secondaryButton1.Location = new System.Drawing.Point(473, 348);
            this.secondaryButton1.Name = "secondaryButton1";
            this.secondaryButton1.Size = new System.Drawing.Size(145, 31);
            this.secondaryButton1.TabIndex = 9;
            this.secondaryButton1.Title = "Cancel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(160, 347);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // statusLblValue
            // 
            this.statusLblValue.AutoSize = true;
            this.statusLblValue.Font = new System.Drawing.Font("Inter SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLblValue.Location = new System.Drawing.Point(91, 348);
            this.statusLblValue.Name = "statusLblValue";
            this.statusLblValue.Size = new System.Drawing.Size(58, 16);
            this.statusLblValue.TabIndex = 7;
            this.statusLblValue.Text = "Running";
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(34, 348);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(51, 16);
            this.statusLbl.TabIndex = 6;
            this.statusLbl.Text = "Status:";
            // 
            // portLbl
            // 
            this.portLbl.AutoSize = true;
            this.portLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLbl.Location = new System.Drawing.Point(32, 105);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(33, 16);
            this.portLbl.TabIndex = 5;
            this.portLbl.Text = "Port";
            // 
            // ipLbl
            // 
            this.ipLbl.AutoSize = true;
            this.ipLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLbl.Location = new System.Drawing.Point(32, 46);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(72, 16);
            this.ipLbl.TabIndex = 4;
            this.ipLbl.Text = "IP address";
            // 
            // primaryButton1
            // 
            this.primaryButton1.Active = false;
            this.primaryButton1.Location = new System.Drawing.Point(639, 348);
            this.primaryButton1.Name = "primaryButton1";
            this.primaryButton1.Size = new System.Drawing.Size(145, 31);
            this.primaryButton1.TabIndex = 2;
            this.primaryButton1.Title = "Save";
            // 
            // fileSystemSettingsPage
            // 
            this.fileSystemSettingsPage.BackColor = System.Drawing.Color.White;
            this.fileSystemSettingsPage.Controls.Add(this.secondaryButton2);
            this.fileSystemSettingsPage.Controls.Add(this.primaryButton2);
            this.fileSystemSettingsPage.Controls.Add(this.browseNetworkDriveBtn);
            this.fileSystemSettingsPage.Controls.Add(this.networkDriveLbl);
            this.fileSystemSettingsPage.Controls.Add(this.networkDriveLocationTextBox);
            this.fileSystemSettingsPage.Location = new System.Drawing.Point(4, 25);
            this.fileSystemSettingsPage.Name = "fileSystemSettingsPage";
            this.fileSystemSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.fileSystemSettingsPage.Size = new System.Drawing.Size(792, 387);
            this.fileSystemSettingsPage.TabIndex = 1;
            this.fileSystemSettingsPage.Text = "File system";
            // 
            // browseNetworkDriveBtn
            // 
            this.browseNetworkDriveBtn.Location = new System.Drawing.Point(539, 37);
            this.browseNetworkDriveBtn.Name = "browseNetworkDriveBtn";
            this.browseNetworkDriveBtn.Size = new System.Drawing.Size(145, 31);
            this.browseNetworkDriveBtn.TabIndex = 6;
            this.browseNetworkDriveBtn.Title = "Browse";
            // 
            // networkDriveLbl
            // 
            this.networkDriveLbl.AutoSize = true;
            this.networkDriveLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.networkDriveLbl.Location = new System.Drawing.Point(5, 42);
            this.networkDriveLbl.Name = "networkDriveLbl";
            this.networkDriveLbl.Size = new System.Drawing.Size(97, 16);
            this.networkDriveLbl.TabIndex = 5;
            this.networkDriveLbl.Text = "Network Drive";
            // 
            // networkDriveLocationTextBox
            // 
            this.networkDriveLocationTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.networkDriveLocationTextBox.Enabled = false;
            this.networkDriveLocationTextBox.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.networkDriveLocationTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.networkDriveLocationTextBox.HintForeColor = System.Drawing.Color.Empty;
            this.networkDriveLocationTextBox.HintText = "";
            this.networkDriveLocationTextBox.isPassword = false;
            this.networkDriveLocationTextBox.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.networkDriveLocationTextBox.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(231)))));
            this.networkDriveLocationTextBox.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.networkDriveLocationTextBox.LineThickness = 1;
            this.networkDriveLocationTextBox.Location = new System.Drawing.Point(143, 37);
            this.networkDriveLocationTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.networkDriveLocationTextBox.Name = "networkDriveLocationTextBox";
            this.networkDriveLocationTextBox.Size = new System.Drawing.Size(379, 32);
            this.networkDriveLocationTextBox.TabIndex = 0;
            this.networkDriveLocationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // advancedSettingsPage
            // 
            this.advancedSettingsPage.Controls.Add(this.secondaryButton3);
            this.advancedSettingsPage.Controls.Add(this.primaryButton3);
            this.advancedSettingsPage.Location = new System.Drawing.Point(4, 25);
            this.advancedSettingsPage.Name = "advancedSettingsPage";
            this.advancedSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.advancedSettingsPage.Size = new System.Drawing.Size(792, 387);
            this.advancedSettingsPage.TabIndex = 2;
            this.advancedSettingsPage.Text = "Advanced";
            this.advancedSettingsPage.UseVisualStyleBackColor = true;
            // 
            // networkDriveOpenFolderDialog
            // 
            this.networkDriveOpenFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // managementServerIpAddressDroPDown
            // 
            this.managementServerIpAddressDroPDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(231)))));
            this.managementServerIpAddressDroPDown.BorderRadius = 3;
            this.managementServerIpAddressDroPDown.DisabledColor = System.Drawing.Color.Gray;
            this.managementServerIpAddressDroPDown.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managementServerIpAddressDroPDown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.managementServerIpAddressDroPDown.Items = new string[0];
            this.managementServerIpAddressDroPDown.Location = new System.Drawing.Point(190, 39);
            this.managementServerIpAddressDroPDown.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.managementServerIpAddressDroPDown.Name = "managementServerIpAddressDroPDown";
            this.managementServerIpAddressDroPDown.NomalColor = System.Drawing.Color.White;
            this.managementServerIpAddressDroPDown.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(231)))));
            this.managementServerIpAddressDroPDown.selectedIndex = -1;
            this.managementServerIpAddressDroPDown.Size = new System.Drawing.Size(241, 40);
            this.managementServerIpAddressDroPDown.TabIndex = 13;
            // 
            // managementServerPortTxt
            // 
            this.managementServerPortTxt.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.managementServerPortTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(231)))));
            this.managementServerPortTxt.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.managementServerPortTxt.BorderThickness = 1;
            this.managementServerPortTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.managementServerPortTxt.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.managementServerPortTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.managementServerPortTxt.isPassword = false;
            this.managementServerPortTxt.Location = new System.Drawing.Point(190, 95);
            this.managementServerPortTxt.Margin = new System.Windows.Forms.Padding(4);
            this.managementServerPortTxt.Name = "managementServerPortTxt";
            this.managementServerPortTxt.Size = new System.Drawing.Size(241, 44);
            this.managementServerPortTxt.TabIndex = 14;
            this.managementServerPortTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // secondaryButton2
            // 
            this.secondaryButton2.Location = new System.Drawing.Point(473, 348);
            this.secondaryButton2.Name = "secondaryButton2";
            this.secondaryButton2.Size = new System.Drawing.Size(145, 31);
            this.secondaryButton2.TabIndex = 11;
            this.secondaryButton2.Title = "Cancel";
            // 
            // primaryButton2
            // 
            this.primaryButton2.Active = false;
            this.primaryButton2.Location = new System.Drawing.Point(639, 348);
            this.primaryButton2.Name = "primaryButton2";
            this.primaryButton2.Size = new System.Drawing.Size(145, 31);
            this.primaryButton2.TabIndex = 10;
            this.primaryButton2.Title = "Save";
            // 
            // secondaryButton3
            // 
            this.secondaryButton3.Location = new System.Drawing.Point(475, 348);
            this.secondaryButton3.Name = "secondaryButton3";
            this.secondaryButton3.Size = new System.Drawing.Size(145, 31);
            this.secondaryButton3.TabIndex = 13;
            this.secondaryButton3.Title = "Cancel";
            // 
            // primaryButton3
            // 
            this.primaryButton3.Active = false;
            this.primaryButton3.Location = new System.Drawing.Point(641, 348);
            this.primaryButton3.Name = "primaryButton3";
            this.primaryButton3.Size = new System.Drawing.Size(145, 31);
            this.primaryButton3.TabIndex = 12;
            this.primaryButton3.Title = "Save";
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsView";
            this.Load += new System.EventHandler(this.SettingsView_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControll.ResumeLayout(false);
            this.managementServerSettingsPage.ResumeLayout(false);
            this.managementServerSettingsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.fileSystemSettingsPage.ResumeLayout(false);
            this.fileSystemSettingsPage.PerformLayout();
            this.advancedSettingsPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private component.basic.topbar.TopBar topBar1;
        private System.Windows.Forms.TabControl tabControll;
        private System.Windows.Forms.TabPage managementServerSettingsPage;
        private System.Windows.Forms.TabPage fileSystemSettingsPage;
        private component.basic.button.PrimaryButton primaryButton1;
        private System.Windows.Forms.Label portLbl;
        private System.Windows.Forms.Label ipLbl;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label statusLblValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private component.basic.button.SecondaryButton secondaryButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage advancedSettingsPage;
        private System.Windows.Forms.FolderBrowserDialog networkDriveOpenFolderDialog;
        private Bunifu.Framework.UI.BunifuMaterialTextbox networkDriveLocationTextBox;
        private System.Windows.Forms.Label networkDriveLbl;
        private component.basic.button.SecondaryButton browseNetworkDriveBtn;
        private Bunifu.Framework.UI.BunifuDropdown managementServerIpAddressDroPDown;
        private Bunifu.Framework.UI.BunifuMetroTextbox managementServerPortTxt;
        private component.basic.button.SecondaryButton secondaryButton2;
        private component.basic.button.PrimaryButton primaryButton2;
        private component.basic.button.SecondaryButton secondaryButton3;
        private component.basic.button.PrimaryButton primaryButton3;
    }
}