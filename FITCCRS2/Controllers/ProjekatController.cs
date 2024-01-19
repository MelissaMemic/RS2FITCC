using FITCCRS2.Model.Requests;
using FITCCRS2.Model.Requests.ProjekatRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.KategorijaService;
using FITCCRS2.Services.ProjekatService;
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
    public class ProjekatController : BaseCRUDController<Model.Projekat, BaseSearchObject, ProjekatUpsertRequest, ProjekatUpsertRequest>
    {
        public IProjekatService _projekatService { get; set; }
        public ProjekatController(IProjekatService projekatService) : base(projekatService)
        {
            _projekatService = projekatService;
        }

        [HttpGet("getLastProjekatUserId")]
        public int getLastProjekatUserId(string username)
        {
            var projekatId = _projekatService.LastProjekatUserId(username);
            return projekatId;
        }

        [HttpGet("getLastProjekatUser")]
        public Model.Projekat getLastProjekatUser(string username)
        {
            var projekat = _projekatService.LastProjekatUser(username);
            return projekat;
        }

        [HttpGet("getallprojekattim")]
        public List<Model.Projekat> getProjekatWithTim()
        {
            var projekat = _projekatService.getAllProjektiTimovi();
            return projekat;
        }

    }
}
