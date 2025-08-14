using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace BarnManagementAPI.Common
{
    public static class ClaimsPrincipalExtensions
    {
        public static int? GetUserId(this ClaimsPrincipal user)
        {
            
            var sub = user.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                      ?? user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (int.TryParse(sub, out var id))
                return id;

            return null;
        }
    }
}
