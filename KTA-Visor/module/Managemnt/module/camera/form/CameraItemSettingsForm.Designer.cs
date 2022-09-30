namespace KTA_Visor.module.Managemnt.module.camera.form
{
    partial class CameraItemSettingsForm
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
            this.topBar = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.badgeIdTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.badgeLbl = new System.Windows.Forms.Label();
            this.dateTimeLbl = new System.Windows.Forms.Label();
            this.leftHeaderLbl = new System.Windows.Forms.Label();
            this.dateTimeTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.rightHeaderLbl = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.syncDateTIme = new System.Windows.Forms.Button();
            this.genBadgeId = new System.Windows.Forms.Button();
            this.genDeviceId = new System.Windows.Forms.Button();
            this.deviceIdLbl = new System.Windows.Forms.Label();
            this.deviceIdTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.saveBtn = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.wifiChk = new System.Windows.Forms.CheckBox();
            this.wifiLbl = new System.Windows.Forms.Label();
            this.gpsChk = new System.Windows.Forms.CheckBox();
            this.gpsLbl = new System.Windows.Forms.Label();
            this.preRecordingChk = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.recordingCodecFormatCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.recordingQualityCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.recordingResolutionCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.genCardId = new System.Windows.Forms.Button();
            this.cardId = new System.Windows.Forms.Label();
            this.cardIdtxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // topBar
            // 
            this.topBar.AllowClose = true;
            this.topBar.AllowMinimize = true;
            this.topBar.AllowResize = true;
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar.Description = "Window";
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Margin = new System.Windows.Forms.Padding(2);
            this.topBar.Name = "topBar";
            this.topBar.Parent = null;
            this.topBar.Size = new System.Drawing.Size(858, 36);
            this.topBar.TabIndex = 0;
            this.topBar.Title = "Window";
            // 
            // badgeIdTxt
            // 
            this.badgeIdTxt.BorderColorFocused = System.Drawing.Color.White;
            this.badgeIdTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.badgeIdTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.badgeIdTxt.BorderThickness = 1;
            this.badgeIdTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.badgeIdTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.badgeIdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.badgeIdTxt.isPassword = false;
            this.badgeIdTxt.Location = new System.Drawing.Point(176, 107);
            this.badgeIdTxt.Margin = new System.Windows.Forms.Padding(4);
            this.badgeIdTxt.Name = "badgeIdTxt";
            this.badgeIdTxt.Size = new System.Drawing.Size(166, 20);
            this.badgeIdTxt.TabIndex = 17;
            this.badgeIdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // badgeLbl
            // 
            this.badgeLbl.AutoSize = true;
            this.badgeLbl.BackColor = System.Drawing.Color.Transparent;
            this.badgeLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.badgeLbl.Location = new System.Drawing.Point(28, 107);
            this.badgeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.badgeLbl.Name = "badgeLbl";
            this.badgeLbl.Size = new System.Drawing.Size(92, 15);
            this.badgeLbl.TabIndex = 16;
            this.badgeLbl.Text = "Numer odznaki";
            // 
            // dateTimeLbl
            // 
            this.dateTimeLbl.AutoSize = true;
            this.dateTimeLbl.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeLbl.Location = new System.Drawing.Point(28, 184);
            this.dateTimeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dateTimeLbl.Name = "dateTimeLbl";
            this.dateTimeLbl.Size = new System.Drawing.Size(88, 15);
            this.dateTimeLbl.TabIndex = 20;
            this.dateTimeLbl.Text = "Data i godzina";
            // 
            // leftHeaderLbl
            // 
            this.leftHeaderLbl.AutoSize = true;
            this.leftHeaderLbl.BackColor = System.Drawing.Color.Transparent;
            this.leftHeaderLbl.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftHeaderLbl.Location = new System.Drawing.Point(9, 21);
            this.leftHeaderLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.leftHeaderLbl.Name = "leftHeaderLbl";
            this.leftHeaderLbl.Size = new System.Drawing.Size(138, 17);
            this.leftHeaderLbl.TabIndex = 30;
            this.leftHeaderLbl.Text = "Device information";
            // 
            // dateTimeTxt
            // 
            this.dateTimeTxt.BorderColorFocused = System.Drawing.Color.White;
            this.dateTimeTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimeTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.dateTimeTxt.BorderThickness = 1;
            this.dateTimeTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dateTimeTxt.Enabled = false;
            this.dateTimeTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimeTxt.isPassword = false;
            this.dateTimeTxt.Location = new System.Drawing.Point(176, 187);
            this.dateTimeTxt.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeTxt.Name = "dateTimeTxt";
            this.dateTimeTxt.Size = new System.Drawing.Size(166, 20);
            this.dateTimeTxt.TabIndex = 31;
            this.dateTimeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // rightHeaderLbl
            // 
            this.rightHeaderLbl.AutoSize = true;
            this.rightHeaderLbl.BackColor = System.Drawing.Color.Transparent;
            this.rightHeaderLbl.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightHeaderLbl.Location = new System.Drawing.Point(17, 21);
            this.rightHeaderLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rightHeaderLbl.Name = "rightHeaderLbl";
            this.rightHeaderLbl.Size = new System.Drawing.Size(121, 17);
            this.rightHeaderLbl.TabIndex = 32;
            this.rightHeaderLbl.Text = "Camera Settings";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.bunifuSeparator1.LineThickness = 5;
            this.bunifuSeparator1.Location = new System.Drawing.Point(454, 36);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(0, 480);
            this.bunifuSeparator1.TabIndex = 33;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.genCardId);
            this.panel1.Controls.Add(this.cardId);
            this.panel1.Controls.Add(this.cardIdtxt);
            this.panel1.Controls.Add(this.syncDateTIme);
            this.panel1.Controls.Add(this.genBadgeId);
            this.panel1.Controls.Add(this.genDeviceId);
            this.panel1.Controls.Add(this.deviceIdLbl);
            this.panel1.Controls.Add(this.deviceIdTxt);
            this.panel1.Controls.Add(this.leftHeaderLbl);
            this.panel1.Controls.Add(this.badgeLbl);
            this.panel1.Controls.Add(this.badgeIdTxt);
            this.panel1.Controls.Add(this.dateTimeTxt);
            this.panel1.Controls.Add(this.dateTimeLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 480);
            this.panel1.TabIndex = 34;
            // 
            // syncDateTIme
            // 
            this.syncDateTIme.BackColor = System.Drawing.Color.White;
            this.syncDateTIme.BackgroundImage = global::KTA_Visor.Properties.Resources.sync;
            this.syncDateTIme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.syncDateTIme.Location = new System.Drawing.Point(334, 187);
            this.syncDateTIme.Margin = new System.Windows.Forms.Padding(2);
            this.syncDateTIme.Name = "syncDateTIme";
            this.syncDateTIme.Size = new System.Drawing.Size(19, 20);
            this.syncDateTIme.TabIndex = 37;
            this.syncDateTIme.UseVisualStyleBackColor = false;
            // 
            // genBadgeId
            // 
            this.genBadgeId.BackColor = System.Drawing.Color.White;
            this.genBadgeId.BackgroundImage = global::KTA_Visor.Properties.Resources.generate;
            this.genBadgeId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.genBadgeId.Location = new System.Drawing.Point(334, 107);
            this.genBadgeId.Margin = new System.Windows.Forms.Padding(2);
            this.genBadgeId.Name = "genBadgeId";
            this.genBadgeId.Size = new System.Drawing.Size(19, 20);
            this.genBadgeId.TabIndex = 35;
            this.genBadgeId.UseVisualStyleBackColor = false;
            // 
            // genDeviceId
            // 
            this.genDeviceId.BackColor = System.Drawing.Color.White;
            this.genDeviceId.BackgroundImage = global::KTA_Visor.Properties.Resources.generate;
            this.genDeviceId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.genDeviceId.Location = new System.Drawing.Point(334, 67);
            this.genDeviceId.Margin = new System.Windows.Forms.Padding(2);
            this.genDeviceId.Name = "genDeviceId";
            this.genDeviceId.Size = new System.Drawing.Size(19, 20);
            this.genDeviceId.TabIndex = 34;
            this.genDeviceId.UseVisualStyleBackColor = false;
            // 
            // deviceIdLbl
            // 
            this.deviceIdLbl.AutoSize = true;
            this.deviceIdLbl.BackColor = System.Drawing.Color.Transparent;
            this.deviceIdLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceIdLbl.Location = new System.Drawing.Point(28, 67);
            this.deviceIdLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.deviceIdLbl.Name = "deviceIdLbl";
            this.deviceIdLbl.Size = new System.Drawing.Size(144, 15);
            this.deviceIdLbl.TabIndex = 32;
            this.deviceIdLbl.Text = "Identyfikator urządzenia";
            // 
            // deviceIdTxt
            // 
            this.deviceIdTxt.BorderColorFocused = System.Drawing.Color.White;
            this.deviceIdTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.deviceIdTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.deviceIdTxt.BorderThickness = 1;
            this.deviceIdTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.deviceIdTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceIdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.deviceIdTxt.isPassword = false;
            this.deviceIdTxt.Location = new System.Drawing.Point(176, 67);
            this.deviceIdTxt.Margin = new System.Windows.Forms.Padding(4);
            this.deviceIdTxt.Name = "deviceIdTxt";
            this.deviceIdTxt.Size = new System.Drawing.Size(166, 20);
            this.deviceIdTxt.TabIndex = 33;
            this.deviceIdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.saveBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 516);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(858, 33);
            this.panel2.TabIndex = 35;
            // 
            // saveBtn
            // 
            this.saveBtn.Active = false;
            this.saveBtn.Location = new System.Drawing.Point(738, 4);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(109, 25);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Title = "Zapisz";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.wifiChk);
            this.panel3.Controls.Add(this.wifiLbl);
            this.panel3.Controls.Add(this.gpsChk);
            this.panel3.Controls.Add(this.gpsLbl);
            this.panel3.Controls.Add(this.preRecordingChk);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.recordingCodecFormatCombo);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.recordingQualityCombo);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.recordingResolutionCombo);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.rightHeaderLbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(454, 36);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(404, 480);
            this.panel3.TabIndex = 36;
            // 
            // wifiChk
            // 
            this.wifiChk.AutoSize = true;
            this.wifiChk.Location = new System.Drawing.Point(173, 237);
            this.wifiChk.Margin = new System.Windows.Forms.Padding(2);
            this.wifiChk.Name = "wifiChk";
            this.wifiChk.Size = new System.Drawing.Size(15, 14);
            this.wifiChk.TabIndex = 57;
            this.wifiChk.UseVisualStyleBackColor = true;
            // 
            // wifiLbl
            // 
            this.wifiLbl.AutoSize = true;
            this.wifiLbl.BackColor = System.Drawing.Color.Transparent;
            this.wifiLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wifiLbl.Location = new System.Drawing.Point(17, 236);
            this.wifiLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.wifiLbl.Name = "wifiLbl";
            this.wifiLbl.Size = new System.Drawing.Size(31, 15);
            this.wifiLbl.TabIndex = 56;
            this.wifiLbl.Text = "WiFi";
            // 
            // gpsChk
            // 
            this.gpsChk.AutoSize = true;
            this.gpsChk.Location = new System.Drawing.Point(173, 205);
            this.gpsChk.Margin = new System.Windows.Forms.Padding(2);
            this.gpsChk.Name = "gpsChk";
            this.gpsChk.Size = new System.Drawing.Size(15, 14);
            this.gpsChk.TabIndex = 55;
            this.gpsChk.UseVisualStyleBackColor = true;
            // 
            // gpsLbl
            // 
            this.gpsLbl.AutoSize = true;
            this.gpsLbl.BackColor = System.Drawing.Color.Transparent;
            this.gpsLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpsLbl.Location = new System.Drawing.Point(17, 204);
            this.gpsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gpsLbl.Name = "gpsLbl";
            this.gpsLbl.Size = new System.Drawing.Size(32, 15);
            this.gpsLbl.TabIndex = 54;
            this.gpsLbl.Text = "GPS";
            // 
            // preRecordingChk
            // 
            this.preRecordingChk.AutoSize = true;
            this.preRecordingChk.Location = new System.Drawing.Point(173, 170);
            this.preRecordingChk.Margin = new System.Windows.Forms.Padding(2);
            this.preRecordingChk.Name = "preRecordingChk";
            this.preRecordingChk.Size = new System.Drawing.Size(15, 14);
            this.preRecordingChk.TabIndex = 53;
            this.preRecordingChk.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 169);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 15);
            this.label10.TabIndex = 52;
            this.label10.Text = "Nagrywanie wstępne";
            // 
            // recordingCodecFormatCombo
            // 
            this.recordingCodecFormatCombo.FormattingEnabled = true;
            this.recordingCodecFormatCombo.Location = new System.Drawing.Point(173, 134);
            this.recordingCodecFormatCombo.Margin = new System.Windows.Forms.Padding(2);
            this.recordingCodecFormatCombo.Name = "recordingCodecFormatCombo";
            this.recordingCodecFormatCombo.Size = new System.Drawing.Size(172, 21);
            this.recordingCodecFormatCombo.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "Kodek formatu";
            // 
            // recordingQualityCombo
            // 
            this.recordingQualityCombo.FormattingEnabled = true;
            this.recordingQualityCombo.Location = new System.Drawing.Point(173, 100);
            this.recordingQualityCombo.Margin = new System.Windows.Forms.Padding(2);
            this.recordingQualityCombo.Name = "recordingQualityCombo";
            this.recordingQualityCombo.Size = new System.Drawing.Size(172, 21);
            this.recordingQualityCombo.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 37;
            this.label3.Text = "Jakość nagrania";
            // 
            // recordingResolutionCombo
            // 
            this.recordingResolutionCombo.FormattingEnabled = true;
            this.recordingResolutionCombo.Location = new System.Drawing.Point(173, 63);
            this.recordingResolutionCombo.Margin = new System.Windows.Forms.Padding(2);
            this.recordingResolutionCombo.Name = "recordingResolutionCombo";
            this.recordingResolutionCombo.Size = new System.Drawing.Size(172, 21);
            this.recordingResolutionCombo.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "Rozdzielczość";
            // 
            // genCardId
            // 
            this.genCardId.BackColor = System.Drawing.Color.White;
            this.genCardId.BackgroundImage = global::KTA_Visor.Properties.Resources.generate;
            this.genCardId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.genCardId.Location = new System.Drawing.Point(334, 146);
            this.genCardId.Margin = new System.Windows.Forms.Padding(2);
            this.genCardId.Name = "genCardId";
            this.genCardId.Size = new System.Drawing.Size(19, 20);
            this.genCardId.TabIndex = 40;
            this.genCardId.UseVisualStyleBackColor = false;
            // 
            // cardId
            // 
            this.cardId.AutoSize = true;
            this.cardId.BackColor = System.Drawing.Color.Transparent;
            this.cardId.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardId.Location = new System.Drawing.Point(28, 146);
            this.cardId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cardId.Name = "cardId";
            this.cardId.Size = new System.Drawing.Size(52, 15);
            this.cardId.TabIndex = 38;
            this.cardId.Text = "ID Karty";
            // 
            // cardIdtxt
            // 
            this.cardIdtxt.BorderColorFocused = System.Drawing.Color.White;
            this.cardIdtxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cardIdtxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.cardIdtxt.BorderThickness = 1;
            this.cardIdtxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cardIdtxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardIdtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cardIdtxt.isPassword = false;
            this.cardIdtxt.Location = new System.Drawing.Point(176, 146);
            this.cardIdtxt.Margin = new System.Windows.Forms.Padding(4);
            this.cardIdtxt.Name = "cardIdtxt";
            this.cardIdtxt.Size = new System.Drawing.Size(166, 20);
            this.cardIdtxt.TabIndex = 39;
            this.cardIdtxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // CameraItemSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(858, 549);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CameraItemSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CameraControlForm";
            this.Load += new System.EventHandler(this.CameraItemForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar;
        private System.Windows.Forms.Label dateTimeLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox badgeIdTxt;
        private System.Windows.Forms.Label badgeLbl;
        private System.Windows.Forms.Label leftHeaderLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox dateTimeTxt;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label rightHeaderLbl;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Panel panel2;
        private KTA_Visor_UI.component.basic.button.PrimaryButton saveBtn;
        private System.Windows.Forms.ComboBox recordingResolutionCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox preRecordingChk;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox recordingCodecFormatCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox recordingQualityCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button genDeviceId;
        private System.Windows.Forms.Label deviceIdLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox deviceIdTxt;
        private System.Windows.Forms.Button syncDateTIme;
        private System.Windows.Forms.Button genBadgeId;
        private System.Windows.Forms.CheckBox wifiChk;
        private System.Windows.Forms.Label wifiLbl;
        private System.Windows.Forms.CheckBox gpsChk;
        private System.Windows.Forms.Label gpsLbl;
        private System.Windows.Forms.Button genCardId;
        private System.Windows.Forms.Label cardId;
        private Bunifu.Framework.UI.BunifuMetroTextbox cardIdtxt;
    }
}