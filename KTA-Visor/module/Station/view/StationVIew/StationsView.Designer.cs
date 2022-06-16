namespace KTA_Visor.module.Station.view
{
    partial class StationsView
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
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.topBar1 = new KTA_Visor.component.basic.topbar.TopBar();
            this.versionTopBarContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.footer1 = new KTA_Visor.component.custom.Footer.Footer();
            this.horizontalSeparator1 = new KTA_Visor.component.basic.table.components.HorizontalSeparator.HorizontalSeparator();
            this.table1 = new KTA_Visor.component.basic.table.Table();
            this.navigationBar1 = new KTA_Visor.component.custom.NavigationBar.NavigationBar();
            this.topBarPanel.SuspendLayout();
            this.versionTopBarContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBarPanel
            // 
            this.topBarPanel.Controls.Add(this.topBar1);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(0, 0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(1480, 35);
            this.topBarPanel.TabIndex = 0;
            // 
            // topBar1
            // 
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(1480, 35);
            this.topBar1.TabIndex = 0;
            this.topBar1.Title = "Window";
            // 
            // versionTopBarContainer
            // 
            this.versionTopBarContainer.Controls.Add(this.navigationBar1);
            this.versionTopBarContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.versionTopBarContainer.Location = new System.Drawing.Point(0, 35);
            this.versionTopBarContainer.Name = "versionTopBarContainer";
            this.versionTopBarContainer.Size = new System.Drawing.Size(1480, 121);
            this.versionTopBarContainer.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(240)))), ((int)(((byte)(251)))));
            this.panel1.Controls.Add(this.footer1);
            this.panel1.Controls.Add(this.horizontalSeparator1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 942);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1480, 82);
            this.panel1.TabIndex = 4;
            // 
            // footer1
            // 
            this.footer1.AutoSize = true;
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(240)))), ((int)(((byte)(251)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footer1.Location = new System.Drawing.Point(0, 2);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(1480, 80);
            this.footer1.TabIndex = 1;
            // 
            // horizontalSeparator1
            // 
            this.horizontalSeparator1.BackColor = System.Drawing.Color.Silver;
            this.horizontalSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.horizontalSeparator1.Location = new System.Drawing.Point(0, 0);
            this.horizontalSeparator1.Name = "horizontalSeparator1";
            this.horizontalSeparator1.Size = new System.Drawing.Size(1480, 2);
            this.horizontalSeparator1.TabIndex = 0;
            // 
            // table1
            // 
            this.table1.AllowAdd = true;
            this.table1.AllowDelete = true;
            this.table1.AllowEdit = true;
            this.table1.AllowSearch = true;
            this.table1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table1.Location = new System.Drawing.Point(0, 156);
            this.table1.Name = "table1";
            this.table1.ShowAdd = true;
            this.table1.ShowControls = false;
            this.table1.ShowDelete = true;
            this.table1.ShowEdit = true;
            this.table1.Size = new System.Drawing.Size(1480, 786);
            this.table1.TabIndex = 5;
            // 
            // navigationBar1
            // 
            this.navigationBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(240)))), ((int)(((byte)(251)))));
            this.navigationBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationBar1.Links = new string[] {
        "\"Stacje\", ",
        "\"Ustawienia\""};
            this.navigationBar1.Location = new System.Drawing.Point(0, 0);
            this.navigationBar1.Name = "navigationBar1";
            this.navigationBar1.Size = new System.Drawing.Size(1480, 121);
            this.navigationBar1.TabIndex = 0;
            // 
            // StationsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 1024);
            this.Controls.Add(this.table1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.versionTopBarContainer);
            this.Controls.Add(this.topBarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StationsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StationsView";
            this.Load += new System.EventHandler(this.StationsView_Load);
            this.topBarPanel.ResumeLayout(false);
            this.versionTopBarContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topBarPanel;
        private component.basic.topbar.TopBar topBar1;
        private System.Windows.Forms.Panel versionTopBarContainer;
        private System.Windows.Forms.Panel panel1;
        private component.basic.table.components.HorizontalSeparator.HorizontalSeparator horizontalSeparator1;
        private component.custom.Footer.Footer footer1;
        private component.basic.table.Table table1;
        private component.custom.NavigationBar.NavigationBar navigationBar1;
    }
}