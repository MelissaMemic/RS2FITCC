using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FITCCRS2.Model.Requests.DpgadjaRequest;
using FITCCRS2.Model.Requests.KriterijRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.KriterijService;
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
    public class KriterijController : BaseCRUDController<Model.Kriteriji, BaseSearchObject, KriterijUpsertRequest, KriterijUpsertRequest>
    {
        private readonly IKriterijService _kriterijService;

        public KriterijController(IKriterijService kriterijService) : base(kriterijService)
        {
            _kriterijService = kriterijService;
        }
    }
}

