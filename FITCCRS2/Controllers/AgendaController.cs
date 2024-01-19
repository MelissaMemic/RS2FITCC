using FITCCRS2.Model;
using FITCCRS2.Model.Requests;
using FITCCRS2.Model.Requests.AgendaRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.AgendaService;
using FITCCRS2.Services.TakmicenjeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FITCCRS2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AgendaController : BaseCRUDController<Model.Agenda, AgendaSearchObject, AgendaInsertObject, AgendaUpdateRequest>
    {
        private readonly IAgendaService _agendaService;
       
        public AgendaController(IAgendaService agendaService) : base(agendaService)
        {
            _agendaService = agendaService;
        }
        [HttpGet("getLast")]
        public List<Model.Agenda> getLastAgenda()
        {
            var list = _agendaService.getLastTakmicenjeAgenda();
            return list;
        }
    }
}
