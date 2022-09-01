using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.sharedKernel.LocalStorage
{
    public class LocalStorage
    {
        private static Dictionary<string, string> _storage = new Dictionary<string, string>();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void set(string key, string value)
        {
            LocalStorage._storage.Add(key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public LocalStorage remove(string key, string value)
        {
            if (!LocalStorage._storage.ContainsKey(key)) return this;

            LocalStorage._storage.Remove(key);
            return this;
        }
    }
}
