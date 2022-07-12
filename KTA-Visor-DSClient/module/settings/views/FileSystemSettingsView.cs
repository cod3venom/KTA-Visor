using KTA_Visor_DSClient.install.settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.settings.views
{
    public partial class FileSystemSettingsView : Form
    {
        private readonly Settings settings;

        public FileSystemSettingsView()
        {
            InitializeComponent();
            this.topBar1.Parent = this;
            this.topBar1.Title = "File System";

            this.settings = new Settings();
        }

        private void FileSystemSettingsView_Load(object sender, EventArgs e)
        {
            this.render();
        }

        private void render()
        {
            this.storageLocationTxt.Text = this.settings.SettingsObj.app.fileSystem.networkStorage;

            this.storageLocationTxt.Click += onBrowseStorageLocation;
            this.saveBtn.OnClick += onSaveSettings;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onBrowseStorageLocation(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() != DialogResult.OK)
                MessageBox.Show("Unable to select location, plese try another folder");

            this.storageLocationTxt.Text = folderDialog.SelectedPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onSaveSettings(object sender, EventArgs e)
        {
            this.settings.SettingsObj.app.fileSystem.networkStorage = this.storageLocationTxt.Text;
            this.settings.Save(this.settings.SettingsObj);
            this.Close();
        }
    }
}
