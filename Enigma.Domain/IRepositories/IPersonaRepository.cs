using Enigma.Domain.Model;
using System.Data;

namespace Enigma.Domain.IRepositories;

public interface IPersonaRepository
{
    Task<dynamic> SelectMultiple(IDbTransaction tx = null);

    Task<int> InsertMultiple(IList<Persona> list, IDbTransaction tx = null);
}