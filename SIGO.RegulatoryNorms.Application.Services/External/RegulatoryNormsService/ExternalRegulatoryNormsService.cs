using Newtonsoft.Json;
using SIGO.RegulatoryNorms.Application.Services.External;
using SIGO.RegulatoryNorms.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Application.Services
{
    public class ExternalRegulatoryNormsService : IExternalRegulatoryNormsService
    {

        private IExternalRegulatoryNormsClient _externalRegulatoryNormsClient;

        public ExternalRegulatoryNormsService(IExternalRegulatoryNormsClient client)
        {
            this._externalRegulatoryNormsClient = client;
        }

        public async Task<List<RegulatoryNormUpdate>> GetRegulatoryNormsAsync(RegulatoryNormCategory category)
        {
            var httpResponseMessage = await _externalRegulatoryNormsClient.GetNormsAsync(category);

            var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

            var regulatoryNormsList = JsonConvert.DeserializeObject<List<RegulatoryNormUpdate>>(jsonResponse.Trim());

            return regulatoryNormsList;
        }
    }
}
