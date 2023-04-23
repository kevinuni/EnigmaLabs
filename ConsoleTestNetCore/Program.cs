// See https://aka.ms/new-console-template for more information
using Enigma.Domain.Dto;
using Enigma.Util;


HttpManager client = HttpManager.Instance();
client.InitializeClient("https://localhost:44376/api");

var res = client.GetAsync<List<PersonaDto>>("persona/").GetAwaiter().GetResult().Data;

Console.WriteLine("Hello, World!");
