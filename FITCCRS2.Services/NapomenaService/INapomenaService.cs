using FITCCRS2.Model.Requests.NapomenaRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;

namespace FITCCRS2.Services.NapomenaService
{
	public interface INapomenaService : IBaseCRUDService<Model.Napomena, BaseSearchObject, NapomenaUpsertRequest, NapomenaUpsertRequest>
    {
    }
}

