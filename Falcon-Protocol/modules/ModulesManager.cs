using Falcon_Protocol.interfaces;
using Falcon_Protocol.modules.detector;
using Falcon_Protocol.types;

namespace Falcon_Protocol.modules
{
    public class ModulesManager
    {
        private readonly ModulesPack modules;
        
        public ModulesManager()
        {
            this.modules = new ModulesPack();
            this.Detector = new DeviceDetector();

            this.packModules();
        }

        public DeviceDetector Detector { get; set; }


        private void packModules()
        {
            this.modules.Add(this.Detector);
        }

        public IModuleInterface GetModule(string name)
        {
            return this.modules.Get(name);
        }
    }
}
