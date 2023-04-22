using Enigma.Domain.Authentication;

namespace Enigma.Api.Authentication;

public interface IJWTManagerRepository
{
    Tokens Authenticate(Users user);
}
