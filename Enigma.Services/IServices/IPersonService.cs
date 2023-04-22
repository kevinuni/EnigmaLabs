using Enigma.Domain.Dto;
using Enigma.Domain.Model;
using Enigma.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Services;

public interface IPersonService : IService<Person>
{
    Task<IEnumerable<PersonDto>> SelectMultiple();

    Task<int> InsertMultiple(IList<Person> list);

    Task<int> TestTransaction(IList<Person> list);
}