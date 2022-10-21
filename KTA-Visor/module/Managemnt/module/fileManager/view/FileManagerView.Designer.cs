namespace KTA_Visor.module.Managemnt.module.fileManager.view
{
    partial class FileManagerView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManagerView));
            this.table = new KTA_Visor_UI.component.basic.table.Table();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.systemPlikówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFilesToUSBMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reportsBtn = new MetroFramework.Controls.MetroButton();
            this.contextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.AllowAdd = false;
            this.table.AllowDelete = true;
            this.table.AllowEdit = true;
            this.table.AllowProgressBar = true;
            this.table.ContextMenuStrip = this.contextMenu;
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(1045, 639);
            this.table.TabIndex = 0;
            this.table.Title = "Historia Plików";
            // 
            // contextMenu
            // 
            this.contextMenu.BackColor = System.Drawing.Color.Silver;
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemPlikówToolStripMenuItem,
            this.reportsMenuItem});
            this.contextMenu.Name = "cameraItemMenuStrip";
            this.contextMenu.Size = new System.Drawing.Size(183, 56);
            // 
            // systemPlikówToolStripMenuItem
            // 
            this.systemPlikówToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyFilesToUSBMenuItem});
            this.systemPlikówToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemPlikówToolStripMenuItem.Image")));
            this.systemPlikówToolStripMenuItem.Name = "systemPlikówToolStripMenuItem";
            this.systemPlikówToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.systemPlikówToolStripMenuItem.Text = "System Plików";
            // 
            // copyFilesToUSBMenuItem
            // 
            this.copyFilesToUSBMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyFilesToUSBMenuItem.Image")));
            this.copyFilesToUSBMenuItem.Name = "copyFilesToUSBMenuItem";
            this.copyFilesToUSBMenuItem.Size = new System.Drawing.Size(261, 26);
            this.copyFilesToUSBMenuItem.Text = "Zgrywanie na Nosnik USB";
            // 
            // reportsMenuItem
            // 
            this.reportsMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportsMenuItem.Image")));
            this.reportsMenuItem.Name = "reportsMenuItem";
            this.reportsMenuItem.Size = new System.Drawing.Size(182, 26);
            this.reportsMenuItem.Text = "Raporty plików";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportsBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 639);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 70);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.table);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1045, 639);
            this.panel2.TabIndex = 2;
            // 
            // reportsBtn
            // 
            this.reportsBtn.Location = new System.Drawing.Point(14, 15);
            this.reportsBtn.Name = "reportsBtn";
            this.reportsBtn.Size = new System.Drawing.Size(112, 33);
            this.reportsBtn.Style = MetroFramework.MetroColorStyle.White;
            this.reportsBtn.TabIndex = 0;
            this.reportsBtn.Text = "Raporty";
            this.reportsBtn.Theme = MetroFramework.MetroThemeStyle.Light;
            this.reportsBtn.UseSelectable = true;
            // 
            // FileManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FileManagerView";
            this.Size = new System.Drawing.Size(1045, 709);
            this.Load += new System.EventHandler(this.FileHistoryViewPanel_Load);
            this.contextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KTA_Visor_UI.component.basic.table.Table table;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem systemPlikówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFilesToUSBMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsMenuItem;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton reportsBtn;
        private System.Windows.Forms.Panel panel2;
    }
}
