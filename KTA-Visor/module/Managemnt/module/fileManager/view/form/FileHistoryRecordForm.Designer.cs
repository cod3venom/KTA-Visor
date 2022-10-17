namespace KTA_Visor.module.Managemnt.module.fileManager.view.form
{
    partial class FileHistoryRecordForm
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
            this.footerPanel = new System.Windows.Forms.Panel();
            this.saveBtn = new MetroFramework.Controls.MetroButton();
            this.stationIdTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.stationIdLbl = new System.Windows.Forms.Label();
            this.cameraCustomIdTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.cameraCustomIdLbl = new System.Windows.Forms.Label();
            this.badgeIdTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.badgeIdLbl = new System.Windows.Forms.Label();
            this.fileNameTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.fileNameLbl = new System.Windows.Forms.Label();
            this.fileSourceTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.fileSourceLbl = new System.Windows.Forms.Label();
            this.fileDestPathTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.fileDestPathLbl = new System.Windows.Forms.Label();
            this.fileSizeTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.fileSizeLbl = new System.Windows.Forms.Label();
            this.createdAtTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.createdAtLbl = new System.Windows.Forms.Label();
            this.isEvidenceChk = new System.Windows.Forms.CheckBox();
            this.isRemovableEvidenceChk = new System.Windows.Forms.CheckBox();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.descriptionTxt = new System.Windows.Forms.RichTextBox();
            this.playVideoBtn = new MetroFramework.Controls.MetroButton();
            this.checkSumTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.checkSumLbl = new System.Windows.Forms.Label();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.saveBtn);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(27, 797);
            this.footerPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(677, 52);
            this.footerPanel.TabIndex = 4;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(540, 14);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(115, 28);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Zapisz";
            this.saveBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.saveBtn.UseSelectable = true;
            // 
            // stationIdTxt
            // 
            this.stationIdTxt.BorderColorFocused = System.Drawing.Color.White;
            this.stationIdTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stationIdTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.stationIdTxt.BorderThickness = 1;
            this.stationIdTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.stationIdTxt.Enabled = false;
            this.stationIdTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationIdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stationIdTxt.isPassword = false;
            this.stationIdTxt.Location = new System.Drawing.Point(36, 123);
            this.stationIdTxt.Margin = new System.Windows.Forms.Padding(5);
            this.stationIdTxt.Name = "stationIdTxt";
            this.stationIdTxt.Size = new System.Drawing.Size(303, 37);
            this.stationIdTxt.TabIndex = 23;
            this.stationIdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // stationIdLbl
            // 
            this.stationIdLbl.AutoSize = true;
            this.stationIdLbl.BackColor = System.Drawing.Color.Transparent;
            this.stationIdLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationIdLbl.Location = new System.Drawing.Point(32, 100);
            this.stationIdLbl.Name = "stationIdLbl";
            this.stationIdLbl.Size = new System.Drawing.Size(141, 19);
            this.stationIdLbl.TabIndex = 22;
            this.stationIdLbl.Text = "Identyfikator Stacji";
            // 
            // cameraCustomIdTxt
            // 
            this.cameraCustomIdTxt.BorderColorFocused = System.Drawing.Color.White;
            this.cameraCustomIdTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cameraCustomIdTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.cameraCustomIdTxt.BorderThickness = 1;
            this.cameraCustomIdTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cameraCustomIdTxt.Enabled = false;
            this.cameraCustomIdTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraCustomIdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cameraCustomIdTxt.isPassword = false;
            this.cameraCustomIdTxt.Location = new System.Drawing.Point(36, 215);
            this.cameraCustomIdTxt.Margin = new System.Windows.Forms.Padding(5);
            this.cameraCustomIdTxt.Name = "cameraCustomIdTxt";
            this.cameraCustomIdTxt.Size = new System.Drawing.Size(303, 37);
            this.cameraCustomIdTxt.TabIndex = 25;
            this.cameraCustomIdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // cameraCustomIdLbl
            // 
            this.cameraCustomIdLbl.AutoSize = true;
            this.cameraCustomIdLbl.BackColor = System.Drawing.Color.Transparent;
            this.cameraCustomIdLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraCustomIdLbl.Location = new System.Drawing.Point(32, 192);
            this.cameraCustomIdLbl.Name = "cameraCustomIdLbl";
            this.cameraCustomIdLbl.Size = new System.Drawing.Size(156, 19);
            this.cameraCustomIdLbl.TabIndex = 24;
            this.cameraCustomIdLbl.Text = "Identyfikator Kamery";
            // 
            // badgeIdTxt
            // 
            this.badgeIdTxt.BorderColorFocused = System.Drawing.Color.White;
            this.badgeIdTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.badgeIdTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.badgeIdTxt.BorderThickness = 1;
            this.badgeIdTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.badgeIdTxt.Enabled = false;
            this.badgeIdTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.badgeIdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.badgeIdTxt.isPassword = false;
            this.badgeIdTxt.Location = new System.Drawing.Point(36, 320);
            this.badgeIdTxt.Margin = new System.Windows.Forms.Padding(5);
            this.badgeIdTxt.Name = "badgeIdTxt";
            this.badgeIdTxt.Size = new System.Drawing.Size(303, 37);
            this.badgeIdTxt.TabIndex = 27;
            this.badgeIdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // badgeIdLbl
            // 
            this.badgeIdLbl.AutoSize = true;
            this.badgeIdLbl.BackColor = System.Drawing.Color.Transparent;
            this.badgeIdLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.badgeIdLbl.Location = new System.Drawing.Point(32, 297);
            this.badgeIdLbl.Name = "badgeIdLbl";
            this.badgeIdLbl.Size = new System.Drawing.Size(116, 19);
            this.badgeIdLbl.TabIndex = 26;
            this.badgeIdLbl.Text = "Numer odznaki";
            // 
            // fileNameTxt
            // 
            this.fileNameTxt.BorderColorFocused = System.Drawing.Color.White;
            this.fileNameTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fileNameTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.fileNameTxt.BorderThickness = 1;
            this.fileNameTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fileNameTxt.Enabled = false;
            this.fileNameTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fileNameTxt.isPassword = false;
            this.fileNameTxt.Location = new System.Drawing.Point(36, 414);
            this.fileNameTxt.Margin = new System.Windows.Forms.Padding(5);
            this.fileNameTxt.Name = "fileNameTxt";
            this.fileNameTxt.Size = new System.Drawing.Size(303, 37);
            this.fileNameTxt.TabIndex = 29;
            this.fileNameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.AutoSize = true;
            this.fileNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.fileNameLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLbl.Location = new System.Drawing.Point(32, 390);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(94, 19);
            this.fileNameLbl.TabIndex = 28;
            this.fileNameLbl.Text = "Nazwa pliku";
            // 
            // fileSourceTxt
            // 
            this.fileSourceTxt.BorderColorFocused = System.Drawing.Color.White;
            this.fileSourceTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fileSourceTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.fileSourceTxt.BorderThickness = 1;
            this.fileSourceTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fileSourceTxt.Enabled = false;
            this.fileSourceTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSourceTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fileSourceTxt.isPassword = false;
            this.fileSourceTxt.Location = new System.Drawing.Point(379, 123);
            this.fileSourceTxt.Margin = new System.Windows.Forms.Padding(5);
            this.fileSourceTxt.Name = "fileSourceTxt";
            this.fileSourceTxt.Size = new System.Drawing.Size(303, 37);
            this.fileSourceTxt.TabIndex = 31;
            this.fileSourceTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // fileSourceLbl
            // 
            this.fileSourceLbl.AutoSize = true;
            this.fileSourceLbl.BackColor = System.Drawing.Color.Transparent;
            this.fileSourceLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSourceLbl.Location = new System.Drawing.Point(379, 100);
            this.fileSourceLbl.Name = "fileSourceLbl";
            this.fileSourceLbl.Size = new System.Drawing.Size(93, 19);
            this.fileSourceLbl.TabIndex = 30;
            this.fileSourceLbl.Text = "Żródło pliku";
            // 
            // fileDestPathTxt
            // 
            this.fileDestPathTxt.BorderColorFocused = System.Drawing.Color.White;
            this.fileDestPathTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fileDestPathTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.fileDestPathTxt.BorderThickness = 1;
            this.fileDestPathTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fileDestPathTxt.Enabled = false;
            this.fileDestPathTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileDestPathTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fileDestPathTxt.isPassword = false;
            this.fileDestPathTxt.Location = new System.Drawing.Point(379, 215);
            this.fileDestPathTxt.Margin = new System.Windows.Forms.Padding(5);
            this.fileDestPathTxt.Name = "fileDestPathTxt";
            this.fileDestPathTxt.Size = new System.Drawing.Size(303, 37);
            this.fileDestPathTxt.TabIndex = 33;
            this.fileDestPathTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // fileDestPathLbl
            // 
            this.fileDestPathLbl.AutoSize = true;
            this.fileDestPathLbl.BackColor = System.Drawing.Color.Transparent;
            this.fileDestPathLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileDestPathLbl.Location = new System.Drawing.Point(379, 192);
            this.fileDestPathLbl.Name = "fileDestPathLbl";
            this.fileDestPathLbl.Size = new System.Drawing.Size(124, 19);
            this.fileDestPathLbl.TabIndex = 32;
            this.fileDestPathLbl.Text = "Lokalizacja pliku";
            // 
            // fileSizeTxt
            // 
            this.fileSizeTxt.BorderColorFocused = System.Drawing.Color.White;
            this.fileSizeTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fileSizeTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.fileSizeTxt.BorderThickness = 1;
            this.fileSizeTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fileSizeTxt.Enabled = false;
            this.fileSizeTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSizeTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fileSizeTxt.isPassword = false;
            this.fileSizeTxt.Location = new System.Drawing.Point(379, 320);
            this.fileSizeTxt.Margin = new System.Windows.Forms.Padding(5);
            this.fileSizeTxt.Name = "fileSizeTxt";
            this.fileSizeTxt.Size = new System.Drawing.Size(303, 37);
            this.fileSizeTxt.TabIndex = 35;
            this.fileSizeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // fileSizeLbl
            // 
            this.fileSizeLbl.AutoSize = true;
            this.fileSizeLbl.BackColor = System.Drawing.Color.Transparent;
            this.fileSizeLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSizeLbl.Location = new System.Drawing.Point(379, 297);
            this.fileSizeLbl.Name = "fileSizeLbl";
            this.fileSizeLbl.Size = new System.Drawing.Size(105, 19);
            this.fileSizeLbl.TabIndex = 34;
            this.fileSizeLbl.Text = "Rozmiar pliku";
            // 
            // createdAtTxt
            // 
            this.createdAtTxt.BorderColorFocused = System.Drawing.Color.White;
            this.createdAtTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.createdAtTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.createdAtTxt.BorderThickness = 1;
            this.createdAtTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.createdAtTxt.Enabled = false;
            this.createdAtTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdAtTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.createdAtTxt.isPassword = false;
            this.createdAtTxt.Location = new System.Drawing.Point(379, 414);
            this.createdAtTxt.Margin = new System.Windows.Forms.Padding(5);
            this.createdAtTxt.Name = "createdAtTxt";
            this.createdAtTxt.Size = new System.Drawing.Size(303, 37);
            this.createdAtTxt.TabIndex = 39;
            this.createdAtTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // createdAtLbl
            // 
            this.createdAtLbl.AutoSize = true;
            this.createdAtLbl.BackColor = System.Drawing.Color.Transparent;
            this.createdAtLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdAtLbl.Location = new System.Drawing.Point(379, 390);
            this.createdAtLbl.Name = "createdAtLbl";
            this.createdAtLbl.Size = new System.Drawing.Size(123, 19);
            this.createdAtLbl.TabIndex = 38;
            this.createdAtLbl.Text = "Data stworzenia";
            // 
            // isEvidenceChk
            // 
            this.isEvidenceChk.AutoSize = true;
            this.isEvidenceChk.Font = new System.Drawing.Font("Inter", 9F);
            this.isEvidenceChk.Location = new System.Drawing.Point(36, 458);
            this.isEvidenceChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.isEvidenceChk.Name = "isEvidenceChk";
            this.isEvidenceChk.Size = new System.Drawing.Size(81, 23);
            this.isEvidenceChk.TabIndex = 42;
            this.isEvidenceChk.Text = "Dowód";
            this.isEvidenceChk.UseVisualStyleBackColor = true;
            // 
            // isRemovableEvidenceChk
            // 
            this.isRemovableEvidenceChk.AutoSize = true;
            this.isRemovableEvidenceChk.Font = new System.Drawing.Font("Inter", 9F);
            this.isRemovableEvidenceChk.Location = new System.Drawing.Point(379, 458);
            this.isRemovableEvidenceChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.isRemovableEvidenceChk.Name = "isRemovableEvidenceChk";
            this.isRemovableEvidenceChk.Size = new System.Drawing.Size(136, 23);
            this.isRemovableEvidenceChk.TabIndex = 43;
            this.isRemovableEvidenceChk.Text = "Można usuwać";
            this.isRemovableEvidenceChk.UseVisualStyleBackColor = true;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.BackColor = System.Drawing.Color.Transparent;
            this.descriptionLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(32, 582);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(41, 19);
            this.descriptionLbl.TabIndex = 44;
            this.descriptionLbl.Text = "Opis";
            // 
            // descriptionTxt
            // 
            this.descriptionTxt.BackColor = System.Drawing.SystemColors.Control;
            this.descriptionTxt.Font = new System.Drawing.Font("Inter", 9F);
            this.descriptionTxt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.descriptionTxt.Location = new System.Drawing.Point(36, 613);
            this.descriptionTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.descriptionTxt.Name = "descriptionTxt";
            this.descriptionTxt.Size = new System.Drawing.Size(644, 191);
            this.descriptionTxt.TabIndex = 45;
            this.descriptionTxt.Text = "";
            // 
            // playVideoBtn
            // 
            this.playVideoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playVideoBtn.Location = new System.Drawing.Point(379, 504);
            this.playVideoBtn.Margin = new System.Windows.Forms.Padding(4);
            this.playVideoBtn.Name = "playVideoBtn";
            this.playVideoBtn.Size = new System.Drawing.Size(149, 28);
            this.playVideoBtn.TabIndex = 3;
            this.playVideoBtn.Text = "Odtwórz nagranie";
            this.playVideoBtn.UseSelectable = true;
            // 
            // checkSumTxt
            // 
            this.checkSumTxt.BorderColorFocused = System.Drawing.Color.White;
            this.checkSumTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkSumTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.checkSumTxt.BorderThickness = 1;
            this.checkSumTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.checkSumTxt.Enabled = false;
            this.checkSumTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSumTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkSumTxt.isPassword = false;
            this.checkSumTxt.Location = new System.Drawing.Point(36, 529);
            this.checkSumTxt.Margin = new System.Windows.Forms.Padding(5);
            this.checkSumTxt.Name = "checkSumTxt";
            this.checkSumTxt.Size = new System.Drawing.Size(303, 37);
            this.checkSumTxt.TabIndex = 47;
            this.checkSumTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // checkSumLbl
            // 
            this.checkSumLbl.AutoSize = true;
            this.checkSumLbl.BackColor = System.Drawing.Color.Transparent;
            this.checkSumLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSumLbl.Location = new System.Drawing.Point(32, 505);
            this.checkSumLbl.Name = "checkSumLbl";
            this.checkSumLbl.Size = new System.Drawing.Size(120, 19);
            this.checkSumLbl.TabIndex = 46;
            this.checkSumLbl.Text = "Suma kontrolna";
            // 
            // FileHistoryRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 874);
            this.Controls.Add(this.checkSumTxt);
            this.Controls.Add(this.checkSumLbl);
            this.Controls.Add(this.playVideoBtn);
            this.Controls.Add(this.descriptionTxt);
            this.Controls.Add(this.descriptionLbl);
            this.Controls.Add(this.isRemovableEvidenceChk);
            this.Controls.Add(this.isEvidenceChk);
            this.Controls.Add(this.createdAtTxt);
            this.Controls.Add(this.createdAtLbl);
            this.Controls.Add(this.fileSizeTxt);
            this.Controls.Add(this.fileSizeLbl);
            this.Controls.Add(this.fileDestPathTxt);
            this.Controls.Add(this.fileDestPathLbl);
            this.Controls.Add(this.fileSourceTxt);
            this.Controls.Add(this.fileSourceLbl);
            this.Controls.Add(this.fileNameTxt);
            this.Controls.Add(this.fileNameLbl);
            this.Controls.Add(this.badgeIdTxt);
            this.Controls.Add(this.badgeIdLbl);
            this.Controls.Add(this.cameraCustomIdTxt);
            this.Controls.Add(this.cameraCustomIdLbl);
            this.Controls.Add(this.stationIdTxt);
            this.Controls.Add(this.stationIdLbl);
            this.Controls.Add(this.footerPanel);
            this.DisplayHeader = false;
            this.DoubleBuffered = false;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FileHistoryRecordForm";
            this.Padding = new System.Windows.Forms.Padding(27, 37, 27, 25);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "FileHistoryRecordForm";
            this.Load += new System.EventHandler(this.FileHistoryRecordForm_Load);
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel footerPanel;
        private Bunifu.Framework.UI.BunifuMetroTextbox createdAtTxt;
        private System.Windows.Forms.Label createdAtLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox fileSizeTxt;
        private System.Windows.Forms.Label fileSizeLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox fileDestPathTxt;
        private System.Windows.Forms.Label fileDestPathLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox fileSourceTxt;
        private System.Windows.Forms.Label fileSourceLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox fileNameTxt;
        private System.Windows.Forms.Label fileNameLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox badgeIdTxt;
        private System.Windows.Forms.Label badgeIdLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox cameraCustomIdTxt;
        private System.Windows.Forms.Label cameraCustomIdLbl;
        private Bunifu.Framework.UI.BunifuMetroTextbox stationIdTxt;
        private System.Windows.Forms.Label stationIdLbl;
        private System.Windows.Forms.CheckBox isRemovableEvidenceChk;
        private System.Windows.Forms.CheckBox isEvidenceChk;
        private System.Windows.Forms.RichTextBox descriptionTxt;
        private System.Windows.Forms.Label descriptionLbl;
        private MetroFramework.Controls.MetroButton saveBtn;
        private MetroFramework.Controls.MetroButton playVideoBtn;
        private Bunifu.Framework.UI.BunifuMetroTextbox checkSumTxt;
        private System.Windows.Forms.Label checkSumLbl;
    }
}