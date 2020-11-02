using System;
using System.Collections.Generic;
using System.Text;

namespace SIGO.RegulatoryNorms.Infrastructure.Persistence.Repositories
{
    public class BaseRepository
    {
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork { get; }
    }
}
