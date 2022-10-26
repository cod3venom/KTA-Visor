using KTA_Visor.module.Managemnt.module.station.view;
using KTA_Visor.module.Station.events;
using TCPTunnel.kernel.extensions.router.dto;
using System;
using MetroFramework;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.station.controller
{
    public class StationController
    {
        private readonly StationView _stationView;

        public event EventHandler<OnRefreshCamerasListEvent> OnRefreshCamerasList;

        public StationController(StationView stationView)
        {
            this._stationView = stationView;
        }

        public void Watch(Request request)
        {
            switch(request.Endpoint)
            {
                case "response://station/delete/still-copying":
                    this.onUnableToRemoveBecauseFilesAreStillCopying(request);
                    break;
            }
        }

        private void onUnableToRemoveBecauseFilesAreStillCopying(Request request)
        {
            MessageBox.Show("Nie można usunąć stacje ponieważ proces kopiowania plików nadal trwa", "Stacja");
        }
    }
}
