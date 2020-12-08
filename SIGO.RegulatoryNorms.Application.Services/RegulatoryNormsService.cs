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
        public RegulatoryNormsService(IUnitOfWork unitOfWork, IExternalRegulatoryNormsService externalRegulatoryNormsService)
        {
            this._regulatoryNormsRepository = new RegulatoryNormsRepository(unitOfWork);
            this._externalRegulatoryNormsService = externalRegulatoryNormsService;
        }

        #region Fields

        private readonly IRegulatoryNormsRepository _regulatoryNormsRepository;
        private readonly IExternalRegulatoryNormsService _externalRegulatoryNormsService;


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

        public async Task<List<DataContracts.RegulatoryNormUpdate>> CheckRegulatoryNormsUpdateAsync()
        {
            //TODO: implement dispose on externalRegulatoryNormsService

            // logic to read external norms base
            var regulatoryNorms = await _externalRegulatoryNormsService.GetRegulatoryNormsAsync(DataContracts.RegulatoryNormCategory.WorkSafety);

          
            // TODO: check logic of database initial population
            // TODO: implement a comparer to check norms diff


            return regulatoryNorms;
        }



        #endregion
    }
}
