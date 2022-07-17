namespace KTA_Visor.module.Tunnel.view
{
    partial class TunnelSettingsView
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
            this.ipAddressLbl = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.fieldsPanel = new System.Windows.Forms.Panel();
            this.modeComboBox = new MetroFramework.Controls.MetroComboBox();
            this.modeLbl = new System.Windows.Forms.Label();
            this.portLbl = new System.Windows.Forms.Label();
            this.horizontalProgressBar = new KTA_Visor_UI.component.custom.HorizontalProgressBar.HorizontalProgressBar();
            this.saveBtn = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.ipTxt = new KTA_Visor_UI.component.basic.textbox.DefaultTextBox();
            this.portTxt = new KTA_Visor_UI.component.basic.textbox.DefaultTextBox();
            this.closeBtn = new KTA_Visor_UI.component.basic.button.SecondaryButton();
            this.footerPanel.SuspendLayout();
            this.fieldsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // ipAddressLbl
            // 
            this.ipAddressLbl.AutoSize = true;
            this.ipAddressLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ipAddressLbl.Location = new System.Drawing.Point(63, 39);
            this.ipAddressLbl.Name = "ipAddressLbl";
            this.ipAddressLbl.Size = new System.Drawing.Size(65, 16);
            this.ipAddressLbl.TabIndex = 2;
            this.ipAddressLbl.Text = "Server IP";
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.closeBtn);
            this.footerPanel.Controls.Add(this.saveBtn);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 403);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(800, 47);
            this.footerPanel.TabIndex = 9;
            // 
            // fieldsPanel
            // 
            this.fieldsPanel.Controls.Add(this.ipAddressLbl);
            this.fieldsPanel.Controls.Add(this.modeComboBox);
            this.fieldsPanel.Controls.Add(this.modeLbl);
            this.fieldsPanel.Controls.Add(this.ipTxt);
            this.fieldsPanel.Controls.Add(this.portLbl);
            this.fieldsPanel.Controls.Add(this.portTxt);
            this.fieldsPanel.Location = new System.Drawing.Point(166, 69);
            this.fieldsPanel.Name = "fieldsPanel";
            this.fieldsPanel.Size = new System.Drawing.Size(500, 161);
            this.fieldsPanel.TabIndex = 14;
            // 
            // modeComboBox
            // 
            this.modeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.modeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modeComboBox.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.ItemHeight = 21;
            this.modeComboBox.Location = new System.Drawing.Point(144, 113);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(279, 27);
            this.modeComboBox.TabIndex = 7;
            this.modeComboBox.UseSelectable = true;
            // 
            // modeLbl
            // 
            this.modeLbl.AutoSize = true;
            this.modeLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.modeLbl.Location = new System.Drawing.Point(39, 116);
            this.modeLbl.Name = "modeLbl";
            this.modeLbl.Size = new System.Drawing.Size(89, 16);
            this.modeLbl.TabIndex = 6;
            this.modeLbl.Text = "Server Mode";
            // 
            // portLbl
            // 
            this.portLbl.AutoSize = true;
            this.portLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.portLbl.Location = new System.Drawing.Point(49, 77);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(79, 16);
            this.portLbl.TabIndex = 4;
            this.portLbl.Text = "Server Port";
            // 
            // horizontalProgressBar
            // 
            this.horizontalProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.horizontalProgressBar.Location = new System.Drawing.Point(241, 267);
            this.horizontalProgressBar.Name = "horizontalProgressBar";
            this.horizontalProgressBar.ProgressColor = System.Drawing.Color.Empty;
            this.horizontalProgressBar.Size = new System.Drawing.Size(310, 10);
            this.horizontalProgressBar.TabIndex = 10;
            this.horizontalProgressBar.Transition = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.Active = false;
            this.saveBtn.Location = new System.Drawing.Point(645, 4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(145, 31);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Title = "Save";
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
            this.topBar1.Title = "Window";
            // 
            // ipTxt
            // 
            this.ipTxt.Location = new System.Drawing.Point(144, 39);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Size = new System.Drawing.Size(279, 24);
            this.ipTxt.TabIndex = 1;
            // 
            // portTxt
            // 
            this.portTxt.Location = new System.Drawing.Point(144, 77);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(279, 24);
            this.portTxt.TabIndex = 3;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.closeBtn.Location = new System.Drawing.Point(494, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(145, 31);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.Title = "Close";
            // 
            // TunnelSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.horizontalProgressBar);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.topBar1);
            this.Controls.Add(this.fieldsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TunnelSettingsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TunnelSettings";
            this.Load += new System.EventHandler(this.TunnelSettings_Load);
            this.footerPanel.ResumeLayout(false);
            this.fieldsPanel.ResumeLayout(false);
            this.fieldsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private System.Windows.Forms.Label ipAddressLbl;
        private KTA_Visor_UI.component.basic.textbox.DefaultTextBox ipTxt;
        private System.Windows.Forms.Panel footerPanel;
        private KTA_Visor_UI.component.basic.button.PrimaryButton saveBtn;
        private KTA_Visor_UI.component.custom.HorizontalProgressBar.HorizontalProgressBar horizontalProgressBar;
        private System.Windows.Forms.Panel fieldsPanel;
        private MetroFramework.Controls.MetroComboBox modeComboBox;
        private System.Windows.Forms.Label modeLbl;
        private System.Windows.Forms.Label portLbl;
        private KTA_Visor_UI.component.basic.textbox.DefaultTextBox portTxt;
        private KTA_Visor_UI.component.basic.button.SecondaryButton closeBtn;
    }
}