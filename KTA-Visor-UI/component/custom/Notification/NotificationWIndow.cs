using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.Notification
{
    public class NotificationWIndow
    {
        private static class Memory
        {
            public static int IterationStep { get; set; }
            public static int Top { get; set; }
        }
        
        private readonly Form notificationForm;

        protected Timer timer;

        private bool isHidden;

        private int slideHeight;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificationForm"></param>
        public NotificationWIndow(Form notificationForm)
        {
            this.notificationForm = notificationForm;
            this.slideHeight = this.notificationForm.Width;
            this.notificationForm.Load += onLoad;
            this.configureTimer();
        }

        private void configureTimer()
        {
            this.timer = new Timer();
            this.timer.Interval = 8000;
            this.timer.Tick += onTimerTick;
            this.timer.Start();
        }

        private void onLoad(object sender, EventArgs e)
        {


            Memory.IterationStep += 1;
            this.notificationForm.TopMost = true;
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            this.notificationForm.Left = workingArea.Left + workingArea.Width - this.notificationForm.Size.Width;
            this.notificationForm.Top = workingArea.Top + workingArea.Height - (this.notificationForm.Size.Height * Memory.IterationStep);

            if (Memory.IterationStep > 1)
            {
                this.notificationForm.Top = workingArea.Top + workingArea.Height - (this.notificationForm.Size.Height * Memory.IterationStep) - 10;
            }

            this.playSound();
        }

        private void onTimerTick(object sender, EventArgs e)
        {
           this.notificationForm.Close();
        }

        protected void playSound()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.notification);
            player.Play();
        }
    }
}
