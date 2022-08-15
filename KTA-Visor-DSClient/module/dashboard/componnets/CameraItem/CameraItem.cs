﻿using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.dashboard.componnets.CameraItem
{
    public partial class CameraItem : UserControl
    {
        public CameraItem()
        {
            InitializeComponent();
        }

        public CameraItem(USBCameraDevice camera)
        {
            InitializeComponent();
            this.SerialNumber = camera.SerialNumber;
            this.Name = camera.Drive.Name;
            this.Camera = camera;
            this.Badge = String.Format("Kamera - {0}", camera.BadgeId);
        }

        public CameraItem(string name, string serialNumber = "")
        {
            this.Name = name;
            this.SerialNumber = serialNumber;
            this.Badge = "Kamera - 124131";
             
        }

        private void CameraItem_Load(object sender, EventArgs e)
        {
           // this.Padding = new Padding(10, 10, 10, 20);
        }

        private void CameraItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#002361");
        }

        private void CameraItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#556C95");
        }

        public USBCameraDevice Camera { get; set; }

        public string Name 
        { 
            get { return this.cameraNameLbl.Text; }
            set { this.cameraNameLbl.Text = value; }
        }

        public string SerialNumber 
        {
            get { return this.cameraSNLbl.Text; }
            set { this.cameraSNLbl.Text = value; }
        }

        public string Badge
        {
            get { return this.badgeLbl.Text; }
            set { this.badgeLbl.Text = value; }
        }

        public string Drive
        {
            get { return this.cameraDriveLbl.Text; }
            set { this.cameraDriveLbl.Text = value; }
        }

       
    }
}
