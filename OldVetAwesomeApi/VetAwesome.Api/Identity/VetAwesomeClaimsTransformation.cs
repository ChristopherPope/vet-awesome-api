using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace VetAwesome.Api.Identity
{
    public class VetAwesomeClaimsTransformation : IClaimsTransformation
    {
        private readonly IHttpContextAccessor http;

        public VetAwesomeClaimsTransformation(IHttpContextAccessor http)
        {
            this.http = http;
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var userId = http.HttpContext?.Session.GetInt32("UserId");
            if (!userId.HasValue ||
                principal is VetAwesomePrincipal)
            {
                return Task.FromResult(principal);
            }

            var id = principal.Identity as ClaimsIdentity;
            if (id == null)
            {
                return Task.FromResult(principal);
            }

            var claimsIdentity = new ClaimsIdentity(id.Claims, id.AuthenticationType, id.NameClaimType, id.RoleClaimType);
            claimsIdentity.AddClaim(new Claim(ClaimType.IdClaim, userId.Value.ToString()));

            var vetAwesomePrincipal = new VetAwesomePrincipal(claimsIdentity);


            return Task.FromResult(vetAwesomePrincipal as ClaimsPrincipal);
        }
    }
}
