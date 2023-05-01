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
            W obj = new W();

            foreach (var prop in properties)
            {
                try
                {
                    var value = reader[prop.Name];
                    if (value.GetType() == typeof(DBNull))
                    {

                    }
                    else if (value.GetType().IsAssignableTo(prop.PropertyType))
                    {
                        prop.SetValue(obj, value, null);
                    }
                    else if (value.GetType().IsGenericType)
                    {
                        //do nothing
                    }
                    else
                    {
                        Console.WriteLine();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            yield return obj;
        }
    }

    protected string GetTableName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()).TableName;
    }

    protected string GetSchema(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()).Schema;
    }

    public async Task<IList<T>> QueryAsync<T>(string spName, object param = null, IDbTransaction tx = null) where T : new()
    {
        var command = CreateCommand(spName, tx);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Clear();

        Type type = param.GetType();
        foreach (var property in type.GetProperties())
        {
            command.Parameters.AddWithValue("@" + property.Name, property.GetValue(param));
        }

        using (var reader = await command.ExecuteReaderAsync())
        {
            var obj = GetSqlDataAsync<T>(reader);
            return await obj.ToListAsync();
        }
    }

    public async Task<(IList<T>, IList<W>)> QueryAsync<T, W>(string spName, object param = null, IDbTransaction tx = null) where T : new() where W : new()
    {
        try
        {
            var command = CreateCommand(spName, tx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();

            Type type = param.GetType();
            foreach (var property in type.GetProperties())
            {
                command.Parameters.AddWithValue("@" + property.Name, property.GetValue(param));
            }

            using (var reader = await command.ExecuteReaderAsync())
            {
                var objT = GetSqlDataAsync<T>(reader);
                IList<T> listOfT = await objT.ToListAsync();

                if (await reader.NextResultAsync())
                {
                    var objW = GetSqlDataAsync<W>(reader);
                    IList<W> listOfW = await objW.ToListAsync();
                    return (listOfT, listOfW);
                }
                return (listOfT, null);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        return new(null, null);
    }
}