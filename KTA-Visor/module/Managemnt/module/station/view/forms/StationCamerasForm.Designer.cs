namespace KTA_Visor.module.Managemnt.module.station.view.forms
{
    partial class StationCamerasForm
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
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.camerasFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.primaryButton1 = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBar1
            // 
            this.topBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(961, 44);
            this.topBar1.TabIndex = 0;
            this.topBar1.Title = "Kamery";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // camerasFlowPanel
            // 
            this.camerasFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.camerasFlowPanel.Location = new System.Drawing.Point(0, 44);
            this.camerasFlowPanel.Name = "camerasFlowPanel";
            this.camerasFlowPanel.Size = new System.Drawing.Size(961, 470);
            this.camerasFlowPanel.TabIndex = 2;
            // 
            // primaryButton1
            // 
            this.primaryButton1.Active = false;
            this.primaryButton1.Location = new System.Drawing.Point(804, 7);
            this.primaryButton1.Name = "primaryButton1";
            this.primaryButton1.Size = new System.Drawing.Size(145, 31);
            this.primaryButton1.TabIndex = 0;
            this.primaryButton1.Title = "Zamknij";
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.primaryButton1);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 514);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(961, 42);
            this.footerPanel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 470);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(941, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 470);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(20, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(921, 20);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(20, 494);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(921, 20);
            this.panel4.TabIndex = 7;
            // 
            // StationCamerasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 556);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.camerasFlowPanel);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.topBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StationCamerasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StationCamerasForm";
            this.Load += new System.EventHandler(this.StationCamerasForm_Load);
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.FlowLayoutPanel camerasFlowPanel;
        private System.Windows.Forms.Panel footerPanel;
        private KTA_Visor_UI.component.basic.button.PrimaryButton primaryButton1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}