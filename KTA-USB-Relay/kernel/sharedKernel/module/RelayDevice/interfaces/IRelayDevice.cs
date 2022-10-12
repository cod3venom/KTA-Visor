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

        void turnOnAll(int transition = 1000);
        void turnOffAll(int transition = 1000);
        void turnOnByPort(int portNumber, int transition = 1000);
        void turnOffByPort(int portNumber, int transition = 1000);
        void isTurnedOn(int portNumber, int transition = 1000);
    }
}
