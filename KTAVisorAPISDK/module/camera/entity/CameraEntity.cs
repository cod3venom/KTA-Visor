using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.entity
{
    public class CameraEntity
    {
        public class Camera
        {
            public string id { get; set; }
            public int index { get; set; }
            public string cameraCustomId { get; set; }
            public string badgeId { get; set; }
            public string driveName { get; set; }
            public bool active { get; set; }
            public string stationId { get; set; }
            public bool currentlySelected { get; set; }
            public string updatedAt { get; set; }
            public string createdAt { get; set; }
            public CameraSettingsEntity.Settings settings { get; set; }
        }

        public Camera data { get; set; }
        public List<Camera> datas { get; set; }
    }
}
