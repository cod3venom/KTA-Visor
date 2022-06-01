﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device.exception
{
    public class DeviceIsNotFalconCameraException : Exception
    {
        public DeviceIsNotFalconCameraException(string message) : base(message)
        {
        }
    }
}