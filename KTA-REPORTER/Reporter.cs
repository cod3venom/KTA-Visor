using KTA_REPORTER.enums;
using KTA_REPORTER.exception;
using KTA_REPORTER.interfaces;
using KTA_REPORTER.reporters;
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
        private string _template;

        public Reporter()
        {
            this._template = "";
        }
 

        public string Assign(string template, Dictionary<string, string> args)
        {
            this._template = template;

            foreach (KeyValuePair<string, string> arg in args)
            {
                if (!this._template.Contains(arg.Key)){
                    continue;
                }

                this._template = this._template.Replace(arg.Key, arg.Value);
            }
            return this._template;
        }

        public void Report(string path, OutputFileTypeEnum type)
        {
            switch(type)
            {
                case OutputFileTypeEnum.HTML:
                    new HTMLReporter().Report(this._template, path);
                    break;
                case OutputFileTypeEnum.PDF:
                    break;
            }
        }
 
    }
}
