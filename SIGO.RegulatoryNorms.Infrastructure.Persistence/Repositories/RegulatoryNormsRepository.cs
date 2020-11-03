using Dapper;
using SIGO.RegulatoryNorms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Infrastructure.Persistence.Repositories
{
    public class RegulatoryNormsRepository : BaseRepository, IRegulatoryNormsRepository, IDisposable
    {
        public RegulatoryNormsRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<List<RegulatoryNorm>> GetAllAsync()
        {
            var sql = @" SELECT * FROM [dbo].[RegulatoryNorms] WHERE Active = 1";

            var regulatoryNorms = await this.UnitOfWork.DbConnector.Connection.QueryAsync<RegulatoryNorm>(sql);

            return regulatoryNorms.ToList();
        }

        public void Dispose()
        {
            base.UnitOfWork.Dispose();
        }
    }
}
