using System.Data;

namespace Enigma.Domain.Base;

public interface ICrudRepository<TDocument>
{
    Task<IList<TDocument>> Select(IDbTransaction tx = null);

    Task<TDocument> Select(int entityId, IDbTransaction tx = null);

    Task<TDocument> Insert(TDocument person, IDbTransaction tx = null);

    Task<TDocument> Update(int id, TDocument person, IDbTransaction tx = null);

    Task<TDocument> Upsert(TDocument person, IDbTransaction tx = null);

    Task<int> Delete(int? id, IDbTransaction tx = null);
}