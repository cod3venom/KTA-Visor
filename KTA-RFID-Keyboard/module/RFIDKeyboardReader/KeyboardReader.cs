using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KTA_RFID_Keyboard.module.reader.events;
using Gma.System.MouseKeyHook;

namespace KTA_RFID_Keyboard.module.RFIDKeyboardReader
{
    public class KeyboardReader
    {
        public event EventHandler<OnKeyboardReaderDataChanagedEvent> OnKeyboardInputChanged;
        public static string Input = "";
        


        private static IKeyboardMouseEvents m_GlobalHook;


        public void Subscribe()
        {
            KeyboardReader.m_GlobalHook = Hook.GlobalEvents();
            KeyboardReader.m_GlobalHook.KeyPress+= M_GlobalHook_KeyDown;
        }

        private void M_GlobalHook_KeyDown(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != (char)Keys.Return)
            {
                KeyboardReader.Input += e.KeyChar;
            }
            else
            {
                this.OnKeyboardInputChanged?.Invoke(sender, new OnKeyboardReaderDataChanagedEvent(KeyboardReader.Input));
                KeyboardReader.Input = "";
            }
        }

        private bool isValidInput(string input)
        {
            if (!input.Contains("-")) return true; //todo

            string[] segments = input.Split('-');
            if (segments.Length != 2) return false;

            string prefix = segments[0];
            string number = segments[1];

            if (prefix != "KTA") return false;
            return true; // TODO
        }
    }


}
