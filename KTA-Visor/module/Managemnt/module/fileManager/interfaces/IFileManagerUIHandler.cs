using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.fileManager.interfaces
{
    public interface IFileManagerUIHandler
    {
        string GetName();
        void Handle();
        void Load();
    }
}
