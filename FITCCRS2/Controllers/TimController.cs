using FITCCRS2.Model;
using FITCCRS2.Model.Requests.TimRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.PredavacService;
using FITCCRS2.Services.TakmicenjeService;
using FITCCRS2.Services.Tim;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FITCCRS2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public class TimController : BaseCRUDController<Model.Tim, TimSearchObject, TimInsertRequest, TimUpdateRequest>
    {
        public ITimService _timService { get; set; }
        public ITakmicenjeService _takmicenjeService { get; set; }
        public TimController(ITimService timService, ITakmicenjeService takmicenjeService) : base(timService)
        {
            _timService = timService;
            _takmicenjeService = takmicenjeService;
        }

        //public override Tim Insert([FromBody] TimInsertRequest insert)
        //{
        //    insert.TakmicenjeId = _takmicenjeService.GetLastTakmicenjeId();
        //    return base.Insert(insert);
        //}

        [HttpGet("getTimsByUser")]
        public List<Model.Tim> getTimsByUser(string username)
        {
            var list = _timService.TimList(username);
            return list;
        }
        [HttpGet("getAllTimData")]
        public List<Model.Tim> getAllTimData(string? searchText)
        {
            var list = _timService.getAllTimData(searchText);
            return list;
        }

        [HttpGet("getLastTimUser")]
        public Model.Tim getLastTimUser(string username)
        {
            var tim = _timService.LastTimUser(username);
            return tim;
        }

        [HttpGet("getLastTimUserId")]
        public int getLastTimUserId(string username)
        {
            var timId = _timService.LastTimUserId(username);
            return timId;
        }


    }
}
