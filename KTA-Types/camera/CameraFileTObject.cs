using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Types.camera
{
    internal class CameraFileTObject
    {
        private string name;
        private string location;
        private float size;
        private string type;

        public CameraFileTObject(string name, string location, float size, string type)
        {
            this.Name = name;
            this.Location = location;
            this.Size = size;
            this.Type = type;
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public float Size { get; set; }
        public string Type{ get; set; }
    }

}
