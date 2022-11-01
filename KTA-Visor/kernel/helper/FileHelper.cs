using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.kernel.helper
{
    public class FileHelper
    {
        
        public static string GetSizeFromPath(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return "0b";
            }

            FileInfo fileInfo = new FileInfo(filePath);
            return FileHelper.ConverTSize((double)fileInfo.Length);
        }

        public static string ConverTSize(double size)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };

            double mod = 1024.0;

            int i = 0;

            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size) + units[i];
        }
    }
}
