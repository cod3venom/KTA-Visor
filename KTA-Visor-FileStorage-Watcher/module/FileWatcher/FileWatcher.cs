using KTA_Visor_FileStorage_Watcher.shared.Global;
using KTAVisorAPISDK.module.fileHistory.entity;
using KTAVisorAPISDK.module.fileHistory.service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static KTAVisorAPISDK.module.fileHistory.entity.FileHistoryEntity;

namespace KTA_Visor_FileStorage_Watcher.module.watcher
{
    internal class FileWatcher
    {
        private System.Timers.Timer _timer;
        private DateTime _lastRun;

        private readonly FileHistoryFileWatcherService fileHistoryFileWatcherService;
        public FileWatcher()
        {
            this._lastRun = DateTime.Now.AddDays(-1);
            this.fileHistoryFileWatcherService = new FileHistoryFileWatcherService();
        }

        
        public void StartWatching()
        {
            _timer = new System.Timers.Timer(10 * 60 * 10); // every 10 minutes
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(onTimeElapsed);
            _timer.Start();
            this.checkFiles();
        }

        private void onTimeElapsed(object sender, ElapsedEventArgs e)
        {
            if (_lastRun.Date < DateTime.Now.Date)
            {
                // stop the timer while we are running the cleanup task
                _timer.Stop();
                //
                // do cleanup stuff
                //
                _lastRun = DateTime.Now;
                _timer.Start();
            }
            
            this.checkFiles();
        }

        private async void checkFiles()
        {
            FileHistoryEntity fileHistoryEntity = await this.fileHistoryFileWatcherService.all();

            if (fileHistoryEntity.datas == null)
                return;


            foreach(FileHistoryEntity.FileHistory entity in fileHistoryEntity.datas)
            {
                if (entity.isDeleted) continue;

                this.deleteFile(entity);
            }
        }

        private void deleteFile(FileHistory file)
        {
            if (Directory.Exists(file.fileDestPath)) return;

            File.Delete(file.fileDestPath);
            _ = this.fileHistoryFileWatcherService.delete(file.id);
        }
    }
}
