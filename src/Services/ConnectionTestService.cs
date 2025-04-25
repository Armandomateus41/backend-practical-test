using System.Data;

namespace BackendPracticalTest.Services
{
    public class ConnectionTestService
    {
        private readonly IDbConnection _connection;

        public ConnectionTestService(IDbConnection connection)
        {
            _connection = connection;
        }

        public bool TestConnection()
        {
            try
            {
                _connection.Open();
                _connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
