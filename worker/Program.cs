using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Generic;
using Models;
using Domain.Models;

static async Task PostMessage(string postData)
{
    //var json = JsonConvert.SerializeObject(postData);
    var content = new StringContent(postData, UnicodeEncoding.UTF8, "application/json");

    using (var httpClientHandler = new HttpClientHandler())
    {
        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
        using (var client = new HttpClient(httpClientHandler))
        {
        //var result = await client.PostAsync("http://publisher_api/api/Values", content);
        var result = await client.PostAsync("https://localhost:7286/api/Producer/CreateMessage", content);
        string resultContent = await result.Content.ReadAsStringAsync();
        }
    } 
}

static async Task PostMessageMarca(string postData)
{
    //var json = JsonConvert.SerializeObject(postData);
    var content = new StringContent(postData, UnicodeEncoding.UTF8, "application/json");

    using (var httpClientHandler = new HttpClientHandler())
    {
        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
        using (var client = new HttpClient(httpClientHandler))
        {
            //var result = await client.PostAsync("http://publisher_api/api/Values", content);
            var result = await client.PostAsync("https://localhost:7286/api/Producer/CreateMarca", content);
            string resultContent = await result.Content.ReadAsStringAsync();
        }
    }
}


static async Task PostMessageModelo(string postData)
{
    //var json = JsonConvert.SerializeObject(postData);
    var content = new StringContent(postData, UnicodeEncoding.UTF8, "application/json");

    using (var httpClientHandler = new HttpClientHandler())
    {
        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
        using (var client = new HttpClient(httpClientHandler))
        {
            //var result = await client.PostAsync("http://publisher_api/api/Values", content);
            var result = await client.PostAsync("https://localhost:7286/api/Producer/CreateModelo", content);
            string resultContent = await result.Content.ReadAsStringAsync();
        }
    }
}


static async Task PostMessageCategoria(string postData)
{
    //var json = JsonConvert.SerializeObject(postData);
    var content = new StringContent(postData, UnicodeEncoding.UTF8, "application/json");

    using (var httpClientHandler = new HttpClientHandler())
    {
        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
        using (var client = new HttpClient(httpClientHandler))
        {
            //var result = await client.PostAsync("http://publisher_api/api/Values", content);
            var result = await client.PostAsync("https://localhost:7286/api/Producer/CreateCategoria", content);
            string resultContent = await result.Content.ReadAsStringAsync();
        }
    }
}

//List<Message> messages = new List <Message>();
//messages.Add(new Message { Body = "Message One", Destinatary = "Test 1", Id = 1 });
//messages.Add(new Message { Body = "Message Two", Destinatary = "Test 2", Id = 2 });
//messages.Add(new Message { Body = "Message Three", Destinatary = "Test 3", Id = 3 });
//messages.Add(new Message { Body = "Message Four", Destinatary = "Test 4", Id = 4 });
//messages.Add(new Message { Body = "Message Five", Destinatary = "Test 5", Id = 5 });
//messages.Add(new Message { Body = "Message One", Destinatary = "Test 1", Id = 1 });
//messages.Add(new Message { Body = "Message Two", Destinatary = "Test 2", Id = 2 });
//messages.Add(new Message { Body = "Message Three", Destinatary = "Test 3", Id = 3 });
//messages.Add(new Message { Body = "Message Four", Destinatary = "Test 4", Id = 4 });
//messages.Add(new Message { Body = "Message Five", Destinatary = "Test 5", Id = 5 });


//List<Marca> marcas = new List<Marca>();
//marcas.Add(new Marca { Nombre = "Message One", Observaciones = "Test 1", Id = 1, Codigo = "Test 1" });
//marcas.Add(new Marca { Nombre = "Message Two", Observaciones = "Test 2", Id = 2, Codigo = "Test 1" });
//marcas.Add(new Marca { Nombre = "Message Three", Observaciones = "Test 3", Id = 3, Codigo = "Test 1" });
//marcas.Add(new Marca { Nombre = "Message Four", Observaciones = "Test 4", Id = 4, Codigo = "Test 1" });
//marcas.Add(new Marca { Nombre = "Message Five", Observaciones = "Test 5", Id = 5, Codigo = "Test 1" });
//marcas.Add(new Marca { Nombre = "Message One", Observaciones = "Test 1", Id = 0, Codigo = "Test 1" });
//marcas.Add(new Marca { Nombre = "Message Two", Observaciones = "Test 2", Id = 2, Codigo = "Test 1" });
//marcas.Add(new Marca { Nombre = "Message Three", Observaciones = "Test 3", Id = 3, Codigo = "Test 1" });
//marcas.Add(new Marca { Nombre = "Message Four", Observaciones = "Test 4", Id = 4, Codigo = "Test 1" });
//marcas.Add(new Marca { Nombre = "Message Five", Observaciones = "Test 5", Id = 5, Codigo = "Test 1" });


//List<Modelo> modelos = new List<Modelo>();
//modelos.Add(new Modelo { Nombre = "Message One", Tipo = "Test 1", Id = 1 });
//modelos.Add(new Modelo { Nombre = "Message Two", Tipo = "Test 2", Id = 2 });
//modelos.Add(new Modelo { Nombre = "Message Three", Tipo = "Test 3", Id = 3 });
//modelos.Add(new Modelo { Nombre = "Message Four", Tipo = "Test 4", Id = 4 });
//modelos.Add(new Modelo { Nombre = "Message Five", Tipo = "Test 5", Id = 5 });
//modelos.Add(new Modelo { Nombre = "Message One", Tipo = "Test 1", Id = 1 });
//modelos.Add(new Modelo { Nombre = "Message Two", Tipo = "Test 2", Id = 2 });
//modelos.Add(new Modelo { Nombre = "Message Three", Tipo = "Test 3", Id = 3 });
//modelos.Add(new Modelo { Nombre = "Message Four", Tipo = "Test 4", Id = 4 });
//modelos.Add(new Modelo { Nombre = "Message Five", Tipo = "Test 5", Id = 5 });

//List<Categoria> categorias = new List<Categoria>();
//categorias.Add(new Categoria { Nombre = "Message One", Id = 1 });
//categorias.Add(new Categoria { Nombre = "Message Two", Id = 2 });
//categorias.Add(new Categoria { Nombre = "Message Three", Id = 3 });
//categorias.Add(new Categoria { Nombre = "Message Four", Id = 4 });
//categorias.Add(new Categoria { Nombre = "Message Five", Id = 5 });
//categorias.Add(new Categoria { Nombre = "Message One", Id = 1 });
//categorias.Add(new Categoria { Nombre = "Message Two", Id = 2 });
//categorias.Add(new Categoria { Nombre = "Message Three", Id = 3 });
//categorias.Add(new Categoria { Nombre = "Message Four", Id = 4 });
//categorias.Add(new Categoria { Nombre = "Message Five", Id = 5 });


//Console.WriteLine("Sleeping to wait for Rabbit");
//Task.Delay(1000).Wait();
//Console.WriteLine("Posting messages to webApi");

//for (int i = 0; i < 30; i++)
//{
//    foreach (var item in messages)
//    {
//        PostMessage(JsonConvert.SerializeObject(item)).Wait();
//    }

//    foreach (var item in marcas)
//    {
//        PostMessageMarca(JsonConvert.SerializeObject(item)).Wait();
//    }

//    foreach (var item in modelos)
//    {
//        PostMessageModelo(JsonConvert.SerializeObject(item)).Wait();
//    }

//    foreach (var item in categorias)
//    {
//        PostMessageCategoria(JsonConvert.SerializeObject(item)).Wait();
//    }
//}


//Console.WriteLine("Posting messages finish");



//var factory = new ConnectionFactory() { HostName = "rabbitmq" };
//ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost", Port = 5672 };
//ConnectionFactory factory = new ConnectionFactory() { HostName = "host.docker.internal" , Port = 5672, UserName = "guest", Password = "guest" };
//var connection = factory.CreateConnection();
//var channel = connection.CreateModel();
//channel.QueueDeclare(queue: "hello",
//                         durable: false,
//                         exclusive: false,
//                         autoDelete: false,
//                         arguments: null);
//var consumer = new EventingBasicConsumer(channel);
//consumer.Received += (model, ea) =>
//{
//    var body = ea.Body.ToArray();
//    var message = Encoding.UTF8.GetString(body);
//    Console.WriteLine(" [x] Received from Rabbit: {0}", message);
//};
//channel.BasicConsume(queue: "hello",
//                         autoAck: true,
//                         consumer: consumer);
//
//Task.Delay(1000).Wait();
//Console.WriteLine(" Press [enter] to exit.");
//Console.ReadLine();


static async Task PostBrand(string postData)
{
    //var json = JsonConvert.SerializeObject(postData);
    var content = new StringContent(postData, UnicodeEncoding.UTF8, "application/json");

    using (var httpClientHandler = new HttpClientHandler())
    {
        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
        using (var client = new HttpClient(httpClientHandler))
        {
            var result = await client.PostAsync("https://api.staging.vecfleet.io/brands/", content);
            //var result = await client.PostAsync("https://localhost:5001/", content);
            string resultContent = await result.Content.ReadAsStringAsync();
        }
    }
}

static async Task GetBrand()
{
    using (var httpClientHandler = new HttpClientHandler())
    {
        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
        using (var client = new HttpClient(httpClientHandler))
        {
            var result = await client.GetAsync("https://api.staging.vecfleet.io/brands/");
            //var result = await client.GetAsync("https://localhost:5001/");
            string resultContent = await result.Content.ReadAsStringAsync();
        }
    }
}

Console.WriteLine("Posting messages to webApi");

for (int i = 0; i < 200; i++)
{
    var item = new Brand { Name = "Test: "+ i + "c", Description = "Test: " + i, Active = true };
    Console.WriteLine(" send {0}", item.Name);
    PostBrand(JsonConvert.SerializeObject(item)).Wait();
    GetBrand().Wait();
}

Console.WriteLine(" Finish Post messages to webApi");
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();