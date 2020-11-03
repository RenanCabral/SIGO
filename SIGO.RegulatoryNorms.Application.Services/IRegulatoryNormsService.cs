using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Application.Services
{
    public interface IRegulatoryNormsService
    {
        Task<List<DataContracts.RegulatoryNorm>> GetAllAsync();
    }
}
