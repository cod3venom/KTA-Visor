﻿namespace KTA_Visor.module.Managemnt.module.fileHistory.view.FileHistoryViewPanel
{
    partial class FileHistoryViewPanel
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
            this.table = new KTA_Visor_UI.component.basic.table.Table();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.AllowAdd = false;
            this.table.AllowDelete = true;
            this.table.AllowEdit = true;
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Margin = new System.Windows.Forms.Padding(2);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(1420, 672);
            this.table.TabIndex = 0;
            this.table.Title = "Historia Plików";
            // 
            // FileHistoryViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FileHistoryViewPanel";
            this.Size = new System.Drawing.Size(1420, 672);
            this.Load += new System.EventHandler(this.FileHistoryViewPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private KTA_Visor_UI.component.basic.table.Table table;
    }
}
