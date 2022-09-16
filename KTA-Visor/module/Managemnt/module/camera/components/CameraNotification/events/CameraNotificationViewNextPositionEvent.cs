using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.camera.components.CameraNotification.events
{
    public class CameraNotificationViewNextPositionEvent: EventArgs
    {

        public CameraNotificationViewNextPositionEvent(int top, int left)
        {
            Top = top;
            Left = left;
        }

        public int Top { get; set; }
        public int Left { get; set; }
    }
}
