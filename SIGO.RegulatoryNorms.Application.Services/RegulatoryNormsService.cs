using SIGO.RegulatoryNorms.Application.Services.Mappers;
using SIGO.RegulatoryNorms.Domain.Entities;
using SIGO.RegulatoryNorms.Infrastructure.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Application.Services
{
    public class RegulatoryNormsService : IRegulatoryNormsService
    {
        public RegulatoryNormsService(IUnitOfWork unitOfWork)
        {
            this._regulatoryNormsRepository = new RegulatoryNormsRepository(unitOfWork);
        }

        #region Fields

        private readonly IRegulatoryNormsRepository _regulatoryNormsRepository;

        #endregion

        #region Public Methods 

        public async Task<List<DataContracts.RegulatoryNorm>> GetAllAsync()
        {
            using (_regulatoryNormsRepository)
            {
                List<RegulatoryNorm> regulatoryNorms = await _regulatoryNormsRepository.GetAllAsync();

                return RegulatoryNormsMapper.MapModelToContract(regulatoryNorms).ToList();
            }
        }

        #endregion
    }
}
