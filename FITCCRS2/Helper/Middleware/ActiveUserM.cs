using FITCCRS2.Auth;
using FITCCRS2.Helper.ActiveUser;
using FITCCRS2.Services.UserMService;
using FITCCRS2.Services.UserService;
using System.Security.Claims;

namespace FITCCRS2.Helper.Middleware
{
    public class ActiveUserM
    {
        private readonly RequestDelegate _next;
        private readonly IActiveUser _activeUsers;
        private IUserMService _userService;

        public ActiveUserM(RequestDelegate next, IActiveUser activeUsers)
        {
            _next = next;
            _activeUsers = activeUsers;
        }

        public async Task Invoke(HttpContext context, IUserMService userService)
        {
            _userService = userService;
            var name = context.User.Claims.SingleOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;

            if (name != null && !_activeUsers.ActiveUsersId.TryGetValue(name, out int userId))
            {
                var response = new UserIdResponse();
                var user = _userService.GetByUsername(name);
                if (user != null)
                {
                    _activeUsers.ActiveUsersId.Add(name, user.UserId);
                }
            }

            await _next(context);
        }
    }
}
