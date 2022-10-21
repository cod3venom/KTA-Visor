using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_REPORTER.abstraction
{
    public class ReporterAbstraction
    {
        protected void Save(string content, string path, bool withProgress = true)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(content);
                writer.Flush();
                writer.Close();
            }
        }

        private void renderProgress(int progress)
        {

        }
    }
}
