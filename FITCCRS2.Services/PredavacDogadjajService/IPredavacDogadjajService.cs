using FITCCRS2.Model.Requests.PredavacDogadjaj;
using FITCCRS2.Model.Requests.PredavacRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.PredavacDogadjajService
{
    public interface IPredavacDogadjajService : IBaseCRUDService<Model.PredavacDogadjaj, BaseSearchObject, PredavacDogadjajUpsertRequest, PredavacDogadjajUpsertRequest>
    {
    }
}
