using KTA_REPORTER.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_REPORTER.interfaces
{
    public interface IReporter
    {
        void Report(string content, string path);
    }
}
