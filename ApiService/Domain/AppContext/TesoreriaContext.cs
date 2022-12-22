using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiService.Domain.AppContext
{
    public class TesoreriaContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public TesoreriaContext(IConfiguration _configuration)
        {
            configuration = _configuration;
            connectionString = configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);

    }
}
