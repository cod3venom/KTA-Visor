using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.kernel.module.ThreadPool
{
    public class ThreadPoolManager
    {
        public static Thread Run(Form parent, Action callBack)
        {
            Thread thr = new Thread((ThreadStart) => {
                parent.Invoke((Action)(() => {
                    callBack();
                }));
            });
            thr.IsBackground = true;
            thr.Start();

            return thr;
        }


        public static Thread Run(Control parent, Action callBack)
        {
            Thread thr = new Thread((ThreadStart) => {
                parent.Invoke((MethodInvoker)(() => {
                    callBack();
                }));
            });
            thr.IsBackground = true;
            thr.Start();

            return thr;
        }
        public static Thread Run( Action callBack)
        {
            Thread thr = new Thread((ThreadStart) => {
                callBack();
            });
            thr.IsBackground = true;
            thr.Start();

            return thr;
        }

        public static Thread RenderForm(Form form)
        {
            Thread thr = new Thread((ThreadStart)=> {
                if (form.Handle == null)
                    return;

                form.Invoke((Action)(() => {
                    form.ShowDialog();
                }));
            });
            thr.IsBackground = true;
            thr.Start();

            return thr;
        }


        public static Thread RenderControl(Form parent, Action callback)
        {
            Thread thr = new Thread((ThreadStart) => {
                parent.Invoke((Action)(() => {
                    callback();
                }));
            });
            thr.IsBackground = true;
            thr.Start();

            return thr;
        }
    }
}
