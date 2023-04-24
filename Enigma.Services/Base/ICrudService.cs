using Enigma.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Services.Base;

public interface ICrudService<TDocument> where TDocument : IDocument
{
    Task<IEnumerable<TDocument>> Select();
    
    Task<TDocument> Select(int id);

    Task<TDocument> Insert(TDocument person);

    Task<TDocument> Update(int id, TDocument person);
    
    Task<TDocument> Upsert(TDocument person);

    Task<int> Delete(int id);
}
