using AutoMapper;
using FITCCRS2.Model.Requests.PredavacRequest;
using FITCCRS2.Model.Requests.SponzorRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;
using FITCCRS2.Services.SponzorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.PredavacService
{
    public class PredavacService : BaseCRUDService<Model.Predavac, Database.Predavac, BaseSearchObject, PredavacUpsertRequest, PredavacUpsertRequest>, IPredavacService
    {
        public PredavacService(RS2SeminarskiContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
