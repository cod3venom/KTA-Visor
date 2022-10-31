using KTA_Visor.module.Managemnt.module.camera.components.CameraFileTransfer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.camera.view.cameraFileTransfersView
{
    public partial class CameraFileTransfersView : UserControl
    {
        public CameraFileTransfersView()
        {
            InitializeComponent();
        }

        private void CameraFileTransfersView_Load(object sender, EventArgs e)
        {
   
        }

        public void Add(CameraFileTranfer transfer)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.transfersFlowPanel.Controls.Add(transfer);
            });
        }
 
    }
}
