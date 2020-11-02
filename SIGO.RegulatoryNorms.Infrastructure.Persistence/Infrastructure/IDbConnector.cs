using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SIGO.RegulatoryNorms.Infrastructure.Persistence.Infrastructure
{
    public interface IDbConnector : IDisposable
    {
        public IDbConnection Connection { get; set; }

        public void Initialize();
    }
}
