using KTA_Visor_DSClient.kernel.helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.generator
{
    public class RandomData
    {
        public static string RandomString(int length = 15, bool upperCase = true)
        {
            string str = Guid.NewGuid().ToString();

            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }

            if (upperCase){
                str = str.ToUpper();
            }

            str = str.Replace("-", "");
            return str;
        }
    }
}
