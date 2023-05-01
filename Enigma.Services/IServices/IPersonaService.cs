using Enigma.Domain.Dto;
using Enigma.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Services;

public interface IPersonaService
{
    Task<IList<Persona>> Select();

    Task<Persona> Select(int id);

    Task<Persona> Insert(Persona person);

    Task<Persona> Update(int id, Persona person);

    Task<Persona> Upsert(Persona person);

    Task<int> Delete(int id);



    Task<IList<PersonaDto>> SelectMultiple();

    Task<int> InsertMultiple(IList<Persona> list);

    Task<int> TestTransaction(IList<Persona> list);
}