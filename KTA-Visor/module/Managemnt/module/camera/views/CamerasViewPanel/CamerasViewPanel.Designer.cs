namespace KTA_Visor.module.Managemnt.module.camera.views.CameraViewPanel
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
            this.table.AllowAdd = false;
            this.table.AllowDelete = false;
            this.table.AllowEdit = false;
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Margin = new System.Windows.Forms.Padding(2);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(980, 558);
            this.table.TabIndex = 0;
            this.table.Title = "Kamery";
            // 
            // CamerasViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CamerasViewPanel";
            this.Size = new System.Drawing.Size(980, 558);
            this.Load += new System.EventHandler(this.CamerasViewPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private KTA_Visor_UI.component.basic.table.Table table;
    }
}
