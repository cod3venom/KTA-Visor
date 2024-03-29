﻿namespace KTA_Visor.module.Managemnt.module.fileManager.handlers.form.Zipper
{
    partial class ZipperForm
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
            this.currentFileLbl = new System.Windows.Forms.Label();
            this.closeBtn = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.destinationFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // currentFileLbl
            // 
            this.currentFileLbl.AutoSize = true;
            this.currentFileLbl.Location = new System.Drawing.Point(21, 89);
            this.currentFileLbl.Name = "currentFileLbl";
            this.currentFileLbl.Size = new System.Drawing.Size(64, 17);
            this.currentFileLbl.TabIndex = 2;
            this.currentFileLbl.Text = "File.mp4";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(434, 12);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Zamknij";
            this.closeBtn.UseSelectable = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.closeBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(18, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 38);
            this.panel1.TabIndex = 4;
            // 
            // metroProgressBar
            // 
            this.metroProgressBar.Location = new System.Drawing.Point(24, 106);
            this.metroProgressBar.Name = "metroProgressBar";
            this.metroProgressBar.Size = new System.Drawing.Size(503, 23);
            this.metroProgressBar.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroProgressBar.TabIndex = 5;
            // 
            // destinationFolder
            // 
            this.destinationFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ZipperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 269);
            this.Controls.Add(this.metroProgressBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.currentFileLbl);
            this.DisplayHeader = false;
            this.Font = new System.Drawing.Font("Inter", 8.25F);
            this.Name = "ZipperForm";
            this.Padding = new System.Windows.Forms.Padding(18, 30, 18, 18);
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Load += new System.EventHandler(this.FilesCopyingForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label currentFileLbl;
        private MetroFramework.Controls.MetroButton closeBtn;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar;
        private System.Windows.Forms.FolderBrowserDialog destinationFolder;
    }
}