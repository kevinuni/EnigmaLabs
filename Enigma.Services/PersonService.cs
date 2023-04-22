using AutoMapper;
using Enigma.Domain.Base;
using Enigma.Domain.Dto;
using Enigma.Domain.IRepositories;
using Enigma.Domain.Model;
using Enigma.Services.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Services;

public class PersonService : Service<Person>, IPersonService
{
    IPersonRepository _personRepository;
    ICrudRepository<Person> _crudPersonRepository;
    private IMapper _mapper;
    private IDatabase _database;

    public PersonService(IPersonRepository personRepository, IMapper mapper, IDatabase database, ICrudRepository<Person> crudPersonRepository) : base(personRepository)
    {
        _personRepository = personRepository;
        _mapper = mapper;
        _database = database;
        _crudPersonRepository = crudPersonRepository;
    }

    public async Task<IEnumerable<PersonDto>> SelectMultiple()
    {
        try
        {
            var result = await _crudPersonRepository.Select();
            //var result = await _personRepository.SelectMultiple().ConfigureAwait(false);

            //List<Person> lstPerson = result.GetType().GetProperty("res1").GetValue(result, null);
            //List<Country> lstCountry = result.GetType().GetProperty("res2").GetValue(result, null);

            var lst = result.Select(x => _mapper.Map<PersonDto>(x));

            return lst;
        }
        catch (Exception e)
        {
            //_logger.LogError(e, "Error en el método Get");
            return null;
        }
    }

    public async Task<int> InsertMultiple(IList<Person> list)
    {
        return await _personRepository.InsertMultiple(list);
    }

    public async Task<int> TestTransaction(IList<Person> list)
    {
        using (IDbTransaction tx = _database.GetConnection().BeginTransaction(IsolationLevel.Serializable))
        {
            int res = 0;

            try
            {
                Person person3 = await _crudPersonRepository.Select(4, tx);
                person3.FirstName = "4544444";
                person3 = await _crudPersonRepository.Update(4, person3, tx);

                res = await _personRepository.InsertMultiple(list, tx);

                tx.Commit();
            }
            catch (Exception ex)
            {
                tx.Rollback();
            }
            return res;
        }
    }

    //public async Task<int> TestExecuteScalar()
    //{

    //}
}