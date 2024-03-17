using Microsoft.Extensions.Configuration;
using Npgsql;
using Transaction.Application.Abstractions;

namespace Transaction.Infrastructure;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public NpgsqlConnection CreateConnection()
    {
        // StackExchange.Profiling.Data.ProfiledDbConnection;
        return new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}