using Enigma.Api.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Enigma.Domain.Authentication;

namespace Enigma.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IJWTManagerRepository _jwtManagerRepository;
    public UsersController(IJWTManagerRepository jwtManagerERepository)
    {
        _jwtManagerRepository = jwtManagerERepository;
    }

    [HttpGet]
    [Route("userList")]
    public List<string> Get()
    {
        var users = new List<string> {
            "Kevin Diaz",
            "Juan Perez",
            "John Doe"
        };

        return users;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("authenticate")]
    public IActionResult Authenticate(Users userData)
    {
        var token = _jwtManagerRepository.Authenticate(userData);

        if (token == null)
        {
            return Unauthorized();
        }

        return Ok(token);
    }
}
