using AutoMapper;
using FITCCRS2.Auth;
using FITCCRS2.Model;
using FITCCRS2.Model.Requests.DpgadjaRequest;
using FITCCRS2.Model.Requests.UserRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.UserMService;
using FITCCRS2.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace FITCCRS2.Controllers
{
    [Authorize]
    public class UserController : BaseCRUDController<Model.User, UserSearchObject, UserUpsertRequest, UserUpsertRequest>
    {
        private readonly IUserMService _userMService;
        private readonly IMapper _mapper;
        public UserController(IMapper mapper, IUserMService userMService) : base(userMService)
        {
           
            _mapper = mapper;
            _userMService = userMService;
        }


        [HttpGet("api/userId")]
        public async Task<ActionResult<GetByIdUserResponse>> GetIdF(CancellationToken cancellationToke)
        {
            var name = User.Claims.SingleOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType);
            if (name == null) return NotFound();

            var response = new UserIdResponse();
            var user = _userMService.GetByUsername(name.Value);
            response.User = user;
            return Ok(response);

        }
    }
}

    