﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.Device.exception
{
    public class CameraUSBDeviceDirectoryNotFoundException : Exception
    {
        public CameraUSBDeviceDirectoryNotFoundException(string message) : base(message)
        {
        }
    }
}
