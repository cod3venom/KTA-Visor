﻿using KTA_Visor_DSClient.kernel.sharedKernel.DTOHelper.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.entity
{
    public class CamerasEntity :  DTOHelperStruct
    {

        public List<Data> data { get; set; }

        public class Card
        {
            public string cardCustomId { get; set; }
            public string officer { get; set; }
            public string id { get; set; }
            public string updatedAt { get; set; }
            public string createdAt { get; set; }
            public bool __isInitialized__ { get; set; }
        }

        public class Data
        {
            public string cameraCustomId { get; set; }
            public Officer officer { get; set; }
            public string id { get; set; }
            public string updatedAt { get; set; }
            public string createdAt { get; set; }
        }

        public class Officer
        {
            public string badgeId { get; set; }
            public string camera { get; set; }
            public Card card { get; set; }
            public string id { get; set; }
            public string ownerId { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string cardCustomID { get; set; }
            public string camCustomId { get; set; }
            public string createdAt { get; set; }
            public string updatedAt { get; set; }
        }
    }
}
