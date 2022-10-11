using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KTA_RFID_Keyboard.module.reader.events;
using Gma.System.MouseKeyHook;
using System.Text.RegularExpressions;

namespace KTA_RFID_Keyboard.module.RFIDKeyboardReader
{
    public class KeyboardReader
    {
        public event EventHandler<OnKeyboardReaderDataChanagedEvent> OnKeyboardInputChanged;
        public static string Input = "";
        


        private static IKeyboardMouseEvents m_GlobalHook;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public KeyboardReader()
        {
            this.Subscribe();
        }

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
                return;
            }

            
            string windowTitle = GetActiveWindowTitle();

            
            //if (windowTitle != "StationsView")
            //    return;
            
            
            this.OnKeyboardInputChanged?.Invoke(sender, new OnKeyboardReaderDataChanagedEvent(KeyboardReader.Input));
            KeyboardReader.Input = "";
        }
    }


}
