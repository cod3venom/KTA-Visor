using KTA_RFID_Keyboard;
using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.camera.command;
using KTA_Visor.module.Managemnt.module.card;
using KTA_Visor.module.Managemnt.module.card.events;
using KTA_Visor.module.Managemnt.module.cardReader.controller;
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
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Managemnt.module.cardReader.form
{
    public partial class CardModeWindow : MetroForm, IModuleInterface
    {
      
        private readonly CardController _cardController;

        public CardModeWindow()
        {
            InitializeComponent();
            this._cardController = new CardController();
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
  
        private string CardInput
        {
            set { this.cardIdTxt.Text = value; }
            get { return this.cardIdTxt.Text; }
        }

        private void hookEvents()
        {
            this.cardIdTxt.Focus();
            this.cardIdTxt.KeyDown += onCardScanningStarted;
        }

        private void onCardScanningStarted(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return){
                this.onCardInputDetected();
            }
        }

        private void onCardInputDetected()
        {
            if (!this.isValidInput(this.CardInput)){
                return;
            }

            Globals.READED_CARD_INPUT = this.CardInput;
            Globals.Logger.info(String.Format("Scanned CARD INPUT: {0}", Globals.READED_CARD_INPUT));

            BlinkCameraInstationBasedOnCardIdCommand.Execute(Globals.READED_CARD_INPUT);

            Globals.READED_CARD_INPUT = "";
            this.CardInput = "";
            this.cardIdTxt.Focus();
        }


        private bool isValidInput(string input)
        {
            Regex regex = new Regex(@"^-?[0-9][0-9,\.]+$");
            var res = regex.IsMatch(input);
            System.Console.WriteLine(res);
            return res;
        }

        public string GetModuleName()
        {
            return "";
        }

        public void Watch(Request request)
        {
           this._cardController.Watch(request);
        }

        void IModuleInterface.ShowDialog()
        {
            this.ShowDialog();
        }
    }
}
