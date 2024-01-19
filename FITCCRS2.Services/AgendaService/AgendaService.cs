using AutoMapper;
using FITCCRS2.Model;
using FITCCRS2.Model.Requests;
using FITCCRS2.Model.Requests.AgendaRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;
using FITCCRS2.Services.KategorijaService;
using FITCCRS2.Services.TakmicenjeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.AgendaService
{
    public class AgendaService : BaseCRUDService<Model.Agenda, Database.Agendum, AgendaSearchObject, AgendaInsertObject, AgendaUpdateRequest>, IAgendaService
    {
        private readonly ITakmicenjeService _takmicenjeService;
        IMapper _mapper;
        public AgendaService(RS2SeminarskiContext context, IMapper mapper, ITakmicenjeService takmicenjeService) : base(context, mapper)
        {
            _takmicenjeService = takmicenjeService;
            _mapper = mapper;
        }

        public List<Agenda> getLastTakmicenjeAgenda()
        {
            var lastTakmicenjeID = _takmicenjeService.GetLastTakmicenjeId();
            var listAgenda = _context.Agenda.Where(x => x.TakmicenjeId == lastTakmicenjeID).ToList();
            return _mapper.Map<List<Model.Agenda>>(listAgenda);
        }
    }
}
