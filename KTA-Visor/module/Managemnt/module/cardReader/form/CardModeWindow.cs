using KTA_RFID_Keyboard;
using KTA_Visor.module.Managemnt.module.camera.command;
using KTA_Visor.module.Managemnt.module.card;
using KTA_Visor.module.Managemnt.module.card.events;
using KTA_Visor.module.Shared.Global;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.cardReader.form
{
    public partial class CardModeWindow : MetroForm
    {
        private RFIDKeyBoard rfid;

        public CardModeWindow()
        {
            InitializeComponent();
            this.rfid = new RFIDKeyBoard();

            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush b = new SolidBrush(Color.DarkCyan)) {
                int borderWidth = 5;
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        private void CardModeWindow_Load(object sender, EventArgs e)
        {
            this.hookEvents();
        }
  
        private void hookEvents()
        {
            this.rfid.OnKeyboardInputChanged += onCardInputDetected;
            this.rfid.Subscribe();
        }

        private void onCardInputDetected(object sender, KTA_RFID_Keyboard.module.reader.events.OnKeyboardReaderDataChanagedEvent e)
        {

            if (!this.isValidInput(e.Input)){
                return;
            }


            Globals.READED_CARD_INPUT = e.Input;
            
            
            
            Globals.Logger.info(String.Format("Scanned CARD INPUT: {0}", Globals.READED_CARD_INPUT));

            BlinkCameraInstationBasedOnCardIdCommand.Execute(Globals.READED_CARD_INPUT);
            Globals.READED_CARD_INPUT = "";

            Thread.Sleep(1000);
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
