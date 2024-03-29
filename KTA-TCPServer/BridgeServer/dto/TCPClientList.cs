﻿using KTA_TCPBridge.BridgeServer.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_TCPBridge.BridgeServer.dto
{
    public class TCPClientList<TKey, TValue> :Dictionary<string, TCPClientTObject>
    {

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="client"></param>
        /// <param name="allowDuplicate"></param>
        /// <returns></returns>
        public TCPClientList <TKey, TValue> addClient(string key, TCPClientTObject client, bool allowDuplicate = false)
        {
            if (allowDuplicate) { 
                this.Add(key, client);
                return this;
            }


            if (!this.ContainsKey(key)) this.Add(key, client);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public TCPClientList<TKey, TValue> removeClient(string key, TCPClientTObject client)
        {
            if (this.ContainsKey(key)) this.Remove(key);

            return this;
        }
    }
}
