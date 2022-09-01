using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.preloader.view
{
    public partial class PreLoaderView : Form
    {
        private static readonly int MAX_PROGRESS = 100;
        private static readonly int PROGRESS_STEP = 1;
        private static readonly int PROGRESS_TIMEOUT = 10;
        private static readonly int MIN_PROGRESS = 0;

        private readonly Form targetForm;

        
        public PreLoaderView()
        {
            InitializeComponent();
        }

        public PreLoaderView(Form targetForm)
        {
            this.targetForm = targetForm;
            InitializeComponent();
        }

        private void PreLoaderView_Load(object sender, EventArgs e)
        {
            this.startLoading();
        }

        private void startLoading()
        {

            this.horizontalProgressBar.OnProgressFinished += OnProgressBarFinished;
            this.horizontalProgressBar.start();
            Application.DoEvents();
        }

        private void OnProgressBarFinished(object sender, EventArgs e)
        {
            this.showTargetView();
        }

        private void showTargetView()
        {
            if (this.InvokeRequired)
            {
                if (!this.targetForm.IsDisposed)
                {
                    this.Invoke((MethodInvoker)delegate {
                        this.Hide();
                        this.targetForm.Show();
                    });
                }
            } else
            {
                this.Invoke((MethodInvoker)delegate {
                    this.Hide();
                    this.targetForm.Show();
                });
            }

        }

      
    }
}
