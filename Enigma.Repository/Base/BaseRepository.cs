using Enigma.Domain.Base;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Enigma.Repository.Base;

public abstract class BaseRepository
{
    protected IDatabase _database;

    protected BaseRepository(IDatabase database)
    {
        _database = database;
    }

    protected SqlCommand CreateCommand(string query, IDbTransaction? tx = null)
    {
        if (tx != null)
        {
            return new SqlCommand(query, (SqlConnection)tx.Connection, (SqlTransaction)tx);
        }
        else
        {
            return new SqlCommand(query, (SqlConnection)_database.GetConnection());
        }
    }

    protected async IAsyncEnumerable<W> GetSqlDataAsync<W>(DbDataReader reader) where W : new()
    {
        var properties = typeof(W).GetProperties();

        while (await reader.ReadAsync())
        {
            W obj = new W();

            foreach (var prop in properties)
            {
                try
                {
                    var value = reader[prop.Name];
                    if (value.GetType() != typeof(DBNull))
                        prop.SetValue(obj, value, null);
                }
                catch { }
            }
            yield return obj;
        }
    }

    protected string GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()).CollectionName;
    }
}