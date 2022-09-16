using KTA_Visor_DSClient.module.Management.module.Camera.controller;
using KTAVisorAPISDK.module.camera.entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.module.client.events;

namespace KTA_Visor_DSClient.module.Management.workers.Tunnel.controller
{
    public class TunnelController
    {
        public event EventHandler<TCPEndpointReceivedEvent> OnEndpointReceived;

        public  TunnelController()
        {

        }

        public void Watch(Request request)
        {


            if (request.Endpoint.Contains("command://station"))
            {
                
            }


            if (request.Endpoint.Contains("command://camera") || request.Endpoint.Contains("command://cameras"))
            {
                new CameraController().Watch(request);
            }

            this.OnEndpointReceived?.Invoke(this, new TCPEndpointReceivedEvent(request));
        }
    }
}
