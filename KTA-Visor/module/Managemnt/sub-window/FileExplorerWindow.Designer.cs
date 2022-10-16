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
            this.fileExplorer1 = new KTA_Visor_UI.component.custom.FIleExplorer.FileExplorer();
            this.SuspendLayout();
            // 
            // fileExplorer1
            // 
            this.fileExplorer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileExplorer1.Location = new System.Drawing.Point(20, 30);
            this.fileExplorer1.Name = "fileExplorer1";
            this.fileExplorer1.Size = new System.Drawing.Size(760, 400);
            this.fileExplorer1.TabIndex = 0;
            this.fileExplorer1.WorkingDirectory = null;
            // 
            // FileExplorerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fileExplorer1);
            this.DisplayHeader = false;
            this.Name = "FileExplorerWindow";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "FileExplorerWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private KTA_Visor_UI.component.custom.FIleExplorer.FileExplorer fileExplorer1;
    }
}