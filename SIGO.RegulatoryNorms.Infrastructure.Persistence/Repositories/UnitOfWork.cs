using SIGO.RegulatoryNorms.Infrastructure.CrossCutting;
using SIGO.RegulatoryNorms.Infrastructure.Persistence.Infrastructure;

namespace SIGO.RegulatoryNorms.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Constructors

        public UnitOfWork()
        {   
        }

        #endregion

        private IDbConnector _dbConnector;

        #region Properties 
        public IDbConnector DbConnector
        {
            get
            {
                if (_dbConnector == null)
                {
                    _dbConnector = new DapperDbConnector(AppConfiguration.ConnectionString);
                    _dbConnector.Initialize();
                }

                return _dbConnector;
            }
            private set
            {
                _dbConnector = value;
            }
        }


        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && _dbConnector != null)
                {
                    // TODO: dispose managed state (managed objects).
                    _dbConnector.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
