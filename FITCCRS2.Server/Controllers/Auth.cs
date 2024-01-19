using FITCCRS2.Server.Models;
using IdentityModel;
using IdentityServer4;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace FITCCRS2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityServerTools _tools;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly HttpClient _httpClient = new();

        public Auth(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IdentityServerTools tools, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tools = tools;
            _roleManager = roleManager;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> SignIn(AuthRequest request)
        {
            var response = new AuthResponse();

            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, lockoutOnFailure: true);

            //var httpResponseMessage = await _httpClient.GetAsync($"https://localhost:7038/api/UserM/GetByUsername?username={request.Username}");

            //var obj=await httpResponseMessage.Content.ReadFromJsonAsync<UserApp>();

            response.Result = result.Succeeded;
            response.IsLockedOut = result.IsLockedOut;
            response.IsNotAllowed = result.IsNotAllowed;
            response.RequiresTwoFactor = result.RequiresTwoFactor;
            response.Username = request.Username;

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(request.Username);
                var roles = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, request.Username) };

                foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role));

                response.Token = await _tools.IssueClientJwtAsync("m2m.client", 3600, scopes: new[] { "FITCCRS2.read" }, additionalClaims: claims);

                return Ok(response);
            }
            return BadRequest("Log in failed");
            //return Ok("Message");
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register(AuthRequest request, string roleName)
        //{
        //    var user = new IdentityUser { UserName = request.Email, Email = request.Email };
        //    var result = await _userManager.CreateAsync(user, request.Password);
        //    var response = new AuthResponse();
        //    response.Result = result.Succeeded;
        //    response.Username = request.Username;

        //    if (result.Succeeded)
        //    {
        //        if (!await _roleManager.RoleExistsAsync(roleName))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole { Name = roleName, NormalizedName = roleName.ToUpper() });
        //        }

        //        if ((await _userManager.GetUsersInRoleAsync(roleName)).Count == 0)
        //        {
        //            var createdUser = await _userManager.FindByNameAsync(request.Username);
        //            await _userManager.AddToRoleAsync(createdUser, roleName);
        //        }
        //        var roles = await _userManager.GetRolesAsync(user);
        //        var claims = new List<Claim> { new Claim(ClaimTypes.Name, request.Username) };

        //        foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role));

        //        response.Token = await _tools.IssueClientJwtAsync("m2m.client", 3600, scopes: new[] { "FITCCRS2.read" }, audiences: new[] { "FITCCRS2.read" }, additionalClaims: claims);

        //        return Ok(response);
        //    }
        //    return BadRequest(result.Errors);

        //}

        [HttpPost]
        [Route("registerUser")]
        public async Task<IActionResult> RegisterUser(RegisterRequest request)
        {

            var user = _userManager.FindByNameAsync(request.Username).Result;
            try
            {
                if (user == null)
                {
                    user = new IdentityUser
                    {
                        UserName = request.Username,
                        Email = request.Email,
                        EmailConfirmed = true,
                    };

                    var result = _userManager.CreateAsync(user, request.Password).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    if (!_userManager.IsInRoleAsync(user, request.Role).Result)
                    {
                        _ = _userManager.AddToRoleAsync(user, request.Role).Result;
                    }

                    result =
                        _userManager.AddClaimsAsync(user,
                        new Claim[]
                        {
                      new Claim(JwtClaimTypes.Name, request.Name),
                      new Claim(JwtClaimTypes.GivenName, request.GivenName),
                      new Claim(JwtClaimTypes.FamilyName, request.FamilyName),
                      new Claim(JwtClaimTypes.WebSite, request.WebSite),
                        }).Result;

                    var userApp = new UserApp
                    {
                        Username = request.Username,
                        Name = request.Name,
                        Lastname=request.FamilyName,
                        IsAllowed=false,
                        Role = request.Role,
                        Website=request.WebSite
                        
                    };

                    var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(userApp), Encoding.UTF8, MediaTypeNames.Application.Json);

                    var httpResponseMessage = await _httpClient.PostAsync("http://localhost:5038/api/UserM", content);

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                }
                return Ok(user);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            return BadRequest("Doslo je do greske prilikom registracije korisnika");
        }

    }
}
