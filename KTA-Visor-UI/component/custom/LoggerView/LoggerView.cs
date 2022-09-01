using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.LoggerView
{
    public partial class LoggerView : UserControl
    {
        private readonly int MAX_HEIGHT = 221;
        private readonly int MIN_HEIGHT = 37;

        public LoggerView()
        {
            InitializeComponent();
        }

        private void LoggerView_Load(object sender, EventArgs e)
        {
            this.richTextBox.Margin = new Padding(24, 24, 24, 0);
            this.richTextBox.ReadOnly = true;

        }

        public Panel ParentPanel { get; set; }

        public void append(string log)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    this.richTextBox.AppendText(log + Environment.NewLine);

                    this.richTextBox.HideSelection = true;
                    this.richTextBox.SelectionStart = richTextBox.Text.Length;
                    this.richTextBox.ScrollToCaret();
                });
            }

            else
            {
                if (this.richTextBox.IsDisposed)
                    return;

                this.richTextBox.AppendText(log + Environment.NewLine);

                this.richTextBox.HideSelection = true;
                this.richTextBox.SelectionStart = richTextBox.Text.Length;
                this.richTextBox.ScrollToCaret();
            }
        }

        private void cleanBtn_Click(object sender, EventArgs e)
        {
            this.richTextBox.Clear();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.maximizePanel.Visible = true;
            this.minimizePanel.Visible = false;

            this.logPanel.Visible = false;
            this.richTextBox.Dock = DockStyle.None;
            this.richTextBox.Visible = false;
            this.Height = this.MIN_HEIGHT;

            if (this.ParentPanel != null)
            {
                this.ParentPanel.Height = this.MIN_HEIGHT;
            }
        }

        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            this.minimizePanel.Visible = true;
            this.maximizePanel.Visible = false;

            this.logPanel.Visible = true;
            this.richTextBox.Visible = true;
            this.Height = this.MAX_HEIGHT;

            if (this.ParentPanel != null)
            {
                this.ParentPanel.Height = this.MAX_HEIGHT;
            }
        }
    }
}
