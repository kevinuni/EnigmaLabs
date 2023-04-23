// See https://aka.ms/new-console-template for more information
using Enigma.Domain.Dto;
using Enigma.Util;

//TestPostmanApi.TestPostman.Run();
////TestGoRestApi.TestGoRest.Run();

HttpManager client = HttpManager.Instance();
client.InitializeClient("http://localhost:5000/api");

var res = client.GetAsync<List<PersonaDto>>("person/").GetAwaiter().GetResult().Data;



//HttpManager httpManager = HttpManager.Instance();
//httpManager.InitializeClient("https://postman-echo.com");
//var par = new Dictionary<string, string>();
//par.Add("test", "123");
//var resultGet = httpManager.GetAsync<GetObject>("get", par);
//var replyGet = resultGet.GetAwaiter().GetResult();
//GetObject dataGet = replyGet.Data;

//var resultPost = httpManager.PostAsync<string, PostObject>("/post", "texto de prueba");
//var replyPost = resultPost.GetAwaiter().GetResult();
//PostObject dataPost = replyPost.Data;


Console.WriteLine("Hello, World!");
