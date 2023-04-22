using Enigma.Domain.Base;
using Enigma.Domain.Model;
using System.Data;

namespace Enigma.Domain.IRepositories;

public interface IPersonRepository : IRepository<Person>
{
    Task<dynamic> SelectMultiple(IDbTransaction tx = null);

    Task<int> InsertMultiple(IList<Person> list, IDbTransaction tx = null);
}