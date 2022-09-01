using KTA_Visor.module.Managemnt.module.camera.dto.request;
using KTA_Visor.module.Managemnt.module.camera.entity;
using KTA_Visor.module.Managemnt.module.camera.events;
using KTA_Visor.module.Managemnt.module.camera.service;
using KTA_Visor.module.Managemnt.module.camera.views.forms;
using KTA_Visor.module.Shared.Exceptions;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.camera.views.CameraViewPanel
{
    public partial class CamerasViewPanel : UserControl
    {
        private readonly ColumnTObject[] Columns = new ColumnTObject[] {
            new ColumnTObject(0, "ID"),
            new ColumnTObject(1, "IDENTYFIKATOR KAMERY"),
            new ColumnTObject(2, "IMIĘ"),
            new ColumnTObject(3, "NAZWISKO"),
            new ColumnTObject(4, "ZMODYFIKOWANO"),
            new ColumnTObject(5, "UTWORZONO")
        };

        private CameraCRUDForm cameraCRUDForm;
        private CameraService cameraService;
        public CamerasViewPanel()
        {
            InitializeComponent();
            this.cameraService = new CameraService();
            this.table.AllowAdd = false;
            this.table.OnEditButton += onClickEditCamera;
            this.table.OnDeleteButton += onClickDeleteCamera;
            this.table.bundle.column.addMultiple(this.Columns);
        }

        private void CamerasViewPanel_Load(object sender, EventArgs e)
        { 
            this.fetchCameras();
        }

        private async void onClickEditCamera(object sender, EventArgs e)
        {
            string selectedCameraId = this.getSelectedCameraId();

            CameraEntity cameraEntity = await this.cameraService.findById(selectedCameraId);
            this.cameraCRUDForm = new CameraCRUDForm(cameraEntity.data.cameraCustomId);
            this.cameraCRUDForm.OnEditCameraEvent += (async delegate (object _sender, OnCameraCRUDEvent evt) {
                await this.cameraService.edit(selectedCameraId, new EditCameraRequestTObject(evt.CameraCustomId));
                this.cameraCRUDForm.Hide();
                this.fetchCameras();
            });
            this.cameraCRUDForm.ShowDialog();
        }

        private async void onClickDeleteCamera(object sender, EventArgs e)
        {
           try
            {
                string selectedCameraId = this.getSelectedCameraId();
                await this.cameraService.delete(selectedCameraId);
                this.fetchCameras();
            }
            catch(UnableToRemoveRecordException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async void fetchCameras()
        {
            CamerasEntity camerasEntity = await this.cameraService.all();
            this.table.DataGridView.Rows.Clear();

            foreach (var camera in camerasEntity.data)
            {
                this.table.bundle.row.add(
                    camera.id,
                    camera.cameraCustomId,
                    camera.officer.firstName,
                    camera.officer.lastName,
                    camera.updatedAt,
                    camera.createdAt
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string getSelectedCameraId()
        {
            return this.table.bundle.row.selectedRow.Cells["ID"].Value.ToString();
        }
    }
}
