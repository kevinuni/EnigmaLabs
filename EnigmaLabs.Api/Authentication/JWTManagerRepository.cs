using Enigma.Domain.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Enigma.Api.Authentication;

public class JWTManagerRepository : IJWTManagerRepository
{
    private readonly IConfiguration configuration;

    Dictionary<string, string> UserRecords = new Dictionary<string, string> {
        {"user1", "password1"},
        {"user2", "password2"},
        {"user3", "password3"}
    };

    public JWTManagerRepository(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public Tokens Authenticate(Users user)
    {
        if (!UserRecords.Any(x => x.Key == user.Name && x.Value == user.Password))
        {
            return null;
        }

        var tokenhandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration[Constants.Settings_JWT_KEY]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new Claim[] {
                    new Claim(ClaimTypes.Name, user.Name)
                }
                ),
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenhandler.CreateToken(tokenDescriptor);

        return new Tokens { Token = tokenhandler.WriteToken(token) };
    }
}
