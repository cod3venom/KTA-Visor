using KTA_Visor_FileStorage_Watcher.module.watcher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_FileStorage_Watcher
{
    public partial class FileWatcherService : ServiceBase
    {
        private readonly FileWatcher watcher;
        public FileWatcherService()
        {
            InitializeComponent();
            this.watcher = new FileWatcher();
        }

        public void onDebug()
        {
            this.OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            this.watcher.StartWatching();
        }

        protected override void OnStop()
        {
        }
    }
}
