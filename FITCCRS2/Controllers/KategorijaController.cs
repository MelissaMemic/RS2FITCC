using FITCCRS2.Model.Requests;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.KategorijaService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FITCCRS2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize(Roles = "admin")]
    public class KategorijaController : BaseCRUDController<Model.Kategorija, KategorijaSearchObject, KategorijaInsertRequest,KategorijaUpdateRequest>
    {
        public IKategorijaService _kategorijaService { get; set; }
        public KategorijaController(IKategorijaService kategorijaService):base(kategorijaService)
        {
            _kategorijaService= kategorijaService;
        }

        [HttpGet("getLast")]
        public List<Model.Kategorija> getLastTakmicenjeDogadjaj()
        {
            var list = _kategorijaService.getLastTakmicenjeKategorije();
            return list;
        }

    }
}
