using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace BackendPracticalTest.Config
{
    public class DbConfig
    {
        private readonly IConfiguration _configuration;

        public DbConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            var cs = _configuration.GetConnectionString("OracleDb")
                     ?? throw new InvalidOperationException("OracleDb not configured");
            return new OracleConnection(cs);
        }
    }
}
