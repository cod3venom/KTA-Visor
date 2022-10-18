using KTA_Visor.kernel.sharedKernel.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Managemnt.module.cardReader.controller
{
    public class CardController : IControllerInterface
    {
        public void Watch(Request request)
        {
            switch(request.Endpoint)
            {
                case "response://camera/blink/card/device-not-found":
                        this.cameraWithProvidedCardNotFound(request);
                    break;
            }
        }

        private void cameraWithProvidedCardNotFound(Request request)
        {
            MessageBox.Show("Kamera z taką kartą nie została odnależiona");
        }
    }
}
