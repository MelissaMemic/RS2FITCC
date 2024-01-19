using FITCCRS2.Model.Requests.RezultatiRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.RezultatiService
{
    public interface IRezultatiService:IBaseCRUDService<Model.Rezultati, RezultatiSearchObject, RezultatiInsertRequest, RezultatiUpdateRequest>
    {
        List<Model.Rezultati> getAllRezultati();

    }
}
