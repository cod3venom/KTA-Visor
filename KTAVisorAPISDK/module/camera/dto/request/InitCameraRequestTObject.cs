﻿
namespace KTAVisorAPISDK.module.camera.dto.request
{
    public class InitCameraRequestTObject
    {
      

        public InitCameraRequestTObject(
            int id = 0,
            string markerId = "",
            string camCustomId = "",
            string badgeId = "",
            string cardId = "",
            string stationId = "",
            string driveName = "",
            bool active = true
        )
        {
            this.id = id;
            this.markerId = markerId;
            this.camCustomId = camCustomId;
            this.badgeId = badgeId;
            this.cardId = cardId;
            this.stationId = stationId;
            this.driveName = driveName;
            this.active = active;

        }

        public int id { get; set; }
        public string markerId { get; set; }
        public string camCustomId { get; set; }
        public string badgeId { get; set; }
        public string cardId { get; set; }
        public string stationId { get; set; }
        public string driveName { get; set; }
        public bool active { get; set; }
    }
}
