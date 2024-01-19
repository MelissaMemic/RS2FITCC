using FITCCRS2.Model.Requests;
using FITCCRS2.Model.Requests.DpgadjaRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.AgendaService;
using FITCCRS2.Services.DogadjajService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FITCCRS2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DogadjajController : BaseCRUDController<Model.Dogadjaj, DogadjajSearchObject, DogadjajUpsertRequest, DogadjajUpsertRequest>
    {
        private readonly IAgendaService _agendaService;

        public IDogadjajService _dogadjajService { get; set; }
        public DogadjajController(IDogadjajService dogadjajService,IAgendaService agendaService) : base(dogadjajService)
        {
            _dogadjajService= dogadjajService;
            _agendaService = agendaService;
        }

        [HttpGet("getLast")]
        public List<Model.Dogadjaj> getLastTakmicenjeDogadjaj()
        {
            var list = _dogadjajService.getLastTakmicenjeDogadjaj();
            return list;
        }

        [HttpGet("getLastAgendasDogadjaji")]
        public List<Model.DogadjajiPerAgenda> getMergedAgendaDogadjaji()
        {
            var list = _dogadjajService.getLastAgendasDogadjaj();

            return list;

        }
    }
}
