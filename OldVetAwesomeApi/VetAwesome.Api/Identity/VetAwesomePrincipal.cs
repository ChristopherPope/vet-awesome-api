using System.Security.Claims;

namespace VetAwesome.Api.Identity
{
    public class VetAwesomePrincipal : ClaimsPrincipal
    {
        public VetAwesomePrincipal(ClaimsIdentity claimsIdentity)
            : base(claimsIdentity) { }

        public int GetUserId()
        {
            var claim = Claims.FirstOrDefault(c => c.Type == ClaimType.IdClaim);
            if (claim == null)
            {
                return 0;
            }

            return Convert.ToInt32(claim.Value);
        }
    }
}
