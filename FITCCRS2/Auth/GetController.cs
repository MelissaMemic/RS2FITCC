using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FITCCRS2.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetController : ControllerBase
    {
        public GetController()
        {

        }

        [HttpGet("api/identity")]
        [SwaggerOperation(
            Summary = "Gets claims",
            Description = "Get claims",
            OperationId = "auth.identity",
            Tags = new[] { "AuthEndpoints" })
        ]
        public async Task<ActionResult<string>> HandleAsync(
            CancellationToken cancellationToken)
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
