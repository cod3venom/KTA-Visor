using KTA_Visor.module.Shared.Global;
using Logger.dto;
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

namespace KTA_Visor.module.Managemnt.sub_window
{
    public partial class TunnelWindow : MetroForm
    {
        private bool _handleCreated = false;
        public TunnelWindow()
        {
            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush b = new SolidBrush(Color.DarkCyan)){
                int borderWidth = 5;
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        private void TunnelWindow_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.startBtn.Click += onStart;
            this.stopBtn.Click += onStop;
            this.closeBtn.Click += onClose;

            this.HandleCreated += onHandleCreated;
            this.FormBorderStyle = FormBorderStyle.None;
            this.renderCorrectColor();
        }
 
        private void onHandleCreated(object sender, EventArgs e)
        {
            this._handleCreated = true;
        }


        private void onStart(object sender, EventArgs e)
        {
            Globals.Server.Start();
            this.renderCorrectColor();
        }

        private void onStop(object sender, EventArgs e)
        {
            Globals.Server.Start();
            this.renderCorrectColor();
        }

        private void renderCorrectColor()
        {
            if (Globals.IS_SERVER_ONLINE)
            {
                this.startBtn.Enabled = false;
                this.stopBtn.Enabled = true;
            } else
            {
                this.startBtn.Enabled = true;
                this.stopBtn.Enabled = false;
            }
           
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Globals.Logger.OnLogHasWritten += Logger_OnLogHasWritten;
        }

        private void Logger_OnLogHasWritten(object sender, LoggerEvent e)
        {
            this.showLog(e);
        }

        private void showLog(LoggerEvent e)
        {

            if (!this._handleCreated)
                return;

            this.Invoke((MethodInvoker)delegate {
                richTextBox.SelectionStart = richTextBox.TextLength;
                richTextBox.SelectionLength = 0;

                richTextBox.SelectionColor = e.Color;
                richTextBox.AppendText(e.Log + Environment.NewLine);
                richTextBox.SelectionColor = richTextBox.ForeColor;
                this.richTextBox.ScrollToCaret();
            });
        }


        private void onClose(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
