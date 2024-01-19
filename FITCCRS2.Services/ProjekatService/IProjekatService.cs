using FITCCRS2.Model.Requests.PredavacRequest;
using FITCCRS2.Model.Requests.ProjekatRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.ProjekatService
{
    public interface IProjekatService : IBaseCRUDService<Model.Projekat, BaseSearchObject, ProjekatUpsertRequest, ProjekatUpsertRequest>
    {
        int LastProjekatUserId(string username);
        Model.Projekat LastProjekatUser(string username);
        List<Model.Projekat> getAllProjektiTimovi();

    }
}
