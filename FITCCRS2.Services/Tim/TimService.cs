using AutoMapper;
using FITCCRS2.Model.Requests.TimRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;
using IdentityServer4.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.Tim
{
    public class TimService : BaseCRUDService<Model.Tim, Database.Tim, TimSearchObject, TimInsertRequest, TimUpdateRequest>, ITimService
    {
        private IMapper _mapper;
        public TimService(RS2SeminarskiContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper=mapper;
        }

        public List<Model.Tim> TimList(string username )
        {
            var tims = _context.Tims.Where(x => x.Username == username).ToList();
            return _mapper.Map<List<Model.Tim>>(tims);
        }

        public Model.Tim LastTimUser(string username)
        {
            var tim = _context.Tims.Where(x => x.Username == username).FirstOrDefault();
            return _mapper.Map<Model.Tim>(tim);
        }

        public int LastTimUserId(string username)
        {
            var tim = _context.Tims.Where(x => x.Username == username).Last();
            return tim.TimId;
        }

        public List<Model.Tim> getAllTimData(string? searchText)
        {
            var list = new List<Model.Tim>();

            
            list = _mapper.Map<List<Model.Tim>>(
                _context.Tims.Include(x => x.Projekats).ToList());

            foreach (var item in list)
            {
                var p = _mapper.Map<List<Model.Projekat>>(
                _context.Projekats.Where(x => x.TimId == item.TimId).ToList());
                if (p.Any() || p != null)
                {
                    item.Projekats = p;
                }
            }
            return list;
        }

    }
}
