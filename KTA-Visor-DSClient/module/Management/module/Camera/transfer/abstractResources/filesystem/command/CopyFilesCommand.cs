using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem.command
{
    public static class CopyFilesCommand
    {
        public static void Execute(FileInfo file, FileInfo destinationFile)
        {
            int bufferSize = 1024 * 1024;

            Console.WriteLine(String.Format("Started copying: {0}", file.FullName));
            using (FileStream fileStream = new FileStream(destinationFile.FullName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.ReadWrite);
                fileStream.SetLength(fs.Length);
                int bytesRead = -1;
                byte[] bytes = new byte[bufferSize];

                while ((bytesRead = fs.Read(bytes, 0, bufferSize)) > 0)
                {
                    fileStream.Write(bytes, 0, bytesRead);
                }

                file = new FileInfo(destinationFile.FullName);
                if (file.Exists)
                {
                    File.SetAttributes(file.FullName, FileAttributes.Hidden);
                    Console.WriteLine(String.Format("File Encryption: {0}", file.FullName));
                    Console.WriteLine(String.Format("End copying: {0}", file.FullName));

                }
            }

        }
    }
}
