using AutoMapper;
using Enigma.Domain.Model;
using Enigma.Services;
using Enigma.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enigma.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonaController : Controller
{
    private readonly IPersonaService _personaService;
    private readonly ICrudService<Persona> _crudPersonService;
    private readonly ILogger<PersonaController> _logger;
    private IMapper _mapper;

    public PersonaController(ILogger<PersonaController> logger, IPersonaService personaService, ICrudService<Persona> crudPersonService, IMapper mapper)
    {
        _personaService = personaService;
        _crudPersonService = crudPersonService;
        _logger = logger;
        _mapper = mapper;
    }


    // GET api/<PersonController>/5
    //[Route("person/{id}")]
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Persona>>> Get(int id)
    {
        var person = await _crudPersonService.Select(id);

        return Ok(person);
    }

    // PUT api/<PersonController>
    [HttpPut("{id}")]
    public async Task<ActionResult<IEnumerable<Persona>>> Update(int id, [FromBody] Persona person)
    {
        person.ModifiedDate = DateTime.Now;
        person.ModifiedBy = "SYSTEM";

        var obj = await _crudPersonService.Update(id, person);
        return Ok(obj);
    }


    [HttpPost]
    public async Task<ActionResult<IEnumerable<Persona>>> Insert([FromBody] Persona person)
    {
        person.CreatedDate = DateTime.Now;
        person.CreatedBy = "SYSTEM";

        var res = await _crudPersonService.Insert(person);

        return Ok(res);
    }

    // DELETE api/<PersonController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var res = await _crudPersonService.Delete(id);

        return Ok(res);
    }

    [HttpGet]
    //[Route("person")]
    //[ResponseType(typeof(CourseDTO))]
    public async Task<ActionResult<IEnumerable<Persona>>> Get()
    {
        try
        {
            var result = await _crudPersonService.Select();

            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error en el método Get");
            return NotFound();
        }
    }

    [HttpPost("InsertMultiple")]
    public async Task<ActionResult> InsertMultiple([FromBody] IEnumerable<Persona> list)
    {
        var res = await _personaService.InsertMultiple(list.ToList());
        return Ok();
    }

    [HttpPost("TestTransaction")]
    public async Task<ActionResult> TestTransaction([FromBody] IEnumerable<Persona> list)
    {
        var res = await _personaService.TestTransaction(list.ToList());

        return Ok();
    }

}
