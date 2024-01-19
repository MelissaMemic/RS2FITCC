using FITCCRS2.Model.Requests.TakmicenjeRequest;
using FITCCRS2.Model.Requests.UserRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.UserMService
{
    public interface IUserMService : IBaseCRUDService<Model.User, UserSearchObject, UserUpsertRequest, UserUpsertRequest>
    {
        Model.User GetByUsername(string username);
        string GetWebsiteByUser(string username); 
        List<Model.User> GetAllByRole(string username); 
        string GetRoleByUser(string username);
        bool CheckRoleByUser(string username, string role);
    }
}
