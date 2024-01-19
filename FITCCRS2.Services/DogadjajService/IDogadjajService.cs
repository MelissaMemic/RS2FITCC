using FITCCRS2.Model;
using FITCCRS2.Model.Requests.DpgadjaRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;

namespace FITCCRS2.Services.DogadjajService
{
    public interface IDogadjajService: IBaseCRUDService<Dogadjaj, DogadjajSearchObject, DogadjajUpsertRequest, DogadjajUpsertRequest>
    {
        List<Model.Dogadjaj> getLastTakmicenjeDogadjaj();
        List<Model.DogadjajiPerAgenda> getLastAgendasDogadjaj();
    }
}
