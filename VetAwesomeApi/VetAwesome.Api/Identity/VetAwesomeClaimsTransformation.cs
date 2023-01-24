using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using VetAwesome.Bll.Interfaces.Services;

namespace VetAwesome.Api.Identity
{
    public class VetAwesomeClaimsTransformation : IClaimsTransformation
    {
        private readonly IHttpContextAccessor http;
        private readonly IUsersService usersSvc;

        public VetAwesomeClaimsTransformation(IHttpContextAccessor http, IUsersService usersSvc)
        {
            this.http = http;
            this.usersSvc = usersSvc;
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
