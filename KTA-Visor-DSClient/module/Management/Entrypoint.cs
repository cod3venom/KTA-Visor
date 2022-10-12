using KTA_Visor_DSClient.install.settings;

using KTA_Visor_DSClient.module.Management.events;
using KTA_Visor_DSClient.module.Management.view;
using KTA_Visor_DSClient.module.Shared;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.Management
{
    public partial class Entrypoint : Form
    {
        public event EventHandler<OnExceptionOccuredEvent> OnExceptionOccured;

        private Settings settings;
        private readonly BootLoader bootLoader;
        private readonly SettingsManager settingsManagerView;

        public Entrypoint()
        {
            InitializeComponent();
            this.settings = new Settings();
            this.bootLoader = new BootLoader();
            this.settingsManagerView = new SettingsManager(Globals.Logger, this.settings);
        }

        private void Entry_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.settings.SettingsObj.app.installed && !this.settings.SettingsObj.app.configured)
                {
                    this.settingsManagerView.ShowDialog();
                    return;
                }


                this.bootLoader.Load();
            }
            catch (Exception ex)
            {
                this.OnExceptionOccured?.Invoke(this, new OnExceptionOccuredEvent(ex));
            }
        }
 
    }
}
