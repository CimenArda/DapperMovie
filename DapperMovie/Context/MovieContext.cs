using System.Data;
using System.Data.SqlClient;
namespace DapperMovie.Context
{
    public class MovieContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public MovieContext(IConfiguration configuration)
        {
            // appsettings.json'dan bağlantı dizesini al
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Veritabanı bağlantısı oluştur
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
