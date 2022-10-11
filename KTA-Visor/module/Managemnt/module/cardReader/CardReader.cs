using KTA_RFID_Keyboard;
using KTA_Visor.module.Managemnt.module.card.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.card
{
    public class CardReader
    {
        public event EventHandler<OnCardReadedEvent> OnCardReaded;
        private RFIDKeyBoard rfid;

        public CardReader()
        {
            this.rfid = new RFIDKeyBoard();

            this.hookEvents();
        }

        private void hookEvents()
        {
            this.rfid.Subscribe();
            this.rfid.OnKeyboardInputChanged += onCardInputDetected;
        }

        private void onCardInputDetected(object sender, KTA_RFID_Keyboard.module.reader.events.OnKeyboardReaderDataChanagedEvent e)
        {
            if (!this.isValidInput(e.Input))
                return;

            this.OnCardReaded?.Invoke(this, new OnCardReadedEvent(e.Input));
        }


        private bool isValidInput(string input)
        {   
            Regex regex = new Regex(@"^-?[0-9][0-9,\.]+$");
            var res = regex.IsMatch(input);
            System.Console.WriteLine(res);
            return res;
        }
    }
}
