using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPTunnel.module.shared
{
    public class Endpoints
    {
        public const string AUTH_NEED_COMMAND_ENDPOINT = "command://auth-required";
        public const string AUTH_IS_OK_COMMAND_ENDPOINT = "command://auth-is-ok";
        public const string AUTH_NEED_RESPONSE_ENDPOINT = "response://auth";
    }
}
