using FITCCRS2.Model.Requests.TakmicenjeRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.TakmicenjeService
{
    public interface ITakmicenjeService:IBaseCRUDService<Model.Takmicenje, TakmicenjeSearchObject, TakmicenjeInsertRequest, TakmicenjeUpdateRequest>
    {
        Model.Takmicenje GetLastTakmicenje();
        int GetLastTakmicenjeId();
    }
}
