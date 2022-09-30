using KTA_Visor.module.Shared.Global;
using Logger.dto;
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
    public partial class TunnelWindow : Form
    { 

        public TunnelWindow()
        {
            InitializeComponent();

            this.topBar1.Parent = this;
        }

        private void TunnelWindow_Load(object sender, EventArgs e)
        {
            this.topBar1.onClose += onClose;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Globals.Logger.OnLogHasWritten += Logger_OnLogHasWritten;
        }


        private void startBtn_Click(object sender, EventArgs e)
        {
            Globals.ServerTunnelBackgroundWorker.Run();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
           Globals.ServerTunnelBackgroundWorker.Stop();

        }

        private void Logger_OnLogHasWritten(object sender, LoggerEvent e)
        {
            this.showLog(e);
        }

        private void showLog(LoggerEvent e)
        {


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
