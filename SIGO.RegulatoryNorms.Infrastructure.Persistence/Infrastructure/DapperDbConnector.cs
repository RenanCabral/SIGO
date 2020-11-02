using System.Data;
using System.Data.SqlClient;

namespace SIGO.RegulatoryNorms.Infrastructure.Persistence.Infrastructure
{
    public class DapperDbConnector : IDbConnector
    {
        private string _connectionString = null;

        public DapperDbConnector(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public IDbConnection Connection { get; set; }


        public void Dispose()
        {   
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Connection?.Dispose();
            }
        }

        public void Initialize()
        {
            if (this.Connection == null)
            {
                this.Connection = new SqlConnection(this._connectionString);
                this.Connection.Open();
            }
        }
    }
}
