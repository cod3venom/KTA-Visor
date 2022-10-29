using KTA_Visor.module.Managemnt.module.station.command;
using KTA_Visor.module.Managemnt.module.station.view;
using KTA_Visor.module.Managemnt.module.station.window;
using KTA_Visor.module.Shared.Global;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Managemnt.module.station.handlers
{
    public class CamerasFlowPanelContextMenuUIHandler
    {
        private readonly StationView _stationView;
        private readonly ContextMenuStrip _contextMenuStrip;
        private readonly CameraService _cameraService;
        public CamerasFlowPanelContextMenuUIHandler(StationView stationView, ContextMenuStrip contextMenuStrip)
        {
            this._stationView = stationView;
            this._contextMenuStrip = contextMenuStrip;
            this._cameraService= new CameraService();
        }

        public void Handle()
        {
            this.hookEvents();
        }

        private void hookEvents()
        {
            this._stationView.refreshCamerasFlowPanelMenuItem.Click += onRefreshFlowList;
        }

        private void onRefreshFlowList(Object sender, EventArgs e)
        {
            string stationId = this._stationView.StationId;
            this._stationView.CamerasUIHandler.Load(stationId);
        }
    }
}
