using AutoMapper;
using FITCCRS2.Model.Requests.RezultatiRequest;
using FITCCRS2.Model.Requests.SponzorRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;
using FITCCRS2.Services.RezultatiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.SponzorService
{
    public class SponzorService : BaseCRUDService<Model.Sponzor, Database.Sponzor, SponzorSearchObject, SponzorUpsertRequest, SponzorUpsertRequest>, ISponzorService
    {
        public SponzorService(RS2SeminarskiContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
