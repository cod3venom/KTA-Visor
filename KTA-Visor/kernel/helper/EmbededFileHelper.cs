using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.kernel.helper
{
    public class EmbededFileHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static string Read(string resourceName, bool debug = false)
        {
            var assembly = Assembly.GetExecutingAssembly();
       
           if (debug)
            {
                foreach (var ass in assembly.GetManifestResourceNames())
                {
                    Console.WriteLine(ass);
                }
            }

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
               return reader.ReadToEnd();
            }
        }
    }
}
