using Logger.dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTALogger
{
    public class Logger
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<LoggerEvent> OnLogHasWritten;

        /// <summary>
        /// 
        /// </summary>
        private string loggerFilePath;

        /// <summary>
        /// 
        /// </summary>
        private FileInfo loggerFile;

        /// <summary>
        /// 
        /// </summary>
        private string startDate;

        /// <summary>
        /// 
        /// </summary>
        public Logger()
        {
            this.startDate = this.currentDate;
            this.initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        private void initialize()
        {
            this.calibrateLogger();
            Thread dateWatcherThr = new Thread(this.dateWatcher);
            dateWatcherThr.IsBackground = true;
            dateWatcherThr.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private void dateWatcher()
        {
            while(true)
            {
                this.calibrateLogger();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void calibrateLogger()
        {
            this.startDate = this.currentDate;

            this.loggerFilePath = string.Format("{0}\\logs\\log_{1}.KTALogger",
               Directory.GetCurrentDirectory(),
               this.startDate
            );
            
            this.loggerFile = new FileInfo(this.loggerFilePath);

            if (!File.Exists(this.loggerFile.FullName)) {
                File.WriteAllText(this.loggerFilePath, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string loggerFormat
        {
            get { return "[{0}] [{1}] {2} # $ {3}"; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string currentDate
        {
            get { return DateTime.Now.ToString("dd-MM-yyyy"); }
        }

        /// <summary>
        /// 
        /// </summary>
        private string currentTime
        {
            get { return DateTime.Now.ToString("h:mm:ss tt"); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public void success(string message, object context = null)
        {
            string caller = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
            this.write("success", caller, message, context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public void info(string message, object context = null)
        {
            string caller = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
            this.write("info", caller, message, context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public void warn(string message, object context = null)
        {
            string caller = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
            this.write("warn", caller, message, context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public void error(string message, object context = null)
        {
            string caller = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
            this.write("error", caller, message, context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        /// <param name="context"></param>
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
            
            this.OnLogHasWritten?.Invoke(this, new LoggerEvent(type, fullText));

            using(StreamWriter sw = this.loggerFile.AppendText())
            {
                sw.WriteLine(fullText);
                sw.Close();
                Console.WriteLine(fullText);
            }
        }
    }
}
