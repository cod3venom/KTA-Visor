﻿namespace KTA_Visor.module.Managemnt.module.camera.views.CameraViewPanel
{
    partial class CamerasViewPanel
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
            this.table.AllowAdd = true;
            this.table.AllowDelete = true;
            this.table.AllowEdit = true;
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(1307, 687);
            this.table.TabIndex = 0;
            this.table.Title = "Kamery";
            // 
            // CamerasViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Name = "CamerasViewPanel";
            this.Size = new System.Drawing.Size(1307, 687);
            this.Load += new System.EventHandler(this.CamerasViewPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private KTA_Visor_UI.component.basic.table.Table table;
    }
}