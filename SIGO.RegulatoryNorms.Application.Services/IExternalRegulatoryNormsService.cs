using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Application.Services
{
    public interface IExternalRegulatoryNormsService
    {
        Task<List<DataContracts.RegulatoryNormUpdate>> CheckRegulatoryNormsUpdateAsync();
    }
}
