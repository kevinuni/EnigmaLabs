using AutoMapper;
using Enigma.Domain.Base;
using Enigma.Domain.Dto;
using Enigma.Domain.IRepositories;
using Enigma.Domain.Model;
using System.Data;

namespace Enigma.Services;

public class PersonaService : IPersonaService
{
    private IPersonaRepository _personRepository;
    private ICrudRepository<Persona> _crudPersonRepository;
    private IMapper _mapper;
    private IDatabase _database;

    public PersonaService(IPersonaRepository personRepository, IMapper mapper, IDatabase database, ICrudRepository<Persona> crudPersonRepository)
    {
        _personRepository = personRepository;
        _mapper = mapper;
        _database = database;
        _crudPersonRepository = crudPersonRepository;
    }

    public async Task<IEnumerable<PersonaDto>> SelectMultiple()
    {
        try
        {
            var result = await _crudPersonRepository.Select();
            //var result = await _personRepository.SelectMultiple().ConfigureAwait(false);

            

            var lst = result.Select(x => _mapper.Map<PersonaDto>(x));

            return lst;
        }
        catch (Exception e)
        {
            //_logger.LogError(e, "Error en el método Get");
            return null;
        }
    }

    public async Task<int> InsertMultiple(IList<Persona> list)
    {
        return await _personRepository.InsertMultiple(list);
    }

    public async Task<int> TestTransaction(IList<Persona> list)
    {
        using (IDbTransaction tx = _database.GetConnection().BeginTransaction(IsolationLevel.Serializable))
        {
            int res = 0;

            try
            {
                Persona person3 = await _crudPersonRepository.Select(4, tx);
                person3.Nombre = "4544444";
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
}