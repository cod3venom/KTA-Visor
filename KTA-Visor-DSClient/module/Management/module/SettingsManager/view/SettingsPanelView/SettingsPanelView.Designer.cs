namespace KTA_Visor_DSClient.module.Management.module.SettingsManager.view.SettingsPanelView
{
    partial class SettingsPanelView
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
            this.autoReconnectChck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.portLbl = new System.Windows.Forms.Label();
            this.portTxt = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.ipLbl = new System.Windows.Forms.Label();
            this.ipTxt = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveBtn = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stationIPLbl = new System.Windows.Forms.Label();
            this.stationIpTxt = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label6 = new System.Windows.Forms.Label();
            this.serialNumberLbl = new System.Windows.Forms.Label();
            this.stationIdTxt = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.autoCopyChk = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.bunifuCustomTextbox1 = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.storageLocationTxt = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.sstationGenBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // autoReconnectChck
            // 
            this.autoReconnectChck.AutoSize = true;
            this.autoReconnectChck.Location = new System.Drawing.Point(124, 98);
            this.autoReconnectChck.Name = "autoReconnectChck";
            this.autoReconnectChck.Size = new System.Drawing.Size(18, 17);
            this.autoReconnectChck.TabIndex = 16;
            this.autoReconnectChck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Auto reconnect";
            // 
            // portLbl
            // 
            this.portLbl.AutoSize = true;
            this.portLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLbl.ForeColor = System.Drawing.Color.Black;
            this.portLbl.Location = new System.Drawing.Point(32, 70);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(78, 16);
            this.portLbl.TabIndex = 14;
            this.portLbl.Text = "Server Port";
            // 
            // portTxt
            // 
            this.portTxt.BorderColor = System.Drawing.Color.SeaGreen;
            this.portTxt.Location = new System.Drawing.Point(124, 70);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(246, 22);
            this.portTxt.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter Medium", 6F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(22, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "Manager Server";
            // 
            // ipLbl
            // 
            this.ipLbl.AutoSize = true;
            this.ipLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLbl.ForeColor = System.Drawing.Color.Black;
            this.ipLbl.Location = new System.Drawing.Point(47, 41);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(63, 16);
            this.ipLbl.TabIndex = 11;
            this.ipLbl.Text = "Server IP";
            // 
            // ipTxt
            // 
            this.ipTxt.BorderColor = System.Drawing.Color.SeaGreen;
            this.ipTxt.Location = new System.Drawing.Point(124, 38);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Size = new System.Drawing.Size(246, 22);
            this.ipTxt.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 496);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 32);
            this.panel1.TabIndex = 17;
            // 
            // saveBtn
            // 
            this.saveBtn.Active = false;
            this.saveBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.saveBtn.Location = new System.Drawing.Point(1039, 0);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(145, 32);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Title = "Save";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter Medium", 6F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(22, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "File System";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Inter", 7.8F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(38, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Storage";
            // 
            // stationIPLbl
            // 
            this.stationIPLbl.AutoSize = true;
            this.stationIPLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationIPLbl.ForeColor = System.Drawing.Color.Black;
            this.stationIPLbl.Location = new System.Drawing.Point(44, 90);
            this.stationIPLbl.Name = "stationIPLbl";
            this.stationIPLbl.Size = new System.Drawing.Size(66, 16);
            this.stationIPLbl.TabIndex = 24;
            this.stationIPLbl.Text = "Station IP";
            // 
            // stationIpTxt
            // 
            this.stationIpTxt.BorderColor = System.Drawing.Color.SeaGreen;
            this.stationIpTxt.Location = new System.Drawing.Point(124, 84);
            this.stationIpTxt.Name = "stationIpTxt";
            this.stationIpTxt.Size = new System.Drawing.Size(246, 22);
            this.stationIpTxt.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Inter Medium", 6F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(22, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "Information";
            // 
            // serialNumberLbl
            // 
            this.serialNumberLbl.AutoSize = true;
            this.serialNumberLbl.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialNumberLbl.ForeColor = System.Drawing.Color.Black;
            this.serialNumberLbl.Location = new System.Drawing.Point(43, 58);
            this.serialNumberLbl.Name = "serialNumberLbl";
            this.serialNumberLbl.Size = new System.Drawing.Size(67, 16);
            this.serialNumberLbl.TabIndex = 21;
            this.serialNumberLbl.Text = "Station ID";
            // 
            // stationIdTxt
            // 
            this.stationIdTxt.BorderColor = System.Drawing.Color.SeaGreen;
            this.stationIdTxt.Location = new System.Drawing.Point(124, 52);
            this.stationIdTxt.Name = "stationIdTxt";
            this.stationIdTxt.Size = new System.Drawing.Size(246, 22);
            this.stationIdTxt.TabIndex = 20;
            // 
            // autoCopyChk
            // 
            this.autoCopyChk.AutoSize = true;
            this.autoCopyChk.Location = new System.Drawing.Point(124, 70);
            this.autoCopyChk.Name = "autoCopyChk";
            this.autoCopyChk.Size = new System.Drawing.Size(18, 17);
            this.autoCopyChk.TabIndex = 26;
            this.autoCopyChk.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Auto Copy";
            // 
            // titleLbl
            // 
            this.titleLbl.BackColor = System.Drawing.Color.Silver;
            this.titleLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLbl.Font = new System.Drawing.Font("Inter Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.Location = new System.Drawing.Point(0, 0);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(1184, 42);
            this.titleLbl.TabIndex = 27;
            this.titleLbl.Text = "Ustawienia";
            this.titleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuCustomTextbox1
            // 
            this.bunifuCustomTextbox1.BorderColor = System.Drawing.Color.SeaGreen;
            this.bunifuCustomTextbox1.Location = new System.Drawing.Point(100, 55);
            this.bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
            this.bunifuCustomTextbox1.Size = new System.Drawing.Size(246, 22);
            this.bunifuCustomTextbox1.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Inter Medium", 6F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(24, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "USB Relay";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(26, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "COM Port";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.31144F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.68856F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 362F));
            this.tableLayoutPanel1.Controls.Add(this.panel8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 42);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 454);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.bunifuCustomTextbox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(433, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(386, 166);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.sstationGenBtn);
            this.panel4.Controls.Add(this.stationIdTxt);
            this.panel4.Controls.Add(this.serialNumberLbl);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.stationIpTxt);
            this.panel4.Controls.Add(this.stationIPLbl);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(424, 166);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ipLbl);
            this.panel5.Controls.Add(this.ipTxt);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.portTxt);
            this.panel5.Controls.Add(this.portLbl);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.autoReconnectChck);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 175);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(424, 166);
            this.panel5.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(433, 175);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(386, 166);
            this.panel6.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.storageLocationTxt);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.autoCopyChk);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 347);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(424, 104);
            this.panel7.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(433, 347);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(386, 104);
            this.panel8.TabIndex = 5;
            // 
            // storageLocationTxt
            // 
            this.storageLocationTxt.BorderColor = System.Drawing.Color.SeaGreen;
            this.storageLocationTxt.Location = new System.Drawing.Point(124, 37);
            this.storageLocationTxt.Name = "storageLocationTxt";
            this.storageLocationTxt.Size = new System.Drawing.Size(246, 22);
            this.storageLocationTxt.TabIndex = 27;
            // 
            // sstationGenBtn
            // 
            this.sstationGenBtn.BackColor = System.Drawing.Color.Transparent;
            this.sstationGenBtn.BackgroundImage = global::KTA_Visor_DSClient.Properties.Resources.generate;
            this.sstationGenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sstationGenBtn.Location = new System.Drawing.Point(376, 48);
            this.sstationGenBtn.Name = "sstationGenBtn";
            this.sstationGenBtn.Size = new System.Drawing.Size(22, 22);
            this.sstationGenBtn.TabIndex = 32;
            this.sstationGenBtn.UseVisualStyleBackColor = false;
            // 
            // SettingsPanelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.panel1);
            this.Name = "SettingsPanelView";
            this.Size = new System.Drawing.Size(1184, 528);
            this.Load += new System.EventHandler(this.SettingsPanelView_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox autoReconnectChck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label portLbl;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox portTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ipLbl;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox ipTxt;
        private System.Windows.Forms.Panel panel1;
        private KTA_Visor_UI.component.basic.button.PrimaryButton saveBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label stationIPLbl;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox stationIpTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label serialNumberLbl;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox stationIdTxt;
        private System.Windows.Forms.CheckBox autoCopyChk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox storageLocationTxt;
        private System.Windows.Forms.Button sstationGenBtn;
    }
}
