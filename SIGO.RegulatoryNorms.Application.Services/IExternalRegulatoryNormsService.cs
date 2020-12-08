using SIGO.RegulatoryNorms.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Application.Services
{
    public interface IExternalRegulatoryNormsService
    {
        Task<List<DataContracts.RegulatoryNormUpdate>> GetRegulatoryNormsAsync(RegulatoryNormCategory category);
    }
}
