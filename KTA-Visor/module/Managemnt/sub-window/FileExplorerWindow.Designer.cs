namespace KTA_Visor.module.Managemnt.sub_window
{
    partial class FileExplorerWindow
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
            this.topBar1 = new KTA_Visor_UI.component.basic.topbar.TopBar();
            this.fileExplorer1 = new KTA_Visor_UI.component.custom.FIleExplorer.FileExplorer();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // topBar1
            // 
            this.topBar1.AllowClose = true;
            this.topBar1.AllowMinimize = false;
            this.topBar1.AllowResize = false;
            this.topBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.topBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topBar1.Description = "";
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Margin = new System.Windows.Forms.Padding(2);
            this.topBar1.Name = "topBar1";
            this.topBar1.Parent = null;
            this.topBar1.Size = new System.Drawing.Size(1384, 36);
            this.topBar1.TabIndex = 0;
            this.topBar1.Title = "Wersja";
            // 
            // fileExplorer1
            // 
            this.fileExplorer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileExplorer1.Location = new System.Drawing.Point(0, 36);
            this.fileExplorer1.Name = "fileExplorer1";
            this.fileExplorer1.Size = new System.Drawing.Size(1384, 414);
            this.fileExplorer1.TabIndex = 1;
            this.fileExplorer1.WorkingDirectory = "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\Common7\\IDE";
            // 
            // FileExplorerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 450);
            this.Controls.Add(this.fileExplorer1);
            this.Controls.Add(this.topBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FileExplorerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VersionWindow";
            this.Load += new System.EventHandler(this.FileExplorerWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private KTA_Visor_UI.component.custom.FIleExplorer.FileExplorer fileExplorer1;
    }
}