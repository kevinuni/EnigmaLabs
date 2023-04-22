using Enigma.Domain.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Enigma.Repository.Base;

public class Repository<TDocument> : IRepository<TDocument> where TDocument : IDocument, new()
{
    protected IDatabase _database;

    protected Repository(IDatabase database)
    {
        _database = database;
    }

    protected SqlCommand CreateCommand(string query, IDbTransaction tx = null)
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
            W element = new W();

            foreach (var prop in properties)
            {
                try
                {
                    var obj = reader[prop.Name];
                    if (obj.GetType() != typeof(DBNull))
                        prop.SetValue(element, obj, null);
                }
                catch { }
            }
            yield return element;
        }
    }

    private protected string GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()).CollectionName;
    }
}
