using Enigma.Domain.Dto;
using Enigma.Domain.Model;
using Enigma.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Services;

public interface IPersonaService
{
    Task<IEnumerable<PersonaDto>> SelectMultiple();

    Task<int> InsertMultiple(IList<Persona> list);

    Task<int> TestTransaction(IList<Persona> list);
}