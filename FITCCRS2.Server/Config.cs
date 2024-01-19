using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;
using System.Text.Json;

namespace FITCCRS2.Server
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources => new[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource
            {
                Name="role",
                UserClaims=new List<string>{"role"}
            }
        };
            
        public static IEnumerable<ApiScope> ApiScopes => new[]
        {
            new ApiScope("FITCCRS2.read"),new ApiScope("FITCCRS2.write"),
        };
        public static IEnumerable<ApiResource> ApiResources => new[] 
        {
            new ApiResource("FITCCRS2")
            {
                Scopes=new List<string>{"FITCCRS2.read","FITCCRS2.write"},
               // ApiSecrets=new List<Secret>{new Secret("ScopeSecret".Sha256())},
                ApiSecrets = new List<Secret> { new Secret("SecretKeyOfDoomThatMustBeAMinimumNumberOfBytes".Sha256()) },
                UserClaims=new List<string>{"role"}
            } 
        };
        public static IEnumerable<Client> Clients =>
            new[]
            {
                new Client
                {
                    ClientId="m2m.client",
                    ClientName="Client Credentials Client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    //ClientSecrets={new Secret("ClientSecret1".Sha256())},
                    ClientSecrets = { new Secret("SecretKeyOfDoomThatMustBeAMinimumNumberOfBytes".Sha256()) },
                    AllowedScopes={ "FITCCRS2.read", "FITCCRS2.write" }
                },
                new Client
                {
                    ClientId="interactive",
                    AllowedGrantTypes=GrantTypes.Code,
                    ClientSecrets={new Secret("ClientSecret1".Sha256())},
                    AllowedScopes={ "openid", "profile","FITCCRS2.read" },
                    RedirectUris = {"https://localhost:5000/signin-oidc"},
                    FrontChannelLogoutUri = "https://localhost:5000/signout-oidc",
                    PostLogoutRedirectUris = {"https://localhost:5000/signout-callback-oidc"},
                    AllowOfflineAccess=true,
                    RequirePkce=true,
                    RequireConsent=true,
                    AllowPlainTextPkce=false,

                }
            };
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "Adresa1",
                    locality = "Mostar",
                    postal_code = 69118,
                    country = "BosniaandHerzegowina"
                };

                return new List<TestUser>
                {
                  new TestUser
                  {
                    SubjectId = "818727",
                    Username = "meli",
                    Password = "Test123!",
                    Claims =
                    {
                      new Claim(JwtClaimTypes.Name, "Melissa Memic"),
                      new Claim(JwtClaimTypes.GivenName, "Melissa"),
                      new Claim(JwtClaimTypes.FamilyName, "Memic"),
                      new Claim(JwtClaimTypes.Email, "mellimostar@gmail.com"),
                      new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                      new Claim(JwtClaimTypes.Role, "admin"),
                      new Claim(JwtClaimTypes.WebSite, "http://google.com"),
                      new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address),
                        IdentityServerConstants.ClaimValueTypes.Json)
                    }
                  },
                  new TestUser
                  {
                    SubjectId = "88421113",
                    Username = "lamija",
                    Password = "Test123!",
                    Claims =
                    {
                      new Claim(JwtClaimTypes.Name, "Lamija Babovic"),
                      new Claim(JwtClaimTypes.GivenName, "Lamija"),
                      new Claim(JwtClaimTypes.FamilyName, "Babovic"),
                      new Claim(JwtClaimTypes.Email, "lamija.babovic@edu.fit.ba"),
                      new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                      new Claim(JwtClaimTypes.Role, "admin"),
                      new Claim(JwtClaimTypes.WebSite, "http://google.com"),
                      new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address),
                        IdentityServerConstants.ClaimValueTypes.Json)
                    }
                  }
                };
            }
        }
    }
}
