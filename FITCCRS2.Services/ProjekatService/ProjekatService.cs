using AutoMapper;
using FITCCRS2.Model.Requests.PredavacRequest;
using FITCCRS2.Model.Requests.ProjekatRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;
using FITCCRS2.Services.KategorijaService;
using FITCCRS2.Services.PredavacService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.ProjekatService
{
    public class ProjekatService : BaseCRUDService<Model.Projekat, Database.Projekat, BaseSearchObject, ProjekatUpsertRequest, ProjekatUpsertRequest>, IProjekatService
    {
        private IKategorijaService _kategorijaService;
        private IMapper _mapper;
        public ProjekatService(RS2SeminarskiContext context, IMapper mapper, IKategorijaService kategorijaService) : base(context, mapper)
        {
            _kategorijaService = kategorijaService;
            _mapper = mapper;   
        }

        public int LastProjekatUserId(string username)
        {
            var projekat = _context.Projekats.Where(x => x.Username == username).ToList().OrderByDescending(x=>x.ProjekatId);
            var proj=projekat.FirstOrDefault();
            return proj.ProjekatId;
        }

        public Model.Projekat LastProjekatUser(string username)
        {
            var tim = _context.Projekats.Where(x => x.Username == username).FirstOrDefault();
            return _mapper.Map<Model.Projekat>(tim);
        }

        public List<Model.Projekat> getAllProjektiTimovi()
        {
            var projekat = _context.Projekats.Include(x => x.Tim).ToList();
            return _mapper.Map<List<Model.Projekat>>(projekat);
        }
    }
}
