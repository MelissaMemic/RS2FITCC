using AutoMapper;
using FITCCRS2.Model.Requests.NapomenaRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;

namespace FITCCRS2.Services.NapomenaService
{
	public class NapomenaService : BaseCRUDService<Model.Napomena, Database.Napomena, BaseSearchObject, NapomenaUpsertRequest, NapomenaUpsertRequest>, INapomenaService
    {
        private IMapper _mapper;
        public NapomenaService(RS2SeminarskiContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

    }
}

