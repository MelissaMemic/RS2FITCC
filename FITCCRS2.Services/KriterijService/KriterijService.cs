using AutoMapper;
using FITCCRS2.Model.Requests.KriterijRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;

namespace FITCCRS2.Services.KriterijService
{
	public class KriterijService : BaseCRUDService<Model.Kriteriji, Database.Kriterij, BaseSearchObject, KriterijUpsertRequest, KriterijUpsertRequest>, IKriterijService
    {
        IMapper _mapper;
        public KriterijService(RS2SeminarskiContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }
    }
}

