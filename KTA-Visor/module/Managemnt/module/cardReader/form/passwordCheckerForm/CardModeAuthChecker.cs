using KTA_Visor.install.settings;
using KTA_Visor.module.Managemnt.module.cardReader.form.passwordCheckerForm.events;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.cardReader.window
{
    public partial class CardModeAuthChecker : MetroForm
    {
        public event EventHandler<OnPassworCheckerPassedEvent> OnPassworCheckerPassed;
        public event EventHandler<OnWrongPasswordProvidedEvent> OnWrongPasswordProvided;
        private readonly Settings _settings; 
        public CardModeAuthChecker()
        {
            InitializeComponent();
            this._settings = new Settings();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush b = new SolidBrush(Color.DarkCyan))
            {
                int borderWidth = 5;
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        private void CardModeAuthCheckerWindow_Load(object sender, EventArgs e)
        {
            this.passwordTxt.TextChanged += onPasswordTextChanged;
            this.authorizeBtn.Click += onAuthorize;
        }

        private void onPasswordTextChanged(object sender, EventArgs e)
        {
            if (this.passwordTxt.Text.Length == 0)
            {
                this.authorizeBtn.Enabled = false;
            } else
            {
                this.authorizeBtn.Enabled = false;
            }
        }

        private void onAuthorize(object sender, EventArgs e)
        {
            if (this.passwordTxt.Text != this._settings?.SettingsObj?.app?.cardMode?.password)
            {
                this.OnWrongPasswordProvided?.Invoke(this, new OnWrongPasswordProvidedEvent());
            } else
            {
                this.OnWrongPasswordProvided?.Invoke(this, new OnWrongPasswordProvidedEvent());
            }
        }
    }
}
