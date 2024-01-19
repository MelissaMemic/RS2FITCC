using AutoMapper;
using FITCCRS2.Model;
using FITCCRS2.Model.Requests;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;
using FITCCRS2.Services.TakmicenjeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.KategorijaService
{
    public class KategorijaService : BaseCRUDService<Model.Kategorija, Database.Kategorija, KategorijaSearchObject, KategorijaInsertRequest, KategorijaUpdateRequest>, IKategorijaService
    {

        private readonly ITakmicenjeService _takmicenjeService;
        IMapper _mapper;
        public KategorijaService(RS2SeminarskiContext context, IMapper mapper, ITakmicenjeService takmicenjeService) : base(context, mapper)
        {
            _takmicenjeService = takmicenjeService;
            _mapper = mapper;
        }
        public List<Model.Kategorija> getLastTakmicenjeKategorije()
        {
            var lastTakmicenjeID = _takmicenjeService.GetLastTakmicenjeId();
            var listKategorije = _context.Kategorijas.Where(x => x.TakmicenjeId == lastTakmicenjeID).ToList();
            return _mapper.Map<List<Model.Kategorija>>(listKategorije);
        }

       
    }
}
