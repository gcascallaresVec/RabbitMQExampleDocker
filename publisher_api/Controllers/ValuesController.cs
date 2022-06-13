using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models;
using publisher_api.Services;

namespace publisher_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IBus _bus;

        public ValuesController(IMessageService messageService, IBus bus)
        {
            _messageService = messageService;
            _bus = bus;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "queue-test" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /*[HttpPost]
        public void Post([FromBody] string payload)
        {
            Console.WriteLine("received a Post: " + payload);
            _messageService.Enqueue(payload);
        }*/

        [HttpPost]
        public async Task<IActionResult> CreateMarca(Modelo modelo)
        {
            if (modelo != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/messagesQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                var text = modelo.GetType();
                await endPoint.Send(modelo);
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
