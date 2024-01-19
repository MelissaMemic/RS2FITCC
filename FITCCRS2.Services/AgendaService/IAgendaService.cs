using FITCCRS2.Model;
using FITCCRS2.Model.Requests;
using FITCCRS2.Model.Requests.AgendaRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.AgendaService
{
    public interface IAgendaService : IBaseCRUDService<Agenda, AgendaSearchObject, AgendaInsertObject, AgendaUpdateRequest>
    {
        List<Agenda> getLastTakmicenjeAgenda();
    }
}
