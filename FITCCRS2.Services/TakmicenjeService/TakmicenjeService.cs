using AutoMapper;
using FITCCRS2.Model.Requests.TakmicenjeRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.TakmicenjeService
{
    public class TakmicenjeService : BaseCRUDService<Model.Takmicenje, Database.Takmicenje, TakmicenjeSearchObject, TakmicenjeInsertRequest, TakmicenjeUpdateRequest>, ITakmicenjeService
    {
        private readonly RS2SeminarskiContext _context;
        private readonly IMapper _mapper;
        public TakmicenjeService(RS2SeminarskiContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Takmicenje GetLastTakmicenje()
        {
            var TakmicenjaSorted = _context.Takmicenjes.OrderByDescending(x => x.Pocetak).ToList();
            var lastTakmicenje = TakmicenjaSorted.FirstOrDefault();
            return _mapper.Map<Model.Takmicenje>(lastTakmicenje);
        }

        public int GetLastTakmicenjeId()
        {
            var TakmicenjaSorted = _context.Takmicenjes.OrderByDescending(x => x.Pocetak).ToList();
            var lastTakmicenje = TakmicenjaSorted.FirstOrDefault();
            return lastTakmicenje.TakmicenjeId;
        }
    }
}
