using AutoMapper;
using FITCCRS2.Model.Requests.PredavacDogadjaj;
using FITCCRS2.Model.Requests.PredavacRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;
using FITCCRS2.Services.PredavacService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.PredavacDogadjajService
{
    public class PredavacDogadjajService : BaseCRUDService<Model.PredavacDogadjaj, Database.PredavacDogadjaj, BaseSearchObject, PredavacDogadjajUpsertRequest, PredavacDogadjajUpsertRequest>, IPredavacDogadjajService
    {
        public PredavacDogadjajService(RS2SeminarskiContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
