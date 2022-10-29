using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPTunnel.kernel.types
{
    public class TCPClientList: List<TCPClientTObject>
    {

        public TCPClientTObject Get(string ip)
        {
            return this.Find((TCPClientTObject client) => client.IpAddress == ip);
        }

        public TCPClientList AddClient(TCPClientTObject client, bool allowDuplicate = false)
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

        public TCPClientList RemoveClient(TCPClientTObject client)
        {
            TCPClientTObject existedClient = this.Find((TCPClientTObject _client)=> _client.IpAddress == client.IpAddress);
            this.Remove(existedClient);
            return this;
        }

        public TCPClientTObject FinByStationCustomId(string customId)
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

        public TCPClientTObject FindByIP(string ip)
        {
            return this.Find((TCPClientTObject obj) => obj.IpAddress == ip);
        }
    }
}