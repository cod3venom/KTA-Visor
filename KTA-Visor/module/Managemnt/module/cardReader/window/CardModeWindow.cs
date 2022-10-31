using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.camera.command;
using KTA_Visor.module.Managemnt.module.cardReader.controller;
using KTA_Visor.module.Shared.Global;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Managemnt.module.cardReader.window
{
    public partial class CardModeWindow : MetroForm, IModuleInterface
    {
        public static string ModuleName = "CardModeWindow";

        private readonly CardController _cardController;
        public CardModeWindow()
        {
            InitializeComponent();
            this._cardController = new CardController();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
             using (Brush b = new SolidBrush(ColorTranslator.FromHtml("#222222")))
            {
                int borderWidth = 5;
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        private void CardModeWindow_Load(object sender, EventArgs e)
        {

            this.hookEvents();
           // this._cardModeAuthCheckerForm.ShowDialog();
        }

        private void hookEvents()
        {
            this.cardIdtxt.Focus();
            this.cardIdtxt.KeyDown += onCardScanningStarted;
        }


        private void onCardScanningStarted(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.onCardInputDetected();
            }
        }

        private void onCardInputDetected()
        {
            if (!this.isValidInput(this.cardIdtxt.Text)){
                return;
            }

            if (Globals.Server.Clients.Count == 0)
            {
                MetroMessageBox.Show(this, "Żadna ze stacji nie jest dostępna");
                return;
            }

            Globals.Logger.info(String.Format("Scanned CARD INPUT: {0}", Globals.READED_CARD_INPUT));
            BlinkCameraInstationBasedOnCardIdCommand.Execute(this.cardIdtxt.Text);
            this.cardIdtxt.Text = "";
            this.cardIdtxt.Focus();
        }


        private bool isValidInput(string input)
        {
            return new Regex(@"^-?[0-9][0-9,\.]+$").IsMatch(input);
        }

        public string GetModuleName()
        {
            return CardModeWindow.ModuleName;
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
