using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTALogger
{
    public class Logger
    {
        private string loggerFormat
        {
            get { return "[{0}] [{1}] {2} # $ {3}"; }
        }
        private string currentTime
        {
            get { return DateTime.Now.ToString("h:mm:ss tt"); }
        }

        public void success(string message, object context = null)
        {
            string caller = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
            this.write("success", caller, message, context);
        }

        public void info(string message, object context = null)
        {
            string caller = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
            this.write("info", caller, message, context);
        }

        public void warn(string message, object context = null)
        {
            string caller = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
            this.write("warn", caller, message, context);
        }

        public void error(string message, object context = null)
        {
            string caller = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
            this.write("error", caller, message, context);
        }

        private void write(string type, string caller, string message, object context = null)
        {
            switch (type)
            {
                case "success": Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case "info": Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                case "warn": Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case "error": Console.ForegroundColor = ConsoleColor.DarkRed; break;
            }

            string fullText = String.Format(loggerFormat, this.currentTime, type, caller, message);
            Console.WriteLine(fullText);
        }
    }
}
