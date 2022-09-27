﻿namespace KTA_Visor_UI.component.basic.table
{
    partial class Table
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableControlsContainer = new System.Windows.Forms.Panel();
            this.columnFilterByCombobx = new Bunifu.Framework.UI.BunifuDropdown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.columnCombobx = new Bunifu.Framework.UI.BunifuDropdown();
            this.label1 = new System.Windows.Forms.Label();
            this.searchTxt = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.filterColumnLbl = new System.Windows.Forms.Label();
            this.searchBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.deletePanel = new System.Windows.Forms.Panel();
            this.deleteBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.editPanel = new System.Windows.Forms.Panel();
            this.editBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.addPanel = new System.Windows.Forms.Panel();
            this.addBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dataGridView1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleLbl = new System.Windows.Forms.Label();
            this.roundedTextBox1 = new KTA_Visor_UI.component.basic.textbox.RoundedTextBox();
            this.horizontalSeparator1 = new KTA_Visor_UI.component.basic.table.components.HorizontalSeparator.HorizontalSeparator();
            this.horizontalSeparator3 = new KTA_Visor_UI.component.basic.table.components.HorizontalSeparator.HorizontalSeparator();
            this.tableControlsContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.deletePanel.SuspendLayout();
            this.editPanel.SuspendLayout();
            this.addPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableControlsContainer
            // 
            this.tableControlsContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tableControlsContainer.Controls.Add(this.panel2);
            this.tableControlsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableControlsContainer.Location = new System.Drawing.Point(0, 42);
            this.tableControlsContainer.Margin = new System.Windows.Forms.Padding(0);
            this.tableControlsContainer.Name = "tableControlsContainer";
            this.tableControlsContainer.Size = new System.Drawing.Size(1660, 51);
            this.tableControlsContainer.TabIndex = 1;
            // 
            // columnFilterByCombobx
            // 
            this.columnFilterByCombobx.BackColor = System.Drawing.Color.Transparent;
            this.columnFilterByCombobx.BorderRadius = 3;
            this.columnFilterByCombobx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.columnFilterByCombobx.DisabledColor = System.Drawing.Color.Gray;
            this.columnFilterByCombobx.ForeColor = System.Drawing.Color.White;
            this.columnFilterByCombobx.Items = new string[0];
            this.columnFilterByCombobx.Location = new System.Drawing.Point(912, 4);
            this.columnFilterByCombobx.Name = "columnFilterByCombobx";
            this.columnFilterByCombobx.NomalColor = System.Drawing.Color.Transparent;
            this.columnFilterByCombobx.onHoverColor = System.Drawing.Color.Transparent;
            this.columnFilterByCombobx.selectedIndex = -1;
            this.columnFilterByCombobx.Size = new System.Drawing.Size(217, 30);
            this.columnFilterByCombobx.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.deletePanel);
            this.panel2.Controls.Add(this.editPanel);
            this.panel2.Controls.Add(this.addPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1489, 51);
            this.panel2.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.columnFilterByCombobx);
            this.panel5.Controls.Add(this.columnCombobx);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.searchTxt);
            this.panel5.Controls.Add(this.filterColumnLbl);
            this.panel5.Controls.Add(this.searchBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(416, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1191, 51);
            this.panel5.TabIndex = 13;
            // 
            // columnCombobx
            // 
            this.columnCombobx.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.columnCombobx.BackColor = System.Drawing.Color.Transparent;
            this.columnCombobx.BorderRadius = 3;
            this.columnCombobx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.columnCombobx.DisabledColor = System.Drawing.Color.Gray;
            this.columnCombobx.ForeColor = System.Drawing.Color.White;
            this.columnCombobx.Items = new string[0];
            this.columnCombobx.Location = new System.Drawing.Point(580, 4);
            this.columnCombobx.Name = "columnCombobx";
            this.columnCombobx.NomalColor = System.Drawing.Color.Transparent;
            this.columnCombobx.onHoverColor = System.Drawing.Color.Transparent;
            this.columnCombobx.selectedIndex = -1;
            this.columnCombobx.Size = new System.Drawing.Size(217, 30);
            this.columnCombobx.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(822, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Sortuj według";
            // 
            // searchTxt
            // 
            this.searchTxt.BorderColorFocused = System.Drawing.Color.White;
            this.searchTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchTxt.BorderColorMouseHover = System.Drawing.Color.White;
            this.searchTxt.BorderThickness = 1;
            this.searchTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchTxt.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchTxt.isPassword = false;
            this.searchTxt.Location = new System.Drawing.Point(7, 4);
            this.searchTxt.Margin = new System.Windows.Forms.Padding(4);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(347, 30);
            this.searchTxt.TabIndex = 16;
            this.searchTxt.Text = "...";
            this.searchTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // filterColumnLbl
            // 
            this.filterColumnLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.filterColumnLbl.AutoSize = true;
            this.filterColumnLbl.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterColumnLbl.Location = new System.Drawing.Point(509, 10);
            this.filterColumnLbl.Name = "filterColumnLbl";
            this.filterColumnLbl.Size = new System.Drawing.Size(56, 15);
            this.filterColumnLbl.TabIndex = 14;
            this.filterColumnLbl.Text = "Kolumna";
            // 
            // searchBtn
            // 
            this.searchBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.searchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.searchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchBtn.BorderRadius = 6;
            this.searchBtn.ButtonText = "Wyszukaj";
            this.searchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchBtn.DisabledColor = System.Drawing.Color.Gray;
            this.searchBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.searchBtn.Iconimage = null;
            this.searchBtn.Iconimage_right = null;
            this.searchBtn.Iconimage_right_Selected = null;
            this.searchBtn.Iconimage_Selected = null;
            this.searchBtn.IconMarginLeft = 0;
            this.searchBtn.IconMarginRight = 0;
            this.searchBtn.IconRightVisible = true;
            this.searchBtn.IconRightZoom = 0D;
            this.searchBtn.IconVisible = true;
            this.searchBtn.IconZoom = 50D;
            this.searchBtn.IsTab = false;
            this.searchBtn.Location = new System.Drawing.Point(362, 4);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(4);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.searchBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.searchBtn.OnHoverTextColor = System.Drawing.Color.Black;
            this.searchBtn.selected = false;
            this.searchBtn.Size = new System.Drawing.Size(125, 30);
            this.searchBtn.TabIndex = 10;
            this.searchBtn.Text = "Wyszukaj";
            this.searchBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.searchBtn.Textcolor = System.Drawing.Color.Black;
            this.searchBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // deletePanel
            // 
            this.deletePanel.Controls.Add(this.deleteBtn);
            this.deletePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.deletePanel.Location = new System.Drawing.Point(274, 0);
            this.deletePanel.Name = "deletePanel";
            this.deletePanel.Size = new System.Drawing.Size(142, 51);
            this.deletePanel.TabIndex = 12;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.deleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteBtn.BorderRadius = 6;
            this.deleteBtn.ButtonText = "Usuń";
            this.deleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteBtn.DisabledColor = System.Drawing.Color.Gray;
            this.deleteBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.deleteBtn.Iconimage = null;
            this.deleteBtn.Iconimage_right = null;
            this.deleteBtn.Iconimage_right_Selected = null;
            this.deleteBtn.Iconimage_Selected = null;
            this.deleteBtn.IconMarginLeft = 0;
            this.deleteBtn.IconMarginRight = 0;
            this.deleteBtn.IconRightVisible = true;
            this.deleteBtn.IconRightZoom = 0D;
            this.deleteBtn.IconVisible = true;
            this.deleteBtn.IconZoom = 50D;
            this.deleteBtn.IsTab = false;
            this.deleteBtn.Location = new System.Drawing.Point(17, 8);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.deleteBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.deleteBtn.OnHoverTextColor = System.Drawing.Color.Black;
            this.deleteBtn.selected = false;
            this.deleteBtn.Size = new System.Drawing.Size(87, 27);
            this.deleteBtn.TabIndex = 9;
            this.deleteBtn.Text = "Usuń";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteBtn.Textcolor = System.Drawing.Color.Black;
            this.deleteBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // editPanel
            // 
            this.editPanel.Controls.Add(this.editBtn);
            this.editPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.editPanel.Location = new System.Drawing.Point(136, 0);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(138, 51);
            this.editPanel.TabIndex = 11;
            // 
            // editBtn
            // 
            this.editBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.editBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.editBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editBtn.BorderRadius = 6;
            this.editBtn.ButtonText = "Edycja";
            this.editBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editBtn.DisabledColor = System.Drawing.Color.Gray;
            this.editBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.editBtn.Iconimage = null;
            this.editBtn.Iconimage_right = null;
            this.editBtn.Iconimage_right_Selected = null;
            this.editBtn.Iconimage_Selected = null;
            this.editBtn.IconMarginLeft = 0;
            this.editBtn.IconMarginRight = 0;
            this.editBtn.IconRightVisible = true;
            this.editBtn.IconRightZoom = 0D;
            this.editBtn.IconVisible = true;
            this.editBtn.IconZoom = 50D;
            this.editBtn.IsTab = false;
            this.editBtn.Location = new System.Drawing.Point(16, 8);
            this.editBtn.Margin = new System.Windows.Forms.Padding(4);
            this.editBtn.Name = "editBtn";
            this.editBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.editBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.editBtn.OnHoverTextColor = System.Drawing.Color.Black;
            this.editBtn.selected = false;
            this.editBtn.Size = new System.Drawing.Size(87, 27);
            this.editBtn.TabIndex = 8;
            this.editBtn.Text = "Edycja";
            this.editBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editBtn.Textcolor = System.Drawing.Color.Black;
            this.editBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // addPanel
            // 
            this.addPanel.Controls.Add(this.addBtn);
            this.addPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.addPanel.Location = new System.Drawing.Point(0, 0);
            this.addPanel.Name = "addPanel";
            this.addPanel.Size = new System.Drawing.Size(136, 51);
            this.addPanel.TabIndex = 10;
            // 
            // addBtn
            // 
            this.addBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.addBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addBtn.BorderRadius = 6;
            this.addBtn.ButtonText = "Utwórz";
            this.addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBtn.DisabledColor = System.Drawing.Color.Gray;
            this.addBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.addBtn.Iconimage = null;
            this.addBtn.Iconimage_right = null;
            this.addBtn.Iconimage_right_Selected = null;
            this.addBtn.Iconimage_Selected = null;
            this.addBtn.IconMarginLeft = 0;
            this.addBtn.IconMarginRight = 0;
            this.addBtn.IconRightVisible = true;
            this.addBtn.IconRightZoom = 0D;
            this.addBtn.IconVisible = true;
            this.addBtn.IconZoom = 50D;
            this.addBtn.IsTab = false;
            this.addBtn.Location = new System.Drawing.Point(14, 8);
            this.addBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addBtn.Name = "addBtn";
            this.addBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.addBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.addBtn.OnHoverTextColor = System.Drawing.Color.Black;
            this.addBtn.selected = false;
            this.addBtn.Size = new System.Drawing.Size(87, 26);
            this.addBtn.TabIndex = 7;
            this.addBtn.Text = "Utwórz";
            this.addBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addBtn.Textcolor = System.Drawing.Color.Black;
            this.addBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.DoubleBuffered = true;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.dataGridView1.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(0, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Inter Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(178)))), ((int)(((byte)(7)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1660, 674);
            this.dataGridView1.TabIndex = 6;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 5;
            this.bunifuElipse2.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.titleLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1660, 42);
            this.panel1.TabIndex = 10;
            // 
            // titleLbl
            // 
            this.titleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLbl.Font = new System.Drawing.Font("Inter Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.Location = new System.Drawing.Point(0, 0);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(1660, 42);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "title";
            this.titleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundedTextBox1
            // 
            this.roundedTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(212)))), ((int)(((byte)(245)))));
            this.roundedTextBox1.BorderRadius = 5;
            this.roundedTextBox1.Location = new System.Drawing.Point(325, 26);
            this.roundedTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.roundedTextBox1.Name = "roundedTextBox1";
            this.roundedTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.roundedTextBox1.Size = new System.Drawing.Size(623, 30);
            this.roundedTextBox1.TabIndex = 7;
            // 
            // horizontalSeparator1
            // 
            this.horizontalSeparator1.BackColor = System.Drawing.Color.Silver;
            this.horizontalSeparator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horizontalSeparator1.Location = new System.Drawing.Point(0, 717);
            this.horizontalSeparator1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.horizontalSeparator1.Name = "horizontalSeparator1";
            this.horizontalSeparator1.Size = new System.Drawing.Size(1310, 2);
            this.horizontalSeparator1.TabIndex = 4;
            // 
            // horizontalSeparator3
            // 
            this.horizontalSeparator3.BackColor = System.Drawing.Color.Silver;
            this.horizontalSeparator3.Dock = System.Windows.Forms.DockStyle.Top;
            this.horizontalSeparator3.Location = new System.Drawing.Point(0, 0);
            this.horizontalSeparator3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.horizontalSeparator3.Name = "horizontalSeparator3";
            this.horizontalSeparator3.Size = new System.Drawing.Size(1310, 2);
            this.horizontalSeparator3.TabIndex = 8;
            // 
            // Table
            // 
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tableControlsContainer);
            this.Controls.Add(this.panel1);
            this.Name = "Table";
            this.Size = new System.Drawing.Size(1660, 767);
            this.Load += new System.EventHandler(this.Table_Load);
            this.tableControlsContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.deletePanel.ResumeLayout(false);
            this.editPanel.ResumeLayout(false);
            this.addPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel tableControlsContainer;
        private components.HorizontalSeparator.HorizontalSeparator horizontalSeparator1;
        private components.HorizontalSeparator.HorizontalSeparator horizontalSeparator3;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dataGridView1;
        private Bunifu.Framework.UI.BunifuFlatButton addBtn;
        private textbox.RoundedTextBox roundedTextBox1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuFlatButton deleteBtn;
        private Bunifu.Framework.UI.BunifuFlatButton editBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel deletePanel;
        private System.Windows.Forms.Panel editPanel;
        private System.Windows.Forms.Panel addPanel;
        private Bunifu.Framework.UI.BunifuFlatButton searchBtn;
        private Bunifu.Framework.UI.BunifuMetroTextbox searchTxt;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label filterColumnLbl;
        private Bunifu.Framework.UI.BunifuDropdown columnCombobx;
        private Bunifu.Framework.UI.BunifuDropdown columnFilterByCombobx;
    }
}
