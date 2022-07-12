using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.helper
{
    public class EmbededFileHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static string Read(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
       
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
               return reader.ReadToEnd();
            }
        }
    }
}
