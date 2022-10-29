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
            FileStream fs = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(content);
                writer.Close();
                fs.Close();
            }
            
        }

        private void renderProgress(int progress)
        {

        }
    }
}
