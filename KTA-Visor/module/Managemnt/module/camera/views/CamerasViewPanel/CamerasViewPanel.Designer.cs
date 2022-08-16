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
            this.table1 = new KTA_Visor_UI.component.basic.table.Table();
            this.SuspendLayout();
            // 
            // table1
            // 
            this.table1.AllowAdd = true;
            this.table1.AllowDelete = true;
            this.table1.AllowEdit = true;
            this.table1.AllowSearch = true;
            this.table1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table1.Location = new System.Drawing.Point(0, 0);
            this.table1.Name = "table1";
            this.table1.ShowAdd = true;
            this.table1.ShowControls = true;
            this.table1.ShowDelete = true;
            this.table1.ShowEdit = true;
            this.table1.Size = new System.Drawing.Size(1307, 687);
            this.table1.TabIndex = 0;
            // 
            // CamerasViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table1);
            this.Name = "CamerasViewPanel";
            this.Size = new System.Drawing.Size(1307, 687);
            this.ResumeLayout(false);

        }

        #endregion

        private KTA_Visor_UI.component.basic.table.Table table1;
    }
}
