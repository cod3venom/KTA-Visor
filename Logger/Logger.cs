using Logger.dto;
using Logger.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTALogger
{
    public class Logger : ILogger
    {

        public event EventHandler<LoggerEvent> OnLogHasWritten;
        private FileInfo loggerFile;
        private DirectoryInfo loggerFileDirectory;
        private string startDate;

        public Logger(DirectoryInfo directory = null)
        {
            this.startDate = this.currentDate;
            if (directory == null) {
                this.loggerFileDirectory = new DirectoryInfo(String.Format("{0}\\kta_logger", Directory.GetCurrentDirectory()));
            } else
            {
                this.loggerFileDirectory = directory;
            }

            this.initialize();
        }

   
        private void initialize()
        {
            this.calibrateLogger();
            Thread dateWatcherThr = new Thread(this.dateWatcher);
            dateWatcherThr.IsBackground = true;
            dateWatcherThr.Start();
        }


        private void dateWatcher()
        {
            while(true)
            {
                this.calibrateLogger();
                Thread.Sleep(100);
            }
        }


        private void calibrateLogger()
        {
            try
            {
                this.startDate = this.currentDate;
                if (!this.loggerFileDirectory.Exists){
                    this.loggerFileDirectory.Create();
                }

                this.loggerFile = new FileInfo(string.Format("{0}\\log_{1}.KTALogger", this.loggerFileDirectory.FullName, this.startDate));

                if (!File.Exists(this.loggerFile.FullName)) {
                    File.WriteAllText(this.loggerFile.FullName, "");
                }
            }
            catch(IOException exception)
            {
                Console.WriteLine(exception.ToString());    
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
        }


        private string loggerFormat
        {
            get { return "[{0}] [{1}] {2} # $ {3}"; }
        }


        private string currentDate
        {
            get { return DateTime.Now.ToString("dd-MM-yyyy"); }
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

        public void print(string message, object context = null)
        {
            string caller = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
            this.write("print", caller, message, context);
        }

        public void hidden(string message, object context = null)
        {
            string caller = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
            this.write("hidden", caller, message, context);
        }

        private void write(string type, string caller, string message, dynamic context = null)
        {
            switch (type)
            {
                case "success": Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case "info": Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                case "warn": Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case "error": Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case "print": Console.ForegroundColor = ConsoleColor.DarkGray; break;
            }

            string fullText = String.Format(loggerFormat, this.currentTime, type, caller, message);
            
            this.OnLogHasWritten?.Invoke(this, new LoggerEvent(type, fullText, message));

            try
            {
                using (StreamWriter sw = this.loggerFile.AppendText())
                {
                    sw.WriteLine(fullText);
                    sw.Close();

                    if (type != "hidden")
                    {
                        Console.WriteLine(fullText);
                    }
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
