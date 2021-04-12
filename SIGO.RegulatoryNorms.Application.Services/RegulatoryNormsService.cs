using SIGO.RegulatoryNorms.Application.Services.Mappers;
using SIGO.RegulatoryNorms.Application.Services.Messaging;
using SIGO.RegulatoryNorms.Domain.Entities;
using SIGO.RegulatoryNorms.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Application.Services
{
    public class RegulatoryNormsService : IRegulatoryNormsService
    {
        public RegulatoryNormsService(IUnitOfWork unitOfWork, IExternalRegulatoryNormsService externalRegulatoryNormsService, IQueuePublisher queuePublisher)
        {
            this._regulatoryNormsRepository = new RegulatoryNormsRepository(unitOfWork);
            this._externalRegulatoryNormsService = externalRegulatoryNormsService;
            this._queuePublisher = queuePublisher;
        }

        #region Fields

        private readonly IRegulatoryNormsRepository _regulatoryNormsRepository;
        private readonly IExternalRegulatoryNormsService _externalRegulatoryNormsService;
        private readonly IQueuePublisher _queuePublisher;

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

        public async Task<List<DataContracts.RegulatoryNorm>> GetNormsByFilterAsync(DataContracts.RegulatoryNormsFilter filter)
        {
            return await Task.FromResult(new List<DataContracts.RegulatoryNorm>());
        }

        public async Task<List<DataContracts.RegulatoryNormUpdate>> CheckRegulatoryNormsUpdateAsync()
        {

            List<DataContracts.RegulatoryNormUpdate> updatedRegulatoryNormsList;

            //TODO: implement dispose on externalRegulatoryNormsService

            // read external norms base
            var regulatoryNorms = await _externalRegulatoryNormsService.GetRegulatoryNormsAsync(DataContracts.RegulatoryNormCategory.WorkSafety);

            using (_regulatoryNormsRepository)
            {
                foreach (var regulatoryNorm in regulatoryNorms)
                {
                    updatedRegulatoryNormsList = new List<DataContracts.RegulatoryNormUpdate>();

                    // get the regulatory norm from database
                    var storedRegulatoryNorm = await _regulatoryNormsRepository.GetByCodeAsync(regulatoryNorm.Code);

                    if (storedRegulatoryNorm != null)
                    {
                        // updates regulatory norms in database
                        if (storedRegulatoryNorm.Description != regulatoryNorm.Description)
                        {
                            storedRegulatoryNorm.Description = regulatoryNorm.Description;
                            storedRegulatoryNorm.ReleaseDate = Convert.ToDateTime(regulatoryNorm.ReleaseDate);
                            await _regulatoryNormsRepository.UpdateAsync(storedRegulatoryNorm);

                            regulatoryNorm.Updated = true;

                            updatedRegulatoryNormsList.Add(regulatoryNorm);
                        }
                    }
                    else
                    {
                        // inserts new regulatory norms in database

                        // TODO: call mapper method here
                        var newRegulatoryNorm = new RegulatoryNorm()
                        {
                            Code = regulatoryNorm.Code,
                            Description = regulatoryNorm.Description,
                            ReleaseDate = Convert.ToDateTime(regulatoryNorm.ReleaseDate)
                    };
                        await _regulatoryNormsRepository.InsertAsync(newRegulatoryNorm);

                        updatedRegulatoryNormsList.Add(regulatoryNorm);
                    }

                    if (updatedRegulatoryNormsList.Any())
                    {
                        //Publishes norms' updates to queue 
                        this._queuePublisher.SendMessage(updatedRegulatoryNormsList);
                    }
                }
            }

            // TODO: check logic of database initial population
            // TODO: implement a comparer to check norms diff

            return regulatoryNorms;
        }

        private bool IsRegulatoryNormUpdated()
        {
            return false;
        }


        #endregion
    }
}
