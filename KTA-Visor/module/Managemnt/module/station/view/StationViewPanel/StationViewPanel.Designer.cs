namespace KTA_Visor.module.Managemnt.module.station.view.StationViewPanel
{
    partial class StationViewPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.stationCamerasPanel = new KTA_Visor.module.Managemnt.module.station.view.StationCameraPanel.StationCamerasPanel();
            this.panel1.SuspendLayout();
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
            this.table.Size = new System.Drawing.Size(850, 696);
            this.table.TabIndex = 1;
            this.table.Title = "Stacje";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.stationCamerasPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 359);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 337);
            this.panel1.TabIndex = 2;
            // 
            // stationCamerasPanel
            // 
            this.stationCamerasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stationCamerasPanel.Location = new System.Drawing.Point(0, 0);
            this.stationCamerasPanel.Name = "stationCamerasPanel";
            this.stationCamerasPanel.Size = new System.Drawing.Size(850, 337);
            this.stationCamerasPanel.TabIndex = 0;
            // 
            // StationViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.table);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StationViewPanel";
            this.Size = new System.Drawing.Size(850, 696);
            this.Load += new System.EventHandler(this.StationViewPanel_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KTA_Visor_UI.component.basic.table.Table table;
        private System.Windows.Forms.Panel panel1;
        private StationCameraPanel.StationCamerasPanel stationCamerasPanel;
    }
}
