// See https://aka.ms/new-console-template for more information
using Enigma.Domain.Dto;
using Enigma.Domain.Model;
using Enigma.Util;



HttpManager client = HttpManager.Instance();
client.InitializeClient("https://localhost:44376/api");

//Dictionary<string, string> par = new Dictionary<string, string>();
//par.Add("id", "1");

var res = await client.Get<List<PersonaDto>>("persona");

var Persona = new Persona
{
    Nombre = "Kevin",
    Apellido = "Diaz",
    DNI = "40819738"

};

Console.WriteLine(res);
