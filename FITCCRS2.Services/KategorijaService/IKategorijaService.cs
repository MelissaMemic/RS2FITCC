using FITCCRS2.Model;
using FITCCRS2.Model.Requests;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.KategorijaService
{
    public interface IKategorijaService:IBaseCRUDService<Kategorija, KategorijaSearchObject, KategorijaInsertRequest, KategorijaUpdateRequest>
    {
        List<Model.Kategorija> getLastTakmicenjeKategorije();
    }
}
