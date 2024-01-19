using FITCCRS2.Model.Requests.RezultatiRequest;
using FITCCRS2.Model.Requests.SponzorRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.SponzorService
{
    public interface ISponzorService : IBaseCRUDService<Model.Sponzor, SponzorSearchObject, SponzorUpsertRequest, SponzorUpsertRequest>
    {
    }
}
