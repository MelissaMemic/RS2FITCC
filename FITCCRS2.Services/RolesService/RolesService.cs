using AutoMapper;
using FITCCRS2.Model.Requests.RolesRequest;
using FITCCRS2.Model.Requests.SponzorRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.Database;
using FITCCRS2.Services.SponzorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.RolesService
{
    public class RolesService : BaseCRUDService<Model.Roles, Database.AspNetRole, BaseSearchObject, RolesUpsertRequest, RolesUpsertRequest>, IRolesService
    {
        public RolesService(RS2SeminarskiContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
