﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPTunnel.kernel.types
{
    public class TCPClientList: List<TCPClientTObject>
    {

        public TCPClientList addClient(TCPClientTObject client, bool allowDuplicate = false)
        {
            if (allowDuplicate)
            {
                this.Add(client);
                return this;
            }


            TCPClientTObject existedClient = this.Find((TCPClientTObject _client)=> _client.IpAddress == client.IpAddress);
            if (existedClient == null)
            {
                this.Add(client);
            }
            return this;
        }

        public TCPClientList removeClient(TCPClientTObject client)
        {
            TCPClientTObject existedClient = this.Find((TCPClientTObject _client)=> _client.IpAddress == client.IpAddress);
            this.Remove(existedClient);
            return this;
        }

        public TCPClientTObject findByStationCustomId(string customId)
        {
            foreach(TCPClientTObject client in this)
            {
                if (client.AuthData?.Identificator == customId)
                {
                    return client;
                }
            }

            return null;
        }
    }
}