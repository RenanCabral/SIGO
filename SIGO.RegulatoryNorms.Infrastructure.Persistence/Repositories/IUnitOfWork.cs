using SIGO.RegulatoryNorms.Infrastructure.Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGO.RegulatoryNorms.Infrastructure.Persistence.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnector DbConnector { get; }
  
    }
}
