using Enigma.Domain.Base;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Enigma.Repository.Base;

public class SqlServerDatabase : IDatabase
{
    private readonly string _connectionString;

    public SqlServerDatabase(IOptions<SqlServerSettings> options)
    {
        _connectionString = options.Value.ConnectionString;
    }

    public IDbConnection GetConnection()
    {
        var conn = new SqlConnection(_connectionString);
        conn.Open();
        return conn;
    }
}