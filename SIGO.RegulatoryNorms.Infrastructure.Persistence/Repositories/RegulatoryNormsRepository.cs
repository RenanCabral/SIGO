using Dapper;
using SIGO.RegulatoryNorms.Domain.Entities;
using SIGO.RegulatoryNorms.Domain.Enums;
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
            var sql = @" SELECT    [RegulatoryNormId]
                                  ,[Code]
                                  ,[Description]
                                  ,[Active]
                                  ,[CategoryId] AS Category
                                  ,[ReleaseDate]
                                  ,[UpdateDate] 
                                  ,[IsApplied]
                        FROM [dbo].[RegulatoryNorms] WHERE Active = 1";

            var regulatoryNorms = await this.UnitOfWork.DbConnector.Connection.QueryAsync<RegulatoryNorm>(sql);

            return regulatoryNorms.ToList();
        }

        public async Task<RegulatoryNorm> GetByCodeAsync(string code)
        {
            var sql = @" SELECT    [RegulatoryNormId]
                                  ,[Code]
                                  ,[Description]
                                  ,[Active]
                                  ,[CategoryId] AS Category
                                  ,[ReleaseDate]
                                  ,[UpdateDate]
                                  ,[IsApplied]
                        FROM [dbo].[RegulatoryNorms] WHERE Code = @code AND Active = 1";

            var param = new { code };

            var regulatoryNorm = await this.UnitOfWork.DbConnector.Connection.QueryFirstOrDefaultAsync<RegulatoryNorm>(sql, param);

            return regulatoryNorm;
        }

        public async Task InsertAsync(RegulatoryNorm regulatoryNorm)
        {
            var sql = @" INSERT INTO [dbo].[RegulatoryNorms] (Code, Description, Active, CategoryId) VALUES (@code, @description, @active, @categoryId)";

            var param = new
            {
                code = regulatoryNorm.Code,
                description = regulatoryNorm.Description,
                active = true,
                categoryId = Convert.ToInt32(regulatoryNorm.Category)
            };

            await this.UnitOfWork.DbConnector.Connection.ExecuteAsync(sql, param);
        }

        public async Task UpdateAsync(RegulatoryNorm regulatoryNorm)
        {
            var sql = @" UPDATE [dbo].[RegulatoryNorms] 
                       SET Description = @description,
                           UpdateDate = @updateDate,
                           CategoryId = @categoryId,
                           ReleaseDate = @releaseDate 
                       WHERE Code = @code";

            var param = new
            {
                code = regulatoryNorm.Code,
                description = regulatoryNorm.Description,
                updateDate = DateTime.UtcNow,
                categoryId = Convert.ToInt32(regulatoryNorm.Category),
                releaseDate = regulatoryNorm.ReleaseDate
            };

            try
            {
                await this.UnitOfWork.DbConnector.Connection.ExecuteAsync(sql, param);
            }
            catch (Exception ex)
            {   
                throw;
            }

            
        }

        public void Dispose()
        {
            base.UnitOfWork.Dispose();
        }
    }
}
