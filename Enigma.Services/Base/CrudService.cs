using Enigma.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Services.Base;

public class CrudService<TDocument> : ICrudService<TDocument> where TDocument : IDocument
{
    private ICrudRepository<TDocument> _repository;

    public CrudService(ICrudRepository<TDocument> repository)
    {
        this._repository = repository;
    }
    public async Task<IEnumerable<TDocument>> Select()
    {
        return await _repository.Select();
    }

    public async Task<TDocument> Select(int id)
    {
        return await _repository.Select(id);
    }

    public async Task<TDocument> Insert(TDocument document)
    {
        return await _repository.Insert(document);
    }

    public async Task<TDocument> Update(int id, TDocument document)
    {
        return await _repository.Update(id, document);
    }

    public async Task<TDocument> Upsert(TDocument document)
    {
        return await _repository.Upsert(document);
    }

    public async Task<int> Delete(int id)
    {
        return await _repository.Delete(id);
    }
}

