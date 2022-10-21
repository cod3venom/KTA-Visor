using KTA_REPORTER.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_REPORTER.reporters
{
    public class HTMLReporter : IReporter
    {
        public void Report(string content, string path)
        {
            using(StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(content);
                writer.Flush();
                writer.Close();
            }
        }
    }
}
