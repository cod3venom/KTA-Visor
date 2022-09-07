using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.Shared.Exceptions
{
    public class UnableToCreateRecordException : Exception
    {
        public UnableToCreateRecordException(string message) : base(message)
        { }
    }
}
