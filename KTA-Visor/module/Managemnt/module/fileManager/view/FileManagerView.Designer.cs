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
            this.oprogramowanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upgradeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
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
            this.table.Size = new System.Drawing.Size(1750, 827);
            this.table.TabIndex = 0;
            this.table.Title = "Historia Plików";
            // 
            // contextMenu
            // 
            this.contextMenu.BackColor = System.Drawing.Color.Silver;
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemPlikówToolStripMenuItem,
            this.oprogramowanieToolStripMenuItem});
            this.contextMenu.Name = "cameraItemMenuStrip";
            this.contextMenu.Size = new System.Drawing.Size(200, 56);
            // 
            // systemPlikówToolStripMenuItem
            // 
            this.systemPlikówToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyFilesToUSBMenuItem});
            this.systemPlikówToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemPlikówToolStripMenuItem.Image")));
            this.systemPlikówToolStripMenuItem.Name = "systemPlikówToolStripMenuItem";
            this.systemPlikówToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.systemPlikówToolStripMenuItem.Text = "System Plików";
            // 
            // copyFilesToUSBMenuItem
            // 
            this.copyFilesToUSBMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyFilesToUSBMenuItem.Image")));
            this.copyFilesToUSBMenuItem.Name = "copyFilesToUSBMenuItem";
            this.copyFilesToUSBMenuItem.Size = new System.Drawing.Size(261, 26);
            this.copyFilesToUSBMenuItem.Text = "Zgrywanie na Nosnik USB";
            // 
            // oprogramowanieToolStripMenuItem
            // 
            this.oprogramowanieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upgradeMenuItem});
            this.oprogramowanieToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("oprogramowanieToolStripMenuItem.Image")));
            this.oprogramowanieToolStripMenuItem.Name = "oprogramowanieToolStripMenuItem";
            this.oprogramowanieToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.oprogramowanieToolStripMenuItem.Text = "Oprogramowanie";
            // 
            // upgradeMenuItem
            // 
            this.upgradeMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("upgradeMenuItem.Image")));
            this.upgradeMenuItem.Name = "upgradeMenuItem";
            this.upgradeMenuItem.Size = new System.Drawing.Size(224, 26);
            this.upgradeMenuItem.Text = "Aktualizacja";
            // 
            // FileManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FileManagerView";
            this.Size = new System.Drawing.Size(1750, 827);
            this.Load += new System.EventHandler(this.FileHistoryViewPanel_Load);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KTA_Visor_UI.component.basic.table.Table table;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem systemPlikówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFilesToUSBMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oprogramowanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upgradeMenuItem;
    }
}
