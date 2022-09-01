using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Auth.exception
{
    public class WrongCredentialsException: Exception
    {
        public WrongCredentialsException(string message): base(message)
        { }
    }
}
