using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_REPORTER.exception
{
    public class TemplateNotFoundException: Exception
    {
        public TemplateNotFoundException(string message): base(message)
        {

        }
    }
}
