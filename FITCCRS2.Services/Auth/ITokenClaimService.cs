using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.Auth
{
    public interface ITokenClaimService
    {
        Task<string> GetTokenAsync(string userName);
    }
}
