using System.Data;
using Npgsql;

namespace Transaction.Application.Abstractions;

public interface ISqlConnectionFactory
{
    NpgsqlConnection CreateConnection();
}