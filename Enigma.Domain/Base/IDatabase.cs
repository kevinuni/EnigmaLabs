using System.Data;

namespace Enigma.Domain.Base;

public interface IDatabase
{
    IDbConnection GetConnection();
}