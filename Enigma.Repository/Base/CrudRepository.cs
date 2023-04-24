using Enigma.Domain.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Enigma.Repository.Base;

public class CrudRepository<TDocument> : Repository<TDocument>, ICrudRepository<TDocument> where TDocument : IDocument, new()
{
    public CrudRepository(IDatabase database) : base(database)
    {
    }

    public async Task<IEnumerable<TDocument>> Select(IDbTransaction? tx = null)
    {
        return await Query(null, tx);
    }

    public async Task<TDocument> Select(int entityId, IDbTransaction? tx = null) 
    {
        var res = await Query(entityId, tx);
        return res.FirstOrDefault();
    }

    private async Task<IEnumerable<TDocument>> Query(int? entityId = null, IDbTransaction? tx = null)
    {
        string entityName = GetCollectionName(typeof(TDocument));
        string spName = "usp_" + entityName + "_Select";
        string parKeyName = "@" + entityName + "Id";

        var command = CreateCommand(spName, tx);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Clear();

        command.Parameters.AddWithValue(parKeyName, entityId.HasValue ? entityId.Value : DBNull.Value);

        using (var reader = await command.ExecuteReaderAsync())
        {
            var obj = GetSqlDataAsync<TDocument>(reader);

            return await obj.ToListAsync();
        }
    }

    public async Task<TDocument> Insert(TDocument entity, IDbTransaction? tx = null)
    {
        string entityName = GetCollectionName(typeof(TDocument));
        string spName = "usp_" + entityName + "_Insert";

        var command = CreateCommand(spName, tx);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Clear();

        CreateParameters(command, entity);

        using (var reader = await command.ExecuteReaderAsync())
        {
            var obj = GetSqlDataAsync<TDocument>(reader);

            var list = await obj.ToListAsync();

            return list.FirstOrDefault();
        }
    }

    public async Task<TDocument> Update(int id, TDocument entity, IDbTransaction? tx = null)
    {
        string entityName = GetCollectionName(typeof(TDocument));
        string spName = "usp_" + entityName + "_Update";
        string propName = entityName + "Id";

        var command = CreateCommand(spName, tx);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Clear();

        if (entity.GetType().GetProperty(propName).GetValue(entity, null).Equals(id) == false)
        {
            throw new Exception("Error");
        }

        CreateParameters(command, entity);

        using (var reader = await command.ExecuteReaderAsync())
        {
            var obj = GetSqlDataAsync<TDocument>(reader);

            var list = await obj.ToListAsync();

            return list.FirstOrDefault();
        }
    }

    public async Task<TDocument> Upsert(TDocument entity, IDbTransaction? tx = null)
    {
        string entityName = GetCollectionName(typeof(TDocument));
        string spName = "usp_" + entityName + "_UI";

        var command = CreateCommand(spName, tx);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Clear();

        CreateParameters(command, entity);

        using (var reader = await command.ExecuteReaderAsync())
        {
            var obj = GetSqlDataAsync<TDocument>(reader);

            var list = await obj.ToListAsync();

            return list.FirstOrDefault();
        }
    }

    public async Task<int> Delete(int? entityId, IDbTransaction? tx = null)
    {
        string entityName = GetCollectionName(typeof(TDocument));
        string spName = "usp_" + entityName + "_Delete";
        string parName = "@" + entityName + "Id";

        var command = CreateCommand(spName, tx);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Clear();

        command.Parameters.AddWithValue(parName, entityId.Value);

        var obj = await command.ExecuteNonQueryAsync();

        return obj;
    }

    public void CreateParameters(SqlCommand command, TDocument obj)
    {
        var properties = typeof(TDocument).GetProperties();

        foreach (var f in properties)
        {
            command.Parameters.AddWithValue("@" + f.Name, f.GetValue(obj) ?? DBNull.Value);
        }
    }
}
