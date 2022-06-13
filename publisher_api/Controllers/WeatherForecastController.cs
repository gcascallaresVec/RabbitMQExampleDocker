using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Models;
using publisher_api.Services;

namespace publisher_api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IBus _bus;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMessageService messageService, IBus bus)
    {
        _bus = bus;
        _logger = logger;
        _messageService = messageService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    /*[HttpPost(Name = "PostMessage")]
    public void PostMessage(Message message)
    {
        var json = JsonConvert.SerializeObject(message);
        Console.WriteLine("received a Post: " + json);
        _messageService.Enqueue(json);
    }*/

    /*[HttpPost(Name = "PostMarca")]
    public void PostMarca(Marca marca)
    {
        var json = JsonConvert.SerializeObject(marca);
        Console.WriteLine("received a Post marca: " + json);
        _messageService.Enqueue(json);
    }*/
    [HttpPost]
    public async Task<IActionResult> CreateMarca(Marca marca)
    {
        if (marca != null)
        {
            Uri uri = new Uri("rabbitmq://localhost/messagesQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            var text = marca.GetType();
            await endPoint.Send(marca);
            return Ok();
        }
        return BadRequest();
    }

}
