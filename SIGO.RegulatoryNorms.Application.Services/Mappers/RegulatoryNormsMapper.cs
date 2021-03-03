using System.Collections.Generic;

namespace SIGO.RegulatoryNorms.Application.Services.Mappers
{
    public class RegulatoryNormsMapper
    {
        public static DataContracts.RegulatoryNorm MapModelToContract(Domain.Entities.RegulatoryNorm regulatoryNorm)
        {
            return new DataContracts.RegulatoryNorm
            {
                Code = regulatoryNorm.Code,
                Description = regulatoryNorm.Description,
                Category = ((DataContracts.RegulatoryNormCategory)(int)regulatoryNorm.Category),
                ReleaseDate = regulatoryNorm.ReleaseDate,
                IsApplied = regulatoryNorm.IsApplied
            };
        }

        public static IEnumerable<DataContracts.RegulatoryNorm> MapModelToContract(List<Domain.Entities.RegulatoryNorm> regulatoryNorms)
        {
            foreach (var regulatoryNorm in regulatoryNorms)
            {
                yield return MapModelToContract(regulatoryNorm);
            }
        }
    }
}
