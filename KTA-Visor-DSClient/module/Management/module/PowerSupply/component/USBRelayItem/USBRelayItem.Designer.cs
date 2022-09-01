namespace KTA_Visor_DSClient.module.Management.module.PowerSupply.component.USBRelayItem
{
    partial class USBRelayItem
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
            this.powerIcon = new Bunifu.Framework.UI.BunifuImageButton();
            this.actionBtn = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            ((System.ComponentModel.ISupportInitialize)(this.powerIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // powerIcon
            // 
            this.powerIcon.BackColor = System.Drawing.Color.Transparent;
            this.powerIcon.Image = global::KTA_Visor_DSClient.Properties.Resources.usbPort_on;
            this.powerIcon.ImageActive = null;
            this.powerIcon.Location = new System.Drawing.Point(63, 20);
            this.powerIcon.Name = "powerIcon";
            this.powerIcon.Size = new System.Drawing.Size(59, 45);
            this.powerIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.powerIcon.TabIndex = 0;
            this.powerIcon.TabStop = false;
            this.powerIcon.Zoom = 10;
            // 
            // actionBtn
            // 
            this.actionBtn.Active = false;
            this.actionBtn.Location = new System.Drawing.Point(22, 92);
            this.actionBtn.Name = "actionBtn";
            this.actionBtn.Size = new System.Drawing.Size(145, 31);
            this.actionBtn.TabIndex = 1;
            this.actionBtn.Title = "Wyłączyć";
            // 
            // USBRelayItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.actionBtn);
            this.Controls.Add(this.powerIcon);
            this.Name = "USBRelayItem";
            this.Size = new System.Drawing.Size(189, 136);
            this.Load += new System.EventHandler(this.USBRelayItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.powerIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton powerIcon;
        private KTA_Visor_UI.component.basic.button.PrimaryButton actionBtn;
    }
}
