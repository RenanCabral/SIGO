using SIGO.RegulatoryNorms.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Application.Services
{
    public interface IRegulatoryNormsService
    {
        Task<List<DataContracts.RegulatoryNorm>> GetAllAsync();
        Task<List<DataContracts.RegulatoryNormUpdate>> CheckRegulatoryNormsUpdateAsync();
        Task<List<DataContracts.RegulatoryNorm>> GetNormsByFilterAsync(RegulatoryNormsFilter filter);
        void PublishHealthCheckMessage();
    }
}
