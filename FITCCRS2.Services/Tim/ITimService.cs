using FITCCRS2.Model.Requests.TimRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
namespace FITCCRS2.Services.Tim
{
    public interface ITimService : IBaseCRUDService<Model.Tim, TimSearchObject, TimInsertRequest, TimUpdateRequest>
    {
       public List<Model.Tim> TimList(string username);
        public List<Model.Tim> getAllTimData(string? searchText);
       public Model.Tim LastTimUser(string username);
       public int LastTimUserId(string username);
    }
}
