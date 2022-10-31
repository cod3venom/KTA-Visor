namespace KTA_Visor.module.Managemnt.module.camera.view.cameraFileTransfersView
{
    partial class CameraFileTransfersView
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
            this.transfersFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // transfersFlowPanel
            // 
            this.transfersFlowPanel.BackColor = System.Drawing.Color.White;
            this.transfersFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transfersFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.transfersFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.transfersFlowPanel.Name = "transfersFlowPanel";
            this.transfersFlowPanel.Size = new System.Drawing.Size(887, 605);
            this.transfersFlowPanel.TabIndex = 0;
            // 
            // CameraFileTransfersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.transfersFlowPanel);
            this.Name = "CameraFileTransfersView";
            this.Size = new System.Drawing.Size(887, 605);
            this.Load += new System.EventHandler(this.CameraFileTransfersView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel transfersFlowPanel;
    }
}
