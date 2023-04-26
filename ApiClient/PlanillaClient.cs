using Enigma.Domain.Dto;
using Enigma.Util;

namespace ApiClient;

public class PlanillaClient
{
    HttpManager client;
    private const string endpoint = "planilla";

    public PlanillaClient()
    {
        if (client == null)
        {
            client = HttpManager.Instance();
            client.InitializeClient("http://localhost:5000/api");
        }
    }
    public async Task<PersonaDto> Get(string periodo)
    {
        var result = await client.Get<PersonaDto>(endpoint + "/" + periodo);
        return result.Data;
    }
}