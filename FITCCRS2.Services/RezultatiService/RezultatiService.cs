using AutoMapper;
using FITCCRS2.Model;
using FITCCRS2.Model.Requests.RezultatiRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;

namespace FITCCRS2.Services.RezultatiService
{
    public class RezultatiService : BaseCRUDService<Model.Rezultati, Database.Rezultat, RezultatiSearchObject, RezultatiInsertRequest, RezultatiUpdateRequest>, IRezultatiService
    {
        public RezultatiService(RS2SeminarskiContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public List<Rezultati> getAllRezultati()
        {
            var listRezultati = _context.Rezultats.ToList();
            foreach (var item in listRezultati)
            {
                if (item.Projekat == null)
                {
                    item.Projekat = _context.Projekats.Where(x => x.ProjekatId == item.ProjekatId).FirstOrDefault();
                }
            }
            return _mapper.Map<List<Model.Rezultati>>(listRezultati);
        }
    }
}
