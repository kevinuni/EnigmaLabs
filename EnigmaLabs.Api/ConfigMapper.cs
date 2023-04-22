using AutoMapper;
using Enigma.Domain.Dto;
using Enigma.Domain.Model;

namespace Enigma.Api;

public class ConfigMapper : Profile
{
    public ConfigMapper()
    {
        CreateMap<Persona, PersonaDto>();
    }
}
