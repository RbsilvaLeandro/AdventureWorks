using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace AdventureWorks.Data
{
    public class Context
    {
        private readonly IConfiguration _configuration;

        protected Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected IDbConnection CreateConnection()
        {
            return new NpgsqlConnection("User ID=postgres;Password=root;Host=127.0.0.1;Port=5432;Database=AdventureWorks");
        }
    }
}
