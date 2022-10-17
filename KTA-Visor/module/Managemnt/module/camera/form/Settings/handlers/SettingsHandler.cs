using KTA_Visor.module.Managemnt.module.camera.form.settings;
using KTA_Visor.module.Shared.Global;
using KTAVisorAPISDK.module.camera.dto.reques;
using KTAVisorAPISDK.module.camera.dto.request;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.entity;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Managemnt.module.camera.form.Settings.handlers
{
    public class SettingsHandler
    {
        private readonly CameraItemSettingsForm _form;
        private readonly StationEntity _station;
        private CameraEntity.Camera _camera;

        private readonly CameraSettingsService cameraSettingsService;
        private readonly CameraService cameraService;
        private readonly CameraCardService cameraCardService;

        public SettingsHandler(CameraItemSettingsForm form, CameraEntity.Camera camera, StationEntity station)
        {
            this._form = form;
            this._camera = camera;
            this._station = station;
            this.cameraSettingsService = new CameraSettingsService();
            this.cameraService = new CameraService();
            this.cameraCardService = new CameraCardService();
        }

        public async void Save()
        {
            bool hasDuplicates = await this.cameraCardService.hasDuplicates(this._form.CardId);

            if (hasDuplicates){
                MetroMessageBox.Show(this._form, "Wybrana karta jest przypisana do innej kamery i nie może być ponownie użyta", "Karta");
                return;
            }

            if (!await this.saveCamera()){
                return;
            }

            if (!await this.saveCameraSettings()){
                MetroMessageBox.Show(this._form, "Coś poszło nie tak, skontaktuj się z Administratorem");
                return;
            }

            
            TCPClientTObject client = Globals.Server.Clients.Find(
                (TCPClientTObject obj) => obj.IpAddress == this._station.data.stationIp
            );

            if (client == null) {
                MetroMessageBox.Show(this._form, "Coś poszło nie tak, zresetuj stacje lub skontaktuj się z Administratorem");
                return;
            }

            CameraEntity syncedCamera = await this.cameraService.findByCustomId(this._camera.cameraCustomId);
            client.Send(new Request(
               "command://cameras/settings/change",
               syncedCamera.data,
               client
            ));

            this._form.Close();
        }

        private async Task<bool> saveCamera()
        {
            CameraEntity camera = await this.cameraService.edit(this._camera.id, new EditCameraRequestTObject(
                this._camera.index,
                this._form.CameraId,
                this._form.BadgeId,
                this._form.CardId,
                this._camera.stationId,
                this._camera.driveName,
                this._camera.active
            ));

            if (camera == null || camera.data == null){
                MetroMessageBox.Show(this._form, "Coś poszło nie tak, skontaktuj się z Administratorem");
                return false;
            }

            this._camera = camera.data;
            return true;
        }

        private async Task<bool> saveCameraSettings()
        {
           CameraSettingsEntity settings = await this.cameraSettingsService.edit(this._camera.id, new EditCameraSettingsTObject(
               this._form.CameraId,
               this._form.BadgeId,
               this._form.CardId,
               this._form.Resolution,
               this._form.Quality,
               this._form.Codec,
               this._form.PreRecording ? 1 : 0,
               0,
               this._form.GPS ? 1:0,
               this._form.WIFI ? 1 : 0,
               this._form.SilentMode ? 1 : 0,
               this._form.AES ? 1 : 0
           ));

            if (settings == null)
            {
                MetroMessageBox.Show(this._form, "Nie udało się zapisać ustawień, skontaktuj się z Administratorem");
                return false;
            }

            return true;
        }
 
    }
}
