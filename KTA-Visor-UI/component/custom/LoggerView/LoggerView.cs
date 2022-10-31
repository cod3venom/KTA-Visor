using System;
using System.Drawing;
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

        public void append(string message, Color color)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate{ 
                    this.appendLog(message, color);
                });
            }
            else
            {
                this.appendLog(message, color);
            }
        }

        private void appendLog(string message, Color color)
        {
            if (this.richTextBox.IsDisposed)
            {
                this.richTextBox = new RichTextBox();
            }
            
            richTextBox.AppendText(message + Environment.NewLine);
            this.richTextBox.ScrollToCaret();
        }

        private void cleanBtn_Click(object sender, EventArgs e)
        {
            this.richTextBox.Clear();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.Minimize();
        }

        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            this.Maximize();
        }


        public void Minimize()
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

        public void Maximize()
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
