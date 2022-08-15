using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_RFID_Keyboard.module.reader.events
{
    public class OnKeyboardReaderDataChanagedEvent : EventArgs
    {
        public OnKeyboardReaderDataChanagedEvent(string input)
        {
            this.Input = input;
        }

        public string Input { get; set; }
    }
}
