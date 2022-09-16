using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_USB_Relay.kernel.sharedKernel.module.commander.interfaces
{
    public interface IRelayDevice
    {
        void Open();

        void turnOnAll();
        void turnOffAll();
        void turnOnByPort(int portNumber);
        void turnOffByPort(int portNumber);
        void isTurnedOn(int portNumber);
    }
}
