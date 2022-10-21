using KTA_REPORTER.enums;
using KTA_REPORTER.exception;
using KTA_REPORTER.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_REPORTER
{
    public class Reporter
    {
        private string _content;

        public Reporter()
        {
            this._content = "";
        }

        public void Load(string template = "")
        {
            if (!File.Exists(template)){
                throw new TemplateNotFoundException("Provided template not found");
            }

            this._content = File.ReadAllText(template);
        }

        public void Assign(Dictionary<string, string> args)
        {
            foreach(KeyValuePair<string, string> arg in args)
            {
                if (!this._content.Contains(arg.Key)){
                    continue;
                }

                this._content.Replace(arg.Key, arg.Value);
            }
        }

        public void Report(OutputFileTypeEnum type)
        {
            throw new NotImplementedException();
        }
 
    }
}
