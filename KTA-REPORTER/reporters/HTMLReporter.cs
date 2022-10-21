using KTA_REPORTER.abstraction;
using KTA_REPORTER.interfaces;

namespace KTA_REPORTER.reporters
{
    public class HTMLReporter : ReporterAbstraction, IReporter
    {
        public void Report(string content, string path)
        {
            this.Save(content, path);
        }
    }
}
