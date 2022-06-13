using Domain.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using publisher_api.Services;

namespace publisher_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IBus _bus;

        public ProducerController(IMessageService messageService, IBus bus)
        {
            _messageService = messageService;
            _bus = bus;
        }



        [Route("SendMessage")]
        [HttpPost]
        public async Task<IActionResult> SendMessage(Brand brand)
        {
            if (brand != null)
            {
                Uri uri = new Uri("amqps://localhost:5672/hello");
                var endPoint = await _bus.GetSendEndpoint(uri);

                await endPoint.Send(brand, context => context.Headers.Set("operation", "create"));
                //await endPoint.Send(brand);
                return Ok();
            }
            return BadRequest();
        }

        [Route("CreateBrand")]
        [HttpPost]
        public async Task<IActionResult> CreateBrand(Brand brand)
        {
            if (brand != null)
            {
                Uri uri = new Uri("amqps://host.docker.internal:5672/helloCreate");
                var endPoint = await _bus.GetSendEndpoint(uri);
                
                await endPoint.Send(brand, context => context.Headers.Set("operation", "create"));
                //await endPoint.Send(brand);
                return Ok();
            }
            return BadRequest();
        }


        [Route("UpdateBrand")]
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(Brand brand)
        {
            if (brand != null)
            {
                Uri uri = new Uri("amqps://host.docker.internal:5672/helloUpdate");
                var endPoint = await _bus.GetSendEndpoint(uri);

                await endPoint.Send(brand, context => context.Headers.Set("operation", "update"));
                //await endPoint.Send(brand);
                return Ok();
            }
            return BadRequest();
        }

        [Route("DeleteBrand")]
        [HttpPost]
        public async Task<IActionResult> DeleteBrand(Brand brand)
        {
            if (brand != null)
            {
                Uri uri = new Uri("amqps://host.docker.internal:5672/hello");
                var endPoint = await _bus.GetSendEndpoint(uri);

                await endPoint.Send(brand, context => context.Headers.Set("operation", "delete"));
                //await endPoint.Send(brand);
                return Ok();
            }
            return BadRequest();
        }

        [Route("ExceptionBrand")]
        [HttpPost]
        public async Task<IActionResult> ExceptionBrand(Brand brand)
        {
            if (brand != null)
            {
                Uri uri = new Uri("amqps://host.docker.internal:5672/hello");
                var endPoint = await _bus.GetSendEndpoint(uri);

                await endPoint.Send(brand, context => context.Headers.Set("operation", "test"));
                //await endPoint.Send(brand);
                return Ok();
            }
            return BadRequest();
        }
    }
}
