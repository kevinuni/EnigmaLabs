namespace Enigma.Services.Base;

public interface ICrudService<TDocument>
{
    Task<IEnumerable<TDocument>> Select();

    Task<TDocument> Select(int id);

    Task<TDocument> Insert(TDocument person);

    Task<TDocument> Update(int id, TDocument person);

    Task<TDocument> Upsert(TDocument person);

    Task<int> Delete(int id);
}