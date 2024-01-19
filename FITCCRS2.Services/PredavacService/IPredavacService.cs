using FITCCRS2.Model.Requests.PredavacRequest;
using FITCCRS2.Model.Requests.SponzorRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.PredavacService
{
    public interface IPredavacService : IBaseCRUDService<Model.Predavac, BaseSearchObject, PredavacUpsertRequest, PredavacUpsertRequest>
    {
    }
}
