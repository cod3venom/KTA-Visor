using KTAVisorAPISDK.module.camera.entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Shared.Global
{
    public class Globals
    {
        public static string READED_CARD_INPUT = "";
        public static bool IS_SERVER_ONLINE = false;
        public static List<CameraEntity.Camera> SELECTED_STATION_ACTIVE_CAMERAS= new List<CameraEntity.Camera>();

        public static ObservableCollection<TCPClientTObject> CLIENTS_LIST = new ObservableCollection<TCPClientTObject>();
    }
}
