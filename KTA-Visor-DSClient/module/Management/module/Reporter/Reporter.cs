using KTA_Visor_DSClient.module.Management.module.Reporter.interfaces;
using KTA_Visor_DSClient.module.Management.module.Reporter.reporters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Reporter
{
    public class Reporter : List<IReporterInterface>
    {

        public Reporter()
        {
            this.Add(new AutoCopyReport());
        }

        public IReporterInterface Get(string name)
        {
            IReporterInterface reporter = this.Find((IReporterInterface reporer) =>
                reporer.Name == name
            );

            return reporter;
        }
    }
}
