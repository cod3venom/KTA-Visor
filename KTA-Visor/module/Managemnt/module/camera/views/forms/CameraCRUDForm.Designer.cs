namespace KTA_Visor.module.Managemnt.module.camera.views.forms
{
    partial class CameraCRUDForm
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
            this.camCustomIdTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.camCustomIdLbl = new System.Windows.Forms.Label();
            this.saveBtn = new KTA_Visor_UI.component.basic.button.PrimaryButton();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
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
            this.topBar1.Size = new System.Drawing.Size(800, 44);
            this.topBar1.TabIndex = 1;
            this.topBar1.Title = "Window";
            // 
            // camCustomIdTxt
            // 
            this.camCustomIdTxt.BorderColorFocused = System.Drawing.Color.White;
            this.camCustomIdTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.camCustomIdTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.camCustomIdTxt.BorderThickness = 1;
            this.camCustomIdTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.camCustomIdTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.camCustomIdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.camCustomIdTxt.isPassword = false;
            this.camCustomIdTxt.Location = new System.Drawing.Point(16, 93);
            this.camCustomIdTxt.Margin = new System.Windows.Forms.Padding(4);
            this.camCustomIdTxt.Name = "camCustomIdTxt";
            this.camCustomIdTxt.Size = new System.Drawing.Size(303, 37);
            this.camCustomIdTxt.TabIndex = 19;
            this.camCustomIdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // camCustomIdLbl
            // 
            this.camCustomIdLbl.AutoSize = true;
            this.camCustomIdLbl.BackColor = System.Drawing.Color.Transparent;
            this.camCustomIdLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.camCustomIdLbl.Location = new System.Drawing.Point(12, 70);
            this.camCustomIdLbl.Name = "camCustomIdLbl";
            this.camCustomIdLbl.Size = new System.Drawing.Size(156, 19);
            this.camCustomIdLbl.TabIndex = 18;
            this.camCustomIdLbl.Text = "Identyfikator Kamery";
            // 
            // saveBtn
            // 
            this.saveBtn.Active = false;
            this.saveBtn.Location = new System.Drawing.Point(676, 411);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(112, 31);
            this.saveBtn.TabIndex = 26;
            this.saveBtn.Title = "Zapisz";
            // 
            // CameraCRUDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.camCustomIdTxt);
            this.Controls.Add(this.camCustomIdLbl);
            this.Controls.Add(this.topBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CameraCRUDForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CameraCRUDForm";
            this.Load += new System.EventHandler(this.CameraCRUDForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private KTA_Visor_UI.component.basic.topbar.TopBar topBar1;
        private Bunifu.Framework.UI.BunifuMetroTextbox camCustomIdTxt;
        private System.Windows.Forms.Label camCustomIdLbl;
        public KTA_Visor_UI.component.basic.button.PrimaryButton saveBtn;
    }
}