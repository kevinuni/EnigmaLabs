using AutoMapper;
using Enigma.Domain.Dto;
using Enigma.Domain.Model;
using Enigma.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enigma.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonaController : Controller
{
    private readonly IPersonaService _personaService;
    private readonly ILogger<PersonaController> _logger;
    private readonly IMapper _mapper;

    public PersonaController(ILogger<PersonaController> logger, IPersonaService personaService, IMapper mapper)
    {
        _personaService = personaService;
        _logger = logger;   
        _mapper = mapper;
    }

    //[HttpGet]
    ////[Route("person")]
    ////[ResponseType(typeof(CourseDTO))]
    //public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
    //{
    //    try
    //    {
    //        var result = await _personaService.Select();
            
    //        var lst = result.Select(x => _mapper.Map<PersonaDto>(x));

    //        return Ok(lst);
    //    }
    //    catch (Exception e)
    //    {
    //        _logger.LogError(e, "Error en el método Get");
    //        return NotFound();
    //    }
    //}

    //// GET api/<PersonController>/5
    ////[Route("person/{id}")]
    //[HttpGet("{id}")]
    //public async Task<ActionResult<PersonaDto>> Get(int id)
    //{
    //    var person = await _personaService.Select(id);
    //    return Ok(person);
    //}

    //// PUT api/<PersonController>
    //[HttpPut("{id}")]
    //public async Task<ActionResult<IEnumerable<Persona>>> Update(int id, [FromBody] Persona person)
    //{
    //    var obj = await _personaService.Update(id, person);
    //    return Ok(obj);
    //}

    //// PUT api/<PersonController>
    //[HttpPut("{id}")]
    //public async Task<ActionResult<IEnumerable<Persona>>> Upsert([FromBody] Persona person)
    //{
    //    var obj = await _personaService.Upsert(person);
    //    return Ok(obj);
    //}


    //[HttpPost]
    //public async Task<ActionResult<IEnumerable<Persona>>> Insert([FromBody] Persona person)
    //{
    //    //person.Bkey = Guid.NewGuid().ToString().GetHashCode().ToString("x");
    //    var res = await _personaService.Insert(person);

    //    return Ok(res);
    //}

    //// DELETE api/<PersonController>/5
    //[HttpDelete("{id}")]
    //public async Task<ActionResult<bool>> Delete(int id)
    //{
    //    var res = await _personaService.Delete(id);

    //    return Ok(res);
    //}

    

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
