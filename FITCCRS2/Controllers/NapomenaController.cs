using FITCCRS2.Model.Requests.NapomenaRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.NapomenaService;
using FITCCRS2.Services.RabbitMQ;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCRS2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public class NapomenaController : BaseCRUDController<Model.Napomena, BaseSearchObject, NapomenaUpsertRequest, NapomenaUpsertRequest>
    {
        public INapomenaService _napomenaService { get; set; }
        private readonly IEmailService _rabbitMqService;

        public NapomenaController(INapomenaService napomenaService,
            IEmailService rabbitMqService) : base(napomenaService)
        {
            _napomenaService = napomenaService;
            _rabbitMqService = rabbitMqService;
        }
        public class Email
        {
            public string Sender { get; set; }
            public string Recipient { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }

        }
        [HttpPost("SendContactEmail")]
        public IActionResult SendContactEmail([FromBody] Email model)
        {
            try
            {
                _rabbitMqService.SendMessage(model);
                Thread.Sleep(TimeSpan.FromSeconds(15));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

