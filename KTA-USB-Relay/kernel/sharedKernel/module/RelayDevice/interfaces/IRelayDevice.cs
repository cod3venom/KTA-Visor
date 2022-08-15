using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_USB_Relay.kernel.sharedKernel.module.commander.interfaces
{
    public interface IRelayDevice
    {
        void Open();

        void TurnOn1();
        void TurnOff1();

        
        void TurnOn2();
        void TurnOff2();


        void TurnOn3();
        void TurnOff3();


        void TurnOn4();
        void TurnOff4();


        void TurnOn5();
        void TurnOff5();


        void TurnOn6();
        void TurnOff6();


        void TurnOn7();
        void TurnOff7();


        void TurnOn8();
        void TurnOff8();

    }
}
