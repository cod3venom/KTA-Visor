﻿namespace KTA_Visor_UI.component.basic.progressbar
{
    partial class FullScreenCircleLoader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullScreenCircleLoader));
            this.spinnerPicBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerPicBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spinnerPicBox
            // 
            this.spinnerPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinnerPicBox.Image = ((System.Drawing.Image)(resources.GetObject("spinnerPicBox.Image")));
            this.spinnerPicBox.Location = new System.Drawing.Point(3, 3);
            this.spinnerPicBox.Name = "spinnerPicBox";
            this.spinnerPicBox.Size = new System.Drawing.Size(1109, 921);
            this.spinnerPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.spinnerPicBox.TabIndex = 0;
            this.spinnerPicBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.spinnerPicBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1115, 927);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // FullScreenCircleLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FullScreenCircleLoader";
            this.Size = new System.Drawing.Size(1115, 927);
            this.Load += new System.EventHandler(this.FullScreenCircleLoader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinnerPicBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox spinnerPicBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
