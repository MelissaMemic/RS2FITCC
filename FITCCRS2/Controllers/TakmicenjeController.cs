using FITCCRS2.Model.Requests.TakmicenjeRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.TakmicenjeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FITCCRS2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public class TakmicenjeController : BaseCRUDController<Model.Takmicenje, TakmicenjeSearchObject, TakmicenjeInsertRequest, TakmicenjeUpdateRequest>
    {
        public ITakmicenjeService _service { get; set; }
        public TakmicenjeController(ITakmicenjeService service):base(service)
        {
            _service=service;
        }
        [HttpGet]
        [Route("lastTakmicenje")]
        public Model.Takmicenje GetLastTakmicenje()
        {
           var lastTakmicenje= _service.GetLastTakmicenje();
            return lastTakmicenje;
        }

        [HttpGet]
        [Route("lastTakmicenjeId")]
        public int GetLastTakmicenjeId()
        {
            var lastTakmicenje = _service.GetLastTakmicenjeId();
            return lastTakmicenje;
        }
    }
}
