using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon_Protocol.interfaces
{
    public interface IModuleInterface
    {
        void Run();
        string GetModuleName();
    }
}
