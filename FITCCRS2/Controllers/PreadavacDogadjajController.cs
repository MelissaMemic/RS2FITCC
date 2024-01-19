using FITCCRS2.Model.Requests.DpgadjaRequest;
using FITCCRS2.Model.Requests.PredavacDogadjaj;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.DogadjajService;
using FITCCRS2.Services.PredavacDogadjajService;
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
    public class PreadavacDogadjajController : BaseCRUDController<Model.PredavacDogadjaj, BaseSearchObject, PredavacDogadjajUpsertRequest, PredavacDogadjajUpsertRequest>
    {
        public IPredavacDogadjajService _predavacdogadjajService { get; set; }
        public PreadavacDogadjajController(IPredavacDogadjajService predavacdogadjajService) : base(predavacdogadjajService)
        {
            _predavacdogadjajService = predavacdogadjajService;
        }
    }
}
