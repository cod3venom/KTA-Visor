using KTA_Visor_DSClient.kernel.sharedKernel.ThreadPool;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.handler
{
    public class CameraFilesTransferingHandler
    {
        private readonly string destination;
        private bool canCopy = true;
        public CameraFilesTransferingHandler(string destination)
        {
            this.destination = destination;
        }

        public void Transfer(List<FileInfo> files, string driveName = "")
        {

            if (this.destination == null || destination == "") {
                return;
            }

            if (!Directory.Exists(this.destination)) {
                throw new Exception("Network drive location does not exists");
            }

            Globals.IS_ALL_COPYING_PROCESS_ARE_END = false;
            ThreadPoolManager.Run(new Action(() => {
                this.CopyFilesWithParalels(files);
            }));
            Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;

        }

        private  void CopyFilesWithParalels(List<FileInfo> files, string driveName = "")
        {
            if (!this.canCopy){
                return;
            }

            try
            {
                List<string> totalCopiedFiles = new List<string>();
                ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 10 };
                Parallel.ForEach(files, options, file => {

                    try
                    {
                        if (!this.canCopy){
                            return;
                        }

                        string destPath = String.Format("{0}\\{1}", this.destination, file.Name);

                        if (!File.Exists(destPath))
                        {
                            Globals.Logger.info(string.Format("Transfering {0} >> to >> {1}", file.Name, destPath));
                            file.CopyTo(destPath);

                            if (File.Exists(destPath))
                            {
                                totalCopiedFiles.Add(destPath);

                                //file.Delete();
                            }
                        }

                    }
                    catch(IOException exception)
                    {
                        if (this.isDiskFull(exception))
                        {
                            this.canCopy = false;
                            Globals.Logger.error("Unable to copy more files, DISK IS FULL");
                        } else
                        {
                            Globals.Logger.error(exception.Message, exception);
                        }
                        Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;
                    }

                });

                Globals.Logger.info(String.Format("Transfering procedure has been finished for: {0}", driveName));
                Globals.Logger.info(String.Format("Successfully copied {0} of {1} files", totalCopiedFiles.Count.ToString(), files.Count.ToString()));
            }
            catch (Exception exception)
            {
                Globals.Logger.error(exception.Message, exception);
                Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;
            }

            Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;
        }

        private bool isDiskFull(Exception ex)
        {
            const int ERROR_HANDLE_DISK_FULL = 0x27;
            const int ERROR_DISK_FULL = 0x70;

            int win32ErrorCode = Marshal.GetHRForException(ex) & 0xFFFF;
            return win32ErrorCode == ERROR_HANDLE_DISK_FULL || win32ErrorCode == ERROR_DISK_FULL;
        }

    }
}
