namespace KTA_Visor_DSClient.module.camera.views.CamerasView
{
    partial class CamerasListView
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.footer1 = new KTA_Visor_UI.component.custom.Footer.Footer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.table = new KTA_Visor_UI.component.basic.table.Table();
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.footer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 563);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1289, 63);
            this.panel3.TabIndex = 1;
            // 
            // footer1
            // 
            this.footer1.AutoSize = true;
            this.footer1.BackColor = System.Drawing.Color.White;
            this.footer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footer1.Location = new System.Drawing.Point(0, 0);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(1289, 63);
            this.footer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.topBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1289, 45);
            this.panel2.TabIndex = 2;
            // 
            // table
            // 
            this.table.AllowAdd = true;
            this.table.AllowDelete = true;
            this.table.AllowEdit = true;
            this.table.AllowSearch = true;
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 45);
            this.table.Name = "table";
            this.table.ShowAdd = true;
            this.table.ShowControls = false;
            this.table.ShowDelete = true;
            this.table.ShowEdit = true;
            this.table.Size = new System.Drawing.Size(1289, 518);
            this.table.TabIndex = 3;
            // 
            // topBar1
            // 
            this.topBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(1289, 45);
            this.topBar1.TabIndex = 0;
            this.topBar1.Title = "Window";
            // 
            // CamerasView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 626);
            this.Controls.Add(this.table);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CamerasView";
            this.Text = "CamerasView";
            this.Load += new System.EventHandler(this.CamerasView_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel3;
        private KTA_Visor_UI.component.custom.Footer.Footer footer1;
        private System.Windows.Forms.Panel panel2;
        private KTA_Visor_UI.component.basic.table.Table table;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
    }
}