using FITCCRS2.Model;
using FITCCRS2.Model.Requests.SponzorRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.SponzorService;
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
    public class SponzorController :  BaseCRUDController<Model.Sponzor, SponzorSearchObject, SponzorUpsertRequest, SponzorUpsertRequest>
    {
        public ISponzorService _service { get; set; }
        public SponzorController(ISponzorService service) : base(service)
        {
            _service = service;
        }

    }
}
