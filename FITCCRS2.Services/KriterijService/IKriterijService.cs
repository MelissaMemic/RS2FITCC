using FITCCRS2.Model.Requests.KriterijRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;

namespace FITCCRS2.Services.KriterijService
{
	public interface IKriterijService: IBaseCRUDService<Model.Kriteriji, BaseSearchObject, KriterijUpsertRequest, KriterijUpsertRequest>
    {
    }
}


