﻿using KTA_TCPBridge.BridgeServer.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_TCPBridge.BridgeServer.Resource.Server.Events
{
    public class TCPServerClientDisonnectedEvent : EventArgs
    {
        private readonly TCPClientTObject client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public TCPServerClientDisonnectedEvent(TCPClientTObject client)
        {
            this.client = client;
        }

        public TCPClientTObject getClient() => this.client;
    }
}
