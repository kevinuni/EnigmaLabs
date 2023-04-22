using Enigma.Domain.Base;
using Enigma.Domain.Model;
using System.Data;

namespace Enigma.Domain.IRepositories;

public interface IPersonRepository : IRepository<Persona>
{
    Task<dynamic> SelectMultiple(IDbTransaction tx = null);

    Task<int> InsertMultiple(IList<Persona> list, IDbTransaction tx = null);
}