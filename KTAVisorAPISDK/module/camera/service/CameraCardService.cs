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
    public class CameraCardService
    {
        private readonly CameraCardRepository _cameraCardRepository;

        public CameraCardService()
        {
            this._cameraCardRepository = new CameraCardRepository();
        }

        public async Task<bool> hasDuplicates(string cardId)
        {
            HttpResponseMessage result = await this._cameraCardRepository.hasDuplicates(cardId);
            string responseBody = await result.Content.ReadAsStringAsync();
            CameraHasCardDuplicatesResponseTObject obj = JsonConvert.DeserializeObject<CameraHasCardDuplicatesResponseTObject>(responseBody);

            if (obj.data == null){
                return false;
            }
            return obj.data.hasDuplicates;
            
        }
    }
}
