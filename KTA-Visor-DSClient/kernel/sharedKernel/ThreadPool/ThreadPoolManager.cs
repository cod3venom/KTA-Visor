using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.sharedKernel.ThreadPool
{
    public static class ThreadPoolManager
    {
        public static Thread Run(Action callback, bool join = false)
        {
            Thread thr = new Thread(() => callback());
            thr.IsBackground = true;
            thr.Start();
            
            if (join)
            {
                thr.Join();
            }

            return thr;
        }
    }
}
