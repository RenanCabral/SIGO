using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Application.Services
{
    public class ExternalRegulatoryNormsService : IExternalRegulatoryNormsService
    {
        public ExternalRegulatoryNormsService(IRegulatoryNormsService regulatoryNormsService)
        {
           // this._regulatoryNormsService = regulatoryNormsService;
        }

        public async Task<List<DataContracts.RegulatoryNormUpdate>> CheckRegulatoryNormsUpdateAsync()
        {
            // logic to read external norms base
           // using (externalRegulatoryNormsClient)
           // {
                // it is expected that a few updated norms are returned here;
                //var regulatoryNorms = externalRegulatoryNormsClient.GetRegulatoryNorms(filter);

                // TODO: check logic of database initial population
                // TODO: implement a comparer to check norms diff
            //}

            return null;
        }
    }
}
