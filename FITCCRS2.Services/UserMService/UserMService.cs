using AutoMapper;
using FITCCRS2.Model.Requests.TakmicenjeRequest;
using FITCCRS2.Model.Requests.UserRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;
using FITCCRS2.Services.TakmicenjeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.UserMService
{
    public class UserMService : BaseCRUDService<Model.User, Database.User, UserSearchObject, UserUpsertRequest, UserUpsertRequest>, IUserMService
    {
        private IMapper _mapper;
        public UserMService(RS2SeminarskiContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public Model.User GetByUsername(string username)
        {
            var user= _context.Users.Where(x=>x.Username==username).FirstOrDefault();
            return _mapper.Map<Model.User>(user);
        }
        public List<Model.User> GetAllByRole(string role) {
            var users = _context.Users.Where(x => x.Role == role).ToList();
            return _mapper.Map<List<Model.User>>(users);
        }
        public string GetWebsiteByUser(string username)
        {
            var user = _context.Users.Where(x => x.Username == username).FirstOrDefault();
            return user.Website;
        }

        public string GetRoleByUser(string username)
        {
            var user = _context.Users.Where(x => x.Username == username).FirstOrDefault();
            return user.Role;
        }

        public bool CheckRoleByUser(string username, string role)
        {
            
            var user = _context.Users.Where(x => x.Username == username).FirstOrDefault();

            if (user.Role.Contains(role))
                return true;
            return false;
        }
    }
}
