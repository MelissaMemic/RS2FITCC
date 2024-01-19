using FITCCRS2.Model;
using FITCCRS2.Model.Requests;
using FITCCRS2.Model.Requests.UserRequest;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.BaseService;
using FITCCRS2.Services.UserMService;
using FITCCRS2.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FITCCRS2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserMController : BaseCRUDController<Model.User, UserSearchObject, UserUpsertRequest, UserUpsertRequest>
    {
        private readonly IUserMService _userService;
        public UserMController(IUserMService service) : base(service)
        {
            _userService = service;
        }

        [HttpGet]
        [Route("GetByUsername")]
        public Model.User GetByUsername(string username)
        {
            return _userService.GetByUsername(username);

        }

        [HttpGet]
        [Route("GetWebsiteByUsername")]
        public string GetWebsiteByUsername(string username)
        {
            return _userService.GetWebsiteByUser(username);

        }

        [HttpGet]
        [Route("getAllByRole")]
        public List<Model.User> getAllByRole(string role)
        {
            return _userService.GetAllByRole(role);

        }
        [HttpGet]
        [Route("GetRoleByUser")]
        public string GetRoleByUser(string username)
        {
            return _userService.GetRoleByUser(username);

        }

        [HttpGet]
        [Route("CheckRoleByUser")]
        public bool CheckRoleByUser(string username, string role)
        {
            return _userService.CheckRoleByUser(username, role);

        }
    }
}
