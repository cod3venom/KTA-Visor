﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Shared.Exceptions
{
    public class WrongCredentialsException : Exception
    {
        public WrongCredentialsException(string message = "") : base(message)
        { 
        }
    }
}
