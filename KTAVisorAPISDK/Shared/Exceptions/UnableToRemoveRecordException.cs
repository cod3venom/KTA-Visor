using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.Shared.Exceptions
{
    public class UnableToRemoveRecordException: Exception
    {
        public UnableToRemoveRecordException(string message = "Niestety nie udało się skasować wybrany rekord."): base(message)
        {
        }
    }
}
