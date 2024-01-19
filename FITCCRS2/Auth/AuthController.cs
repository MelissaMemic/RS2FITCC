using FITCCRS2.Model;
using FITCCRS2.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FITCCRS2.Auth
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenClaimService _tokenClaimsService;

        public AuthController(SignInManager<IdentityUser> signInManager,
            ITokenClaimService tokenClaimsService)
        {
            _signInManager = signInManager;
            _tokenClaimsService = tokenClaimsService;
        }

        [HttpGet("api/authenticate")]
        [SwaggerOperation(
           Summary = "Authenticates a user",
           Description = "Authenticates a user",
           OperationId = "auth.authenticate",
           Tags = new[] { "AuthEndpoints" })
       ]
        public  async Task<ActionResult<AuthResponse>> HandleAsync([FromQuery] AuthRequest request,
           CancellationToken cancellationToken)
        {
            var response = new AuthResponse(request.CorrelationId());

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            //var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, true);

            response.Result = result.Succeeded;
            response.IsLockedOut = result.IsLockedOut;
            response.IsNotAllowed = result.IsNotAllowed;
            response.RequiresTwoFactor = result.RequiresTwoFactor;
            response.Username = request.Username;

            if (result.Succeeded) response.Token = await _tokenClaimsService.GetTokenAsync(request.Username);

            return response;
        }


    }
}
