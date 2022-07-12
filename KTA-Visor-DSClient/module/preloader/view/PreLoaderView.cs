﻿using System;
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
            Thread thr = new Thread(this.startLoading);
            thr.IsBackground = true;
            thr.Start();

            
        }

        private void startLoading()
        {
            for(int i = MIN_PROGRESS; i < MAX_PROGRESS; i+= PROGRESS_STEP)
            {
                string progress = string.Format("Loaded {0}%", i.ToString());
                this.Invoke((MethodInvoker)delegate
                {
                    this.loaderLbl.Text = progress;
                });

                Thread.Sleep(PROGRESS_TIMEOUT);
            }

            this.showTargetView();
        }

        private void showTargetView()
        {
            if (!this.targetForm.IsDisposed)
            {
                this.Invoke((MethodInvoker)delegate{
                    this.Hide();
                    this.targetForm.Show();
                });
            }

        }

      
    }
}
