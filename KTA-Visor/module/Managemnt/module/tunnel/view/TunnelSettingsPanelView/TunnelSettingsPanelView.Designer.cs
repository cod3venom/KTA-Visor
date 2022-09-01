namespace KTA_Visor.module.Managemnt.module.tunnel.view.TunnelSettingsPanelView
{
    partial class TunnelSettingsViewPanel
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
            this.horizontalProgressBar = new KTA_Visor_UI.component.custom.HorizontalProgressBar.HorizontalProgressBar();
            this.fieldsPanel = new System.Windows.Forms.Panel();
            this.ipAddressLbl = new System.Windows.Forms.Label();
            this.modeComboBox = new MetroFramework.Controls.MetroComboBox();
            this.modeLbl = new System.Windows.Forms.Label();
            this.ipTxt = new KTA_Visor_UI.component.basic.textbox.DefaultTextBox();
            this.portLbl = new System.Windows.Forms.Label();
            this.portTxt = new KTA_Visor_UI.component.basic.textbox.DefaultTextBox();
            this.saveBtn = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.titleLbl = new System.Windows.Forms.Label();
            this.fieldsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // horizontalProgressBar
            // 
            this.horizontalProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.horizontalProgressBar.Location = new System.Drawing.Point(292, 350);
            this.horizontalProgressBar.Name = "horizontalProgressBar";
            this.horizontalProgressBar.ProgressColor = System.Drawing.Color.Empty;
            this.horizontalProgressBar.Size = new System.Drawing.Size(310, 10);
            this.horizontalProgressBar.TabIndex = 15;
            this.horizontalProgressBar.Transition = 0;
            // 
            // fieldsPanel
            // 
            this.fieldsPanel.Controls.Add(this.ipAddressLbl);
            this.fieldsPanel.Controls.Add(this.modeComboBox);
            this.fieldsPanel.Controls.Add(this.modeLbl);
            this.fieldsPanel.Controls.Add(this.ipTxt);
            this.fieldsPanel.Controls.Add(this.portLbl);
            this.fieldsPanel.Controls.Add(this.portTxt);
            this.fieldsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldsPanel.Location = new System.Drawing.Point(0, 42);
            this.fieldsPanel.Name = "fieldsPanel";
            this.fieldsPanel.Size = new System.Drawing.Size(858, 419);
            this.fieldsPanel.TabIndex = 16;
            // 
            // ipAddressLbl
            // 
            this.ipAddressLbl.AutoSize = true;
            this.ipAddressLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ipAddressLbl.Location = new System.Drawing.Point(63, 39);
            this.ipAddressLbl.Name = "ipAddressLbl";
            this.ipAddressLbl.Size = new System.Drawing.Size(76, 16);
            this.ipAddressLbl.TabIndex = 2;
            this.ipAddressLbl.Text = "IP Serwera";
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
            this.modeLbl.Size = new System.Drawing.Size(90, 16);
            this.modeLbl.TabIndex = 6;
            this.modeLbl.Text = "Tryb Servera";
            // 
            // ipTxt
            // 
            this.ipTxt.Location = new System.Drawing.Point(144, 39);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Size = new System.Drawing.Size(279, 24);
            this.ipTxt.TabIndex = 1;
            // 
            // portLbl
            // 
            this.portLbl.AutoSize = true;
            this.portLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.portLbl.Location = new System.Drawing.Point(49, 77);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(90, 16);
            this.portLbl.TabIndex = 4;
            this.portLbl.Text = "Port Serwera";
            // 
            // portTxt
            // 
            this.portTxt.Location = new System.Drawing.Point(144, 77);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(279, 24);
            this.portTxt.TabIndex = 3;
            // 
            // saveBtn
            // 
            this.saveBtn.Active = false;
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(699, 19);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(145, 31);
            this.saveBtn.TabIndex = 17;
            this.saveBtn.Title = "Zapisz";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 461);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 62);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.titleLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(858, 42);
            this.panel2.TabIndex = 19;
            // 
            // titleLbl
            // 
            this.titleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLbl.Font = new System.Drawing.Font("Inter Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.Location = new System.Drawing.Point(0, 0);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(858, 42);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "Ustawienia tunelu";
            this.titleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TunnelSettingsViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fieldsPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.horizontalProgressBar);
            this.Name = "TunnelSettingsViewPanel";
            this.Size = new System.Drawing.Size(858, 523);
            this.Load += new System.EventHandler(this.TunnelSettingsViewPanel_Load);
            this.fieldsPanel.ResumeLayout(false);
            this.fieldsPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KTA_Visor_UI.component.custom.HorizontalProgressBar.HorizontalProgressBar horizontalProgressBar;
        private System.Windows.Forms.Panel fieldsPanel;
        private System.Windows.Forms.Label ipAddressLbl;
        private MetroFramework.Controls.MetroComboBox modeComboBox;
        private System.Windows.Forms.Label modeLbl;
        private KTA_Visor_UI.component.basic.textbox.DefaultTextBox ipTxt;
        private System.Windows.Forms.Label portLbl;
        private KTA_Visor_UI.component.basic.textbox.DefaultTextBox portTxt;
        private KTA_Visor_UI.component.basic.button.PrimaryButton saveBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label titleLbl;
    }
}
