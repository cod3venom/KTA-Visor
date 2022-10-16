using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor_UI.component.custom.ClientsList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Managemnt.module.clientsManager.view
{
    public partial class ClientsManagerView : ClientsList, IControllerInterface
    {
        public ClientsManagerView()
        {
            InitializeComponent();
        }

        public void Watch(Request request)
        {
        }
    }
}
