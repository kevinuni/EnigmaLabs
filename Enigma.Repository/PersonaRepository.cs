using Enigma.Domain.Base;
using Enigma.Domain.IRepositories;
using Enigma.Domain.Model;
using Enigma.Repository.Base;
using Enigma.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Repository;

public class PersonaRepository : Repository<Persona>, IPersonRepository
{
    public PersonaRepository(IDatabase database) : base(database)
    {

    }

    public async Task<dynamic> SelectMultiple(IDbTransaction tx = null)
    {
        const string spName = "usp_getPersonAndCountry";

        var command = CreateCommand(spName, tx);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Clear();

        List<Persona> lstPerson = null;
        List<Country> lstCountry = null;

        using (var reader = await command.ExecuteReaderAsync())
        {
            var obj = GetSqlDataAsync<Persona>(reader);
            lstPerson = await obj.ToListAsync();

            if (await reader.NextResultAsync())
            {
                var objCountries = GetSqlDataAsync<Country>(reader);
                lstCountry = await objCountries.ToListAsync();
            }
        }

        var result = new { res1 = lstPerson, res2 = lstCountry };

        return result;
    }


    public async Task<int> InsertMultiple(IList<Persona> list, IDbTransaction tx = null)
    {
        const string spName = "dbo.usp_Person_InsertMany";
        const string sqlParameterName = "@lstPerson";
        const string typeName = "dbo.Person";

        var command = CreateCommand(spName, tx);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Clear();

        var dt = list.ToList().Select(x => new
        {
            x.FirstName,
            x.LastName,
            x.DOI,
            x.IsPerNat
        }).AsEnumerable();


        var par = new SqlParameter(sqlParameterName, SqlDbType.Structured);
        par.Value = CollectionManager.ToDataTable(dt);
        par.TypeName = typeName;

        command.Parameters.Add(par);

        int res = await command.ExecuteNonQueryAsync();

        return res;
    }
}