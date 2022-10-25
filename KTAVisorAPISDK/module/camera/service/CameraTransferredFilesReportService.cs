using KTAVisorAPISDK.module.camera.dto.request;
using KTAVisorAPISDK.module.camera.dto.response;
using KTAVisorAPISDK.module.camera.repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.service
{
    public class CameraTransferredFilesReportService
    {
        private readonly CameraTransferredFilesReportEntity _cameraTransferredFilesReportRepository;

        public CameraTransferredFilesReportService()
        {
            this._cameraTransferredFilesReportRepository = new CameraTransferredFilesReportEntity();
        }

        public async Task<CameraTransferredFilesReportEntity> create(CreateCameraTransferredFileReportRequestTObject request)
        {
            HttpResponseMessage result = await this._cameraTransferredFilesReportRepository.create(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CameraTransferredFilesReportEntity>(responseBody);
        }
    }
}
