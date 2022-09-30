using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.dto
{
    public class LoggerEvent:EventArgs
    {
        public LoggerEvent(string type = "", string log = "", string message = "")
        {
            this.Type = type;
            this.Log = log;
            this.Message = message;
            this.calibrateColor();
        }

        private void calibrateColor()
        {
            switch (this.Type)
            {
                case "success": this.Color = Color.DarkGreen; break;
                case "info": this.Color = Color.DarkBlue; break;
                case "warn": this.Color = Color.Yellow; break;
                case "error": this.Color = Color.DarkRed; break;
                case "print": this.Color = Color.DarkGray; break;
            }
        }
        public string Type { get; set; }
        public string Log { get; set; }
        public string Message { get; set; }
        public Color Color { get; set; }
    }
}
