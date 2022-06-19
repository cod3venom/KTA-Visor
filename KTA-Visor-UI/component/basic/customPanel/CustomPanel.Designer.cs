namespace KTA_Visor_UI.component.basic.shadowPanel
{
    partial class CustomPanel
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
            this.mainElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SuspendLayout();
            // 
            // mainElipse
            // 
            this.mainElipse.ElipseRadius = 5;
            this.mainElipse.TargetControl = this;
            this.mainElipse.TargetControlResized += new System.EventHandler(this.ShadowPanel_Load);
            // 
            // CustomPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "CustomPanel";
            this.Size = new System.Drawing.Size(384, 385);
            this.Load += new System.EventHandler(this.ShadowPanel_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomPanel_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse mainElipse;
    }
}
